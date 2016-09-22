using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Poseidon.Core.DAL.Mongo
{
    using MongoDB.Bson;
    using Poseidon.Base;
    using Poseidon.Core.DL;
    using Poseidon.Core.IDAL;
    using Poseidon.Data.BaseDAL;
    using Poseidon.Model;

    /// <summary>
    /// 能源模型数据访问类
    /// </summary>
    internal class EnergyModelRepository : IEnergyModelRepository
    {

        #region Method

        public ErrorCode Create(EnergyModel obj)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 新增能源模型
        /// </summary>
        /// <param name="model">基础属性</param>
        /// <param name="properties">自定义属性</param>
        /// <returns></returns>
        public ErrorCode Create(EnergyModel model, List<ModelProperty> properties)
        {
            BsonDocument doc = new BsonDocument
            {
                { "key", model.Key },
                { "name", model.Name },
                { "base", model.Base },
                { "type", Convert.ToInt32(model.Type) },
                { "remark", model.Remark }
            };

            BsonArray array = new BsonArray();
            foreach (var item in properties)
            {
                BsonDocument d = new BsonDocument
                {
                    { "name", item.Name },
                    { "type", item.Type.ToString() },
                    { "remark", item.Remark }
                };
                array.Add(d);
            }

            doc.Add("properties", array);

            BaseDALMongo mongo = new BaseDALMongo();
            var result = mongo.Insert("customModel", doc);

            return result;
        }

        /// <summary>
        /// 获取所有能源模型基本属性
        /// </summary>
        /// <returns></returns>
        public List<EnergyModel> FindAllWithMain()
        {
            BaseDALMongo mongo = new BaseDALMongo();
            var data = mongo.FindAll("customModel");

            List<EnergyModel> models = new List<EnergyModel>();
            foreach (var item in data)
            {
                EnergyModel m = new EnergyModel();
                m.Key = item["key"].ToString();
                m.Name = item["name"].ToString();

                models.Add(m);
            }

            return models;
        }
        #endregion //Method
    }
}
