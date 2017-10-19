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
    /// 文件业务访问服务类
    /// </summary>
    internal class FileService : AbstractLocalService<File>, IFileService
    {
        #region Field
        /// <summary>
        /// 业务类对象
        /// </summary>
        private FileBusiness bl = null;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 文件业务访问服务类
        /// </summary>
        public FileService() : base(BusinessFactory<FileBusiness>.Instance)
        {
            this.bl = this.baseBL as FileBusiness;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 根据模型类型查找文件
        /// </summary>
        /// <param name="modelType">模型类型</param>
        /// <returns></returns>
        public IEnumerable<File> FindByModelType(string modelType)
        {
            return this.bl.FindByModelType(modelType);
        }

        /// <summary>
        /// 根据ID查找文件
        /// </summary>
        /// <param name="fileIds">文件ID列表</param>
        /// <returns></returns>
        public IEnumerable<File> FindWithIds(List<string> fileIds)
        {
            return this.bl.FindWithIds(fileIds);
        }
        #endregion //Method
    }
}
