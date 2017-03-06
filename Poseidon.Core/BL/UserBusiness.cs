using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Core.BL
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Common;
    using Poseidon.Core.IDAL;
    using Poseidon.Core.DL;

    /// <summary>
    /// 用户业务类
    /// </summary>
    public class UserBusiness : AbsctractBusiness<User>
    {
        #region Constructor
        /// <summary>
        /// 用户业务类
        /// </summary>
        public UserBusiness()
        {
            this.baseDal = RepositoryFactory<IUserRepository>.Instance;
        }
        #endregion //Constructor

        #region Method
        public bool Login(string userName, string password)
        {
            var dal = this.baseDal as IUserRepository;

            long count = dal.Count("userName", userName);
            if (count == 0)
                return false;

            var user = dal.FindOneByField("userName", userName);

            if (Hasher.SHA1Encrypt(password) != user.Password)
                return false;

            return true;
        }
        #endregion //Method
    }
}
