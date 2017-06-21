using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Test
{
    using Poseidon.Base.System;
    using Poseidon.Core.DL;
    using Poseidon.Core.Utility;
    using Poseidon.Common;

    public static class GlobalAction
    {
        #region Method
        public static void Initialize()
        {
            string source = AppConfig.GetAppSetting("ConnectionSource");
            if (string.IsNullOrEmpty(source))
                throw new PoseidonException(ErrorCode.DatabaseConnectionNotFound);

            string connection = "";
            if (source == "dbconfig")
            {
                string name = AppConfig.GetAppSetting("DbConnection");
                connection = ConfigUtility.GetConnectionString(name);
            }
            else if (source == "appconfig")
            {
                connection = AppConfig.GetConnectionString();
            }

            if (string.IsNullOrEmpty(connection))
                throw new PoseidonException(ErrorCode.DatabaseConnectionNotFound);

            Cache.Instance.Add("ConnectionString", connection);
        }
        #endregion //Method
    }
}
