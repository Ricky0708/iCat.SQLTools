using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickySQLTools.CompareUtility
{
    public class fksComparer : IEqualityComparer<string[]>
    {
        public bool Equals(string[] x, string[] y)
        {
            return true;
        }

        public int GetHashCode(string[] obj)
        {
            return obj[0].GetHashCode() + obj[1].GetHashCode();
        }
    }

    public class XmlUnionComparer : IEqualityComparer<DataRow>
    {

        public bool Equals(DataRow x, DataRow y)
        {
            x["Xml_A"] = true;
            x["Xml_B"] = true;
            if (x.Table.Columns.Contains("ColType"))
            {
                for (int i = 0; i < x.ItemArray.Length - 3; i++)
                {
                    if (!x[i].Equals(y[i]))
                    {
                        x["Type_Equal"] = "X";
                    }
                }
            }
            else
            {
            }

            return true;
        }

        public int GetHashCode(DataRow obj)
        {
            if (obj.Table.Columns.Contains("ColType"))
            {
                return ((string)obj[0]).GetHashCode() + ((string)obj[2]).GetHashCode();
            }
            else
            {
                return ((string)obj[0]).GetHashCode();
            }
        }

    }

}
