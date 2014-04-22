namespace Monopoly
{
    partial class ImproveMenu
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
            this.lbxPropList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImprove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxPropList
            // 
            this.lbxPropList.FormattingEnabled = true;
            this.lbxPropList.Location = new System.Drawing.Point(138, 12);
            this.lbxPropList.Name = "lbxPropList";
            this.lbxPropList.Size = new System.Drawing.Size(214, 95);
            this.lbxPropList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Your Owned Properties:";
            // 
            // btnImprove
            // 
            this.btnImprove.Location = new System.Drawing.Point(57, 38);
            this.btnImprove.Name = "btnImprove";
            this.btnImprove.Size = new System.Drawing.Size(75, 23);
            this.btnImprove.TabIndex = 2;
            this.btnImprove.Text = "Improve!";
            this.btnImprove.UseVisualStyleBackColor = true;
            this.btnImprove.Click += new System.EventHandler(this.btnImprove_Click);
            // 
            // ImproveMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 116);
            this.Controls.Add(this.btnImprove);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxPropList);
            this.Name = "ImproveMenu";
            this.Text = "ImproveMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxPropList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImprove;
    }
}