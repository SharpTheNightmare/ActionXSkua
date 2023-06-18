namespace ActionXSkua
{
    partial class ActionXWindow
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
            UnlockLabel = new LinkLabel();
            SkipCutsceneCheckBox = new CheckBox();
            HidePlayersCheckBox = new CheckBox();
            LagKillerCheckBox = new CheckBox();
            ProvokeCheckBox = new CheckBox();
            CellJumpCheckBox = new CheckBox();
            HostTooCheckBox = new CheckBox();
            ConClientTextBox = new Label();
            LogTextBox = new TextBox();
            CompleteQuestCheckBox = new CheckBox();
            MapJoinCheckBox = new CheckBox();
            BuyCheckBox = new CheckBox();
            GetMapItemCheckBox = new CheckBox();
            AcceptQuestCheckBox = new CheckBox();
            BroadcastTextBox = new TextBox();
            InfiniteRangeCheckBox = new CheckBox();
            LoadQuestCheckBox = new CheckBox();
            StartConButton = new Button();
            BroadcastMSG = new Button();
            OptionsGB = new GroupBox();
            AutoAttackCheckBox = new CheckBox();
            SendOptionsGB = new GroupBox();
            ConnectionGB = new GroupBox();
            HostIPTextBox = new TextBox();
            PortTextBox = new NumericUpDown();
            label2 = new Label();
            label1 = new Label();
            ClientCheckBox = new CheckBox();
            HeaderName = new System.ComponentModel.BackgroundWorker();
            OptionsGB.SuspendLayout();
            SendOptionsGB.SuspendLayout();
            ConnectionGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PortTextBox).BeginInit();
            SuspendLayout();
            // 
            // UnlockLabel
            // 
            UnlockLabel.AutoSize = true;
            UnlockLabel.Location = new Point(205, 0);
            UnlockLabel.Name = "UnlockLabel";
            UnlockLabel.Size = new Size(52, 15);
            UnlockLabel.TabIndex = 13;
            UnlockLabel.TabStop = true;
            UnlockLabel.Text = "[Unlock]";
            UnlockLabel.Visible = false;
            UnlockLabel.LinkClicked += UnlockLabel_LinkClicked;
            // 
            // SkipCutsceneCheckBox
            // 
            SkipCutsceneCheckBox.AutoSize = true;
            SkipCutsceneCheckBox.Enabled = false;
            SkipCutsceneCheckBox.Font = new Font("Segoe UI", 7.75F, FontStyle.Regular, GraphicsUnit.Point);
            SkipCutsceneCheckBox.Location = new Point(132, 64);
            SkipCutsceneCheckBox.Name = "SkipCutsceneCheckBox";
            SkipCutsceneCheckBox.Size = new Size(103, 17);
            SkipCutsceneCheckBox.TabIndex = 6;
            SkipCutsceneCheckBox.Text = "Skip Custscene";
            SkipCutsceneCheckBox.UseVisualStyleBackColor = true;
            SkipCutsceneCheckBox.CheckedChanged += SkipCutsceneCheckBox_CheckedChanged;
            // 
            // HidePlayersCheckBox
            // 
            HidePlayersCheckBox.AutoSize = true;
            HidePlayersCheckBox.Enabled = false;
            HidePlayersCheckBox.Font = new Font("Segoe UI", 7.75F, FontStyle.Regular, GraphicsUnit.Point);
            HidePlayersCheckBox.Location = new Point(143, 41);
            HidePlayersCheckBox.Name = "HidePlayersCheckBox";
            HidePlayersCheckBox.Size = new Size(88, 17);
            HidePlayersCheckBox.TabIndex = 4;
            HidePlayersCheckBox.Text = "Hide Players";
            HidePlayersCheckBox.UseVisualStyleBackColor = true;
            HidePlayersCheckBox.CheckedChanged += HidePlayersCheckBox_CheckedChanged;
            // 
            // LagKillerCheckBox
            // 
            LagKillerCheckBox.AutoSize = true;
            LagKillerCheckBox.Enabled = false;
            LagKillerCheckBox.Font = new Font("Segoe UI", 7.75F, FontStyle.Regular, GraphicsUnit.Point);
            LagKillerCheckBox.Location = new Point(18, 64);
            LagKillerCheckBox.Name = "LagKillerCheckBox";
            LagKillerCheckBox.Size = new Size(72, 17);
            LagKillerCheckBox.TabIndex = 3;
            LagKillerCheckBox.Text = "Lag Killer";
            LagKillerCheckBox.UseVisualStyleBackColor = true;
            LagKillerCheckBox.CheckedChanged += LagKillerCheckBox_CheckedChanged;
            // 
            // ProvokeCheckBox
            // 
            ProvokeCheckBox.AutoSize = true;
            ProvokeCheckBox.Enabled = false;
            ProvokeCheckBox.Font = new Font("Segoe UI", 7.75F, FontStyle.Regular, GraphicsUnit.Point);
            ProvokeCheckBox.Location = new Point(28, 41);
            ProvokeCheckBox.Name = "ProvokeCheckBox";
            ProvokeCheckBox.Size = new Size(67, 17);
            ProvokeCheckBox.TabIndex = 2;
            ProvokeCheckBox.Text = "Provoke";
            ProvokeCheckBox.UseVisualStyleBackColor = true;
            ProvokeCheckBox.CheckedChanged += ProvokeCheckBox_CheckedChanged;
            // 
            // CellJumpCheckBox
            // 
            CellJumpCheckBox.AutoSize = true;
            CellJumpCheckBox.Checked = true;
            CellJumpCheckBox.CheckState = CheckState.Checked;
            CellJumpCheckBox.Font = new Font("Segoe UI", 7.75F, FontStyle.Regular, GraphicsUnit.Point);
            CellJumpCheckBox.Location = new Point(106, 55);
            CellJumpCheckBox.Name = "CellJumpCheckBox";
            CellJumpCheckBox.Size = new Size(75, 17);
            CellJumpCheckBox.TabIndex = 14;
            CellJumpCheckBox.Text = "Cell Jump";
            CellJumpCheckBox.UseVisualStyleBackColor = true;
            // 
            // HostTooCheckBox
            // 
            HostTooCheckBox.AutoSize = true;
            HostTooCheckBox.Checked = true;
            HostTooCheckBox.CheckState = CheckState.Checked;
            HostTooCheckBox.Font = new Font("Segoe UI", 7.75F, FontStyle.Regular, GraphicsUnit.Point);
            HostTooCheckBox.Location = new Point(127, 0);
            HostTooCheckBox.Name = "HostTooCheckBox";
            HostTooCheckBox.Size = new Size(72, 17);
            HostTooCheckBox.TabIndex = 0;
            HostTooCheckBox.Text = "Host Too";
            HostTooCheckBox.UseVisualStyleBackColor = true;
            HostTooCheckBox.Visible = false;
            // 
            // ConClientTextBox
            // 
            ConClientTextBox.AutoSize = true;
            ConClientTextBox.Location = new Point(272, 241);
            ConClientTextBox.Name = "ConClientTextBox";
            ConClientTextBox.Size = new Size(111, 15);
            ConClientTextBox.TabIndex = 19;
            ConClientTextBox.Text = "Client Connected: 0";
            ConClientTextBox.Visible = false;
            // 
            // LogTextBox
            // 
            LogTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            LogTextBox.Location = new Point(274, 14);
            LogTextBox.MaxLength = int.MaxValue;
            LogTextBox.Multiline = true;
            LogTextBox.Name = "LogTextBox";
            LogTextBox.ReadOnly = true;
            LogTextBox.ScrollBars = ScrollBars.Vertical;
            LogTextBox.Size = new Size(463, 198);
            LogTextBox.TabIndex = 18;
            // 
            // CompleteQuestCheckBox
            // 
            CompleteQuestCheckBox.AutoSize = true;
            CompleteQuestCheckBox.Checked = true;
            CompleteQuestCheckBox.CheckState = CheckState.Checked;
            CompleteQuestCheckBox.Font = new Font("Segoe UI", 7.75F, FontStyle.Regular, GraphicsUnit.Point);
            CompleteQuestCheckBox.Location = new Point(6, 36);
            CompleteQuestCheckBox.Name = "CompleteQuestCheckBox";
            CompleteQuestCheckBox.Size = new Size(108, 17);
            CompleteQuestCheckBox.TabIndex = 4;
            CompleteQuestCheckBox.Text = "Quest Complete";
            CompleteQuestCheckBox.UseVisualStyleBackColor = true;
            // 
            // MapJoinCheckBox
            // 
            MapJoinCheckBox.AutoSize = true;
            MapJoinCheckBox.Checked = true;
            MapJoinCheckBox.CheckState = CheckState.Checked;
            MapJoinCheckBox.Font = new Font("Segoe UI", 7.75F, FontStyle.Regular, GraphicsUnit.Point);
            MapJoinCheckBox.Location = new Point(17, 55);
            MapJoinCheckBox.Name = "MapJoinCheckBox";
            MapJoinCheckBox.Size = new Size(73, 17);
            MapJoinCheckBox.TabIndex = 13;
            MapJoinCheckBox.Text = "Map Join";
            MapJoinCheckBox.UseVisualStyleBackColor = true;
            // 
            // BuyCheckBox
            // 
            BuyCheckBox.AutoSize = true;
            BuyCheckBox.Checked = true;
            BuyCheckBox.CheckState = CheckState.Checked;
            BuyCheckBox.Font = new Font("Segoe UI", 7.75F, FontStyle.Regular, GraphicsUnit.Point);
            BuyCheckBox.Location = new Point(199, 55);
            BuyCheckBox.Name = "BuyCheckBox";
            BuyCheckBox.Size = new Size(44, 17);
            BuyCheckBox.TabIndex = 3;
            BuyCheckBox.Text = "Buy";
            BuyCheckBox.UseVisualStyleBackColor = true;
            // 
            // GetMapItemCheckBox
            // 
            GetMapItemCheckBox.AutoSize = true;
            GetMapItemCheckBox.Checked = true;
            GetMapItemCheckBox.CheckState = CheckState.Checked;
            GetMapItemCheckBox.Font = new Font("Segoe UI", 7.75F, FontStyle.Regular, GraphicsUnit.Point);
            GetMapItemCheckBox.Location = new Point(134, 36);
            GetMapItemCheckBox.Name = "GetMapItemCheckBox";
            GetMapItemCheckBox.Size = new Size(95, 17);
            GetMapItemCheckBox.TabIndex = 5;
            GetMapItemCheckBox.Text = "Get Map Item";
            GetMapItemCheckBox.UseVisualStyleBackColor = true;
            // 
            // AcceptQuestCheckBox
            // 
            AcceptQuestCheckBox.AutoSize = true;
            AcceptQuestCheckBox.Checked = true;
            AcceptQuestCheckBox.CheckState = CheckState.Checked;
            AcceptQuestCheckBox.Font = new Font("Segoe UI", 7.75F, FontStyle.Regular, GraphicsUnit.Point);
            AcceptQuestCheckBox.Location = new Point(144, 17);
            AcceptQuestCheckBox.Name = "AcceptQuestCheckBox";
            AcceptQuestCheckBox.Size = new Size(93, 17);
            AcceptQuestCheckBox.TabIndex = 2;
            AcceptQuestCheckBox.Text = "Quest Accept";
            AcceptQuestCheckBox.UseVisualStyleBackColor = true;
            // 
            // BroadcastTextBox
            // 
            BroadcastTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            BroadcastTextBox.Location = new Point(274, 215);
            BroadcastTextBox.MaxLength = 65535;
            BroadcastTextBox.Name = "BroadcastTextBox";
            BroadcastTextBox.Size = new Size(419, 23);
            BroadcastTextBox.TabIndex = 20;
            BroadcastTextBox.Text = "Hello World!";
            BroadcastTextBox.KeyDown += BroadcastTextBox_KeyDown;
            // 
            // InfiniteRangeCheckBox
            // 
            InfiniteRangeCheckBox.AutoSize = true;
            InfiniteRangeCheckBox.Enabled = false;
            InfiniteRangeCheckBox.Font = new Font("Segoe UI", 7.75F, FontStyle.Regular, GraphicsUnit.Point);
            InfiniteRangeCheckBox.Location = new Point(138, 22);
            InfiniteRangeCheckBox.Name = "InfiniteRangeCheckBox";
            InfiniteRangeCheckBox.Size = new Size(99, 17);
            InfiniteRangeCheckBox.TabIndex = 1;
            InfiniteRangeCheckBox.Text = "Infinite Range";
            InfiniteRangeCheckBox.UseVisualStyleBackColor = true;
            InfiniteRangeCheckBox.CheckedChanged += InfiniteRangeCheckBox_CheckedChanged;
            // 
            // LoadQuestCheckBox
            // 
            LoadQuestCheckBox.AutoSize = true;
            LoadQuestCheckBox.Checked = true;
            LoadQuestCheckBox.CheckState = CheckState.Checked;
            LoadQuestCheckBox.Font = new Font("Segoe UI", 7.75F, FontStyle.Regular, GraphicsUnit.Point);
            LoadQuestCheckBox.Location = new Point(27, 17);
            LoadQuestCheckBox.Name = "LoadQuestCheckBox";
            LoadQuestCheckBox.Size = new Size(84, 17);
            LoadQuestCheckBox.TabIndex = 1;
            LoadQuestCheckBox.Text = "Quest Load";
            LoadQuestCheckBox.UseVisualStyleBackColor = true;
            // 
            // StartConButton
            // 
            StartConButton.FlatStyle = FlatStyle.System;
            StartConButton.Location = new Point(193, 31);
            StartConButton.Name = "StartConButton";
            StartConButton.Size = new Size(75, 51);
            StartConButton.TabIndex = 14;
            StartConButton.Text = "Connect";
            StartConButton.UseVisualStyleBackColor = true;
            StartConButton.Click += StartConButton_Click;
            // 
            // BroadcastMSG
            // 
            BroadcastMSG.Anchor = AnchorStyles.Right;
            BroadcastMSG.Location = new Point(694, 214);
            BroadcastMSG.Name = "BroadcastMSG";
            BroadcastMSG.Size = new Size(43, 26);
            BroadcastMSG.TabIndex = 21;
            BroadcastMSG.Text = "Send";
            BroadcastMSG.UseVisualStyleBackColor = true;
            BroadcastMSG.Click += BroadcastMSG_Click;
            // 
            // OptionsGB
            // 
            OptionsGB.Controls.Add(AutoAttackCheckBox);
            OptionsGB.Controls.Add(UnlockLabel);
            OptionsGB.Controls.Add(SkipCutsceneCheckBox);
            OptionsGB.Controls.Add(HidePlayersCheckBox);
            OptionsGB.Controls.Add(LagKillerCheckBox);
            OptionsGB.Controls.Add(ProvokeCheckBox);
            OptionsGB.Controls.Add(InfiniteRangeCheckBox);
            OptionsGB.Controls.Add(HostTooCheckBox);
            OptionsGB.Location = new Point(7, 167);
            OptionsGB.Name = "OptionsGB";
            OptionsGB.Size = new Size(261, 90);
            OptionsGB.TabIndex = 17;
            OptionsGB.TabStop = false;
            OptionsGB.Text = "Client Options";
            // 
            // AutoAttackCheckBox
            // 
            AutoAttackCheckBox.AutoSize = true;
            AutoAttackCheckBox.Enabled = false;
            AutoAttackCheckBox.Font = new Font("Segoe UI", 7.75F, FontStyle.Regular, GraphicsUnit.Point);
            AutoAttackCheckBox.Location = new Point(18, 20);
            AutoAttackCheckBox.Name = "AutoAttackCheckBox";
            AutoAttackCheckBox.Size = new Size(86, 17);
            AutoAttackCheckBox.TabIndex = 14;
            AutoAttackCheckBox.Text = "Auto Attack";
            AutoAttackCheckBox.UseVisualStyleBackColor = true;
            AutoAttackCheckBox.CheckedChanged += AutoAttackCheckBox_CheckedChanged;
            // 
            // SendOptionsGB
            // 
            SendOptionsGB.Controls.Add(CellJumpCheckBox);
            SendOptionsGB.Controls.Add(CompleteQuestCheckBox);
            SendOptionsGB.Controls.Add(MapJoinCheckBox);
            SendOptionsGB.Controls.Add(BuyCheckBox);
            SendOptionsGB.Controls.Add(GetMapItemCheckBox);
            SendOptionsGB.Controls.Add(AcceptQuestCheckBox);
            SendOptionsGB.Controls.Add(LoadQuestCheckBox);
            SendOptionsGB.Location = new Point(7, 82);
            SendOptionsGB.Name = "SendOptionsGB";
            SendOptionsGB.Size = new Size(261, 77);
            SendOptionsGB.TabIndex = 16;
            SendOptionsGB.TabStop = false;
            SendOptionsGB.Text = "Copy Options";
            // 
            // ConnectionGB
            // 
            ConnectionGB.Controls.Add(HostIPTextBox);
            ConnectionGB.Controls.Add(PortTextBox);
            ConnectionGB.Controls.Add(label2);
            ConnectionGB.Controls.Add(label1);
            ConnectionGB.Location = new Point(7, 7);
            ConnectionGB.Name = "ConnectionGB";
            ConnectionGB.Size = new Size(180, 75);
            ConnectionGB.TabIndex = 15;
            ConnectionGB.TabStop = false;
            ConnectionGB.Text = "Connect To";
            // 
            // HostIPTextBox
            // 
            HostIPTextBox.Location = new Point(49, 16);
            HostIPTextBox.Name = "HostIPTextBox";
            HostIPTextBox.Size = new Size(115, 23);
            HostIPTextBox.TabIndex = 1;
            HostIPTextBox.Text = "127.0.0.1";
            HostIPTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // PortTextBox
            // 
            PortTextBox.Location = new Point(49, 44);
            PortTextBox.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            PortTextBox.Minimum = new decimal(new int[] { 1024, 0, 0, 0 });
            PortTextBox.Name = "PortTextBox";
            PortTextBox.Size = new Size(115, 23);
            PortTextBox.TabIndex = 2;
            PortTextBox.TextAlign = HorizontalAlignment.Center;
            PortTextBox.Value = new decimal(new int[] { 1024, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 46);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 4;
            label2.Text = "Port";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 19);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 3;
            label1.Text = "IP";
            // 
            // ClientCheckBox
            // 
            ClientCheckBox.AutoSize = true;
            ClientCheckBox.Checked = true;
            ClientCheckBox.CheckState = CheckState.Checked;
            ClientCheckBox.Location = new Point(200, 14);
            ClientCheckBox.Name = "ClientCheckBox";
            ClientCheckBox.Size = new Size(68, 19);
            ClientCheckBox.TabIndex = 13;
            ClientCheckBox.Text = "Is Client";
            ClientCheckBox.UseVisualStyleBackColor = true;
            ClientCheckBox.CheckedChanged += ClientCheckBox_CheckedChanged;
            // 
            // HeaderName
            // 
            HeaderName.WorkerReportsProgress = true;
            HeaderName.DoWork += HeaderName_DoWork;
            HeaderName.RunWorkerCompleted += HeaderName_RunWorkerCompleted;
            // 
            // ActionXWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(744, 268);
            Controls.Add(ConClientTextBox);
            Controls.Add(LogTextBox);
            Controls.Add(BroadcastTextBox);
            Controls.Add(StartConButton);
            Controls.Add(BroadcastMSG);
            Controls.Add(OptionsGB);
            Controls.Add(SendOptionsGB);
            Controls.Add(ConnectionGB);
            Controls.Add(ClientCheckBox);
            MaximumSize = new Size(1000, 307);
            MinimumSize = new Size(517, 307);
            Name = "ActionXWindow";
            Text = "ActionX Skua";
            FormClosing += ActionXWindow_FormClosing;
            OptionsGB.ResumeLayout(false);
            OptionsGB.PerformLayout();
            SendOptionsGB.ResumeLayout(false);
            SendOptionsGB.PerformLayout();
            ConnectionGB.ResumeLayout(false);
            ConnectionGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PortTextBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private LinkLabel UnlockLabel;
        private CheckBox SkipCutsceneCheckBox;
        private CheckBox HidePlayersCheckBox;
        private CheckBox LagKillerCheckBox;
        private CheckBox ProvokeCheckBox;
        private CheckBox CellJumpCheckBox;
        private CheckBox HostTooCheckBox;
        private Label ConClientTextBox;
        public TextBox LogTextBox;
        private CheckBox CompleteQuestCheckBox;
        private CheckBox MapJoinCheckBox;
        private CheckBox BuyCheckBox;
        private CheckBox GetMapItemCheckBox;
        private CheckBox AcceptQuestCheckBox;
        private TextBox BroadcastTextBox;
        private CheckBox InfiniteRangeCheckBox;
        private CheckBox LoadQuestCheckBox;
        private Button StartConButton;
        private Button BroadcastMSG;
        private GroupBox OptionsGB;
        private CheckBox AutoAttackCheckBox;
        private GroupBox SendOptionsGB;
        private GroupBox ConnectionGB;
        private TextBox HostIPTextBox;
        private NumericUpDown PortTextBox;
        private Label label2;
        private Label label1;
        private CheckBox ClientCheckBox;
        private System.ComponentModel.BackgroundWorker HeaderName;
    }
}