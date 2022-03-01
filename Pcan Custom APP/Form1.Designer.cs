namespace Pcan_Custom_APP
{
    partial class Form1
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtData7 = new System.Windows.Forms.TextBox();
            this.txtData6 = new System.Windows.Forms.TextBox();
            this.txtData5 = new System.Windows.Forms.TextBox();
            this.txtData4 = new System.Windows.Forms.TextBox();
            this.txtData3 = new System.Windows.Forms.TextBox();
            this.txtData2 = new System.Windows.Forms.TextBox();
            this.txtData1 = new System.Windows.Forms.TextBox();
            this.txtData0 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.lstMessages = new System.Windows.Forms.ListView();
            this.clhID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhLength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "None",
            "DNG-Channel 1",
            "ISA-Channel 1",
            "ISA-Channel 2",
            "ISA-Channel 3",
            "ISA-Channel 4",
            "ISA-Channel 5",
            "ISA-Channel 6",
            "ISA-Channel 7",
            "ISA-Channel 8",
            "PCC-Channel 1",
            "PCC-Channel 2",
            "PCI-Channel 1",
            "PCI-Channel 2",
            "PCI-Channel 3",
            "PCI-Channel 4",
            "PCI-Channel 5",
            "PCI-Channel 6",
            "PCI-Channel 7",
            "PCI-Channel 8",
            "USB-Channel 1",
            "USB-Channel 2",
            "USB-Channel 3",
            "USB-Channel 4",
            "USB-Channel 5",
            "USB-Channel 6",
            "USB-Channel 7",
            "USB-Channel 8"});
            this.comboBox1.Location = new System.Drawing.Point(22, 49);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(329, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(248, 47);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Scan";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Detected device";
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.textBox1);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.button3);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.txtID);
            this.groupBox6.Controls.Add(this.txtData7);
            this.groupBox6.Controls.Add(this.txtData6);
            this.groupBox6.Controls.Add(this.txtData5);
            this.groupBox6.Controls.Add(this.txtData4);
            this.groupBox6.Controls.Add(this.txtData3);
            this.groupBox6.Controls.Add(this.txtData2);
            this.groupBox6.Controls.Add(this.txtData1);
            this.groupBox6.Controls.Add(this.txtData0);
            this.groupBox6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox6.Location = new System.Drawing.Point(12, 118);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(441, 149);
            this.groupBox6.TabIndex = 52;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Write Messages";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 115;
            this.label4.Text = "Status : ";
            // 
            // textBox1
            // 
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Location = new System.Drawing.Point(83, 41);
            this.textBox1.MaxLength = 2;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(49, 20);
            this.textBox1.TabIndex = 114;
            this.textBox1.Text = "0";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(80, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 113;
            this.label5.Text = "Length:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 111;
            this.label3.Text = "Data (Hex):";
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.Cursor = System.Windows.Forms.Cursors.Default;
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Location = new System.Drawing.Point(305, 89);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(78, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Send";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "ID (Hex):";
            // 
            // txtID
            // 
            this.txtID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtID.Location = new System.Drawing.Point(22, 41);
            this.txtID.MaxLength = 3;
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(49, 20);
            this.txtID.TabIndex = 0;
            this.txtID.Text = "0";
            // 
            // txtData7
            // 
            this.txtData7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtData7.Location = new System.Drawing.Point(359, 41);
            this.txtData7.MaxLength = 2;
            this.txtData7.Name = "txtData7";
            this.txtData7.Size = new System.Drawing.Size(24, 20);
            this.txtData7.TabIndex = 13;
            this.txtData7.Text = "00";
            this.txtData7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtData6
            // 
            this.txtData6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtData6.Location = new System.Drawing.Point(329, 41);
            this.txtData6.MaxLength = 2;
            this.txtData6.Name = "txtData6";
            this.txtData6.Size = new System.Drawing.Size(24, 20);
            this.txtData6.TabIndex = 12;
            this.txtData6.Text = "00";
            this.txtData6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtData5
            // 
            this.txtData5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtData5.Location = new System.Drawing.Point(299, 41);
            this.txtData5.MaxLength = 2;
            this.txtData5.Name = "txtData5";
            this.txtData5.Size = new System.Drawing.Size(24, 20);
            this.txtData5.TabIndex = 11;
            this.txtData5.Text = "00";
            this.txtData5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtData4
            // 
            this.txtData4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtData4.Location = new System.Drawing.Point(269, 41);
            this.txtData4.MaxLength = 2;
            this.txtData4.Name = "txtData4";
            this.txtData4.Size = new System.Drawing.Size(24, 20);
            this.txtData4.TabIndex = 10;
            this.txtData4.Text = "00";
            this.txtData4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtData3
            // 
            this.txtData3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtData3.Location = new System.Drawing.Point(239, 41);
            this.txtData3.MaxLength = 2;
            this.txtData3.Name = "txtData3";
            this.txtData3.Size = new System.Drawing.Size(24, 20);
            this.txtData3.TabIndex = 9;
            this.txtData3.Text = "00";
            this.txtData3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtData2
            // 
            this.txtData2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtData2.Location = new System.Drawing.Point(210, 41);
            this.txtData2.MaxLength = 2;
            this.txtData2.Name = "txtData2";
            this.txtData2.Size = new System.Drawing.Size(24, 20);
            this.txtData2.TabIndex = 8;
            this.txtData2.Text = "00";
            this.txtData2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtData1
            // 
            this.txtData1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtData1.Location = new System.Drawing.Point(180, 41);
            this.txtData1.MaxLength = 2;
            this.txtData1.Name = "txtData1";
            this.txtData1.Size = new System.Drawing.Size(24, 20);
            this.txtData1.TabIndex = 7;
            this.txtData1.Text = "00";
            this.txtData1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtData0
            // 
            this.txtData0.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtData0.Location = new System.Drawing.Point(149, 41);
            this.txtData0.MaxLength = 2;
            this.txtData0.Name = "txtData0";
            this.txtData0.Size = new System.Drawing.Size(24, 20);
            this.txtData0.TabIndex = 6;
            this.txtData0.Text = "00";
            this.txtData0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(441, 100);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(329, 60);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(91, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Disconnected";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Data Rate";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "1 MBit/sec",
            "800 kBit/s",
            "500 kBit/sec",
            "250 kBit/sec",
            "125 kBit/sec",
            "100 kBit/sec",
            "95,238 kBit/s",
            "83,333 kBit/s",
            "50 kBit/sec",
            "47,619 kBit/s",
            "33,333 kBit/s",
            "20 kBit/sec",
            "10 kBit/sec",
            "5 kBit/sec"});
            this.comboBox2.Location = new System.Drawing.Point(149, 49);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(93, 21);
            this.comboBox2.TabIndex = 5;
            // 
            // lstMessages
            // 
            this.lstMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhID,
            this.clhType,
            this.clhLength,
            this.clhData});
            this.lstMessages.FullRowSelect = true;
            this.lstMessages.HideSelection = false;
            this.lstMessages.Location = new System.Drawing.Point(16, 19);
            this.lstMessages.MultiSelect = false;
            this.lstMessages.Name = "lstMessages";
            this.lstMessages.Size = new System.Drawing.Size(313, 199);
            this.lstMessages.TabIndex = 54;
            this.lstMessages.UseCompatibleStateImageBehavior = false;
            this.lstMessages.View = System.Windows.Forms.View.Details;
            // 
            // clhID
            // 
            this.clhID.Text = "ID";
            this.clhID.Width = 35;
            // 
            // clhType
            // 
            this.clhType.Text = "Type";
            this.clhType.Width = 57;
            // 
            // clhLength
            // 
            this.clhLength.Text = "Length";
            this.clhLength.Width = 110;
            // 
            // clhData
            // 
            this.clhData.Text = "Data";
            this.clhData.Width = 100;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.lstMessages);
            this.groupBox2.Location = new System.Drawing.Point(459, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(339, 255);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Receive ";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(16, 224);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 55;
            this.button5.Text = "Read";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(254, 224);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 56;
            this.button6.Text = "Riset";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(71, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 116;
            this.label6.Text = "         ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 287);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Form1";
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtData7;
        private System.Windows.Forms.TextBox txtData6;
        private System.Windows.Forms.TextBox txtData5;
        private System.Windows.Forms.TextBox txtData4;
        private System.Windows.Forms.TextBox txtData3;
        private System.Windows.Forms.TextBox txtData2;
        private System.Windows.Forms.TextBox txtData1;
        private System.Windows.Forms.TextBox txtData0;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ListView lstMessages;
        private System.Windows.Forms.ColumnHeader clhID;
        private System.Windows.Forms.ColumnHeader clhType;
        private System.Windows.Forms.ColumnHeader clhLength;
        private System.Windows.Forms.ColumnHeader clhData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label6;
    }
}

