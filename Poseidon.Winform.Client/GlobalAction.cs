using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Winform.Client
{
    using Poseidon.Common;

    /// <summary>
    /// 全局操作类
    /// </summary>
    public sealed class GlobalAction
    {
        #region Field
        /// <summary>
        /// 实例
        /// </summary>
        private static GlobalAction _instance;

        /// <summary>
        /// 锁变量
        /// </summary>
        private static object syncRoot = new object();
        #endregion //Field

        #region Constructor
        private GlobalAction()
        {
           
        }
        #endregion //Constructor

        #region Property
        /// <summary>
        /// 单件实例
        /// </summary>
        public static GlobalAction Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new GlobalAction();
                        }
                    }
                }
                return _instance;
            }
        }
        #endregion //Property
    }
}
