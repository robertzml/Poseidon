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
            this.barBtnEnergyList = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnOrganizationList = new DevExpress.XtraBars.BarButtonItem();
            this.barChildList = new DevExpress.XtraBars.BarMdiChildrenListItem();
            this.barBtnEnergyAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnOrganizationAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnExit = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnOrganizationOverview = new DevExpress.XtraBars.BarButtonItem();
            this.rpObject = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rgoOrganization = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpModel = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rgmOrganization = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rgmEnergy = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rgmBuilding = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rgmEquipment = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rgmStaff = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpSystem = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.tabMdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.barBtnOrganizationObjectAdd = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMdiManager)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl.ExpandCollapseItem,
            this.barBtnEnergyList,
            this.barBtnOrganizationList,
            this.barChildList,
            this.barBtnEnergyAdd,
            this.barBtnOrganizationAdd,
            this.barBtnExit,
            this.barBtnOrganizationOverview,
            this.barBtnOrganizationObjectAdd});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 9;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpObject,
            this.rpModel,
            this.rpSystem});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.Size = new System.Drawing.Size(924, 147);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
            this.ribbonControl.Toolbar.ItemLinks.Add(this.barBtnExit);
            // 
            // barBtnEnergyList
            // 
            this.barBtnEnergyList.Caption = "能源模型总览";
            this.barBtnEnergyList.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barBtnEnergyList.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnEnergyList.Glyph")));
            this.barBtnEnergyList.Id = 1;
            this.barBtnEnergyList.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnEnergyList.LargeGlyph")));
            this.barBtnEnergyList.Name = "barBtnEnergyList";
            this.barBtnEnergyList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnEnergy_ItemClick);
            // 
            // barBtnOrganizationList
            // 
            this.barBtnOrganizationList.Caption = "组织模型总览";
            this.barBtnOrganizationList.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barBtnOrganizationList.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnOrganizationList.Glyph")));
            this.barBtnOrganizationList.Id = 2;
            this.barBtnOrganizationList.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnOrganizationList.LargeGlyph")));
            this.barBtnOrganizationList.Name = "barBtnOrganizationList";
            this.barBtnOrganizationList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnOrganizationList_ItemClick);
            // 
            // barChildList
            // 
            this.barChildList.Caption = "窗口";
            this.barChildList.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barChildList.Id = 3;
            this.barChildList.Name = "barChildList";
            // 
            // barBtnEnergyAdd
            // 
            this.barBtnEnergyAdd.Caption = "添加模型";
            this.barBtnEnergyAdd.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barBtnEnergyAdd.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnEnergyAdd.Glyph")));
            this.barBtnEnergyAdd.Id = 4;
            this.barBtnEnergyAdd.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnEnergyAdd.LargeGlyph")));
            this.barBtnEnergyAdd.Name = "barBtnEnergyAdd";
            this.barBtnEnergyAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnEnergyAdd_ItemClick);
            // 
            // barBtnOrganizationAdd
            // 
            this.barBtnOrganizationAdd.Caption = "添加模型";
            this.barBtnOrganizationAdd.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barBtnOrganizationAdd.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnOrganizationAdd.Glyph")));
            this.barBtnOrganizationAdd.Id = 5;
            this.barBtnOrganizationAdd.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnOrganizationAdd.LargeGlyph")));
            this.barBtnOrganizationAdd.Name = "barBtnOrganizationAdd";
            this.barBtnOrganizationAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnOrganizationAdd_ItemClick);
            // 
            // barBtnExit
            // 
            this.barBtnExit.Caption = "退出系统";
            this.barBtnExit.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barBtnExit.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnExit.Glyph")));
            this.barBtnExit.Id = 6;
            this.barBtnExit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnExit.LargeGlyph")));
            this.barBtnExit.Name = "barBtnExit";
            this.barBtnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnExit_ItemClick);
            // 
            // barBtnOrganizationOverview
            // 
            this.barBtnOrganizationOverview.Caption = "组织对象总览";
            this.barBtnOrganizationOverview.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barBtnOrganizationOverview.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnOrganizationOverview.Glyph")));
            this.barBtnOrganizationOverview.Id = 7;
            this.barBtnOrganizationOverview.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnOrganizationOverview.LargeGlyph")));
            this.barBtnOrganizationOverview.Name = "barBtnOrganizationOverview";
            this.barBtnOrganizationOverview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnOrganizationOverview_ItemClick);
            // 
            // rpObject
            // 
            this.rpObject.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rgoOrganization});
            this.rpObject.Name = "rpObject";
            this.rpObject.Text = "对象管理";
            // 
            // rgoOrganization
            // 
            this.rgoOrganization.ItemLinks.Add(this.barBtnOrganizationOverview);
            this.rgoOrganization.ItemLinks.Add(this.barBtnOrganizationObjectAdd);
            this.rgoOrganization.Name = "rgoOrganization";
            this.rgoOrganization.Text = "组织对象";
            // 
            // rpModel
            // 
            this.rpModel.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rgmOrganization,
            this.rgmEnergy,
            this.rgmBuilding,
            this.rgmEquipment,
            this.rgmStaff});
            this.rpModel.Name = "rpModel";
            this.rpModel.Text = "模型管理";
            // 
            // rgmOrganization
            // 
            this.rgmOrganization.ItemLinks.Add(this.barBtnOrganizationList);
            this.rgmOrganization.ItemLinks.Add(this.barBtnOrganizationAdd);
            this.rgmOrganization.Name = "rgmOrganization";
            this.rgmOrganization.Text = "组织模型";
            // 
            // rgmEnergy
            // 
            this.rgmEnergy.ItemLinks.Add(this.barBtnEnergyList);
            this.rgmEnergy.ItemLinks.Add(this.barBtnEnergyAdd);
            this.rgmEnergy.Name = "rgmEnergy";
            this.rgmEnergy.Text = "能源模型";
            // 
            // rgmBuilding
            // 
            this.rgmBuilding.Name = "rgmBuilding";
            this.rgmBuilding.Text = "建筑模型";
            // 
            // rgmEquipment
            // 
            this.rgmEquipment.Name = "rgmEquipment";
            this.rgmEquipment.Text = "设备模型";
            // 
            // rgmStaff
            // 
            this.rgmStaff.Name = "rgmStaff";
            this.rgmStaff.Text = "人员模型";
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
            // barBtnOrganizationObjectAdd
            // 
            this.barBtnOrganizationObjectAdd.Caption = "添加对象";
            this.barBtnOrganizationObjectAdd.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barBtnOrganizationObjectAdd.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnOrganizationObjectAdd.Glyph")));
            this.barBtnOrganizationObjectAdd.Id = 8;
            this.barBtnOrganizationObjectAdd.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnOrganizationObjectAdd.LargeGlyph")));
            this.barBtnOrganizationObjectAdd.Name = "barBtnOrganizationObjectAdd";
            this.barBtnOrganizationObjectAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnOrganizationObjectAdd_ItemClick);
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
        private DevExpress.XtraBars.Ribbon.RibbonPage rpObject;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem barBtnEnergyList;
        private DevExpress.XtraBars.BarButtonItem barBtnOrganizationList;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpModel;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rgmEnergy;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager tabMdiManager;
        private DevExpress.XtraBars.BarMdiChildrenListItem barChildList;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rgmOrganization;
        private DevExpress.XtraBars.BarButtonItem barBtnEnergyAdd;
        private DevExpress.XtraBars.BarButtonItem barBtnOrganizationAdd;
        private DevExpress.XtraBars.BarButtonItem barBtnExit;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpSystem;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rgoOrganization;
        private DevExpress.XtraBars.BarButtonItem barBtnOrganizationOverview;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rgmBuilding;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rgmEquipment;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rgmStaff;
        private DevExpress.XtraBars.BarButtonItem barBtnOrganizationObjectAdd;
    }
}

