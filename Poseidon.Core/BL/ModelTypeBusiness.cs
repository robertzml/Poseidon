﻿using System;
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
    /// 模型类型业务类
    /// </summary>
    public class ModelTypeBusiness : AbsctractBusiness<ModelType>
    {
        #region Constructor
        public ModelTypeBusiness()
        {
            this.baseDal = RepositoryFactory<IModelTypeRepository>.Instance;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 根据代码获取模型类型
        /// </summary>
        /// <param name="code">代码</param>
        /// <returns></returns>
        public ModelType FindByCode(string code)
        {
            var dal = this.baseDal as IModelTypeRepository;
            return dal.FindByCode(code);
        }
        #endregion //Method
    }
}
