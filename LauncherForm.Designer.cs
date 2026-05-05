using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace KSP_DL
{
    partial class LauncherForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LauncherForm));
            sidebarPanel = new Panel();
            heroIconPictureBox = new IconPictureBox();
            libraryStatusBadge = new Label();
            libraryStatusLabel = new Label();
            libraryGameLabel = new Label();
            libraryTitleLabel = new Label();
            contentPanel = new Panel();
            launchPanel = new Panel();
            launchStatusValueLabel = new Label();
            launchStatusTitleLabel = new Label();
            launchKspButton = new IconButton();
            cleanArchivesButton = new IconButton();
            footerLabel = new Label();
            detailsPanel = new Panel();
            modsStatusValueLabel = new Label();
            modsStatusTitleLabel = new Label();
            installStatusValueLabel = new Label();
            installStatusTitleLabel = new Label();
            refreshButton = new IconButton();
            exitButton = new IconButton();
            openDownloadsButton = new IconButton();
            openCkanButton = new IconButton();
            downloadKspButton = new IconButton();
            subtitleLabel = new Label();
            titleLabel = new Label();
            sidebarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)heroIconPictureBox).BeginInit();
            contentPanel.SuspendLayout();
            launchPanel.SuspendLayout();
            detailsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.FromArgb(22, 28, 37);
            sidebarPanel.Controls.Add(heroIconPictureBox);
            sidebarPanel.Controls.Add(libraryStatusBadge);
            sidebarPanel.Controls.Add(libraryStatusLabel);
            sidebarPanel.Controls.Add(libraryGameLabel);
            sidebarPanel.Controls.Add(libraryTitleLabel);
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Location = new Point(0, 0);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(220, 520);
            sidebarPanel.TabIndex = 0;
            // 
            // heroIconPictureBox
            // 
            heroIconPictureBox.BackColor = Color.Transparent;
            heroIconPictureBox.ForeColor = Color.FromArgb(96, 165, 250);
            heroIconPictureBox.IconChar = IconChar.Rocket;
            heroIconPictureBox.IconColor = Color.FromArgb(96, 165, 250);
            heroIconPictureBox.IconFont = IconFont.Auto;
            heroIconPictureBox.IconSize = 40;
            heroIconPictureBox.Location = new Point(24, 74);
            heroIconPictureBox.Name = "heroIconPictureBox";
            heroIconPictureBox.Size = new Size(42, 40);
            heroIconPictureBox.TabIndex = 4;
            heroIconPictureBox.TabStop = false;
            // 
            // libraryStatusBadge
            // 
            libraryStatusBadge.BackColor = Color.FromArgb(51, 160, 44);
            libraryStatusBadge.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            libraryStatusBadge.ForeColor = Color.White;
            libraryStatusBadge.Location = new Point(24, 145);
            libraryStatusBadge.Name = "libraryStatusBadge";
            libraryStatusBadge.Size = new Size(74, 24);
            libraryStatusBadge.TabIndex = 3;
            libraryStatusBadge.Text = "ONLINE";
            libraryStatusBadge.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // libraryStatusLabel
            // 
            libraryStatusLabel.ForeColor = Color.FromArgb(186, 197, 209);
            libraryStatusLabel.Location = new Point(24, 193);
            libraryStatusLabel.Name = "libraryStatusLabel";
            libraryStatusLabel.Size = new Size(170, 83);
            libraryStatusLabel.TabIndex = 2;
            libraryStatusLabel.Text = "Official backup downloader and mod launcher for Kerbal Space Program.";
            // 
            // libraryGameLabel
            // 
            libraryGameLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            libraryGameLabel.ForeColor = Color.White;
            libraryGameLabel.Location = new Point(72, 76);
            libraryGameLabel.Name = "libraryGameLabel";
            libraryGameLabel.Size = new Size(170, 38);
            libraryGameLabel.TabIndex = 1;
            libraryGameLabel.Text = "KSP";
            // 
            // libraryTitleLabel
            // 
            libraryTitleLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            libraryTitleLabel.ForeColor = Color.FromArgb(115, 141, 166);
            libraryTitleLabel.Location = new Point(24, 35);
            libraryTitleLabel.Name = "libraryTitleLabel";
            libraryTitleLabel.Size = new Size(96, 23);
            libraryTitleLabel.TabIndex = 0;
            libraryTitleLabel.Text = "LIBRARY";
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.FromArgb(13, 18, 26);
            contentPanel.Controls.Add(launchPanel);
            contentPanel.Controls.Add(footerLabel);
            contentPanel.Controls.Add(detailsPanel);
            contentPanel.Controls.Add(refreshButton);
            contentPanel.Controls.Add(exitButton);
            contentPanel.Controls.Add(openDownloadsButton);
            contentPanel.Controls.Add(openCkanButton);
            contentPanel.Controls.Add(downloadKspButton);
            contentPanel.Controls.Add(subtitleLabel);
            contentPanel.Controls.Add(titleLabel);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(220, 0);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(700, 520);
            contentPanel.TabIndex = 1;
            // 
            // launchPanel
            // 
            launchPanel.BackColor = Color.FromArgb(24, 32, 44);
            launchPanel.Controls.Add(launchStatusValueLabel);
            launchPanel.Controls.Add(launchStatusTitleLabel);
            launchPanel.Controls.Add(launchKspButton);
            launchPanel.Controls.Add(cleanArchivesButton);
            launchPanel.Location = new Point(39, 136);
            launchPanel.Name = "launchPanel";
            launchPanel.Size = new Size(621, 114);
            launchPanel.TabIndex = 9;
            // 
            // launchStatusValueLabel
            // 
            launchStatusValueLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            launchStatusValueLabel.ForeColor = Color.White;
            launchStatusValueLabel.Location = new Point(33, 51);
            launchStatusValueLabel.Name = "launchStatusValueLabel";
            launchStatusValueLabel.Size = new Size(245, 31);
            launchStatusValueLabel.TabIndex = 2;
            launchStatusValueLabel.Text = "Install not detected";
            // 
            // launchStatusTitleLabel
            // 
            launchStatusTitleLabel.ForeColor = Color.FromArgb(130, 149, 169);
            launchStatusTitleLabel.Location = new Point(33, 26);
            launchStatusTitleLabel.Name = "launchStatusTitleLabel";
            launchStatusTitleLabel.Size = new Size(111, 23);
            launchStatusTitleLabel.TabIndex = 1;
            launchStatusTitleLabel.Text = "PLAY STATUS";
            // 
            // launchKspButton
            // 
            launchKspButton.BackColor = Color.FromArgb(80, 164, 76);
            launchKspButton.Enabled = false;
            launchKspButton.FlatAppearance.BorderSize = 0;
            launchKspButton.FlatStyle = FlatStyle.Flat;
            launchKspButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            launchKspButton.ForeColor = Color.White;
            launchKspButton.IconChar = IconChar.Play;
            launchKspButton.IconColor = Color.FromArgb(148, 163, 184);
            launchKspButton.IconFont = IconFont.Auto;
            launchKspButton.IconSize = 24;
            launchKspButton.ImageAlign = ContentAlignment.MiddleLeft;
            launchKspButton.Location = new Point(412, 43);
            launchKspButton.Name = "launchKspButton";
            launchKspButton.Padding = new Padding(10, 0, 0, 0);
            launchKspButton.Size = new Size(198, 64);
            launchKspButton.TabIndex = 0;
            launchKspButton.Text = "Launch KSP";
            launchKspButton.TextAlign = ContentAlignment.MiddleLeft;
            launchKspButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            launchKspButton.UseVisualStyleBackColor = false;
            launchKspButton.Click += LaunchKspButton_Click;
            // 
            // cleanArchivesButton
            // 
            cleanArchivesButton.BackColor = Color.FromArgb(51, 65, 85);
            cleanArchivesButton.FlatAppearance.BorderSize = 0;
            cleanArchivesButton.FlatStyle = FlatStyle.Flat;
            cleanArchivesButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            cleanArchivesButton.ForeColor = Color.White;
            cleanArchivesButton.IconChar = IconChar.Broom;
            cleanArchivesButton.IconColor = Color.White;
            cleanArchivesButton.IconFont = IconFont.Auto;
            cleanArchivesButton.IconSize = 20;
            cleanArchivesButton.ImageAlign = ContentAlignment.MiddleLeft;
            cleanArchivesButton.Location = new Point(412, 9);
            cleanArchivesButton.Name = "cleanArchivesButton";
            cleanArchivesButton.Padding = new Padding(10, 0, 0, 0);
            cleanArchivesButton.Size = new Size(198, 28);
            cleanArchivesButton.TabIndex = 3;
            cleanArchivesButton.Text = "Clean Archives";
            cleanArchivesButton.TextAlign = ContentAlignment.MiddleLeft;
            cleanArchivesButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            cleanArchivesButton.UseVisualStyleBackColor = false;
            cleanArchivesButton.Click += CleanArchivesButton_Click;
            // 
            // footerLabel
            // 
            footerLabel.ForeColor = Color.FromArgb(130, 149, 169);
            footerLabel.Location = new Point(39, 463);
            footerLabel.Name = "footerLabel";
            footerLabel.Size = new Size(621, 44);
            footerLabel.TabIndex = 8;
            footerLabel.Text = "Tip: install CKAN for one-click mod management.";
            // 
            // detailsPanel
            // 
            detailsPanel.BackColor = Color.FromArgb(24, 32, 44);
            detailsPanel.Controls.Add(modsStatusValueLabel);
            detailsPanel.Controls.Add(modsStatusTitleLabel);
            detailsPanel.Controls.Add(installStatusValueLabel);
            detailsPanel.Controls.Add(installStatusTitleLabel);
            detailsPanel.Location = new Point(39, 272);
            detailsPanel.Name = "detailsPanel";
            detailsPanel.Size = new Size(621, 126);
            detailsPanel.TabIndex = 7;
            // 
            // modsStatusValueLabel
            // 
            modsStatusValueLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            modsStatusValueLabel.ForeColor = Color.White;
            modsStatusValueLabel.Location = new Point(317, 52);
            modsStatusValueLabel.Name = "modsStatusValueLabel";
            modsStatusValueLabel.Size = new Size(236, 37);
            modsStatusValueLabel.TabIndex = 3;
            modsStatusValueLabel.Text = "CKAN not found";
            // 
            // modsStatusTitleLabel
            // 
            modsStatusTitleLabel.ForeColor = Color.FromArgb(130, 149, 169);
            modsStatusTitleLabel.Location = new Point(317, 29);
            modsStatusTitleLabel.Name = "modsStatusTitleLabel";
            modsStatusTitleLabel.Size = new Size(92, 23);
            modsStatusTitleLabel.TabIndex = 2;
            modsStatusTitleLabel.Text = "MODS";
            // 
            // installStatusValueLabel
            // 
            installStatusValueLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            installStatusValueLabel.ForeColor = Color.White;
            installStatusValueLabel.Location = new Point(34, 52);
            installStatusValueLabel.Name = "installStatusValueLabel";
            installStatusValueLabel.Size = new Size(236, 37);
            installStatusValueLabel.TabIndex = 1;
            installStatusValueLabel.Text = "Ready to download";
            // 
            // installStatusTitleLabel
            // 
            installStatusTitleLabel.ForeColor = Color.FromArgb(130, 149, 169);
            installStatusTitleLabel.Location = new Point(34, 29);
            installStatusTitleLabel.Name = "installStatusTitleLabel";
            installStatusTitleLabel.Size = new Size(139, 23);
            installStatusTitleLabel.TabIndex = 0;
            installStatusTitleLabel.Text = "INSTALL STATUS";
            // 
            // refreshButton
            // 
            refreshButton.BackColor = Color.FromArgb(42, 56, 74);
            refreshButton.FlatAppearance.BorderSize = 0;
            refreshButton.FlatStyle = FlatStyle.Flat;
            refreshButton.ForeColor = Color.White;
            refreshButton.IconChar = IconChar.SyncAlt;
            refreshButton.IconColor = Color.White;
            refreshButton.IconFont = IconFont.Auto;
            refreshButton.IconSize = 18;
            refreshButton.ImageAlign = ContentAlignment.MiddleLeft;
            refreshButton.Location = new Point(485, 412);
            refreshButton.Name = "refreshButton";
            refreshButton.Padding = new Padding(10, 0, 0, 0);
            refreshButton.Size = new Size(175, 46);
            refreshButton.TabIndex = 6;
            refreshButton.Text = "Refresh Status";
            refreshButton.TextAlign = ContentAlignment.MiddleLeft;
            refreshButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            refreshButton.UseVisualStyleBackColor = false;
            refreshButton.Click += RefreshButton_Click;
            // 
            // exitButton
            // 
            exitButton.BackColor = Color.FromArgb(28, 36, 48);
            exitButton.FlatAppearance.BorderSize = 0;
            exitButton.FlatStyle = FlatStyle.Flat;
            exitButton.ForeColor = Color.White;
            exitButton.IconChar = IconChar.Close;
            exitButton.IconColor = Color.White;
            exitButton.IconFont = IconFont.Auto;
            exitButton.IconSize = 18;
            exitButton.ImageAlign = ContentAlignment.MiddleLeft;
            exitButton.Location = new Point(485, 412);
            exitButton.Name = "exitButton";
            exitButton.Padding = new Padding(10, 0, 0, 0);
            exitButton.Size = new Size(81, 46);
            exitButton.TabIndex = 5;
            exitButton.Text = "Exit";
            exitButton.TextAlign = ContentAlignment.MiddleLeft;
            exitButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            exitButton.UseVisualStyleBackColor = false;
            exitButton.Click += ExitButton_Click;
            // 
            // openDownloadsButton
            // 
            openDownloadsButton.BackColor = Color.FromArgb(28, 36, 48);
            openDownloadsButton.FlatAppearance.BorderSize = 0;
            openDownloadsButton.FlatStyle = FlatStyle.Flat;
            openDownloadsButton.ForeColor = Color.White;
            openDownloadsButton.IconChar = IconChar.FolderOpen;
            openDownloadsButton.IconColor = Color.White;
            openDownloadsButton.IconFont = IconFont.Auto;
            openDownloadsButton.IconSize = 18;
            openDownloadsButton.ImageAlign = ContentAlignment.MiddleLeft;
            openDownloadsButton.Location = new Point(262, 412);
            openDownloadsButton.Name = "openDownloadsButton";
            openDownloadsButton.Padding = new Padding(10, 0, 0, 0);
            openDownloadsButton.Size = new Size(205, 46);
            openDownloadsButton.TabIndex = 4;
            openDownloadsButton.Text = "Open Download Folder";
            openDownloadsButton.TextAlign = ContentAlignment.MiddleLeft;
            openDownloadsButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            openDownloadsButton.UseVisualStyleBackColor = false;
            openDownloadsButton.Click += OpenDownloadsButton_Click;
            // 
            // openCkanButton
            // 
            openCkanButton.BackColor = Color.FromArgb(28, 36, 48);
            openCkanButton.FlatAppearance.BorderSize = 0;
            openCkanButton.FlatStyle = FlatStyle.Flat;
            openCkanButton.ForeColor = Color.White;
            openCkanButton.IconChar = IconChar.PuzzlePiece;
            openCkanButton.IconColor = Color.White;
            openCkanButton.IconFont = IconFont.Auto;
            openCkanButton.IconSize = 18;
            openCkanButton.ImageAlign = ContentAlignment.MiddleLeft;
            openCkanButton.Location = new Point(39, 412);
            openCkanButton.Name = "openCkanButton";
            openCkanButton.Padding = new Padding(10, 0, 0, 0);
            openCkanButton.Size = new Size(205, 46);
            openCkanButton.TabIndex = 3;
            openCkanButton.Text = "Open CKAN (Mods)";
            openCkanButton.TextAlign = ContentAlignment.MiddleLeft;
            openCkanButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            openCkanButton.UseVisualStyleBackColor = false;
            openCkanButton.Click += OpenCkanButton_Click;
            // 
            // downloadKspButton
            // 
            downloadKspButton.BackColor = Color.FromArgb(68, 113, 190);
            downloadKspButton.FlatAppearance.BorderSize = 0;
            downloadKspButton.FlatStyle = FlatStyle.Flat;
            downloadKspButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            downloadKspButton.ForeColor = Color.White;
            downloadKspButton.IconChar = IconChar.Download;
            downloadKspButton.IconColor = Color.White;
            downloadKspButton.IconFont = IconFont.Auto;
            downloadKspButton.IconSize = 18;
            downloadKspButton.ImageAlign = ContentAlignment.MiddleLeft;
            downloadKspButton.Location = new Point(579, 412);
            downloadKspButton.Name = "downloadKspButton";
            downloadKspButton.Padding = new Padding(10, 0, 0, 0);
            downloadKspButton.Size = new Size(81, 46);
            downloadKspButton.TabIndex = 2;
            downloadKspButton.Text = "Get KSP";
            downloadKspButton.TextAlign = ContentAlignment.MiddleLeft;
            downloadKspButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            downloadKspButton.UseVisualStyleBackColor = false;
            downloadKspButton.Click += DownloadKspButton_Click;
            // 
            // subtitleLabel
            // 
            subtitleLabel.ForeColor = Color.FromArgb(164, 179, 195);
            subtitleLabel.Location = new Point(43, 74);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(606, 41);
            subtitleLabel.TabIndex = 1;
            subtitleLabel.Text = "Launch your installed copy, manage mods with CKAN, and download KSP files into the same launcher folder.";
            // 
            // titleLabel
            // 
            titleLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Location = new Point(37, 29);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(498, 45);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Kerbal Space Program Launcher";
            // 
            // LauncherForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(13, 18, 26);
            ClientSize = new Size(920, 520);
            Controls.Add(contentPanel);
            Controls.Add(sidebarPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LauncherForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KSP Launcher";
            Load += LauncherForm_Load;
            sidebarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)heroIconPictureBox).EndInit();
            contentPanel.ResumeLayout(false);
            launchPanel.ResumeLayout(false);
            detailsPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel sidebarPanel;
        private IconPictureBox heroIconPictureBox;
        private Label libraryStatusBadge;
        private Label libraryStatusLabel;
        private Label libraryGameLabel;
        private Label libraryTitleLabel;
        private Panel contentPanel;
        private Panel launchPanel;
        private Label launchStatusValueLabel;
        private Label launchStatusTitleLabel;
        private Label footerLabel;
        private Panel detailsPanel;
        private IconButton launchKspButton;
        private IconButton cleanArchivesButton;
        private Label modsStatusValueLabel;
        private Label modsStatusTitleLabel;
        private Label installStatusValueLabel;
        private Label installStatusTitleLabel;
        private IconButton refreshButton;
        private IconButton exitButton;
        private IconButton openDownloadsButton;
        private IconButton openCkanButton;
        private IconButton downloadKspButton;
        private Label subtitleLabel;
        private Label titleLabel;

        private Label LibraryStatusLabel => libraryStatusLabel;
        private Label InstallStatusValueLabel => installStatusValueLabel;
        private Label ModsStatusValueLabel => modsStatusValueLabel;
        private Label LaunchStatusValueLabel => launchStatusValueLabel;
        private Label FooterLabel => footerLabel;
    }
}
