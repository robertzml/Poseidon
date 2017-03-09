using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poseidon.Winform.Client
{
    using Poseidon.Base.Framework;
    using Poseidon.Common;
    using Poseidon.Core.BL;
    using Poseidon.Core.DL;
    using Poseidon.Core.Utility;
    using Poseidon.Winform.Base;

    /// <summary>
    /// 用户登录窗体
    /// </summary>
    public partial class LoginForm : BaseForm
    {
        #region Field
        /// <summary>
        /// 用户
        /// </summary>
        private User user;
        #endregion //Field

        #region Constructor
        public LoginForm()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 载入记住用户名密码
        /// </summary>
        private void LoadRemember()
        {
            if (ConfigUtility.CheckRememberUser())
            {
                this.txtUserName.Text = ConfigUtility.GetRememberUserName();
                this.txtPassword.Text = ConfigUtility.GetRememberPassword();
            }
        }

        /// <summary>
        /// 记住用户名密码
        /// </summary>
        private void SaveRemember()
        {
            if (ConfigUtility.CheckRememberUser())
                ConfigUtility.UpdateRememberUser(this.txtUserName.Text, this.txtPassword.Text);
            else
                ConfigUtility.SaveRememberUser(this.txtUserName.Text, this.txtPassword.Text);
        }

        /// <summary>
        /// 输入检查
        /// </summary>
        /// <returns></returns>
        private Tuple<bool, string> CheckInput()
        {
            string errorMessage = "";

            if (string.IsNullOrEmpty(this.txtUserName.Text.Trim()))
            {
                errorMessage = "用户名不能为空";
                return new Tuple<bool, string>(false, errorMessage);
            }

            if (string.IsNullOrEmpty(this.txtPassword.Text.Trim()))
            {
                errorMessage = "密码不能为空";
                return new Tuple<bool, string>(false, errorMessage);
            }

            return new Tuple<bool, string>(true, "");
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginForm_Load(object sender, EventArgs e)
        {
            LoadRemember();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var hash = Hasher.SHA1Encrypt(this.txtPassword.Text);
            var result = BusinessFactory<UserBusiness>.Instance.Login(this.txtUserName.Text, hash);

            if (result)
            {
                if (this.chkRemember.Checked)
                {
                    SaveRemember();
                }

                this.user = BusinessFactory<UserBusiness>.Instance.FindByUserName(this.txtUserName.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageUtil.ShowWarning("用户名或密码错误");
                this.txtPassword.Text = "";
                return;
            }
        }
        #endregion //Event

        #region Property
        /// <summary>
        /// 登录用户
        /// </summary>
        public User User
        {
            get
            {
                return this.user;
            }
        }
        #endregion //Property
    }
}
