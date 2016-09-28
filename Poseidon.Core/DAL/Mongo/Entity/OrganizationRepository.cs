using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.DAL.Mongo
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using Poseidon.Base;
    using Poseidon.Core.DL;
    using Poseidon.Core.IDAL;
    using Poseidon.Data.BaseDAL;

    /// <summary>
    /// 组织对象数据访问类
    /// </summary>
    internal class OrganizationRepository : IOrganizationRepository
    {
        #region Field
        private BaseDALMongo mongo;

        private string collectionName = "organization";
        #endregion //Field

        #region Constructor
        public OrganizationRepository()
        {
            this.mongo = new BaseDALMongo();
        }
        #endregion //Constructor

        #region Method
        
        public IEnumerable<Organization> FindAll()
        {
            throw new NotImplementedException();
        }

        public Organization FindByField<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }

        public Organization FindById(string id)
        {
            throw new NotImplementedException();
        }

        public Organization FindById(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Organization> FindListByField<Tvalue>(string field, Tvalue value)
        {
            throw new NotImplementedException();
        }


        public ErrorCode Create(Organization entity)
        {
            BsonDocument doc = new BsonDocument();

            doc.AddRange(entity.Values);

            var result = mongo.Insert(this.collectionName, doc);

            return result;
        }        


        public ErrorCode Update(Organization entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Delete(Organization entity)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
