using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poseidon.Test
{
    using Poseidon.Base.Framework;
    using Poseidon.Caller.Facade;
    using Poseidon.Core.DL;

    /// <summary>
    /// 模型类型类测试
    /// </summary>
    [TestClass]
    public class ModelTypeTest
    {
        #region Constructor
        public ModelTypeTest()
        {
            GlobalAction.Initialize();
        }
        #endregion //Constructor

        #region Test
        /// <summary>
        /// 测试创建
        /// </summary>
        [TestMethod]
        public void TestCreate()
        {
            ModelType entity = new ModelType();
            entity.Name = "测试";
            entity.Code = "test";
            entity.Remark = "T";

            //CallerFactory<IModelTypeService>.Instance.Create(entity);

            Assert.AreEqual("123", entity.Id);
        }

        /// <summary>
        /// 测试按代码查找
        /// </summary>
        [TestMethod]
        public void TestFindByCode()
        {
            string code = "Energy.Department";

            var entity = CallerFactory<IModelTypeService>.Instance.FindByCode(code);

            Assert.AreEqual(code, entity.Code);
        }
        #endregion //Test
    }
}
