using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickySQLTools
{
    public enum SettingEnum
    {
        GetUsing,
        GetConnectionString,
        GetIncludeAttr,
        GetNamespace
    }

    public enum HideButton
    {
        SetConfig
    }


}
namespace RickySQLTools.DAL
{
    public partial class ErrorClasss
    {
        protected enum ResultCode
        {
            EmptyCode,
            XmlFileNotFound, // Can't find xml 
            CheckParentTableError, //Not each parent table all be checked !
            ConnectoinEmpty,//Connection string is not set yet !
            NothinToUpdate,//Nothing could be update !
            RefrenceNullDAO,//Data access object is empty, please load data from SQL !
        }
    }
}