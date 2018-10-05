using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poseidon.Test.Base
{
    using Poseidon.Base.Framework;
    using Poseidon.Common;
    using Poseidon.Caller.Facade;

    /// <summary>
    /// 服务访问测试
    /// </summary>
    [TestClass]
    public class CallerTest
    {
        #region Constructor
        public CallerTest()
        {
            Cache.Instance.Add("CallerType", "win");
            Cache.Instance.Add("DALPrefix", "Mongo");
            Cache.Instance.Add("ConnectionString", "mongodb://localhost:27017");
        }
        #endregion //Constructor

        #region Test
        [TestMethod]
        public void CallerTest1()
        {
            var c1 = CallerFactory<IBuildingService>.Instance;
            var c2 = CallerFactory<IBuildingService>.Instance;

            Assert.IsTrue(c1.Equals(c2));

            foreach (var item in Cache.Instance.GetKeys())
            {                
                Console.WriteLine(string.Format("key {0}, value: {1}", item, Cache.Instance[item]));
            }
        }

        [TestMethod]
        public void CallerTest2()
        {
            var c1 = CallerFactory<IBuildingService>.Instance;
            var c2 = CallerFactory<IBuildingService>.GetInstance(CallerType.WebApi);

            Assert.IsFalse(c1.Equals(c2));

            foreach (var item in Cache.Instance.GetKeys())
            {
                Console.WriteLine(string.Format("key {0}, value: {1}", item, Cache.Instance[item]));
            }
        }
        #endregion //Test
    }
}
