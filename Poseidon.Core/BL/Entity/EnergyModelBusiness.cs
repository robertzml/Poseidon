using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.BL
{
    using Poseidon.Base.Entity;
    using Poseidon.Model;

    public class EnergyModelBusiness
    {
        #region Field
        private Poseidon.Core.DAL.Mongo.EnergyModelRepository dal;
        #endregion //Field

        #region Constructor
        public EnergyModelBusiness()
        {
            this.dal = new DAL.Mongo.EnergyModelRepository();
        }
        #endregion //Constructor

        #region Method
        public ErrorCode Create(EnergyModel model, List<ModelProperty> properties)
        {
            var result = this.dal.Create(model, properties);
            return result;
        }

        public List<EnergyModel> FindAll()
        {
            var data = this.dal.FindAllWithMain();
            return data;
        }
        #endregion //Method
    }
}
