using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickySQLTools.Models
{
    public class SSO_USER_PROFILE
    {
        public string ID_NO { get; set; }
        public string CNAME { get; set; }
        public string EMP_ID { get; set; }
        public string EMP_TYPE_CODE { get; set; }
        public string CMP_SERIL_NO { get; set; }
        public DateTime CMP_ENT_DTE { get; set; }
        public DateTime FH_ENT_DTE { get; set; }
        public DateTime RGL_HIRE_DATE { get; set; }
        public string DEP_SERIL_NO_ACT { get; set; }
        public string DEP_SERIL_NO_FUN { get; set; }
        public string DEP_SERIL_NO_FLOW { get; set; }
        public string TIT_CODE { get; set; }
        public string TIT_NAME { get; set; }
        public string JOB_CODE { get; set; }
        public string JOB_NAME { get; set; }
        public string POS_CODE { get; set; }
        public string POS_NAME { get; set; }
        public DateTime BIRTHDAY { get; set; }
        public string PER_TEL { get; set; }
        public string NATION_CODE { get; set; }
        public string OFC_SITE_CODE { get; set; }
        public string EMAIL { get; set; }
        public string HEAD_COUNT { get; set; }
        public string PWD { get; set; }
        public bool IS_LOCKED { get; set; }
        public bool IS_ADMIN { get; set; }
    }
}