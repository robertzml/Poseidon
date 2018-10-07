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
        public void TestCRUD()
        {
            ModelType entity = new ModelType();
            entity.Name = "测试";
            entity.Code = "test";
            entity.Remark = "T";

            var mt = CallerFactory<IModelTypeService>.Instance.Create(entity);

            Assert.AreEqual(mt.Id, entity.Id);

            var info = CallerFactory<IModelTypeService>.Instance.FindById(mt.Id);
            Assert.AreEqual("test", mt.Code);

            info.Remark = "rem";
            CallerFactory<IModelTypeService>.Instance.Update(info);
            Assert.AreEqual("rem", info.Remark);


            var result = CallerFactory<IModelTypeService>.Instance.Delete(mt);
            Assert.IsTrue(result.success);
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
