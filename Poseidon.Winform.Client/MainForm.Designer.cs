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
            this.bbiEntityModelAdd = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEntityModelOverview = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBusinessModelOverview = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBusinessModelAdd = new DevExpress.XtraBars.BarButtonItem();
            this.bbiModelTypeOv = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExpenseAccount = new DevExpress.XtraBars.BarButtonItem();
            this.rpExpense = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgExpenseInfo = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpOrganization = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpModel = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgEntityModel = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgBusinessModel = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpSystem = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
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
            this.bbiEntityModelAdd,
            this.bbiEntityModelOverview,
            this.bbiBusinessModelOverview,
            this.bbiBusinessModelAdd,
            this.bbiModelTypeOv,
            this.bbiExpenseAccount});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 19;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpExpense,
            this.rpOrganization,
            this.rpModel,
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
            // bbiEntityModelAdd
            // 
            this.bbiEntityModelAdd.Caption = "添加模型";
            this.bbiEntityModelAdd.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiEntityModelAdd.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiEntityModelAdd.Glyph")));
            this.bbiEntityModelAdd.Id = 9;
            this.bbiEntityModelAdd.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiEntityModelAdd.LargeGlyph")));
            this.bbiEntityModelAdd.Name = "bbiEntityModelAdd";
            // 
            // bbiEntityModelOverview
            // 
            this.bbiEntityModelOverview.Caption = "实体模型总览";
            this.bbiEntityModelOverview.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiEntityModelOverview.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiEntityModelOverview.Glyph")));
            this.bbiEntityModelOverview.Id = 10;
            this.bbiEntityModelOverview.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiEntityModelOverview.LargeGlyph")));
            this.bbiEntityModelOverview.Name = "bbiEntityModelOverview";
            // 
            // bbiBusinessModelOverview
            // 
            this.bbiBusinessModelOverview.Caption = "业务模型总览";
            this.bbiBusinessModelOverview.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiBusinessModelOverview.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiBusinessModelOverview.Glyph")));
            this.bbiBusinessModelOverview.Id = 11;
            this.bbiBusinessModelOverview.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiBusinessModelOverview.LargeGlyph")));
            this.bbiBusinessModelOverview.Name = "bbiBusinessModelOverview";
            // 
            // bbiBusinessModelAdd
            // 
            this.bbiBusinessModelAdd.Caption = "添加模型";
            this.bbiBusinessModelAdd.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.bbiBusinessModelAdd.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiBusinessModelAdd.Glyph")));
            this.bbiBusinessModelAdd.Id = 12;
            this.bbiBusinessModelAdd.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiBusinessModelAdd.LargeGlyph")));
            this.bbiBusinessModelAdd.Name = "bbiBusinessModelAdd";
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
            // rpExpense
            // 
            this.rpExpense.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgExpenseInfo});
            this.rpExpense.Name = "rpExpense";
            this.rpExpense.Text = "费用支出";
            // 
            // rpgExpenseInfo
            // 
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
            this.rpgGroup.Name = "rpgGroup";
            this.rpgGroup.Text = "组织分组";
            // 
            // rpModel
            // 
            this.rpModel.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgEntityModel,
            this.rpgBusinessModel});
            this.rpModel.Name = "rpModel";
            this.rpModel.Text = "模型管理";
            // 
            // rpgEntityModel
            // 
            this.rpgEntityModel.ItemLinks.Add(this.bbiEntityModelOverview);
            this.rpgEntityModel.ItemLinks.Add(this.bbiEntityModelAdd);
            this.rpgEntityModel.Name = "rpgEntityModel";
            this.rpgEntityModel.Text = "实体模型";
            // 
            // rpgBusinessModel
            // 
            this.rpgBusinessModel.ItemLinks.Add(this.bbiBusinessModelOverview);
            this.rpgBusinessModel.ItemLinks.Add(this.bbiBusinessModelAdd);
            this.rpgBusinessModel.Name = "rpgBusinessModel";
            this.rpgBusinessModel.Text = "业务模型";
            // 
            // rpSystem
            // 
            this.rpSystem.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.rpSystem.Name = "rpSystem";
            this.rpSystem.Text = "系统管理";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barChildList);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
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
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpModel;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager tabMdiManager;
        private DevExpress.XtraBars.BarMdiChildrenListItem barChildList;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpSystem;
        private DevExpress.XtraBars.BarButtonItem bbiEntityModelAdd;
        private DevExpress.XtraBars.BarButtonItem bbiEntityModelOverview;
        private DevExpress.XtraBars.BarButtonItem bbiBusinessModelOverview;
        private DevExpress.XtraBars.BarButtonItem bbiBusinessModelAdd;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgEntityModel;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgBusinessModel;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpOrganization;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgGroup;
        private DevExpress.XtraBars.BarButtonItem bbiModelTypeOv;
        private DevExpress.XtraBars.BarButtonItem bbiExpenseAccount;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpExpense;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgExpenseInfo;
    }
}

