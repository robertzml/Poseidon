namespace Poseidon.Winform.Core
{
    partial class GroupsTree
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tlGroup = new DevExpress.XtraTreeList.TreeList();
            this.colId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colParentId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colRemark = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colStatus = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bsGroup = new System.Windows.Forms.BindingSource();
            ((System.ComponentModel.ISupportInitialize)(this.tlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // tlGroup
            // 
            this.tlGroup.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colId,
            this.colName,
            this.colCode,
            this.colParentId,
            this.colRemark,
            this.colStatus});
            this.tlGroup.DataSource = this.bsGroup;
            this.tlGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlGroup.KeyFieldName = "Id";
            this.tlGroup.Location = new System.Drawing.Point(0, 0);
            this.tlGroup.Name = "tlGroup";
            this.tlGroup.OptionsBehavior.Editable = false;
            this.tlGroup.OptionsBehavior.PopulateServiceColumns = true;
            this.tlGroup.OptionsCustomization.AllowColumnMoving = false;
            this.tlGroup.OptionsCustomization.AllowQuickHideColumns = false;
            this.tlGroup.OptionsMenu.EnableColumnMenu = false;
            this.tlGroup.OptionsMenu.EnableFooterMenu = false;
            this.tlGroup.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.tlGroup.ParentFieldName = "ParentId";
            this.tlGroup.Size = new System.Drawing.Size(309, 304);
            this.tlGroup.TabIndex = 0;
            this.tlGroup.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tlGroup_FocusedNodeChanged);
            this.tlGroup.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tlGroup_MouseDoubleClick);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Width = 114;
            // 
            // colName
            // 
            this.colName.Caption = "名称";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 228;
            // 
            // colCode
            // 
            this.colCode.Caption = "代码";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 1;
            this.colCode.Width = 228;
            // 
            // colParentId
            // 
            this.colParentId.FieldName = "ParentId";
            this.colParentId.Name = "colParentId";
            this.colParentId.Width = 48;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "备注";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 2;
            this.colRemark.Width = 229;
            // 
            // colStatus
            // 
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Width = 49;
            // 
            // bsGroup
            // 
            this.bsGroup.DataSource = typeof(Poseidon.Core.DL.Group);
            // 
            // GroupsTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlGroup);
            this.Name = "GroupsTree";
            this.Size = new System.Drawing.Size(309, 304);
            this.Load += new System.EventHandler(this.GroupsTree_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList tlGroup;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colParentId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colRemark;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colStatus;
        private System.Windows.Forms.BindingSource bsGroup;
    }
}
