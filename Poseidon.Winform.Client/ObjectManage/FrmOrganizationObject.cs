using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Poseidon.Winform.Client
{
    using Poseidon.Base;
    using Poseidon.Core.BL;
    using Poseidon.Core.DL;
    using Poseidon.Winform.Base;

    /// <summary>
    /// 组织对象总览窗体
    /// </summary>
    public partial class FrmOrganizationObject : BaseForm
    {
        #region Field
        /// <summary>
        /// 组织模型列表
        /// </summary>
        private List<CustomModel> modelList;
        #endregion //Field

        #region Constructor
        public FrmOrganizationObject()
        {
            InitializeComponent();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 初始化类型树
        /// </summary>
        private void InitTree()
        {
            var top = this.modelList.Single(r => r.Base == PoseidonConstant.RootModelName);

            TreeNode node = new TreeNode { Name = top.Key, Text = top.Name, Tag = top };
            this.tvModel.Nodes.Add(node);

            AddSubTreeNode(node);

            node.Expand();
        }

        /// <summary>
        /// 递归添加子节点
        /// </summary>
        /// <param name="node">父节点</param>
        private void AddSubTreeNode(TreeNode node)
        {
            var data = this.modelList.Where(r => r.Base == node.Name);
            if (data.Count() == 0)
                return;

            foreach (var item in data)
            {
                TreeNode sub = new TreeNode { Name = item.Key, Text = item.Name, Tag = item };
                node.Nodes.Add(sub);

                AddSubTreeNode(sub);
            }
        }

        /// <summary>
        /// 初始化选中模型属性
        /// </summary>
        /// <param name="key">模型标识</param>
        private void InitModelProperty(string key)
        {
            var model = this.modelList.Single(r => r.Key == key);

            if (model.Base == PoseidonConstant.RootModelName) //组织基类不显示
                return;

            this.txtKey.Text = model.Key;
            this.txtName.Text = model.Name;
            this.txtBase.Text = model.Base;
            this.txtRemark.Text = model.Remark;

            this.lvProperty.Items.Clear();
            foreach (var item in model.Properties)
            {
                var lvi = new ListViewItem(item.Name);
                lvi.SubItems.Add(item.Type.ToString());
                lvi.SubItems.Add(item.Remark);

                this.lvProperty.Items.Add(lvi);
            }
        }
        #endregion //Function

        #region Event
        /// <summary>
        /// 窗体载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmOrganizationObject_Load(object sender, EventArgs e)
        {
            this.modelList = BusinessFactory<CustomModelBusiness>.Instance.FindByType(CustomModelType.Organization);

            InitTree();
        }

        /// <summary>
        /// 选择节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvModel_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.tvModel.SelectedNode == null)
                return;

            InitModelProperty(e.Node.Name);
        }
        #endregion //Event

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.tvModel.SelectedNode == null)
                return;

            var model = this.tvModel.SelectedNode.Tag as CustomModel;
            if (model.Base == PoseidonConstant.RootModelName)
                return;


            ChildFormManage.ShowDialogForm(typeof(FrmOrganizationObjectAdd));
        }
    }
}
