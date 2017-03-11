using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.BL
{
    using Poseidon.Base.Framework;
    using Poseidon.Core.DL;
    using Poseidon.Core.IDAL;

    /// <summary>
    /// 配置业务类
    /// </summary>
    public class ConfigBusiness : AbstractBusiness<Config>
    {
        #region Constructor
        /// <summary>
        /// 字典业务类
        /// </summary>
        public ConfigBusiness()
        {
            this.baseDal = RepositoryFactory<IConfigRepository>.Instance;
        }

        /// <summary>
        /// 字典业务类
        /// </summary>
        /// <param name="dbType">指定数据库</param>
        public ConfigBusiness(string dbType)
        {
            this.baseDal = RepositoryFactory<IConfigRepository>.GetInstance(dbType);
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 按名称查找配置
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        public Config FindByName(string name)
        {
            return this.baseDal.FindOneByField("name", name);
        }

        /// <summary>
        /// 检查是否存在配置
        /// </summary>
        /// <param name="name">配置字段名</param>
        /// <returns></returns>
        public bool HaveConfig(string name)
        {
            return this.baseDal.Count("name", name) > 0;
        }
        #endregion //Method
    }
}
