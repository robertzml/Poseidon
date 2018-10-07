using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.BL
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Common;
    using Poseidon.Core.IDAL;
    using Poseidon.Core.DL;

    /// <summary>
    /// 数据集业务类
    /// </summary>
    public class DatasetBusiness : AbstractBusiness<Dataset>, IBaseBL<Dataset>
    {
        #region Constructor
        /// <summary>
        /// 数据集业务类
        /// </summary>
        public DatasetBusiness()
        {
            this.baseDal = RepositoryFactory<IDatasetRepository>.Instance;
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 检查重复项
        /// </summary>
        /// <param name="entity">权限实体</param>
        /// <returns></returns>
        private bool CheckDuplicate(Dataset entity)
        {
            var exists = this.FindListByField("code", entity.Code);
            if (exists.Count() > 0)
            {
                if (exists.First().Id == entity.Id)
                    return true;
                else
                    return false;
            }
            else
                return true;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 根据代码查找数据集
        /// </summary>
        /// <param name="code">数据集代码</param>
        /// <returns></returns>
        public Dataset FindByCode(string code)
        {
            var entity = this.baseDal.FindOneByField("code", code);
            return entity;
        }

        /// <summary>
        /// 添加数据集
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public override Dataset Create(Dataset entity)
        {
            if (!CheckDuplicate(entity))
                throw new PoseidonException(ErrorCode.DuplicateCode);

            entity.Status = 0;
            return base.Create(entity);
        }

        /// <summary>
        /// 编辑数据集
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public override (bool success, string errorMessage) Update(Dataset entity)
        {
            if (!CheckDuplicate(entity))
                return (false, ErrorCode.DuplicateCode.DisplayName());
            return base.Update(entity);
        }
        #endregion //Method
    }
}
