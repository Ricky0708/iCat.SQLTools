using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickySQLTools.DAL
{
    public partial class ErrorClasss
    {
        private string _ErrMsg = "";

        public string ErrMsg
        {
            get
            {
                string result = _ErrMsg;
                _ErrMsg = "";
                if (result == "")
                {
                    switch (resultCode)
                    {
                        case ResultCode.XmlFileNotFound:
                            result = "Can't find xml !";
                            break;
                        case ResultCode.CheckParentTableError:
                            result = "Not each parent table all be checked !";
                            break;
                        case ResultCode.ConnectoinEmpty:
                            result = "Connection string is not set yet !";
                            break;
                        case ResultCode.NothinToUpdate:
                            result = "Nothing could be update !";
                            break;
                        case ResultCode.RefrenceNullDAO:
                            result = "Data access object is empty, please load data from SQL !";
                            break;
                        case ResultCode.EmptyCode:
                            result = "";
                            break;
                        default:
                            break;
                    }
                }
                resultCode = ResultCode.EmptyCode;
                return result;
            }
            set { _ErrMsg = value; }
        }

        protected ResultCode resultCode { get; set; } = ResultCode.EmptyCode;


    }


}
