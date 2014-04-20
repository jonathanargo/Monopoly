namespace Monopoly
{
    partial class DebuggingForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lbxBoardSpaces = new System.Windows.Forms.ListBox();
            this.rbtPlayer1 = new System.Windows.Forms.RadioButton();
            this.rbtPlayer2 = new System.Windows.Forms.RadioButton();
            this.btnSendToPos = new System.Windows.Forms.Button();
            this.btnPrintStats = new System.Windows.Forms.Button();
            this.btnGoToJail = new System.Windows.Forms.Button();
            this.btnGoToProp = new System.Windows.Forms.Button();
            this.btnGoToRailroad = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGoToChance = new System.Windows.Forms.Button();
            this.btnGoToUtil = new System.Windows.Forms.Button();
            this.btnGoToGo = new System.Windows.Forms.Button();
            this.btnCopyLog = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnTruncateLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Send To Position";
            // 
            // lbxBoardSpaces
            // 
            this.lbxBoardSpaces.FormattingEnabled = true;
            this.lbxBoardSpaces.Location = new System.Drawing.Point(107, 13);
            this.lbxBoardSpaces.Name = "lbxBoardSpaces";
            this.lbxBoardSpaces.Size = new System.Drawing.Size(185, 56);
            this.lbxBoardSpaces.TabIndex = 1;
            // 
            // rbtPlayer1
            // 
            this.rbtPlayer1.AutoSize = true;
            this.rbtPlayer1.Checked = true;
            this.rbtPlayer1.Location = new System.Drawing.Point(12, 243);
            this.rbtPlayer1.Name = "rbtPlayer1";
            this.rbtPlayer1.Size = new System.Drawing.Size(63, 17);
            this.rbtPlayer1.TabIndex = 2;
            this.rbtPlayer1.TabStop = true;
            this.rbtPlayer1.Text = "Player 1";
            this.rbtPlayer1.UseVisualStyleBackColor = true;
            // 
            // rbtPlayer2
            // 
            this.rbtPlayer2.AutoSize = true;
            this.rbtPlayer2.Location = new System.Drawing.Point(12, 265);
            this.rbtPlayer2.Name = "rbtPlayer2";
            this.rbtPlayer2.Size = new System.Drawing.Size(63, 17);
            this.rbtPlayer2.TabIndex = 3;
            this.rbtPlayer2.Text = "Player 2";
            this.rbtPlayer2.UseVisualStyleBackColor = true;
            // 
            // btnSendToPos
            // 
            this.btnSendToPos.Location = new System.Drawing.Point(298, 13);
            this.btnSendToPos.Name = "btnSendToPos";
            this.btnSendToPos.Size = new System.Drawing.Size(36, 23);
            this.btnSendToPos.TabIndex = 4;
            this.btnSendToPos.Text = "Go";
            this.btnSendToPos.UseVisualStyleBackColor = true;
            this.btnSendToPos.Click += new System.EventHandler(this.btnSendToPos_Click_1);
            // 
            // btnPrintStats
            // 
            this.btnPrintStats.Location = new System.Drawing.Point(237, 259);
            this.btnPrintStats.Name = "btnPrintStats";
            this.btnPrintStats.Size = new System.Drawing.Size(96, 23);
            this.btnPrintStats.TabIndex = 5;
            this.btnPrintStats.Text = "Print Player Stats";
            this.btnPrintStats.UseVisualStyleBackColor = true;
            // 
            // btnGoToJail
            // 
            this.btnGoToJail.Location = new System.Drawing.Point(107, 76);
            this.btnGoToJail.Name = "btnGoToJail";
            this.btnGoToJail.Size = new System.Drawing.Size(68, 23);
            this.btnGoToJail.TabIndex = 6;
            this.btnGoToJail.Text = "Go To Jail";
            this.btnGoToJail.UseVisualStyleBackColor = true;
            this.btnGoToJail.Click += new System.EventHandler(this.btnGoToJail_Click);
            // 
            // btnGoToProp
            // 
            this.btnGoToProp.Location = new System.Drawing.Point(181, 76);
            this.btnGoToProp.Name = "btnGoToProp";
            this.btnGoToProp.Size = new System.Drawing.Size(68, 23);
            this.btnGoToProp.TabIndex = 7;
            this.btnGoToProp.Text = "Property";
            this.btnGoToProp.UseVisualStyleBackColor = true;
            this.btnGoToProp.Click += new System.EventHandler(this.btnGoToProp_Click);
            // 
            // btnGoToRailroad
            // 
            this.btnGoToRailroad.Location = new System.Drawing.Point(255, 76);
            this.btnGoToRailroad.Name = "btnGoToRailroad";
            this.btnGoToRailroad.Size = new System.Drawing.Size(68, 23);
            this.btnGoToRailroad.TabIndex = 8;
            this.btnGoToRailroad.Text = "Railroad";
            this.btnGoToRailroad.UseVisualStyleBackColor = true;
            this.btnGoToRailroad.Click += new System.EventHandler(this.btnGoToRailroad_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Shortcuts:";
            // 
            // btnGoToChance
            // 
            this.btnGoToChance.Location = new System.Drawing.Point(181, 105);
            this.btnGoToChance.Name = "btnGoToChance";
            this.btnGoToChance.Size = new System.Drawing.Size(68, 23);
            this.btnGoToChance.TabIndex = 13;
            this.btnGoToChance.Text = "Chance";
            this.btnGoToChance.UseVisualStyleBackColor = true;
            this.btnGoToChance.Click += new System.EventHandler(this.btnGoToChance_Click_1);
            // 
            // btnGoToUtil
            // 
            this.btnGoToUtil.Location = new System.Drawing.Point(107, 105);
            this.btnGoToUtil.Name = "btnGoToUtil";
            this.btnGoToUtil.Size = new System.Drawing.Size(68, 23);
            this.btnGoToUtil.TabIndex = 14;
            this.btnGoToUtil.Text = "Utility";
            this.btnGoToUtil.UseVisualStyleBackColor = true;
            this.btnGoToUtil.Click += new System.EventHandler(this.btnGoToUtil_Click);
            // 
            // btnGoToGo
            // 
            this.btnGoToGo.Location = new System.Drawing.Point(255, 105);
            this.btnGoToGo.Name = "btnGoToGo";
            this.btnGoToGo.Size = new System.Drawing.Size(68, 23);
            this.btnGoToGo.TabIndex = 15;
            this.btnGoToGo.Text = "Go";
            this.btnGoToGo.UseVisualStyleBackColor = true;
            this.btnGoToGo.Click += new System.EventHandler(this.btnGoToGo_Click);
            // 
            // btnCopyLog
            // 
            this.btnCopyLog.Location = new System.Drawing.Point(237, 230);
            this.btnCopyLog.Name = "btnCopyLog";
            this.btnCopyLog.Size = new System.Drawing.Size(96, 23);
            this.btnCopyLog.TabIndex = 16;
            this.btnCopyLog.Text = "Copy Log";
            this.btnCopyLog.UseVisualStyleBackColor = true;
            this.btnCopyLog.Click += new System.EventHandler(this.btnCopyLog_Click);
            // 
            // btnTruncateLog
            // 
            this.btnTruncateLog.Location = new System.Drawing.Point(238, 201);
            this.btnTruncateLog.Name = "btnTruncateLog";
            this.btnTruncateLog.Size = new System.Drawing.Size(96, 23);
            this.btnTruncateLog.TabIndex = 17;
            this.btnTruncateLog.Text = "Truncate Log";
            this.btnTruncateLog.UseVisualStyleBackColor = true;
            this.btnTruncateLog.Click += new System.EventHandler(this.btnTruncateLog_Click);
            // 
            // DebuggingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 293);
            this.Controls.Add(this.btnTruncateLog);
            this.Controls.Add(this.btnCopyLog);
            this.Controls.Add(this.btnGoToGo);
            this.Controls.Add(this.btnGoToUtil);
            this.Controls.Add(this.btnGoToChance);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGoToRailroad);
            this.Controls.Add(this.btnGoToProp);
            this.Controls.Add(this.btnGoToJail);
            this.Controls.Add(this.btnPrintStats);
            this.Controls.Add(this.btnSendToPos);
            this.Controls.Add(this.rbtPlayer2);
            this.Controls.Add(this.rbtPlayer1);
            this.Controls.Add(this.lbxBoardSpaces);
            this.Controls.Add(this.label1);
            this.Name = "DebuggingForm";
            this.Text = "DebuggingForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbxBoardSpaces;
        private System.Windows.Forms.RadioButton rbtPlayer1;
        private System.Windows.Forms.RadioButton rbtPlayer2;
        private System.Windows.Forms.Button btnSendToPos;
        private System.Windows.Forms.Button btnPrintStats;
        private System.Windows.Forms.Button btnGoToJail;
        private System.Windows.Forms.Button btnGoToProp;
        private System.Windows.Forms.Button btnGoToRailroad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGoToChance;
        private System.Windows.Forms.Button btnGoToUtil;
        private System.Windows.Forms.Button btnGoToGo;
        private System.Windows.Forms.Button btnCopyLog;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnTruncateLog;
    }
}