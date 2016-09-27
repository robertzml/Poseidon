namespace Poseidon.Winform.Client
{
    partial class FrmOrganizationObjectAdd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dvgObject = new Poseidon.Winform.Base.WinVerticalGrid();
            ((System.ComponentModel.ISupportInitialize)(this.plFill)).BeginInit();
            this.plFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plBottom)).BeginInit();
            this.plBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(255, 25);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(138, 25);
            // 
            // plFill
            // 
            this.plFill.Appearance.BackColor = System.Drawing.Color.White;
            this.plFill.Appearance.Options.UseBackColor = true;
            this.plFill.Controls.Add(this.groupControl1);
            this.plFill.Size = new System.Drawing.Size(366, 301);
            // 
            // plBottom
            // 
            this.plBottom.Appearance.BackColor = System.Drawing.Color.White;
            this.plBottom.Appearance.Options.UseBackColor = true;
            this.plBottom.Location = new System.Drawing.Point(0, 301);
            this.plBottom.Size = new System.Drawing.Size(366, 80);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dvgObject);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(366, 301);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "对象属性";
            // 
            // dvgObject
            // 
            this.dvgObject.DataSource = null;
            this.dvgObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvgObject.Location = new System.Drawing.Point(2, 21);
            this.dvgObject.Name = "dvgObject";
            this.dvgObject.Size = new System.Drawing.Size(362, 278);
            this.dvgObject.TabIndex = 2;
            // 
            // FrmOrganizationObjectAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 381);
            this.Name = "FrmOrganizationObjectAdd";
            this.Text = "组织对象添加";
            this.Load += new System.EventHandler(this.FrmOrganizationObjectAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.plFill)).EndInit();
            this.plFill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.plBottom)).EndInit();
            this.plBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private Base.WinVerticalGrid dvgObject;
    }
}