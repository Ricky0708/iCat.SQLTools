using iCat.SQLTools.Shareds.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace iCat.SQLTools.Services.Interfaces
{
    public interface IDBDiagramService
    {
        string GenerateScript(DataSet ds, StringCase nameCase, bool isShowDescriptionAfterColName = false);
    }
}
