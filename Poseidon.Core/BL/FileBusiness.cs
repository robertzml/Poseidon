using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.BL
{
    using Poseidon.Base.Framework;
    using Poseidon.Core.IDAL;
    using Poseidon.Core.DL;

    /// <summary>
    /// 文件对象业务类
    /// </summary>
    public class FileBusiness : AbstractBusiness<File>, IBaseBL<File>
    {
        #region Constructor
        /// <summary>
        /// 文件对象业务类
        /// </summary>
        public FileBusiness()
        {
            this.baseDal = RepositoryFactory<IFileRepository>.Instance;
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
            var dal = this.baseDal as IFileRepository;
            return dal.FindByModelType(modelType);
        }

        /// <summary>
        /// 根据ID查找文件
        /// </summary>
        /// <param name="fileIds">文件ID列表</param>
        /// <returns></returns>
        public IEnumerable<File> FindWithIds(List<string> fileIds)
        {
            var dal = this.baseDal as IFileRepository;
            return dal.FindWithIds(fileIds);
        }
        #endregion //Method
    }
}
