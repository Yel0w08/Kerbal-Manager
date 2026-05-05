using FontAwesome.Sharp;

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
            HeaderIconPictureBox = new IconPictureBox();
            HeaderSubtitleLabel = new Label();
            HeaderTitleLabel = new Label();
            DetailsPanel = new Panel();
            LaunchStatusLabel = new Label();
            StatusCaptionLabel = new Label();
            WarningLabel = new Label();
            TmpWarning = new Label();
            GetButton = new IconButton();
            KSP_Version = new ComboBox();
            TypeOfFile = new ComboBox();
            ProgressBar = new ProgressBar();
            CDKeyInput = new TextBox();
            PathToDonload = new FolderBrowserDialog();
            DownloadHintLabel = new Label();
            VersionLabel = new Label();
            KeyLabel = new Label();
            LocationLabel = new Label();
            CloseButton = new IconButton();
            LaunchButton = new IconButton();
            CleanupArchivesCheckBox = new CheckBox();
            HeaderPanel.SuspendLayout();
            DetailsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)HeaderIconPictureBox).BeginInit();
            SuspendLayout();
            // 
            // HeaderPanel
            // 
            HeaderPanel.BackColor = Color.FromArgb(31, 41, 55);
            HeaderPanel.Controls.Add(HeaderIconPictureBox);
            HeaderPanel.Controls.Add(HeaderSubtitleLabel);
            HeaderPanel.Controls.Add(HeaderTitleLabel);
            HeaderPanel.Location = new Point(12, 12);
            HeaderPanel.Name = "HeaderPanel";
            HeaderPanel.Size = new Size(560, 104);
            HeaderPanel.TabIndex = 0;
            // 
            // HeaderIconPictureBox
            // 
            HeaderIconPictureBox.BackColor = Color.Transparent;
            HeaderIconPictureBox.ForeColor = Color.FromArgb(96, 165, 250);
            HeaderIconPictureBox.IconChar = IconChar.SatelliteDish;
            HeaderIconPictureBox.IconColor = Color.FromArgb(96, 165, 250);
            HeaderIconPictureBox.IconFont = IconFont.Auto;
            HeaderIconPictureBox.IconSize = 34;
            HeaderIconPictureBox.Location = new Point(21, 15);
            HeaderIconPictureBox.Name = "HeaderIconPictureBox";
            HeaderIconPictureBox.Size = new Size(36, 34);
            HeaderIconPictureBox.TabIndex = 2;
            HeaderIconPictureBox.TabStop = false;
            // 
            // HeaderSubtitleLabel
            // 
            HeaderSubtitleLabel.ForeColor = Color.FromArgb(191, 201, 212);
            HeaderSubtitleLabel.Location = new Point(21, 53);
            HeaderSubtitleLabel.Name = "HeaderSubtitleLabel";
            HeaderSubtitleLabel.Size = new Size(511, 32);
            HeaderSubtitleLabel.TabIndex = 1;
            HeaderSubtitleLabel.Text = "Download archived KSP files into this launcher folder, then launch the installed game directly from here.";
            // 
            // HeaderTitleLabel
            // 
            HeaderTitleLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            HeaderTitleLabel.ForeColor = Color.White;
            HeaderTitleLabel.Location = new Point(63, 15);
            HeaderTitleLabel.Name = "HeaderTitleLabel";
            HeaderTitleLabel.Size = new Size(318, 38);
            HeaderTitleLabel.TabIndex = 0;
            HeaderTitleLabel.Text = "KSP Downloader";
            // 
            // DetailsPanel
            // 
            DetailsPanel.BackColor = Color.FromArgb(17, 24, 39);
            DetailsPanel.Controls.Add(LaunchStatusLabel);
            DetailsPanel.Controls.Add(StatusCaptionLabel);
            DetailsPanel.Controls.Add(WarningLabel);
            DetailsPanel.Controls.Add(TmpWarning);
            DetailsPanel.Controls.Add(LocationLabel);
            DetailsPanel.Controls.Add(KeyLabel);
            DetailsPanel.Controls.Add(CDKeyInput);
            DetailsPanel.Controls.Add(CleanupArchivesCheckBox);
            DetailsPanel.Controls.Add(ProgressBar);
            DetailsPanel.Controls.Add(VersionLabel);
            DetailsPanel.Controls.Add(KSP_Version);
            DetailsPanel.Controls.Add(DownloadHintLabel);
            DetailsPanel.Controls.Add(TypeOfFile);
            DetailsPanel.Location = new Point(12, 131);
            DetailsPanel.Name = "DetailsPanel";
            DetailsPanel.Size = new Size(560, 282);
            DetailsPanel.TabIndex = 1;
            // 
            // LaunchStatusLabel
            // 
            LaunchStatusLabel.ForeColor = Color.White;
            LaunchStatusLabel.Location = new Point(20, 231);
            LaunchStatusLabel.Name = "LaunchStatusLabel";
            LaunchStatusLabel.Size = new Size(512, 31);
            LaunchStatusLabel.TabIndex = 15;
            LaunchStatusLabel.Text = "KSP_x64.exe not found yet";
            // 
            // StatusCaptionLabel
            // 
            StatusCaptionLabel.ForeColor = Color.FromArgb(148, 163, 184);
            StatusCaptionLabel.Location = new Point(20, 206);
            StatusCaptionLabel.Name = "StatusCaptionLabel";
            StatusCaptionLabel.Size = new Size(120, 23);
            StatusCaptionLabel.TabIndex = 14;
            StatusCaptionLabel.Text = "LAUNCH STATUS";
            // 
            // WarningLabel
            // 
            WarningLabel.AutoSize = true;
            WarningLabel.ForeColor = Color.Red;
            WarningLabel.Location = new Point(20, 16);
            WarningLabel.Name = "WarningLabel";
            WarningLabel.Size = new Size(260, 15);
            WarningLabel.TabIndex = 0;
            WarningLabel.Text = "A valid 32-character decryption key is required.";
            WarningLabel.Click += WarningLabel_Click_1;
            // 
            // TmpWarning
            // 
            TmpWarning.AutoSize = true;
            TmpWarning.ForeColor = Color.DarkOrange;
            TmpWarning.Location = new Point(20, 36);
            TmpWarning.Name = "TmpWarning";
            TmpWarning.Size = new Size(0, 15);
            TmpWarning.TabIndex = 1;
            // 
            // GetButton
            // 
            GetButton.BackColor = Color.FromArgb(59, 130, 246);
            GetButton.FlatAppearance.BorderSize = 0;
            GetButton.FlatStyle = FlatStyle.Flat;
            GetButton.Font = new Font("Segoe UI", 15F);
            GetButton.ForeColor = Color.White;
            GetButton.IconChar = IconChar.Download;
            GetButton.IconColor = Color.White;
            GetButton.IconFont = IconFont.Auto;
            GetButton.IconSize = 24;
            GetButton.ImageAlign = ContentAlignment.MiddleLeft;
            GetButton.Location = new Point(12, 429);
            GetButton.Name = "GetButton";
            GetButton.Padding = new Padding(12, 0, 0, 0);
            GetButton.Size = new Size(215, 62);
            GetButton.TabIndex = 2;
            GetButton.Text = "Download";
            GetButton.TextAlign = ContentAlignment.MiddleLeft;
            GetButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            GetButton.UseVisualStyleBackColor = false;
            GetButton.Click += GetButton_Click;
            // 
            // KSP_Version
            // 
            KSP_Version.BackColor = Color.FromArgb(30, 41, 59);
            KSP_Version.DisplayMember = "1";
            KSP_Version.FlatStyle = FlatStyle.Flat;
            KSP_Version.FormattingEnabled = true;
            KSP_Version.ForeColor = Color.White;
            KSP_Version.IntegralHeight = false;
            KSP_Version.Items.AddRange(new object[] { "Kerbal Space Program 1.12.5.3190 (latest)" });
            KSP_Version.Location = new Point(20, 166);
            KSP_Version.Name = "KSP_Version";
            KSP_Version.Size = new Size(398, 23);
            KSP_Version.TabIndex = 10;
            KSP_Version.Tag = "";
            KSP_Version.SelectedIndexChanged += KSPVersionComboBox_SelectedIndexChanged;
            // 
            // TypeOfFile
            // 
            TypeOfFile.BackColor = Color.FromArgb(30, 41, 59);
            TypeOfFile.FlatStyle = FlatStyle.Flat;
            TypeOfFile.FormattingEnabled = true;
            TypeOfFile.ForeColor = Color.White;
            TypeOfFile.Items.AddRange(new object[] { "SFX", ".7z", "CLEAN" });
            TypeOfFile.Location = new Point(431, 166);
            TypeOfFile.Name = "TypeOfFile";
            TypeOfFile.Size = new Size(101, 23);
            TypeOfFile.TabIndex = 12;
            TypeOfFile.SelectedIndexChanged += FileTypeComboBox_SelectedIndexChanged;
            // 
            // ProgressBar
            // 
            ProgressBar.BackColor = Color.FromArgb(255, 128, 0);
            ProgressBar.ForeColor = Color.FromArgb(255, 128, 0);
            ProgressBar.Location = new Point(20, 123);
            ProgressBar.Name = "ProgressBar";
            ProgressBar.Size = new Size(512, 26);
            ProgressBar.TabIndex = 8;
            ProgressBar.UseWaitCursor = true;
            ProgressBar.Click += progressBar_Click;
            // 
            // CDKeyInput
            // 
            CDKeyInput.BackColor = Color.FromArgb(30, 41, 59);
            CDKeyInput.CharacterCasing = CharacterCasing.Upper;
            CDKeyInput.Cursor = Cursors.IBeam;
            CDKeyInput.ForeColor = Color.White;
            CDKeyInput.HideSelection = false;
            CDKeyInput.Location = new Point(20, 87);
            CDKeyInput.MaxLength = 32;
            CDKeyInput.Name = "CDKeyInput";
            CDKeyInput.Size = new Size(512, 23);
            CDKeyInput.TabIndex = 6;
            CDKeyInput.TextChanged += KeyInput_TextChanged;
            // 
            // CleanupArchivesCheckBox
            // 
            CleanupArchivesCheckBox.AutoSize = true;
            CleanupArchivesCheckBox.Checked = true;
            CleanupArchivesCheckBox.CheckState = CheckState.Checked;
            CleanupArchivesCheckBox.ForeColor = Color.FromArgb(191, 201, 212);
            CleanupArchivesCheckBox.Location = new Point(20, 185);
            CleanupArchivesCheckBox.Name = "CleanupArchivesCheckBox";
            CleanupArchivesCheckBox.Size = new Size(243, 19);
            CleanupArchivesCheckBox.TabIndex = 13;
            CleanupArchivesCheckBox.Text = "Offer to clean archive files after launch";
            CleanupArchivesCheckBox.UseVisualStyleBackColor = true;
            // 
            // DownloadHintLabel
            // 
            DownloadHintLabel.AutoSize = true;
            DownloadHintLabel.ForeColor = Color.FromArgb(148, 163, 184);
            DownloadHintLabel.Location = new Point(431, 148);
            DownloadHintLabel.Name = "DownloadHintLabel";
            DownloadHintLabel.Size = new Size(86, 15);
            DownloadHintLabel.TabIndex = 11;
            DownloadHintLabel.Text = "Package format";
            // 
            // VersionLabel
            // 
            VersionLabel.AutoSize = true;
            VersionLabel.ForeColor = Color.FromArgb(148, 163, 184);
            VersionLabel.Location = new Point(20, 148);
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Size = new Size(77, 15);
            VersionLabel.TabIndex = 9;
            VersionLabel.Text = "Game version";
            // 
            // KeyLabel
            // 
            KeyLabel.AutoSize = true;
            KeyLabel.ForeColor = Color.FromArgb(148, 163, 184);
            KeyLabel.Location = new Point(20, 69);
            KeyLabel.Name = "KeyLabel";
            KeyLabel.Size = new Size(86, 15);
            KeyLabel.TabIndex = 5;
            KeyLabel.Text = "Decryption key";
            // 
            // LocationLabel
            // 
            LocationLabel.AutoEllipsis = true;
            LocationLabel.ForeColor = Color.FromArgb(191, 201, 212);
            LocationLabel.Location = new Point(20, 52);
            LocationLabel.Name = "LocationLabel";
            LocationLabel.Size = new Size(512, 17);
            LocationLabel.TabIndex = 4;
            LocationLabel.Text = "Download location:";
            // 
            // CloseButton
            // 
            CloseButton.BackColor = Color.FromArgb(51, 65, 85);
            CloseButton.FlatAppearance.BorderSize = 0;
            CloseButton.FlatStyle = FlatStyle.Flat;
            CloseButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            CloseButton.ForeColor = Color.White;
            CloseButton.IconChar = IconChar.Xmark;
            CloseButton.IconColor = Color.White;
            CloseButton.IconFont = IconFont.Auto;
            CloseButton.IconSize = 22;
            CloseButton.ImageAlign = ContentAlignment.MiddleLeft;
            CloseButton.Location = new Point(467, 429);
            CloseButton.Name = "CloseButton";
            CloseButton.Padding = new Padding(10, 0, 0, 0);
            CloseButton.Size = new Size(105, 62);
            CloseButton.TabIndex = 5;
            CloseButton.Text = "Close";
            CloseButton.TextAlign = ContentAlignment.MiddleLeft;
            CloseButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            CloseButton.UseVisualStyleBackColor = false;
            CloseButton.Click += CloseButton_Click;
            // 
            // LaunchButton
            // 
            LaunchButton.BackColor = Color.FromArgb(34, 197, 94);
            LaunchButton.Enabled = false;
            LaunchButton.FlatAppearance.BorderSize = 0;
            LaunchButton.FlatStyle = FlatStyle.Flat;
            LaunchButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            LaunchButton.ForeColor = Color.White;
            LaunchButton.IconChar = IconChar.Play;
            LaunchButton.IconColor = Color.FromArgb(148, 163, 184);
            LaunchButton.IconFont = IconFont.Auto;
            LaunchButton.IconSize = 24;
            LaunchButton.ImageAlign = ContentAlignment.MiddleLeft;
            LaunchButton.Location = new Point(239, 429);
            LaunchButton.Name = "LaunchButton";
            LaunchButton.Padding = new Padding(12, 0, 0, 0);
            LaunchButton.Size = new Size(216, 62);
            LaunchButton.TabIndex = 4;
            LaunchButton.Text = "Launch KSP";
            LaunchButton.TextAlign = ContentAlignment.MiddleLeft;
            LaunchButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            LaunchButton.UseVisualStyleBackColor = false;
            LaunchButton.Click += LaunchButton_Click;
            // 
            // UncryptKey
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 23, 42);
            ClientSize = new Size(584, 503);
            Controls.Add(LaunchButton);
            Controls.Add(CloseButton);
            Controls.Add(GetButton);
            Controls.Add(DetailsPanel);
            Controls.Add(HeaderPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "UncryptKey";
            StartPosition = FormStartPosition.CenterParent;
            Text = "KSP Downloader";
            Load += Form1_Load;
            HeaderPanel.ResumeLayout(false);
            DetailsPanel.ResumeLayout(false);
            DetailsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)HeaderIconPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel HeaderPanel;
        private IconPictureBox HeaderIconPictureBox;
        private Label HeaderSubtitleLabel;
        private Label HeaderTitleLabel;
        private Panel DetailsPanel;
        private Label LaunchStatusLabel;
        private Label StatusCaptionLabel;
        private IconButton GetButton;
        private ComboBox KSP_Version;
        private ComboBox TypeOfFile;
        private Label WarningLabel;
        private Label TmpWarning;
        private ProgressBar ProgressBar;
        private TextBox CDKeyInput;
        private FolderBrowserDialog PathToDonload;
        private Label DownloadHintLabel;
        private Label VersionLabel;
        private Label KeyLabel;
        private Label LocationLabel;
        private IconButton CloseButton;
        private IconButton LaunchButton;
        private CheckBox CleanupArchivesCheckBox;
    }
}
