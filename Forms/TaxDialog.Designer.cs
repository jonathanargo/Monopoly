namespace Monopoly
{
    partial class TaxDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaxDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnTenPercent = new System.Windows.Forms.Button();
            this.btnTwoHundred = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Would you like to pay $200, or would you \r\nlike to pay 10% tax on your money?";
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(23, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnTenPercent
            // 
            this.btnTenPercent.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnTenPercent.Location = new System.Drawing.Point(119, 68);
            this.btnTenPercent.Name = "btnTenPercent";
            this.btnTenPercent.Size = new System.Drawing.Size(75, 23);
            this.btnTenPercent.TabIndex = 2;
            this.btnTenPercent.Text = "10%";
            this.btnTenPercent.UseVisualStyleBackColor = true;
            // 
            // btnTwoHundred
            // 
            this.btnTwoHundred.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnTwoHundred.Location = new System.Drawing.Point(200, 68);
            this.btnTwoHundred.Name = "btnTwoHundred";
            this.btnTwoHundred.Size = new System.Drawing.Size(75, 23);
            this.btnTwoHundred.TabIndex = 3;
            this.btnTwoHundred.Text = "$200";
            this.btnTwoHundred.UseVisualStyleBackColor = true;
            // 
            // TaxDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 102);
            this.Controls.Add(this.btnTwoHundred);
            this.Controls.Add(this.btnTenPercent);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "TaxDialog";
            this.Text = "Income Tax";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnTenPercent;
        private System.Windows.Forms.Button btnTwoHundred;
    }
}