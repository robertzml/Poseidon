using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.BL
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Core.IDAL;
    using Poseidon.Core.DL;

    /// <summary>
    /// 菜单对象业务类
    /// </summary>
    public class MenuBusiness : AbstractBusiness<Menu>, IBaseBL<Menu>
    {
        #region Constructor
        /// <summary>
        /// 菜单对象业务类
        /// </summary>
        public MenuBusiness()
        {
            this.baseDal = RepositoryFactory<IMenuRepository>.Instance;
        }
        #endregion //Constructor

        #region Method

        #endregion //Method
    }
}
