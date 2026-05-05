namespace KSP_DL
{
    partial class UncryptKey
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UncryptKey));
            HeaderPanel = new Panel();
            HeaderBadgeLabel = new Label();
            HeaderSubtitleLabel = new Label();
            HeaderTitleLabel = new Label();
            DetailsPanel = new Panel();
            AutoKeyPathLabel = new Label();
            KeyStatusLabel = new Label();
            ExtractionStatusLabel = new Label();
            LaunchStatusLabel = new Label();
            WarningLabel = new Label();
            TmpWarning = new Label();
            LocationLabel = new Label();
            KeyLabel = new Label();
            CDKeyInput = new TextBox();
            VersionLabel = new Label();
            KSP_Version = new ComboBox();
            DownloadHintLabel = new Label();
            TypeOfFile = new ComboBox();
            ProgressBar = new ProgressBar();
            PathToDonload = new FolderBrowserDialog();
            GetButton = new Button();
            LaunchButton = new Button();
            OpenExtractionFolderButton = new Button();
            CloseButton = new Button();
            HeaderPanel.SuspendLayout();
            DetailsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // HeaderPanel
            // 
            HeaderPanel.BackColor = Color.FromArgb(248, 250, 252);
            HeaderPanel.Controls.Add(HeaderBadgeLabel);
            HeaderPanel.Controls.Add(HeaderSubtitleLabel);
            HeaderPanel.Controls.Add(HeaderTitleLabel);
            HeaderPanel.Location = new Point(12, 12);
            HeaderPanel.Name = "HeaderPanel";
            HeaderPanel.Size = new Size(560, 104);
            HeaderPanel.TabIndex = 0;
            HeaderPanel.Paint += HeaderPanel_Paint;
            // 
            // HeaderBadgeLabel
            // 
            HeaderBadgeLabel.BackColor = Color.FromArgb(37, 99, 235);
            HeaderBadgeLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            HeaderBadgeLabel.ForeColor = Color.White;
            HeaderBadgeLabel.Location = new Point(21, 15);
            HeaderBadgeLabel.Name = "HeaderBadgeLabel";
            HeaderBadgeLabel.Size = new Size(36, 36);
            HeaderBadgeLabel.TabIndex = 2;
            HeaderBadgeLabel.Text = "K";
            HeaderBadgeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // HeaderSubtitleLabel
            // 
            HeaderSubtitleLabel.ForeColor = Color.FromArgb(71, 85, 105);
            HeaderSubtitleLabel.Location = new Point(21, 53);
            HeaderSubtitleLabel.Name = "HeaderSubtitleLabel";
            HeaderSubtitleLabel.Size = new Size(511, 32);
            HeaderSubtitleLabel.TabIndex = 1;
            HeaderSubtitleLabel.Text = "Download archived KSP files into this launcher folder, auto-load the key when available, and launch the game directly after extraction.";
            // 
            // HeaderTitleLabel
            // 
            HeaderTitleLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            HeaderTitleLabel.ForeColor = Color.FromArgb(15, 23, 42);
            HeaderTitleLabel.Location = new Point(63, 15);
            HeaderTitleLabel.Name = "HeaderTitleLabel";
            HeaderTitleLabel.Size = new Size(318, 38);
            HeaderTitleLabel.TabIndex = 0;
            HeaderTitleLabel.Text = "KSP Downloader";
            // 
            // DetailsPanel
            // 
            DetailsPanel.BackColor = Color.FromArgb(248, 250, 252);
            DetailsPanel.Controls.Add(AutoKeyPathLabel);
            DetailsPanel.Controls.Add(KeyStatusLabel);
            DetailsPanel.Controls.Add(ExtractionStatusLabel);
            DetailsPanel.Controls.Add(LaunchStatusLabel);
            DetailsPanel.Controls.Add(WarningLabel);
            DetailsPanel.Controls.Add(TmpWarning);
            DetailsPanel.Controls.Add(LocationLabel);
            DetailsPanel.Controls.Add(KeyLabel);
            DetailsPanel.Controls.Add(CDKeyInput);
            DetailsPanel.Controls.Add(VersionLabel);
            DetailsPanel.Controls.Add(KSP_Version);
            DetailsPanel.Controls.Add(DownloadHintLabel);
            DetailsPanel.Controls.Add(TypeOfFile);
            DetailsPanel.Location = new Point(12, 131);
            DetailsPanel.Name = "DetailsPanel";
            DetailsPanel.Size = new Size(560, 296);
            DetailsPanel.TabIndex = 1;
            // 
            // AutoKeyPathLabel
            // 
            AutoKeyPathLabel.AutoEllipsis = true;
            AutoKeyPathLabel.ForeColor = Color.FromArgb(100, 116, 139);
            AutoKeyPathLabel.Location = new Point(20, 262);
            AutoKeyPathLabel.Name = "AutoKeyPathLabel";
            AutoKeyPathLabel.Size = new Size(512, 17);
            AutoKeyPathLabel.TabIndex = 17;
            AutoKeyPathLabel.Text = "Key file: not detected";
            // 
            // KeyStatusLabel
            // 
            KeyStatusLabel.ForeColor = Color.FromArgb(71, 85, 105);
            KeyStatusLabel.Location = new Point(20, 125);
            KeyStatusLabel.Name = "KeyStatusLabel";
            KeyStatusLabel.Size = new Size(512, 14);
            KeyStatusLabel.TabIndex = 16;
            KeyStatusLabel.Text = "No key file detected. Paste your 32-character key here.";
            // 
            // ExtractionStatusLabel
            // 
            ExtractionStatusLabel.AutoEllipsis = true;
            ExtractionStatusLabel.ForeColor = Color.FromArgb(100, 116, 139);
            ExtractionStatusLabel.Location = new Point(20, 245);
            ExtractionStatusLabel.Name = "ExtractionStatusLabel";
            ExtractionStatusLabel.Size = new Size(512, 17);
            ExtractionStatusLabel.TabIndex = 18;
            ExtractionStatusLabel.Text = "No extracted KSP folder detected yet.";
            // 
            // LaunchStatusLabel
            // 
            LaunchStatusLabel.ForeColor = Color.FromArgb(15, 23, 42);
            LaunchStatusLabel.Location = new Point(21, 227);
            LaunchStatusLabel.Name = "LaunchStatusLabel";
            LaunchStatusLabel.Size = new Size(511, 18);
            LaunchStatusLabel.TabIndex = 15;
            LaunchStatusLabel.Text = "KSP_x64.exe not found yet";
            // 
            // WarningLabel
            // 
            WarningLabel.AutoSize = true;
            WarningLabel.ForeColor = Color.FromArgb(185, 28, 28);
            WarningLabel.Location = new Point(20, 16);
            WarningLabel.Name = "WarningLabel";
            WarningLabel.Size = new Size(254, 15);
            WarningLabel.TabIndex = 0;
            WarningLabel.Text = "A valid 32-character decryption key is required.";
            WarningLabel.Click += WarningLabel_Click_1;
            // 
            // TmpWarning
            // 
            TmpWarning.AutoSize = true;
            TmpWarning.ForeColor = Color.FromArgb(194, 65, 12);
            TmpWarning.Location = new Point(20, 36);
            TmpWarning.Name = "TmpWarning";
            TmpWarning.Size = new Size(0, 15);
            TmpWarning.TabIndex = 1;
            // 
            // LocationLabel
            // 
            LocationLabel.AutoEllipsis = true;
            LocationLabel.ForeColor = Color.FromArgb(71, 85, 105);
            LocationLabel.Location = new Point(20, 64);
            LocationLabel.Name = "LocationLabel";
            LocationLabel.Size = new Size(512, 17);
            LocationLabel.TabIndex = 4;
            LocationLabel.Text = "Download location:";
            // 
            // KeyLabel
            // 
            KeyLabel.AutoSize = true;
            KeyLabel.ForeColor = Color.FromArgb(100, 116, 139);
            KeyLabel.Location = new Point(21, 81);
            KeyLabel.Name = "KeyLabel";
            KeyLabel.Size = new Size(86, 15);
            KeyLabel.TabIndex = 5;
            KeyLabel.Text = "Decryption key";
            // 
            // CDKeyInput
            // 
            CDKeyInput.BackColor = Color.White;
            CDKeyInput.CharacterCasing = CharacterCasing.Upper;
            CDKeyInput.Cursor = Cursors.IBeam;
            CDKeyInput.ForeColor = Color.FromArgb(15, 23, 42);
            CDKeyInput.HideSelection = false;
            CDKeyInput.Location = new Point(21, 99);
            CDKeyInput.MaxLength = 32;
            CDKeyInput.Name = "CDKeyInput";
            CDKeyInput.Size = new Size(512, 23);
            CDKeyInput.TabIndex = 6;
            CDKeyInput.TextChanged += KeyInput_TextChanged;
            // 
            // VersionLabel
            // 
            VersionLabel.AutoSize = true;
            VersionLabel.ForeColor = Color.FromArgb(100, 116, 139);
            VersionLabel.Location = new Point(20, 158);
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Size = new Size(79, 15);
            VersionLabel.TabIndex = 9;
            VersionLabel.Text = "Game version";
            // 
            // KSP_Version
            // 
            KSP_Version.BackColor = Color.White;
            KSP_Version.DisplayMember = "1";
            KSP_Version.FlatStyle = FlatStyle.Flat;
            KSP_Version.ForeColor = Color.FromArgb(15, 23, 42);
            KSP_Version.FormattingEnabled = true;
            KSP_Version.IntegralHeight = false;
            KSP_Version.Items.AddRange(new object[] { "Kerbal Space Program 1.12.5.3190 (latest)" });
            KSP_Version.Location = new Point(20, 176);
            KSP_Version.Name = "KSP_Version";
            KSP_Version.Size = new Size(398, 23);
            KSP_Version.TabIndex = 10;
            KSP_Version.Tag = "";
            KSP_Version.SelectedIndexChanged += KSPVersionComboBox_SelectedIndexChanged;
            // 
            // DownloadHintLabel
            // 
            DownloadHintLabel.AutoSize = true;
            DownloadHintLabel.ForeColor = Color.FromArgb(100, 116, 139);
            DownloadHintLabel.Location = new Point(431, 158);
            DownloadHintLabel.Name = "DownloadHintLabel";
            DownloadHintLabel.Size = new Size(90, 15);
            DownloadHintLabel.TabIndex = 11;
            DownloadHintLabel.Text = "Package format";
            // 
            // TypeOfFile
            // 
            TypeOfFile.BackColor = Color.White;
            TypeOfFile.FlatStyle = FlatStyle.Flat;
            TypeOfFile.ForeColor = Color.FromArgb(15, 23, 42);
            TypeOfFile.FormattingEnabled = true;
            TypeOfFile.Items.AddRange(new object[] { "SFX", ".7z", "CLEAN" });
            TypeOfFile.Location = new Point(431, 176);
            TypeOfFile.Name = "TypeOfFile";
            TypeOfFile.Size = new Size(101, 23);
            TypeOfFile.TabIndex = 12;
            TypeOfFile.SelectedIndexChanged += FileTypeComboBox_SelectedIndexChanged;
            // 
            // ProgressBar
            // 
            ProgressBar.BackColor = Color.FromArgb(219, 234, 254);
            ProgressBar.ForeColor = Color.FromArgb(37, 99, 235);
            ProgressBar.Location = new Point(12, 433);
            ProgressBar.Name = "ProgressBar";
            ProgressBar.Size = new Size(560, 26);
            ProgressBar.TabIndex = 8;
            ProgressBar.UseWaitCursor = true;
            ProgressBar.Click += progressBar_Click;
            // 
            // GetButton
            // 
            GetButton.BackColor = Color.FromArgb(37, 99, 235);
            GetButton.FlatAppearance.BorderSize = 0;
            GetButton.FlatStyle = FlatStyle.Flat;
            GetButton.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            GetButton.ForeColor = Color.White;
            GetButton.Location = new Point(12, 465);
            GetButton.Name = "GetButton";
            GetButton.Size = new Size(215, 62);
            GetButton.TabIndex = 2;
            GetButton.Text = "Download";
            GetButton.UseVisualStyleBackColor = false;
            GetButton.Click += GetButton_Click;
            // 
            // LaunchButton
            // 
            LaunchButton.BackColor = Color.FromArgb(22, 163, 74);
            LaunchButton.Enabled = false;
            LaunchButton.FlatAppearance.BorderSize = 0;
            LaunchButton.FlatStyle = FlatStyle.Flat;
            LaunchButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            LaunchButton.ForeColor = Color.White;
            LaunchButton.Location = new Point(239, 465);
            LaunchButton.Name = "LaunchButton";
            LaunchButton.Size = new Size(216, 30);
            LaunchButton.TabIndex = 4;
            LaunchButton.Text = "Launch KSP";
            LaunchButton.UseVisualStyleBackColor = false;
            LaunchButton.Click += LaunchButton_Click;
            // 
            // OpenExtractionFolderButton
            // 
            OpenExtractionFolderButton.BackColor = Color.FromArgb(226, 232, 240);
            OpenExtractionFolderButton.Enabled = false;
            OpenExtractionFolderButton.FlatAppearance.BorderSize = 0;
            OpenExtractionFolderButton.FlatStyle = FlatStyle.Flat;
            OpenExtractionFolderButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            OpenExtractionFolderButton.ForeColor = Color.FromArgb(15, 23, 42);
            OpenExtractionFolderButton.Location = new Point(239, 501);
            OpenExtractionFolderButton.Name = "OpenExtractionFolderButton";
            OpenExtractionFolderButton.Size = new Size(216, 26);
            OpenExtractionFolderButton.TabIndex = 6;
            OpenExtractionFolderButton.Text = "Open Extracted Folder";
            OpenExtractionFolderButton.UseVisualStyleBackColor = false;
            OpenExtractionFolderButton.Click += OpenExtractionFolderButton_Click;
            // 
            // CloseButton
            // 
            CloseButton.BackColor = Color.FromArgb(254, 226, 226);
            CloseButton.FlatAppearance.BorderSize = 0;
            CloseButton.FlatStyle = FlatStyle.Flat;
            CloseButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            CloseButton.ForeColor = Color.FromArgb(153, 27, 27);
            CloseButton.Location = new Point(467, 465);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(105, 62);
            CloseButton.TabIndex = 5;
            CloseButton.Text = "Close";
            CloseButton.UseVisualStyleBackColor = false;
            CloseButton.Click += CloseButton_Click;
            // 
            // UncryptKey
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(584, 540);
            Controls.Add(OpenExtractionFolderButton);
            Controls.Add(LaunchButton);
            Controls.Add(CloseButton);
            Controls.Add(GetButton);
            Controls.Add(DetailsPanel);
            Controls.Add(HeaderPanel);
            Controls.Add(ProgressBar);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "UncryptKey";
            StartPosition = FormStartPosition.CenterParent;
            Text = "KSP Downloader";
            Load += Form1_Load;
            HeaderPanel.ResumeLayout(false);
            DetailsPanel.ResumeLayout(false);
            DetailsPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel HeaderPanel;
        private Label HeaderBadgeLabel;
        private Label HeaderSubtitleLabel;
        private Label HeaderTitleLabel;
        private Panel DetailsPanel;
        private Label AutoKeyPathLabel;
        private Label KeyStatusLabel;
        private Label ExtractionStatusLabel;
        private Label LaunchStatusLabel;
        private Label WarningLabel;
        private Label TmpWarning;
        private ComboBox KSP_Version;
        private ComboBox TypeOfFile;
        private ProgressBar ProgressBar;
        private TextBox CDKeyInput;
        private FolderBrowserDialog PathToDonload;
        private Label DownloadHintLabel;
        private Label VersionLabel;
        private Label KeyLabel;
        private Label LocationLabel;
        private Button GetButton;
        private Button LaunchButton;
        private Button OpenExtractionFolderButton;
        private Button CloseButton;
    }
}
