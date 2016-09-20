using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.DAL.Mongo
{
    using MongoDB.Bson;
    using Poseidon.Base.Entity;
    using Poseidon.Data.BaseDAL;
    using Poseidon.Model;

    public class EnergyModelRepository
    {
        public ErrorCode Create(Poseidon.Model.EnergyModel model, List<ModelProperty> properties)
        {
            BsonDocument doc = new BsonDocument
            {
                { "key", model.Key },
                { "name", model.Name },
                { "base", model.Base },
                { "type", Convert.ToInt32(ModelType.Energy) },
                { "remark", model.Remark }
            };

            foreach (var item in properties)
            {
                BsonDocument d = new BsonDocument
                {
                    { "type", item.Type.ToString() },
                    { "remark", item.Remark }
                };
                doc.Add(item.Name, d);
            }

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
    }
}
