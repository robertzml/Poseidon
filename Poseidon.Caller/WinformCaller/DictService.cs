using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Caller.WinformCaller
{
    using Poseidon.Base.Framework;
    using Poseidon.Caller.Facade;
    using Poseidon.Core.BL;
    using Poseidon.Core.DL;

    /// <summary>
    /// 字典业务访问服务类
    /// </summary>
    internal class DictService : AbstractLocalService<Dict>, IDictService
    {
        #region Field
        /// <summary>
        /// 业务类对象
        /// </summary>
        private DictBusiness bl = null;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 字典业务访问服务类
        /// </summary>
        public DictService() : base(BusinessFactory<DictBusiness>.Instance)
        {
            this.bl = this.baseBL as DictBusiness;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 按分类查找
        /// </summary>
        /// <param name="categoryId">分类ID</param>
        /// <returns></returns>
        public IEnumerable<Dict> FindByCategory(string categoryId)
        {
            return this.bl.FindByCategory(categoryId);
        }

        /// <summary>
        /// 查找字典值
        /// </summary>
        /// <param name="code">字典代码</param>
        /// <param name="key">键</param>
        /// <returns></returns>
        public string FindValue(string code, int key)
        {
            return this.bl.FindValue(code, key);
        }

        /// <summary>
        /// 查找字典项
        /// </summary>
        /// <param name="code">字典代码</param>
        /// <returns></returns>
        public List<DictItem> FindItems(string code)
        {
            return this.bl.FindItems(code);
        }
        #endregion //Method
    }
}
