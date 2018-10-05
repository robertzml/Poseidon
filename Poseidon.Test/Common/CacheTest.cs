using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poseidon.Test.Common
{
    using Poseidon.Common;

    /// <summary>
    /// 缓存测试
    /// </summary>
    [TestClass]
    public class CacheTest
    {
        #region Function
        private Task AddCacheItem(string key, string val)
        {
            var task = Task.Run(() =>
            {
                Cache.Instance.Add(key, val);
                Console.WriteLine("key is {0}", key);
            });

            return task;
        }
        #endregion //Function

        #region Test
        /// <summary>
        /// 多线程测试
        /// </summary>
        [TestMethod]
        public void ThreadTest()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 10; i++)
            {
                var task = AddCacheItem((i % 2).ToString(), "jack");
                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            Assert.AreEqual(2, Cache.Instance.Count());

            sw.Stop();

            Console.WriteLine("total time is {0} millisecond", sw.ElapsedMilliseconds);
        }
        #endregion //Test
    }
}
