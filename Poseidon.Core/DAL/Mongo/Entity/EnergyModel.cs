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

    public class EnergyModel
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
            var result = mongo.Insert("customerModel", doc);

            return result;
        }

        //public DataTable FindAll()
        //{
        //    BaseDALMongo 

        //}
    }
}
