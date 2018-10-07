using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.BL
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Core.DL;
    using Poseidon.Core.IDAL;

    /// <summary>
    /// 字典分组业务类
    /// </summary>
    public class DictCategoryBusiness : AbstractBusiness<DictCategory>, IBaseBL<DictCategory>
    {
        #region Constructor
        /// <summary>
        /// 字典分组业务类
        /// </summary>
        public DictCategoryBusiness()
        {
            this.baseDal = RepositoryFactory<IDictCategoryRepository>.Instance;
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 检查分组是否含有字典
        /// </summary>
        /// <param name="id">字典分组ID</param>
        /// <returns></returns>
        private bool CheckHasDict(string id)
        {
            DictBusiness dictBusiness = new DictBusiness();
            var data = dictBusiness.FindByCategory(id);
            if (data.Count() > 0)
                return true;
            else
                return false;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 删除字典分组
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public override (bool success, string errorMessage) Delete(DictCategory entity)
        {
            if (CheckHasDict(entity.Id))
                return (false, "字典分组含有字典");

            return base.Delete(entity);
        }

        /// <summary>
        /// 删除字典分组
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public override (bool success, string errorMessage) Delete(string id)
        {
            if (CheckHasDict(id))
                return (false, "字典分组含有字典");

            return base.Delete(id);
        }
        #endregion //Method
    }
}
