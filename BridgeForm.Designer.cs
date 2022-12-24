namespace LiveSplitBridge
{
    partial class BridgeForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
      this.connectBtn = new System.Windows.Forms.Button();
      this.disconnectBtn = new System.Windows.Forms.Button();
      this.logList = new System.Windows.Forms.ListView();
      this.listColTim = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.listColMsg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.logLabel = new System.Windows.Forms.Label();
      this.resetModeLbl = new System.Windows.Forms.Label();
      this.resetModeCmb = new System.Windows.Forms.ComboBox();
      this.resetHotkeyLbl = new System.Windows.Forms.Label();
      this.resetHotkeyTxt = new System.Windows.Forms.TextBox();
      this.resetDefaultBtn = new System.Windows.Forms.Button();
      this.testSplitBtn = new System.Windows.Forms.Button();
      this.testResetBtn = new System.Windows.Forms.Button();
      this.clearLogBtn = new System.Windows.Forms.Button();
      this.copyLogBtn = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // connectBtn
      // 
      this.connectBtn.Location = new System.Drawing.Point(13, 13);
      this.connectBtn.Name = "connectBtn";
      this.connectBtn.Size = new System.Drawing.Size(154, 23);
      this.connectBtn.TabIndex = 0;
      this.connectBtn.Text = "Connect to LiveSplit";
      this.connectBtn.UseVisualStyleBackColor = true;
      this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
      // 
      // disconnectBtn
      // 
      this.disconnectBtn.Enabled = false;
      this.disconnectBtn.Location = new System.Drawing.Point(174, 13);
      this.disconnectBtn.Margin = new System.Windows.Forms.Padding(4, 3, 3, 3);
      this.disconnectBtn.Name = "disconnectBtn";
      this.disconnectBtn.Size = new System.Drawing.Size(154, 23);
      this.disconnectBtn.TabIndex = 1;
      this.disconnectBtn.Text = "Disconnect from LiveSplit";
      this.disconnectBtn.UseVisualStyleBackColor = true;
      this.disconnectBtn.Click += new System.EventHandler(this.disconnectBtn_Click);
      // 
      // logList
      // 
      this.logList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.logList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listColTim,
            this.listColMsg});
      this.logList.FullRowSelect = true;
      this.logList.HideSelection = false;
      this.logList.Location = new System.Drawing.Point(14, 121);
      this.logList.Name = "logList";
      this.logList.Size = new System.Drawing.Size(517, 166);
      this.logList.TabIndex = 2;
      this.logList.UseCompatibleStateImageBehavior = false;
      this.logList.View = System.Windows.Forms.View.Details;
      this.logList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.logList_KeyUp);
      // 
      // listColTim
      // 
      this.listColTim.Text = "Timestamp";
      this.listColTim.Width = 135;
      // 
      // listColMsg
      // 
      this.listColMsg.Text = "Message";
      this.listColMsg.Width = 350;
      // 
      // logLabel
      // 
      this.logLabel.AutoSize = true;
      this.logLabel.Location = new System.Drawing.Point(13, 103);
      this.logLabel.Margin = new System.Windows.Forms.Padding(3, 12, 3, 2);
      this.logLabel.Name = "logLabel";
      this.logLabel.Size = new System.Drawing.Size(60, 13);
      this.logLabel.TabIndex = 3;
      this.logLabel.Text = "Debug Log";
      // 
      // resetModeLbl
      // 
      this.resetModeLbl.AutoSize = true;
      this.resetModeLbl.Location = new System.Drawing.Point(13, 49);
      this.resetModeLbl.Margin = new System.Windows.Forms.Padding(3, 10, 3, 2);
      this.resetModeLbl.Name = "resetModeLbl";
      this.resetModeLbl.Size = new System.Drawing.Size(65, 13);
      this.resetModeLbl.TabIndex = 4;
      this.resetModeLbl.Text = "Reset Mode";
      // 
      // resetModeCmb
      // 
      this.resetModeCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.resetModeCmb.FormattingEnabled = true;
      this.resetModeCmb.Items.AddRange(new object[] {
            "Hotkey",
            "Server"});
      this.resetModeCmb.Location = new System.Drawing.Point(16, 67);
      this.resetModeCmb.Name = "resetModeCmb";
      this.resetModeCmb.Size = new System.Drawing.Size(100, 21);
      this.resetModeCmb.TabIndex = 5;
      // 
      // resetHotkeyLbl
      // 
      this.resetHotkeyLbl.AutoSize = true;
      this.resetHotkeyLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.resetHotkeyLbl.ForeColor = System.Drawing.SystemColors.Highlight;
      this.resetHotkeyLbl.Location = new System.Drawing.Point(122, 49);
      this.resetHotkeyLbl.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
      this.resetHotkeyLbl.Name = "resetHotkeyLbl";
      this.resetHotkeyLbl.Size = new System.Drawing.Size(72, 13);
      this.resetHotkeyLbl.TabIndex = 6;
      this.resetHotkeyLbl.Text = "Reset Hotkey";
      this.resetHotkeyLbl.Click += new System.EventHandler(this.resetHotkeyLbl_Click);
      // 
      // resetHotkeyTxt
      // 
      this.resetHotkeyTxt.Location = new System.Drawing.Point(122, 67);
      this.resetHotkeyTxt.Name = "resetHotkeyTxt";
      this.resetHotkeyTxt.Size = new System.Drawing.Size(100, 20);
      this.resetHotkeyTxt.TabIndex = 7;
      this.resetHotkeyTxt.Text = "{F15}";
      // 
      // resetDefaultBtn
      // 
      this.resetDefaultBtn.Location = new System.Drawing.Point(228, 65);
      this.resetDefaultBtn.Name = "resetDefaultBtn";
      this.resetDefaultBtn.Size = new System.Drawing.Size(100, 23);
      this.resetDefaultBtn.TabIndex = 8;
      this.resetDefaultBtn.Text = "Revert to Default";
      this.resetDefaultBtn.UseVisualStyleBackColor = true;
      this.resetDefaultBtn.Click += new System.EventHandler(this.resetDefaultBtn_Click);
      // 
      // testSplitBtn
      // 
      this.testSplitBtn.Enabled = false;
      this.testSplitBtn.Location = new System.Drawing.Point(358, 25);
      this.testSplitBtn.Name = "testSplitBtn";
      this.testSplitBtn.Size = new System.Drawing.Size(75, 23);
      this.testSplitBtn.TabIndex = 9;
      this.testSplitBtn.Text = "Test Split";
      this.testSplitBtn.UseVisualStyleBackColor = true;
      this.testSplitBtn.Click += new System.EventHandler(this.testSplitBtn_Click);
      // 
      // testResetBtn
      // 
      this.testResetBtn.Enabled = false;
      this.testResetBtn.Location = new System.Drawing.Point(358, 54);
      this.testResetBtn.Name = "testResetBtn";
      this.testResetBtn.Size = new System.Drawing.Size(75, 23);
      this.testResetBtn.TabIndex = 10;
      this.testResetBtn.Text = "Test Reset";
      this.testResetBtn.UseVisualStyleBackColor = true;
      this.testResetBtn.Click += new System.EventHandler(this.testResetBtn_Click);
      // 
      // clearLogBtn
      // 
      this.clearLogBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.clearLogBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.clearLogBtn.Location = new System.Drawing.Point(473, 96);
      this.clearLogBtn.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
      this.clearLogBtn.Name = "clearLogBtn";
      this.clearLogBtn.Size = new System.Drawing.Size(58, 20);
      this.clearLogBtn.TabIndex = 11;
      this.clearLogBtn.Text = "Clear Log";
      this.clearLogBtn.UseVisualStyleBackColor = true;
      this.clearLogBtn.Click += new System.EventHandler(this.clearLogBtn_Click);
      // 
      // copyLogBtn
      // 
      this.copyLogBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.copyLogBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.copyLogBtn.Location = new System.Drawing.Point(358, 96);
      this.copyLogBtn.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
      this.copyLogBtn.Name = "copyLogBtn";
      this.copyLogBtn.Size = new System.Drawing.Size(109, 20);
      this.copyLogBtn.TabIndex = 12;
      this.copyLogBtn.Text = "Copy Log to Clipboard";
      this.copyLogBtn.UseVisualStyleBackColor = true;
      this.copyLogBtn.Click += new System.EventHandler(this.copyLogBtn_Click);
      // 
      // BridgeForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.copyLogBtn);
      this.Controls.Add(this.clearLogBtn);
      this.Controls.Add(this.testResetBtn);
      this.Controls.Add(this.testSplitBtn);
      this.Controls.Add(this.resetDefaultBtn);
      this.Controls.Add(this.resetHotkeyTxt);
      this.Controls.Add(this.resetHotkeyLbl);
      this.Controls.Add(this.resetModeCmb);
      this.Controls.Add(this.resetModeLbl);
      this.Controls.Add(this.logLabel);
      this.Controls.Add(this.logList);
      this.Controls.Add(this.disconnectBtn);
      this.Controls.Add(this.connectBtn);
      this.Name = "BridgeForm";
      this.Padding = new System.Windows.Forms.Padding(10);
      this.Size = new System.Drawing.Size(544, 300);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Button disconnectBtn;
        private System.Windows.Forms.ListView logList;
        private System.Windows.Forms.ColumnHeader listColTim;
        private System.Windows.Forms.ColumnHeader listColMsg;
        private System.Windows.Forms.Label logLabel;
        private System.Windows.Forms.Label resetModeLbl;
        private System.Windows.Forms.ComboBox resetModeCmb;
        private System.Windows.Forms.Label resetHotkeyLbl;
        private System.Windows.Forms.TextBox resetHotkeyTxt;
        private System.Windows.Forms.Button resetDefaultBtn;
        private System.Windows.Forms.Button testSplitBtn;
        private System.Windows.Forms.Button testResetBtn;
    private System.Windows.Forms.Button clearLogBtn;
    private System.Windows.Forms.Button copyLogBtn;
  }
}
