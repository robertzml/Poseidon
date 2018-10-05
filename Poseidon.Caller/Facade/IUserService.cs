using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poseidon.Caller.Facade
{
    using Poseidon.Base.Framework;
    using Poseidon.Core.DL;

    /// <summary>
    /// 用户数据访问服务接口
    /// </summary>
    public interface IUserService : IBaseService<User>
    {
        /// <summary>
        /// 按用户名获取用户
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        User FindByUserName(string userName);

        /// <summary>
        /// 按ID查找用户
        /// </summary>
        /// <param name="ids">用户ID列表</param>
        /// <returns></returns>
        IEnumerable<User> FindWithIds(List<string> ids);

        /// <summary>
        /// 检查用户是否Root
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns></returns>
        bool IsRoot(string id);

        /// <summary>
        /// 获取用户所有权限列表
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns>权限代码列表</returns>
        IEnumerable<string> GetPrivileges(string id);

        /// <summary>
        /// 检查用户是否含有指定权限
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="code">权限代码</param>
        /// <returns></returns>
        bool HasPrivilege(string id, string code);

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">散列密码</param>
        /// <returns></returns>
        bool Login(string userName, string password);

        /// <summary>
        /// 检查用户密码
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">散列密码</param>
        /// <returns></returns>
        bool CheckPassword(string userName, string password);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="oldPassword">原密码</param>
        /// <param name="newPassword">新密码</param>
        /// <returns></returns>
        bool ChangePassword(string userName, string oldPassword, string newPassword);

        /// <summary>
        /// 设置权限
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <param name="codes">权限代码列表</param>
        void SetPrivileges(string id, List<string> codes);

        /// <summary>
        /// 启用用户
        /// </summary>
        /// <param name="id">用户ID</param>
        void Enable(string id);

        /// <summary>
        /// 禁用用户
        /// </summary>
        /// <param name="id">用户ID</param>
        void Disable(string id);
    }
}
