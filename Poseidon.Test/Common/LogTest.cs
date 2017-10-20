using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poseidon.Test.Common
{
    using Poseidon.Common;

    /// <summary>
    /// 日志测试
    /// </summary>
    [TestClass]
    public class LogTest
    {
        #region Test        
        [TestMethod]
        public void TestDebug()
        {
            Logger.Instance.Debug("Debug Info");
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void TestWarning()
        {
            Logger.Instance.Warning("Warning");
            Assert.AreEqual(1, 1);
        }


        [TestMethod]
        public void TestException()
        {
            try
            {
                int a = 3;
                int b = a / 0;

                Assert.AreEqual(0, b);
            }
            catch(Exception e)
            {
                Logger.Instance.Exception("测试", e);
            }
        }
        #endregion //Test
    }
}
