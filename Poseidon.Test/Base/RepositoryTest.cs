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
    using Poseidon.Core.DL;
    using Poseidon.Core.IDAL;

    /// <summary>
    /// 数据访问层测试
    /// </summary>
    [TestClass]
    public class RepositoryTest
    {
        #region Constructor
        public RepositoryTest()
        {
            Cache.Instance.Add("DALPrefix", "Mongo");
            Cache.Instance.Add("ConnectionString", "mongodb://localhost:27017");
        }
        #endregion //Constructor

        #region Test
        [TestMethod]
        public void RepoTest1()
        {
            //var b1repo = RepositoryFactory<IBuildingRepository>.Instance;
            //var b2repo = RepositoryFactory<IBuildingRepository>.Instance;

            //Assert.IsTrue(b1repo.Equals(b2repo));

            //var b3repo = RepositoryFactory<IBuildingRepository>.GetInstance(DataBaseType.MongoDB);
            //Assert.IsFalse(b1repo.Equals(b3repo));

            foreach (var item in Cache.Instance.GetKeys())
            {
                Console.WriteLine(item);
            }
        }
        #endregion //Test
    }
}
