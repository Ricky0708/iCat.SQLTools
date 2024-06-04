using iCat.SQLTools.Repositories.Enums;
using iCat.SQLTools.Shareds.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCat.SQLTools.Models
{
    public class SettingConfig
    {
        public required List<ConnectionSetting> ConnectionSettings { get; set; }

    }

    public class ConnectionSetting
    {
        public required string Namespace { get; set; }
        public required string Using { get; set; }
        public required string ClassSuffix { get; set; }
        public required string Key { get; set; }
        public required ConnectionType ConnectionType { get; set; }
        public required string ConnectionString { get; set; }
        public required int SEQ { get; set; }

    }
}
