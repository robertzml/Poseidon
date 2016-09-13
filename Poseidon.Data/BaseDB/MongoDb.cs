using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Poseidon.Data.BaseDB
{
    public class MongoDB
    {
        public void Connect()
        {
            var client = new MongoClient();
            //client.GetDatabase();
        }
    }
}
