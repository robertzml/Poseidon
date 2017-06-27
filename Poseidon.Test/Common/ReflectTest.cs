using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poseidon.Test.Common
{
    using Poseidon.Common;

    /// <summary>
    /// 反射测试
    /// </summary>
    [TestClass]
    public class ReflectTest
    {
        #region Test
        /// <summary>
        /// 测试简单反射
        /// </summary>
        [TestMethod]
        public void TestReflect1()
        {
            var obj1 = Reflect<Foo>.Create(typeof(Foo).FullName, typeof(Foo).Assembly.GetName().Name, true);
            var obj2 = Reflect<Foo>.Create(typeof(Foo).FullName, typeof(Foo).Assembly.GetName().Name, true);

            Assert.IsTrue(obj1.Equals(obj2));

            obj1.Set(5);

            Assert.AreEqual(obj1.Get(), obj2.Get());

            var obj3 = new Foo();
            var obj4 = new Foo();

            Assert.IsFalse(obj3.Equals(obj4));
        }

        /// <summary>
        /// 测试多线程反射
        /// </summary>
        [TestMethod]
        public void TestReflect2()
        {
            List<Task<Foo>> tasks = new List<Task<Foo>>();
            int count = 2;
            for (int i = 0; i < count; i++)
            {
                var task = Task.Run(() =>
                {
                    var obj = Reflect<Foo>.Create(typeof(Foo).FullName, typeof(Foo).Assembly.GetName().Name, true);
                    return obj;
                });

                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            var foo0 = tasks[0].Result;
            var foo1 = tasks[1].Result;

            foo0.Set(12);

            Assert.AreEqual(foo0.Get(), foo1.Get());
            Assert.IsTrue(foo0.Equals(foo1));

            for (int i = 1; i < count; i++)
            {
                Assert.IsTrue(foo0.Equals(tasks[i].Result));
            }

            Console.WriteLine("Test finished");
        }
        #endregion //Test
    }
}
