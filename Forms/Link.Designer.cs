namespace Nhap_Hoc_TSV.Forms
{
    partial class Link
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
            this.LinkHolder = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.BtnConfirm = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.LinkHolder.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // LinkHolder
            // 
            this.LinkHolder.EditValue = "";
            this.LinkHolder.Location = new System.Drawing.Point(79, 87);
            this.LinkHolder.Name = "LinkHolder";
            this.LinkHolder.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI Variable Text", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LinkHolder.Properties.Appearance.Options.UseFont = true;
            this.LinkHolder.Properties.Appearance.Options.UseTextOptions = true;
            this.LinkHolder.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.LinkHolder.Properties.AutoHeight = false;
            this.LinkHolder.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.LinkHolder.Size = new System.Drawing.Size(817, 37);
            this.LinkHolder.TabIndex = 8;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.Location = new System.Drawing.Point(12, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(974, 45);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "1. Học bạ THPT (*)";
            // 
            // BtnConfirm
            // 
            this.BtnConfirm.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.BtnConfirm.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.BtnConfirm.Appearance.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConfirm.Appearance.Options.UseBackColor = true;
            this.BtnConfirm.Appearance.Options.UseBorderColor = true;
            this.BtnConfirm.Appearance.Options.UseFont = true;
            this.BtnConfirm.Location = new System.Drawing.Point(429, 144);
            this.BtnConfirm.Name = "BtnConfirm";
            this.BtnConfirm.Size = new System.Drawing.Size(144, 37);
            this.BtnConfirm.TabIndex = 10;
            this.BtnConfirm.Text = "Xác Nhận";
            this.BtnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // Link
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 210);
            this.Controls.Add(this.BtnConfirm);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.LinkHolder);
            this.Name = "Link";
            this.Text = "Link";
            ((System.ComponentModel.ISupportInitialize)(this.LinkHolder.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit LinkHolder;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton BtnConfirm;
    }
}