namespace Monopoly
{
    partial class PropertyQuery
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
            this.cmbProperties = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmbProperties
            // 
            this.cmbProperties.FormattingEnabled = true;
            this.cmbProperties.Location = new System.Drawing.Point(13, 13);
            this.cmbProperties.Name = "cmbProperties";
            this.cmbProperties.Size = new System.Drawing.Size(249, 21);
            this.cmbProperties.TabIndex = 0;
            this.cmbProperties.SelectedIndexChanged += new System.EventHandler(this.cmbProperties_SelectedIndexChanged);
            // 
            // PropertyQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 70);
            this.Controls.Add(this.cmbProperties);
            this.Name = "PropertyQuery";
            this.Text = "PropertyQuery";
            this.Load += new System.EventHandler(this.PropertyQuery_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbProperties;
    }
}