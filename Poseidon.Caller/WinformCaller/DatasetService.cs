﻿using System;
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
    /// 数据集业务访问服务
    /// </summary>
    internal class DatasetService : AbstractLocalService<Dataset>, IDatasetService
    {
        #region Field
        /// <summary>
        /// 业务类对象
        /// </summary>
        private DatasetBusiness bl = null;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 数据集业务访问服务
        /// </summary>
        public DatasetService() : base(BusinessFactory<DatasetBusiness>.Instance)
        {
            this.bl = this.baseBL as DatasetBusiness;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 根据代码查找数据集
        /// </summary>
        /// <param name="code">数据集代码</param>
        /// <returns></returns>
        public Dataset FindByCode(string code)
        {
            return this.bl.FindByCode(code);
        }
        #endregion //Method
    }
}
