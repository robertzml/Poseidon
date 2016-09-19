﻿namespace Poseidon.Winform.Client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbonControl = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barBtnEnergyList = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnDepartment = new DevExpress.XtraBars.BarButtonItem();
            this.barChildList = new DevExpress.XtraBars.BarMdiChildrenListItem();
            this.barBtnEnergyAdd = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageObject = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonGroupEnergy = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonGroupDepartment = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.tabMdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager();
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
            this.barBtnDepartment,
            this.barChildList,
            this.barBtnEnergyAdd});
            this.ribbonControl.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl.MaxItemId = 5;
            this.ribbonControl.Name = "ribbonControl";
            this.ribbonControl.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPageObject});
            this.ribbonControl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl.Size = new System.Drawing.Size(924, 147);
            this.ribbonControl.StatusBar = this.ribbonStatusBar;
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
            // barBtnDepartment
            // 
            this.barBtnDepartment.Caption = "部门模型";
            this.barBtnDepartment.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barBtnDepartment.Glyph = ((System.Drawing.Image)(resources.GetObject("barBtnDepartment.Glyph")));
            this.barBtnDepartment.Id = 2;
            this.barBtnDepartment.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barBtnDepartment.LargeGlyph")));
            this.barBtnDepartment.Name = "barBtnDepartment";
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
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barChildList);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonPageObject
            // 
            this.ribbonPageObject.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonGroupEnergy,
            this.ribbonGroupDepartment});
            this.ribbonPageObject.Name = "ribbonPageObject";
            this.ribbonPageObject.Text = "模型管理";
            // 
            // ribbonGroupEnergy
            // 
            this.ribbonGroupEnergy.ItemLinks.Add(this.barBtnEnergyList);
            this.ribbonGroupEnergy.ItemLinks.Add(this.barBtnEnergyAdd);
            this.ribbonGroupEnergy.Name = "ribbonGroupEnergy";
            this.ribbonGroupEnergy.Text = "能源模型";
            // 
            // ribbonGroupDepartment
            // 
            this.ribbonGroupDepartment.ItemLinks.Add(this.barBtnDepartment);
            this.ribbonGroupDepartment.Name = "ribbonGroupDepartment";
            this.ribbonGroupDepartment.Text = "部门模型";
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
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMdiManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem barBtnEnergyList;
        private DevExpress.XtraBars.BarButtonItem barBtnDepartment;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageObject;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonGroupEnergy;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager tabMdiManager;
        private DevExpress.XtraBars.BarMdiChildrenListItem barChildList;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonGroupDepartment;
        private DevExpress.XtraBars.BarButtonItem barBtnEnergyAdd;
    }
}
