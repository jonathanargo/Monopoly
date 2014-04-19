namespace Monopoly
{
    partial class Monopoly
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
            this.lblPlayer1 = new System.Windows.Forms.Label();
            this.lblPlayer2 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.P1Money = new System.Windows.Forms.Label();
            this.P2Money = new System.Windows.Forms.Label();
            this.P1MoneyOut = new System.Windows.Forms.Label();
            this.P1PosOut = new System.Windows.Forms.Label();
            this.P1Pos = new System.Windows.Forms.Label();
            this.P2Pos = new System.Windows.Forms.Label();
            this.P1gooj = new System.Windows.Forms.Label();
            this.P1GoojOut = new System.Windows.Forms.Label();
            this.P2GoojOut = new System.Windows.Forms.Label();
            this.P2PosOut = new System.Windows.Forms.Label();
            this.P2MoneyOut = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lablel1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.P1OwnedPropsOut = new System.Windows.Forms.ListBox();
            this.P2OwnedPropsOut = new System.Windows.Forms.ListBox();
            this.lbxOutput = new System.Windows.Forms.ListBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.btnDebug = new System.Windows.Forms.Button();
            this.btnRoll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPlayer1
            // 
            this.lblPlayer1.AutoSize = true;
            this.lblPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPlayer1.Location = new System.Drawing.Point(183, 29);
            this.lblPlayer1.Name = "lblPlayer1";
            this.lblPlayer1.Size = new System.Drawing.Size(91, 25);
            this.lblPlayer1.TabIndex = 4;
            this.lblPlayer1.Text = "Player 1";
            // 
            // lblPlayer2
            // 
            this.lblPlayer2.AutoSize = true;
            this.lblPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer2.Location = new System.Drawing.Point(483, 29);
            this.lblPlayer2.Name = "lblPlayer2";
            this.lblPlayer2.Size = new System.Drawing.Size(91, 25);
            this.lblPlayer2.TabIndex = 5;
            this.lblPlayer2.Text = "Player 2";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(12, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Start Game";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(12, 41);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 8;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // P1Money
            // 
            this.P1Money.AutoSize = true;
            this.P1Money.Location = new System.Drawing.Point(185, 78);
            this.P1Money.Name = "P1Money";
            this.P1Money.Size = new System.Drawing.Size(42, 13);
            this.P1Money.TabIndex = 9;
            this.P1Money.Text = "Money:";
            // 
            // P2Money
            // 
            this.P2Money.AutoSize = true;
            this.P2Money.Location = new System.Drawing.Point(485, 78);
            this.P2Money.Name = "P2Money";
            this.P2Money.Size = new System.Drawing.Size(42, 13);
            this.P2Money.TabIndex = 10;
            this.P2Money.Text = "Money:";
            // 
            // P1MoneyOut
            // 
            this.P1MoneyOut.AutoSize = true;
            this.P1MoneyOut.Location = new System.Drawing.Point(261, 78);
            this.P1MoneyOut.Name = "P1MoneyOut";
            this.P1MoneyOut.Size = new System.Drawing.Size(22, 13);
            this.P1MoneyOut.TabIndex = 11;
            this.P1MoneyOut.Text = "out";
            // 
            // P1PosOut
            // 
            this.P1PosOut.AutoSize = true;
            this.P1PosOut.Location = new System.Drawing.Point(261, 102);
            this.P1PosOut.Name = "P1PosOut";
            this.P1PosOut.Size = new System.Drawing.Size(22, 13);
            this.P1PosOut.TabIndex = 14;
            this.P1PosOut.Text = "out";
            // 
            // P1Pos
            // 
            this.P1Pos.AutoSize = true;
            this.P1Pos.Location = new System.Drawing.Point(185, 102);
            this.P1Pos.Name = "P1Pos";
            this.P1Pos.Size = new System.Drawing.Size(47, 13);
            this.P1Pos.TabIndex = 13;
            this.P1Pos.Text = "Position:";
            // 
            // P2Pos
            // 
            this.P2Pos.AutoSize = true;
            this.P2Pos.Location = new System.Drawing.Point(485, 102);
            this.P2Pos.Name = "P2Pos";
            this.P2Pos.Size = new System.Drawing.Size(47, 13);
            this.P2Pos.TabIndex = 15;
            this.P2Pos.Text = "Position:";
            // 
            // P1gooj
            // 
            this.P1gooj.AutoSize = true;
            this.P1gooj.Location = new System.Drawing.Point(185, 125);
            this.P1gooj.Name = "P1gooj";
            this.P1gooj.Size = new System.Drawing.Size(69, 13);
            this.P1gooj.TabIndex = 17;
            this.P1gooj.Text = "GOOJ Cards:";
            // 
            // P1GoojOut
            // 
            this.P1GoojOut.AutoSize = true;
            this.P1GoojOut.Location = new System.Drawing.Point(261, 125);
            this.P1GoojOut.Name = "P1GoojOut";
            this.P1GoojOut.Size = new System.Drawing.Size(22, 13);
            this.P1GoojOut.TabIndex = 18;
            this.P1GoojOut.Text = "out";
            // 
            // P2GoojOut
            // 
            this.P2GoojOut.AutoSize = true;
            this.P2GoojOut.Location = new System.Drawing.Point(567, 125);
            this.P2GoojOut.Name = "P2GoojOut";
            this.P2GoojOut.Size = new System.Drawing.Size(22, 13);
            this.P2GoojOut.TabIndex = 21;
            this.P2GoojOut.Text = "out";
            // 
            // P2PosOut
            // 
            this.P2PosOut.AutoSize = true;
            this.P2PosOut.Location = new System.Drawing.Point(567, 102);
            this.P2PosOut.Name = "P2PosOut";
            this.P2PosOut.Size = new System.Drawing.Size(22, 13);
            this.P2PosOut.TabIndex = 20;
            this.P2PosOut.Text = "out";
            // 
            // P2MoneyOut
            // 
            this.P2MoneyOut.AutoSize = true;
            this.P2MoneyOut.Location = new System.Drawing.Point(567, 78);
            this.P2MoneyOut.Name = "P2MoneyOut";
            this.P2MoneyOut.Size = new System.Drawing.Size(22, 13);
            this.P2MoneyOut.TabIndex = 19;
            this.P2MoneyOut.Text = "out";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(485, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "GOOJ Cards:";
            // 
            // lablel1
            // 
            this.lablel1.AutoSize = true;
            this.lablel1.Location = new System.Drawing.Point(185, 155);
            this.lablel1.Name = "lablel1";
            this.lablel1.Size = new System.Drawing.Size(91, 13);
            this.lablel1.TabIndex = 23;
            this.lablel1.Text = "Owned Properties";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(485, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Owned Properties";
            // 
            // P1OwnedPropsOut
            // 
            this.P1OwnedPropsOut.FormattingEnabled = true;
            this.P1OwnedPropsOut.Location = new System.Drawing.Point(188, 185);
            this.P1OwnedPropsOut.Name = "P1OwnedPropsOut";
            this.P1OwnedPropsOut.Size = new System.Drawing.Size(140, 95);
            this.P1OwnedPropsOut.TabIndex = 25;
            // 
            // P2OwnedPropsOut
            // 
            this.P2OwnedPropsOut.FormattingEnabled = true;
            this.P2OwnedPropsOut.Location = new System.Drawing.Point(488, 185);
            this.P2OwnedPropsOut.Name = "P2OwnedPropsOut";
            this.P2OwnedPropsOut.Size = new System.Drawing.Size(140, 95);
            this.P2OwnedPropsOut.TabIndex = 26;
            // 
            // lbxOutput
            // 
            this.lbxOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxOutput.FormattingEnabled = true;
            this.lbxOutput.ItemHeight = 16;
            this.lbxOutput.Location = new System.Drawing.Point(188, 351);
            this.lbxOutput.Name = "lbxOutput";
            this.lbxOutput.Size = new System.Drawing.Size(440, 148);
            this.lbxOutput.TabIndex = 27;
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(140, 351);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(39, 13);
            this.lblOutput.TabIndex = 28;
            this.lblOutput.Text = "Output";
            // 
            // btnDebug
            // 
            this.btnDebug.Location = new System.Drawing.Point(12, 73);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(75, 23);
            this.btnDebug.TabIndex = 29;
            this.btnDebug.Text = "Debug";
            this.btnDebug.UseVisualStyleBackColor = true;
            // 
            // btnRoll
            // 
            this.btnRoll.Enabled = false;
            this.btnRoll.Location = new System.Drawing.Point(188, 316);
            this.btnRoll.Name = "btnRoll";
            this.btnRoll.Size = new System.Drawing.Size(75, 23);
            this.btnRoll.TabIndex = 30;
            this.btnRoll.Text = "Roll!";
            this.btnRoll.UseVisualStyleBackColor = true;
            this.btnRoll.Click += new System.EventHandler(this.btnRoll_Click);
            // 
            // Monopoly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 523);
            this.Controls.Add(this.btnRoll);
            this.Controls.Add(this.btnDebug);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.lbxOutput);
            this.Controls.Add(this.P2OwnedPropsOut);
            this.Controls.Add(this.P1OwnedPropsOut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lablel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.P2GoojOut);
            this.Controls.Add(this.P2PosOut);
            this.Controls.Add(this.P2MoneyOut);
            this.Controls.Add(this.P1GoojOut);
            this.Controls.Add(this.P1gooj);
            this.Controls.Add(this.P2Pos);
            this.Controls.Add(this.P1PosOut);
            this.Controls.Add(this.P1Pos);
            this.Controls.Add(this.P1MoneyOut);
            this.Controls.Add(this.P2Money);
            this.Controls.Add(this.P1Money);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblPlayer2);
            this.Controls.Add(this.lblPlayer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Monopoly";
            this.Text = "Monopoly";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Monopoly_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label P1Money;
        private System.Windows.Forms.Label P2Money;
        private System.Windows.Forms.Label P1MoneyOut;
        private System.Windows.Forms.Label P1PosOut;
        private System.Windows.Forms.Label P1Pos;
        private System.Windows.Forms.Label P2Pos;
        private System.Windows.Forms.Label P1gooj;
        private System.Windows.Forms.Label P1GoojOut;
        private System.Windows.Forms.Label P2GoojOut;
        private System.Windows.Forms.Label P2PosOut;
        private System.Windows.Forms.Label P2MoneyOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lablel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox P1OwnedPropsOut;
        private System.Windows.Forms.ListBox P2OwnedPropsOut;
        private System.Windows.Forms.ListBox lbxOutput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Button btnDebug;
        private System.Windows.Forms.Button btnRoll;


    }
}

