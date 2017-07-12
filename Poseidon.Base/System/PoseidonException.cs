using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Base.System
{
    using Poseidon.Common;

    /// <summary>
    /// Poseidon异常类
    /// </summary>
    [Serializable]
    public class PoseidonException : Exception
    {
        #region Field
        /// <summary>
        /// 错误代码
        /// </summary>
        private ErrorCode errorCode;

        /// <summary>
        /// HTTP状态码
        /// </summary>
        HttpStatusCode httpStatusCode;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// Poseidon异常类
        /// </summary>
        /// <param name="errorCode">错误代码</param>
        public PoseidonException(ErrorCode errorCode) : base(errorCode.DisplayName())
        {
            this.errorCode = errorCode;
        }

        /// <summary>
        /// Poseidon异常类
        /// </summary>
        /// <param name="message">错误消息</param>
        public PoseidonException(string message) : base(message)
        {

        }

        /// <summary>
        /// Poseidon异常类
        /// </summary>
        /// <param name="message">错误消息</param>
        /// <param name="inner">内部异常</param>
        public PoseidonException(string message, Exception inner) : base(message, inner)
        {

        }

        /// <summary>
        /// Poseidon异常类
        /// </summary>
        /// <param name="errorCode">错误代码</param>
        /// <param name="inner">内部异常</param>
        public PoseidonException(ErrorCode errorCode, Exception inner) : base(errorCode.DisplayName(), inner)
        {
            this.errorCode = errorCode;
        }

        /// <summary>
        /// Poseidon异常类，网络异常
        /// </summary>
        /// <param name="errorCode">错误代码</param>
        /// <param name="httpStatusCode">HTTP状态码</param>
        public PoseidonException(ErrorCode errorCode, HttpStatusCode httpStatusCode) : base(errorCode.DisplayName())
        {
            this.errorCode = errorCode;
        }
        #endregion //Constructor

        #region Property
        /// <summary>
        /// 错误代码
        /// </summary>
        public ErrorCode ErrorCode
        {
            get
            {
                return this.errorCode;
            }
        }

        /// <summary>
        /// HTTP状态码
        /// </summary>
        public HttpStatusCode HttpStatusCode
        {
            get
            {
                return httpStatusCode;
            }
        }
        #endregion //Property
    }
}
