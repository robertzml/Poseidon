namespace Poseidon.Winform.Client
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barChildList = new DevExpress.XtraBars.BarMdiChildrenListItem();
            this.bbiModelTypeOv = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExpenseAccount = new DevExpress.XtraBars.BarButtonItem();
            this.bbiGroupOv = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDepartmentOv = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPopulation = new DevExpress.XtraBars.BarButtonItem();
            this.bbiFund = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTargetOverview = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTargetMake = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUserAdd = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExpenseOv = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDictOv = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExpenseReceipt = new DevExpress.XtraBars.BarButtonItem();
            this.rpTarget = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgTargetEnergy = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgTargetBase = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpExpense = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgExpenseInfo = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpOrganization = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpSystem = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgSystemFunction = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgPrivilege = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.tabMdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMdiManager)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.barChildList,
            this.bbiModelTypeOv,
            this.bbiExpenseAccount,
            this.bbiGroupOv,
            this.bbiDepartmentOv,
            this.bbiPopulation,
            this.bbiFund,
            this.bbiTargetOverview,
            this.bbiTargetMake,
            this.bbiUserAdd,
            this.bbiExpenseOv,
            this.bbiDictOv,
            this.bbiExpenseReceipt});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 30;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpTarget,
            this.rpExpense,
            this.rpOrganization,
            this.rpSystem});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.Size = new System.Drawing.Size(924, 147);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            // 
            // barChildList
            // 
            this.barChildList.Caption = "窗口";
            this.barChildList.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barChildList.Id = 3;
            this.barChildList.Name = "barChildList";
            // 
            // bbiModelTypeOv
            // 
            this.bbiModelTypeOv.Caption = "模型类型总览";
            this.bbiModelTypeOv.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiModelTypeOv.Glyph")));
            this.bbiModelTypeOv.Id = 17;
            this.bbiModelTypeOv.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiModelTypeOv.LargeGlyph")));
            this.bbiModelTypeOv.Name = "bbiModelTypeOv";
            this.bbiModelTypeOv.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiModelTypeOv_ItemClick);
            // 
            // bbiExpenseAccount
            // 
            this.bbiExpenseAccount.Caption = "支出账户";
            this.bbiExpenseAccount.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiExpenseAccount.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiExpenseAccount.Glyph")));
            this.bbiExpenseAccount.Id = 18;
            this.bbiExpenseAccount.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiExpenseAccount.LargeGlyph")));
            this.bbiExpenseAccount.Name = "bbiExpenseAccount";
            this.bbiExpenseAccount.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExpenseAccount_ItemClick);
            // 
            // bbiGroupOv
            // 
            this.bbiGroupOv.Caption = "分组总览";
            this.bbiGroupOv.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiGroupOv.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiGroupOv.Glyph")));
            this.bbiGroupOv.Id = 19;
            this.bbiGroupOv.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiGroupOv.LargeGlyph")));
            this.bbiGroupOv.Name = "bbiGroupOv";
            this.bbiGroupOv.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiGroupOv_ItemClick);
            // 
            // bbiDepartmentOv
            // 
            this.bbiDepartmentOv.Caption = "部门总览";
            this.bbiDepartmentOv.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiDepartmentOv.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiDepartmentOv.Glyph")));
            this.bbiDepartmentOv.Id = 21;
            this.bbiDepartmentOv.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiDepartmentOv.LargeGlyph")));
            this.bbiDepartmentOv.Name = "bbiDepartmentOv";
            this.bbiDepartmentOv.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDepartmentOv_ItemClick);
            // 
            // bbiPopulation
            // 
            this.bbiPopulation.Caption = "人数统计";
            this.bbiPopulation.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiPopulation.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiPopulation.Glyph")));
            this.bbiPopulation.Id = 22;
            this.bbiPopulation.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiPopulation.LargeGlyph")));
            this.bbiPopulation.Name = "bbiPopulation";
            this.bbiPopulation.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPopulation_ItemClick);
            // 
            // bbiFund
            // 
            this.bbiFund.Caption = "经费统计";
            this.bbiFund.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiFund.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiFund.Glyph")));
            this.bbiFund.Id = 23;
            this.bbiFund.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiFund.LargeGlyph")));
            this.bbiFund.Name = "bbiFund";
            this.bbiFund.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiFund_ItemClick);
            // 
            // bbiTargetOverview
            // 
            this.bbiTargetOverview.Caption = "指标总览";
            this.bbiTargetOverview.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiTargetOverview.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiTargetOverview.Glyph")));
            this.bbiTargetOverview.Id = 24;
            this.bbiTargetOverview.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiTargetOverview.LargeGlyph")));
            this.bbiTargetOverview.Name = "bbiTargetOverview";
            this.bbiTargetOverview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiTargetOverview_ItemClick);
            // 
            // bbiTargetMake
            // 
            this.bbiTargetMake.Caption = "指标制定";
            this.bbiTargetMake.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiTargetMake.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiTargetMake.Glyph")));
            this.bbiTargetMake.Id = 25;
            this.bbiTargetMake.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiTargetMake.LargeGlyph")));
            this.bbiTargetMake.Name = "bbiTargetMake";
            this.bbiTargetMake.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiTargetMake_ItemClick);
            // 
            // bbiUserAdd
            // 
            this.bbiUserAdd.Caption = "添加用户";
            this.bbiUserAdd.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiUserAdd.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiUserAdd.Glyph")));
            this.bbiUserAdd.Id = 26;
            this.bbiUserAdd.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiUserAdd.LargeGlyph")));
            this.bbiUserAdd.Name = "bbiUserAdd";
            this.bbiUserAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiUserAdd_ItemClick);
            // 
            // bbiExpenseOv
            // 
            this.bbiExpenseOv.Caption = "支出总览";
            this.bbiExpenseOv.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiExpenseOv.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiExpenseOv.Glyph")));
            this.bbiExpenseOv.Id = 27;
            this.bbiExpenseOv.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiExpenseOv.LargeGlyph")));
            this.bbiExpenseOv.Name = "bbiExpenseOv";
            this.bbiExpenseOv.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExpenseOv_ItemClick);
            // 
            // bbiDictOv
            // 
            this.bbiDictOv.Caption = "字典总览";
            this.bbiDictOv.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiDictOv.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiDictOv.Glyph")));
            this.bbiDictOv.Id = 28;
            this.bbiDictOv.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiDictOv.LargeGlyph")));
            this.bbiDictOv.Name = "bbiDictOv";
            this.bbiDictOv.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDictOv_ItemClick);
            // 
            // bbiExpenseReceipt
            // 
            this.bbiExpenseReceipt.Caption = "支出单据";
            this.bbiExpenseReceipt.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiExpenseReceipt.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiExpenseReceipt.Glyph")));
            this.bbiExpenseReceipt.Id = 29;
            this.bbiExpenseReceipt.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiExpenseReceipt.LargeGlyph")));
            this.bbiExpenseReceipt.Name = "bbiExpenseReceipt";
            this.bbiExpenseReceipt.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiExpenseReceipt_ItemClick);
            // 
            // rpTarget
            // 
            this.rpTarget.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgTargetEnergy,
            this.rpgTargetBase});
            this.rpTarget.Name = "rpTarget";
            this.rpTarget.Text = "指标化管理";
            // 
            // rpgTargetEnergy
            // 
            this.rpgTargetEnergy.ItemLinks.Add(this.bbiTargetOverview);
            this.rpgTargetEnergy.ItemLinks.Add(this.bbiTargetMake);
            this.rpgTargetEnergy.Name = "rpgTargetEnergy";
            this.rpgTargetEnergy.Text = "用能指标";
            // 
            // rpgTargetBase
            // 
            this.rpgTargetBase.ItemLinks.Add(this.bbiDepartmentOv);
            this.rpgTargetBase.ItemLinks.Add(this.bbiPopulation);
            this.rpgTargetBase.ItemLinks.Add(this.bbiFund);
            this.rpgTargetBase.Name = "rpgTargetBase";
            this.rpgTargetBase.Text = "基础数据";
            // 
            // rpExpense
            // 
            this.rpExpense.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgExpenseInfo});
            this.rpExpense.Name = "rpExpense";
            this.rpExpense.Text = "费用支出";
            // 
            // rpgExpenseInfo
            // 
            this.rpgExpenseInfo.ItemLinks.Add(this.bbiExpenseOv);
            this.rpgExpenseInfo.ItemLinks.Add(this.bbiExpenseReceipt);
            this.rpgExpenseInfo.ItemLinks.Add(this.bbiExpenseAccount);
            this.rpgExpenseInfo.Name = "rpgExpenseInfo";
            this.rpgExpenseInfo.Text = "基本信息";
            // 
            // rpOrganization
            // 
            this.rpOrganization.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgGroup});
            this.rpOrganization.Name = "rpOrganization";
            this.rpOrganization.Text = "组织管理";
            // 
            // rpgGroup
            // 
            this.rpgGroup.ItemLinks.Add(this.bbiModelTypeOv);
            this.rpgGroup.ItemLinks.Add(this.bbiGroupOv);
            this.rpgGroup.Name = "rpgGroup";
            this.rpgGroup.Text = "组织分组";
            // 
            // rpSystem
            // 
            this.rpSystem.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgSystemFunction,
            this.rpgPrivilege});
            this.rpSystem.Name = "rpSystem";
            this.rpSystem.Text = "系统管理";
            // 
            // rpgSystemFunction
            // 
            this.rpgSystemFunction.ItemLinks.Add(this.bbiDictOv);
            this.rpgSystemFunction.ItemLinks.Add(this.barChildList);
            this.rpgSystemFunction.Name = "rpgSystemFunction";
            this.rpgSystemFunction.Text = "系统功能";
            // 
            // rpgPrivilege
            // 
            this.rpgPrivilege.ItemLinks.Add(this.bbiUserAdd);
            this.rpgPrivilege.Name = "rpgPrivilege";
            this.rpgPrivilege.Text = "权限管理";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 557);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbonControl;
            this.ribbonStatusBar.Size = new System.Drawing.Size(924, 31);
            // 
            // tabMdiManager
            // 
            this.tabMdiManager.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.tabMdiManager.MdiParent = this;
            this.tabMdiManager.PinPageButtonShowMode = DevExpress.XtraTab.PinPageButtonShowMode.InActiveTabPageHeader;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 588);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbonControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Ribbon = this.ribbonControl;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "能源科数据管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMdiManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgSystemFunction;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager tabMdiManager;
        private DevExpress.XtraBars.BarMdiChildrenListItem barChildList;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpSystem;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpOrganization;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgGroup;
        private DevExpress.XtraBars.BarButtonItem bbiModelTypeOv;
        private DevExpress.XtraBars.BarButtonItem bbiExpenseAccount;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpExpense;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgExpenseInfo;
        private DevExpress.XtraBars.BarButtonItem bbiGroupOv;
        private DevExpress.XtraBars.BarButtonItem bbiDepartmentOv;
        private DevExpress.XtraBars.BarButtonItem bbiPopulation;
        private DevExpress.XtraBars.BarButtonItem bbiFund;
        private DevExpress.XtraBars.BarButtonItem bbiTargetOverview;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpTarget;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgTargetEnergy;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgTargetBase;
        private DevExpress.XtraBars.BarButtonItem bbiTargetMake;
        private DevExpress.XtraBars.BarButtonItem bbiUserAdd;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgPrivilege;
        private DevExpress.XtraBars.BarButtonItem bbiExpenseOv;
        private DevExpress.XtraBars.BarButtonItem bbiDictOv;
        private DevExpress.XtraBars.BarButtonItem bbiExpenseReceipt;
    }
}

