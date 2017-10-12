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
    /// 菜单业务访问服务类
    /// </summary>
    internal class MenuService : AbstractLocalService<Menu>, IMenuService
    {
        #region Field
        /// <summary>
        /// 业务类对象
        /// </summary>
        private MenuBusiness bl = null;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 菜单业务访问服务类
        /// </summary>
        public MenuService() : base(BusinessFactory<MenuBusiness>.Instance)
        {
            this.bl = this.baseBL as MenuBusiness;
        }
        #endregion //Constructor
    }
}
