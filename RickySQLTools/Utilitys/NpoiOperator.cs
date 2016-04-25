using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Data;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using System.Drawing;
using NPOI.SS.Util;

namespace RickySQLTools.DAL
{
    public class NpoiOperator
    {
        #region const
        private const string dtTables = "Tables";
        private const string dtColumns = "Columns";
        private const string dtFKs = "FKs";
        private const string dtSpsAndFuncs = "SpsAndFuncs";
        private const string dtInputParams = "InputParams";
        private const string dtOutputParams = "OutputParams";
        private const string dtIndexes = "Indexes";
        #endregion

        #region property
        private Queue<string> que = new Queue<string>();

        private DataSet _ds { get; set; }

        #endregion

        #region workbook and cell style
        private XSSFWorkbook wb { get; set; }

        private XSSFCellStyle cellStyle { get; set; }
        private XSSFCellStyle linkCellStyle { get; set; }
        public XSSFCellStyle linkCellStyleWithoutBorder { get; set; }
        private XSSFCellStyle cellStyleAligCenter { get; set; }
        private XSSFCellStyle cellStyleHead { get; set; }
        private XSSFCellStyle cellStyleHeadWithBackColor { get; set; }
        #endregion

        #region ctor and public method

        public NpoiOperator(DataSet _ds)
        {
            this._ds = _ds;
            wb = new XSSFWorkbook();

            cellStyleHead = (XSSFCellStyle)wb.CreateCellStyle();
            cellStyleHead.BorderLeft = BorderStyle.Medium;
            cellStyleHead.BorderRight = BorderStyle.Medium;
            cellStyleHead.BorderTop = BorderStyle.Medium;
            cellStyleHead.BorderBottom = BorderStyle.Medium;
            XSSFFont headFont = (XSSFFont)wb.CreateFont();
            headFont.SetColor(new XSSFColor(System.Drawing.Color.Black));
            headFont.IsBold = true;
            cellStyleHead.SetFont(headFont);

            cellStyleHeadWithBackColor = (XSSFCellStyle)wb.CreateCellStyle();
            cellStyleHeadWithBackColor.BorderLeft = BorderStyle.Medium;
            cellStyleHeadWithBackColor.BorderRight = BorderStyle.Medium;
            cellStyleHeadWithBackColor.BorderTop = BorderStyle.Medium;
            cellStyleHeadWithBackColor.BorderBottom = BorderStyle.Medium;
            cellStyleHeadWithBackColor.SetFont(headFont);
            cellStyleHeadWithBackColor.FillPattern = FillPattern.ThinBackwardDiagonals;
            cellStyle = (XSSFCellStyle)wb.CreateCellStyle();
            cellStyle.BorderLeft = BorderStyle.Medium;
            cellStyle.BorderRight = BorderStyle.Medium;
            cellStyle.BorderTop = BorderStyle.Medium;
            cellStyle.BorderBottom = BorderStyle.Medium;


            cellStyleAligCenter = (XSSFCellStyle)wb.CreateCellStyle();
            cellStyleAligCenter.BorderLeft = BorderStyle.Medium;
            cellStyleAligCenter.BorderRight = BorderStyle.Medium;
            cellStyleAligCenter.BorderTop = BorderStyle.Medium;
            cellStyleAligCenter.BorderBottom = BorderStyle.Medium;
            cellStyleAligCenter.VerticalAlignment = VerticalAlignment.Center;
            cellStyleAligCenter.Alignment = HorizontalAlignment.Center;

            linkCellStyle = (XSSFCellStyle)wb.CreateCellStyle();
            XSSFFont linkFont = (XSSFFont)wb.CreateFont();
            linkFont.SetColor(new XSSFColor(System.Drawing.Color.Blue));
            linkCellStyle.SetFont(linkFont);
            linkCellStyle.BorderLeft = BorderStyle.Medium;
            linkCellStyle.BorderRight = BorderStyle.Medium;
            linkCellStyle.BorderTop = BorderStyle.Medium;
            linkCellStyle.BorderBottom = BorderStyle.Medium;
            linkCellStyle.VerticalAlignment = VerticalAlignment.Center;

            linkCellStyleWithoutBorder = (XSSFCellStyle)wb.CreateCellStyle();
            linkCellStyleWithoutBorder.SetFont(linkFont);
            linkCellStyleWithoutBorder.Alignment = HorizontalAlignment.Center;
            linkCellStyleWithoutBorder.VerticalAlignment = VerticalAlignment.Center;
            //when sheet name's length is more than 31 char, redefine the sheet name
            for (int i = 0; i < 100; i++)
            {
                que.Enqueue("TempName" + i.ToString());
            }
        }

        public bool WriteToExcel(string fileName)
        {
            DataView dvTables = _ds.Tables[dtTables].DefaultView;
            DataView dvColumns = _ds.Tables[dtColumns].DefaultView;
            DataView dvFks = _ds.Tables[dtFKs].DefaultView;
            DataView dvSpsAndFuncs = _ds.Tables[dtSpsAndFuncs].DefaultView;
            DataView dvInputParams = _ds.Tables[dtInputParams].DefaultView;
            DataView dvOutputParams = _ds.Tables[dtOutputParams].DefaultView;
            DataView dvIndexes = _ds.Tables[dtIndexes].DefaultView;

            //create sheet for index
            XSSFSheet sheet = (XSSFSheet)wb.CreateSheet("Index");
            IRow headRow = sheet.CreateRow(0);
            headRow.CreateCell(0).SetCellValue("Name"); headRow.GetCell(0).CellStyle = cellStyle;
            headRow.CreateCell(1).SetCellValue("Type"); headRow.GetCell(1).CellStyle = cellStyle;
            headRow.CreateCell(2).SetCellValue("Description"); headRow.GetCell(2).CellStyle = cellStyle;
            int i = 0;
            //lisk tables and views
            foreach (DataRow dr in _ds.Tables[dtTables].Rows)
            {
                string tableName = dr["TableName"].ToString();
                string tableDescription = dr["TableDescription"].ToString();
                string tableType = dr["TableType"].ToString();
                dvTables.RowFilter = "TableName = '" + tableName + "'";
                dvColumns.RowFilter = "TableName = '" + tableName + "'";
                dvIndexes.RowFilter = "TableName = '" + tableName + "'";
                dvFks.RowFilter = "ParentTable = '" + tableName + "' OR ReferencedTable = '" + tableName + "'";

                //create sheet for table and view
                tableName = CreateSheet_TableAndView(dvTables, dvColumns, dvIndexes, dvFks);
                IRow currentRow = sheet.CreateRow(i + 1);

                //create cell in sheet index and set hyperlink
                XSSFHyperlink link = new XSSFHyperlink(HyperlinkType.Document);
                link.Address = "'" + tableName + "'!A1";
                currentRow.CreateCell(0).SetCellValue(tableName); currentRow.GetCell(0).CellStyle = linkCellStyle;
                currentRow.CreateCell(1).SetCellValue(tableType); currentRow.GetCell(1).CellStyle = cellStyle;
                currentRow.CreateCell(2).SetCellValue(tableDescription); currentRow.GetCell(2).CellStyle = cellStyle;
                currentRow.GetCell(0).Hyperlink = link;
                i++;
            }

            //list sps ans funcs
            foreach (DataRow dr in _ds.Tables[dtSpsAndFuncs].Rows)
            {
                string specific_Name = dr["SPECIFIC_NAME"].ToString();
                string routineType = dr["ROUTINE_TYPE"].ToString();
                string routineDefinition = GetSpAndFuncDescription(dr["ROUTINE_DEFINITION"].ToString());

                dvSpsAndFuncs.RowFilter = "SPECIFIC_NAME = '" + specific_Name + "'";
                dvInputParams.RowFilter = "SPECIFIC_NAME = '" + specific_Name + "'";
                dvOutputParams.RowFilter = "SPECIFIC_NAME = '" + specific_Name + "'";

                //create sheet for sp and func
                specific_Name = CreateSheet_SpsAndFuncs(dvSpsAndFuncs, dvInputParams, dvOutputParams);

                //create cell in sheet index and set hyperlink
                IRow currentRow = sheet.CreateRow(i + 1);
                currentRow.CreateCell(0).SetCellValue(specific_Name); currentRow.GetCell(0).CellStyle = linkCellStyle;
                currentRow.CreateCell(1).SetCellValue(routineType); currentRow.GetCell(1).CellStyle = cellStyle;
                currentRow.CreateCell(2).SetCellValue(routineDefinition); currentRow.GetCell(2).CellStyle = cellStyle;
                XSSFHyperlink link = new XSSFHyperlink(HyperlinkType.Document);
                link.Address = "'" + specific_Name + "'!A1";
                currentRow.GetCell(0).Hyperlink = link;
                i++;
            }
            sheet.SetColumnWidth(0, 12000);
            sheet.SetColumnWidth(1, 4000);
            sheet.SetColumnWidth(2, 4000);
            DoWriteToExcel(fileName);
            return true;
        }
        #endregion

        #region private method1

        private string GetSpAndFuncDescription(string ROUTINE_DEFINITION)
        {
            int startIndex = ROUTINE_DEFINITION.IndexOf("/**");
            int endIndex = ROUTINE_DEFINITION.IndexOf("**/");
            if (startIndex > -1)
            {
                ROUTINE_DEFINITION = ROUTINE_DEFINITION.Substring(startIndex + 3, endIndex - 3);
            }
            else
            {
                ROUTINE_DEFINITION = "";
            }
            return ROUTINE_DEFINITION;
        }


        private void DoWriteToExcel(string fileName)
        {

            using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                wb.Write(stream);
            }
        }
        #endregion

        #region pivate generat sheet method

        private string CreateSheet_TableAndView(DataView dvTables, DataView dvColumns, DataView dvIndexes, DataView dvFks)
        {
            string tableName = dvTables[0]["TableName"].ToString();
            string tableDescription = dvTables[0]["TableDescription"].ToString();
            string tableType = dvTables[0]["TableType"].ToString();
            if (tableName.Length > 31)
            {
                tableName = que.Dequeue();
            }
            XSSFSheet sheet = wb.CreateSheet(tableName) as XSSFSheet;
            int i = 0;
            //head row
            IRow headRow = sheet.CreateRow(i);
            headRow.CreateCell(0).SetCellValue("TableName");
            headRow.CreateCell(1).SetCellFormula("RIGHT(CELL(\"filename\",A1),LEN(CELL(\"filename\",A1))-FIND(\"]\",CELL(\"filename\",A1)))");
            sheet.AddMergedRegion(new CellRangeAddress(0, 0, 1, 2));
            headRow.CreateCell(3).SetCellValue("Index"); headRow.GetCell(3).CellStyle = linkCellStyleWithoutBorder;
            XSSFHyperlink link = new XSSFHyperlink(HyperlinkType.Document);
            link.Address = "'Index'!A1";
            headRow.GetCell(3).Hyperlink = link;

            //column row head
            i += 3;
            IRow colHead = sheet.CreateRow(i);
            colHead.CreateCell(0).SetCellValue("Columns"); colHead.GetCell(0).CellStyle = cellStyleHeadWithBackColor;
            colHead.CreateCell(1).SetCellValue("ColName"); colHead.GetCell(1).CellStyle = cellStyleHead;
            colHead.CreateCell(2).SetCellValue("Type"); colHead.GetCell(2).CellStyle = cellStyleHead;
            colHead.CreateCell(3).SetCellValue("Length"); colHead.GetCell(3).CellStyle = cellStyleHead;
            colHead.CreateCell(4).SetCellValue("IsNull"); colHead.GetCell(4).CellStyle = cellStyleHead;
            colHead.CreateCell(5).SetCellValue("Description"); colHead.GetCell(5).CellStyle = cellStyleHead;

            //columns body row
            for (int n = 0; n < dvColumns.Count; n++)
            {
                i += 1;
                IRow colBody = sheet.CreateRow(i);
                colBody.CreateCell(0).SetCellValue(n + 1); colBody.GetCell(0).CellStyle = cellStyleAligCenter;
                colBody.CreateCell(1).SetCellValue(dvColumns[n]["ColName"].ToString()); colBody.GetCell(1).CellStyle = cellStyle;
                colBody.CreateCell(2).SetCellValue(dvColumns[n]["ColType"].ToString()); colBody.GetCell(2).CellStyle = cellStyle;
                colBody.CreateCell(3).SetCellValue(dvColumns[n]["ColLength"].ToString()); colBody.GetCell(3).CellStyle = cellStyle;
                colBody.CreateCell(4).SetCellValue((dvColumns[n]["IsNullable"].ToString() == "1").ToString().Replace("False","")); colBody.GetCell(4).CellStyle = cellStyle;
                colBody.CreateCell(5).SetCellValue(dvColumns[n]["ColDescription"].ToString()); colBody.GetCell(5).CellStyle = cellStyle;

            }


            //fks row head
            i += 3;
            IRow fkHead = sheet.CreateRow(i);
            fkHead.CreateCell(0).SetCellValue("FKs"); fkHead.GetCell(0).CellStyle = cellStyleHeadWithBackColor;
            fkHead.CreateCell(1).SetCellValue("Name"); fkHead.GetCell(1).CellStyle = cellStyleHead;
            fkHead.CreateCell(2).SetCellValue("MasterTable"); fkHead.GetCell(2).CellStyle = cellStyleHead;
            fkHead.CreateCell(3).SetCellValue("MasterCol"); fkHead.GetCell(3).CellStyle = cellStyleHead;
            fkHead.CreateCell(4).SetCellValue("DetailTable"); fkHead.GetCell(4).CellStyle = cellStyleHead;
            fkHead.CreateCell(5).SetCellValue("DetailCol"); fkHead.GetCell(5).CellStyle = cellStyleHead;
            //fks row
            for (int n = 0; n < dvFks.Count; n++)
            {
                i += 1;
                IRow fkBody = sheet.CreateRow(i);
                fkBody.CreateCell(0).SetCellValue(n + 1); fkBody.GetCell(0).CellStyle = cellStyleAligCenter;
                fkBody.CreateCell(1).SetCellValue(dvFks[n]["name"].ToString()); fkBody.GetCell(1).CellStyle = cellStyle;
                fkBody.CreateCell(2).SetCellValue(dvFks[n]["ReferencedTable"].ToString()); fkBody.GetCell(2).CellStyle = cellStyle;
                fkBody.CreateCell(3).SetCellValue(dvFks[n]["ReferencedColumn"].ToString()); fkBody.GetCell(3).CellStyle = cellStyle;
                fkBody.CreateCell(4).SetCellValue((dvFks[n]["ParentTable"].ToString())); fkBody.GetCell(4).CellStyle = cellStyle;
                fkBody.CreateCell(5).SetCellValue(dvFks[n]["ParentColumn"].ToString()); fkBody.GetCell(5).CellStyle = cellStyle;
            }
            //pk & ix row head
            i += 3;
            IRow pixHead = sheet.CreateRow(i);
            pixHead.CreateCell(0).SetCellValue("PKs & IXs"); pixHead.GetCell(0).CellStyle = cellStyleHeadWithBackColor;
            pixHead.CreateCell(1).SetCellValue("Name"); pixHead.GetCell(1).CellStyle = cellStyleHead;
            pixHead.CreateCell(2).SetCellValue("Column Name"); pixHead.GetCell(2).CellStyle = cellStyleHead;
            pixHead.CreateCell(3).SetCellValue(""); pixHead.GetCell(3).CellStyle = cellStyleHead;
            pixHead.CreateCell(4).SetCellValue(""); pixHead.GetCell(4).CellStyle = cellStyleHead;
            pixHead.CreateCell(5).SetCellValue(""); pixHead.GetCell(5).CellStyle = cellStyleHead;
            sheet.AddMergedRegion(new CellRangeAddress(i, i, 2, 5));

            //pk & ix row
            for (int n = 0; n < dvIndexes.Count; n++)
            {
                i += 1;
                IRow indexBody = sheet.CreateRow(i);
                indexBody.CreateCell(0).SetCellValue(n + 1); indexBody.GetCell(0).CellStyle = cellStyleAligCenter;
                indexBody.CreateCell(1).SetCellValue(dvIndexes[n]["IndexName"].ToString()); indexBody.GetCell(1).CellStyle = cellStyle;
                indexBody.CreateCell(2).SetCellValue(dvIndexes[n]["ColName"].ToString()); indexBody.GetCell(2).CellStyle = cellStyle;
                indexBody.CreateCell(3).SetCellValue(""); indexBody.GetCell(3).CellStyle = cellStyle;
                indexBody.CreateCell(4).SetCellValue(""); indexBody.GetCell(4).CellStyle = cellStyle;
                indexBody.CreateCell(5).SetCellValue(""); indexBody.GetCell(5).CellStyle = cellStyle;
                sheet.AddMergedRegion(new CellRangeAddress(i, i, 2, 5));
            }


            sheet.SetColumnWidth(0, 3000);
            sheet.SetColumnWidth(1, 8000);
            sheet.SetColumnWidth(2, 8000);
            sheet.SetColumnWidth(3, 8000);
            sheet.SetColumnWidth(4, 8000);
            sheet.SetColumnWidth(5, 8000);
            return tableName;
            //IRow headerRow = sheet.CreateRow(i + 3);
            //headerRow.CreateCell(0).SetCellValue(dr["TableName"].ToString());
        }

        private string CreateSheet_SpsAndFuncs(DataView dvSpsAndFuncs, DataView dvInputParams, DataView dvOutputParams)
        {
            string specific_Name = dvSpsAndFuncs[0]["SPECIFIC_NAME"].ToString();
            if (specific_Name.Length > 31)
            {
                specific_Name = que.Dequeue();
            }
            XSSFSheet sheet = wb.CreateSheet(specific_Name) as XSSFSheet;
            int i = 0;
            //head row
            IRow headRow = sheet.CreateRow(i);
            headRow.CreateCell(0).SetCellValue("TableName");
            headRow.CreateCell(1).SetCellFormula("RIGHT(CELL(\"filename\",A1),LEN(CELL(\"filename\",A1))-FIND(\"]\",CELL(\"filename\",A1)))");
            sheet.AddMergedRegion(new CellRangeAddress(0, 0, 1, 2));
            headRow.CreateCell(3).SetCellValue("Index"); headRow.GetCell(3).CellStyle = linkCellStyleWithoutBorder;
            XSSFHyperlink link = new XSSFHyperlink(HyperlinkType.Document);
            link.Address = "'Index'!A1";
            headRow.GetCell(3).Hyperlink = link;
            headRow = sheet.CreateRow(i + 1);
            headRow.CreateCell(1).SetCellValue(GetSpAndFuncDescription(dvSpsAndFuncs[0]["ROUTINE_DEFINITION"].ToString()));
            //Input params row head
            i += 3;
            IRow inputParamsHead = sheet.CreateRow(i);
            inputParamsHead.CreateCell(0).SetCellValue("Input Params"); inputParamsHead.GetCell(0).CellStyle = cellStyleHeadWithBackColor;
            inputParamsHead.CreateCell(1).SetCellValue("Name"); inputParamsHead.GetCell(1).CellStyle = cellStyleHead;
            inputParamsHead.CreateCell(2).SetCellValue("Type"); inputParamsHead.GetCell(2).CellStyle = cellStyleHead;
            inputParamsHead.CreateCell(3).SetCellValue("Length"); inputParamsHead.GetCell(3).CellStyle = cellStyleHead;
            inputParamsHead.CreateCell(4).SetCellValue("Mode"); inputParamsHead.GetCell(4).CellStyle = cellStyleHead;

            //Input params  body row
            for (int n = 0; n < dvInputParams.Count; n++)
            {
                i += 1;
                IRow InputParams = sheet.CreateRow(i);
                InputParams.CreateCell(0).SetCellValue(n + 1); InputParams.GetCell(0).CellStyle = cellStyleAligCenter;
                InputParams.CreateCell(1).SetCellValue(dvInputParams[n]["Parameter_Name"].ToString()); InputParams.GetCell(1).CellStyle = cellStyle;
                InputParams.CreateCell(2).SetCellValue(dvInputParams[n]["Data_Type"].ToString()); InputParams.GetCell(2).CellStyle = cellStyle;
                InputParams.CreateCell(3).SetCellValue(dvInputParams[n]["Character_Maximum_Length"].ToString()); InputParams.GetCell(3).CellStyle = cellStyle;
                InputParams.CreateCell(4).SetCellValue(dvInputParams[n]["Parameter_Mode"].ToString()); InputParams.GetCell(4).CellStyle = cellStyle;
            }

            //Output params row head
            i += 3;
            IRow outputParamsHead = sheet.CreateRow(i);
            outputParamsHead.CreateCell(0).SetCellValue("Output Params"); outputParamsHead.GetCell(0).CellStyle = cellStyleHeadWithBackColor;
            outputParamsHead.CreateCell(1).SetCellValue("Name"); outputParamsHead.GetCell(1).CellStyle = cellStyleHead;
            outputParamsHead.CreateCell(2).SetCellValue("Type"); outputParamsHead.GetCell(2).CellStyle = cellStyleHead;
            outputParamsHead.CreateCell(3).SetCellValue("Error_Message"); outputParamsHead.GetCell(3).CellStyle = cellStyleHead;
            outputParamsHead.CreateCell(4).SetCellValue(""); outputParamsHead.GetCell(4).CellStyle = cellStyle;
            sheet.AddMergedRegion(new CellRangeAddress(i, i, 3, 4));

            //Output params  body row
            for (int n = 0; n < dvOutputParams.Count; n++)
            {
                i += 1;
                IRow outputParams = sheet.CreateRow(i);
                outputParams.CreateCell(0).SetCellValue(n + 1); outputParams.GetCell(0).CellStyle = cellStyleAligCenter;
                outputParams.CreateCell(1).SetCellValue(dvOutputParams[n]["Name"].ToString()); outputParams.GetCell(1).CellStyle = cellStyle;
                outputParams.CreateCell(2).SetCellValue(dvOutputParams[n]["System_Type_Name"].ToString()); outputParams.GetCell(2).CellStyle = cellStyle;
                outputParams.CreateCell(3).SetCellValue(dvOutputParams[n]["Error_Message"].ToString()); outputParams.GetCell(3).CellStyle = cellStyle;
                outputParams.CreateCell(4).SetCellValue(""); outputParams.GetCell(4).CellStyle = cellStyle;
                sheet.AddMergedRegion(new CellRangeAddress(i, i, 3, 4));
            }

            sheet.SetColumnWidth(0, 3500);
            sheet.SetColumnWidth(1, 8000);
            sheet.SetColumnWidth(2, 8000);
            sheet.SetColumnWidth(3, 8000);
            sheet.SetColumnWidth(4, 8000);
            sheet.SetColumnWidth(5, 8000);
            return specific_Name;
        }

        #endregion


    }
}
