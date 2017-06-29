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
    using Poseidon.Core.BL;
  
    /// <summary>
    /// 业务类测试
    /// </summary>
    [TestClass]
    public class BusinessTest
    {
        #region Constructor
        public BusinessTest()
        {
            Cache.Instance.Add("DALPrefix", "Mongo");
            Cache.Instance.Add("ConnectionString", "mongodb://localhost:27017");
        }
        #endregion //Constructor

        #region Test
        [TestMethod]
        public void BLTest1()
        {
            var bll1 = BusinessFactory<GroupBusiness>.Instance;
            var bll2 = BusinessFactory<GroupBusiness>.Instance;

            Assert.IsTrue(bll1.Equals(bll2));

            var bll3 = BusinessFactory<GroupBusiness>.GetInstance();
            Assert.IsFalse(bll1.Equals(bll3));
        }

        [TestMethod]
        public void BLTest2()
        {
            List<Task<GroupBusiness>> tasks = new List<Task<GroupBusiness>>();
            int count = 50;
            for (int i = 0; i < count; i++)
            {
                var task = Task.Run(() =>
                {
                    var obj = BusinessFactory<GroupBusiness>.Instance;
                    return obj;
                });

                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            var foo0 = tasks[0].Result;
            var foo1 = tasks[1].Result;
           
            Assert.IsTrue(foo0.Equals(foo1));

            for (int i = 1; i < count; i++)
            {
                Assert.IsTrue(foo0.Equals(tasks[i].Result));
            }


            foreach (var item in Cache.Instance.GetKeys())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Test finished");
        }

        [TestMethod]
        public void BLTest3()
        {
            int count = 50;
            List<Task<GroupBusiness>> tasks = new List<Task<GroupBusiness>>();
            for (int i = 0; i < count; i++)
            {
                var task = Task.Run(() =>
                {
                    var obj = new GroupBusiness();
                    return obj;
                });

                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            var foo0 = tasks[0].Result;
            var foo1 = tasks[1].Result;

            Assert.IsFalse(foo0.Equals(foo1));
            Console.WriteLine("Test finished");
        }
        #endregion //Test
    }
}
