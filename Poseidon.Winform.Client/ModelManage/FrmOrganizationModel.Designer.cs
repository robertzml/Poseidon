namespace Poseidon.Winform.Client
{
    partial class FrmOrganizationModel
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
            this.dgModel = new Poseidon.Winform.Client.ModelListGrid();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dgModel);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(731, 427);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "模型列表";
            // 
            // dgModel
            // 
            this.dgModel.DataSource = null;
            this.dgModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgModel.Location = new System.Drawing.Point(2, 21);
            this.dgModel.Name = "dgModel";
            this.dgModel.Size = new System.Drawing.Size(727, 404);
            this.dgModel.TabIndex = 0;
            // 
            // FrmOrganizationModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 427);
            this.Controls.Add(this.groupControl1);
            this.Name = "FrmOrganizationModel";
            this.Text = "组织模型总览";
            this.Load += new System.EventHandler(this.FrmOrganizationModel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private ModelListGrid dgModel;
    }
}