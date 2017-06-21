using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poseidon.Test
{
    using Poseidon.Base.Framework;
    using Poseidon.Caller.Facade;
    using Poseidon.Core.BL;
    using Poseidon.Core.DL;

    /// <summary>
    /// 线程测试
    /// </summary>
    [TestClass]
    public class ThreadTest
    {
        #region Constructor
        public ThreadTest()
        {
            GlobalAction.Initialize();
        }
        #endregion //Constructor

        #region Test
        [TestMethod]
        public void TestThreadRead()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var groups = BusinessFactory<GroupBusiness>.Instance.FindAll();

            List<Task> tasks = new List<Task>();
            foreach(var item in groups)
            {
                var task = Task.Run(() =>
                {
                    var group = BusinessFactory<GroupBusiness>.Instance.FindById(item.Id);

                    Assert.AreEqual(item.Id, group.Id);
                });

                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());
            sw.Stop();

            Console.WriteLine("total time is {0} millisecond", sw.ElapsedMilliseconds);
        }
        #endregion //Test
    }
}
