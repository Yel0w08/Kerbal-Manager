using System.Drawing;
using System.Windows.Forms;

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
            heroBadgeLabel = new Label();
            libraryStatusBadge = new Label();
            libraryStatusLabel = new Label();
            keySourceLabel = new Label();
            keyStatusValueLabel = new Label();
            keyStatusTitleLabel = new Label();
            libraryGameLabel = new Label();
            libraryTitleLabel = new Label();
            contentPanel = new Panel();
            launchPanel = new Panel();
            launchStatusValueLabel = new Label();
            launchStatusTitleLabel = new Label();
            launchHintLabel = new Label();
            launchKspButton = new Button();
            cleanArchivesButton = new Button();
            openGameFolderButton = new Button();
            footerLabel = new Label();
            detailsPanel = new Panel();
            modsStatusValueLabel = new Label();
            modsStatusTitleLabel = new Label();
            installStatusValueLabel = new Label();
            installStatusTitleLabel = new Label();
            refreshButton = new Button();
            exitButton = new Button();
            openDownloadsButton = new Button();
            openCkanButton = new Button();
            downloadKspButton = new Button();
            subtitleLabel = new Label();
            titleLabel = new Label();
            sidebarPanel.SuspendLayout();
            contentPanel.SuspendLayout();
            launchPanel.SuspendLayout();
            detailsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.FromArgb(245, 247, 250);
            sidebarPanel.Controls.Add(heroBadgeLabel);
            sidebarPanel.Controls.Add(libraryStatusBadge);
            sidebarPanel.Controls.Add(libraryStatusLabel);
            sidebarPanel.Controls.Add(keySourceLabel);
            sidebarPanel.Controls.Add(keyStatusValueLabel);
            sidebarPanel.Controls.Add(keyStatusTitleLabel);
            sidebarPanel.Controls.Add(libraryGameLabel);
            sidebarPanel.Controls.Add(libraryTitleLabel);
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Location = new Point(0, 0);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(230, 520);
            sidebarPanel.TabIndex = 0;
            // 
            // heroBadgeLabel
            // 
            heroBadgeLabel.BackColor = Color.FromArgb(59, 130, 246);
            heroBadgeLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            heroBadgeLabel.ForeColor = Color.White;
            heroBadgeLabel.Location = new Point(24, 76);
            heroBadgeLabel.Name = "heroBadgeLabel";
            heroBadgeLabel.Size = new Size(42, 42);
            heroBadgeLabel.TabIndex = 4;
            heroBadgeLabel.Text = "K";
            heroBadgeLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // libraryStatusBadge
            // 
            libraryStatusBadge.BackColor = Color.FromArgb(220, 252, 231);
            libraryStatusBadge.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            libraryStatusBadge.ForeColor = Color.FromArgb(22, 101, 52);
            libraryStatusBadge.Location = new Point(24, 145);
            libraryStatusBadge.Name = "libraryStatusBadge";
            libraryStatusBadge.Size = new Size(74, 24);
            libraryStatusBadge.TabIndex = 3;
            libraryStatusBadge.Text = "ONLINE";
            libraryStatusBadge.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // libraryStatusLabel
            // 
            libraryStatusLabel.ForeColor = Color.FromArgb(71, 85, 105);
            libraryStatusLabel.Location = new Point(24, 193);
            libraryStatusLabel.Name = "libraryStatusLabel";
            libraryStatusLabel.Size = new Size(170, 83);
            libraryStatusLabel.TabIndex = 2;
            libraryStatusLabel.Text = "Community launcher for Kerbal Space Program downloads, installs, and mods.";
            // 
            // keySourceLabel
            // 
            keySourceLabel.ForeColor = Color.FromArgb(100, 116, 139);
            keySourceLabel.Location = new Point(24, 371);
            keySourceLabel.Name = "keySourceLabel";
            keySourceLabel.Size = new Size(170, 50);
            keySourceLabel.TabIndex = 7;
            keySourceLabel.Text = "Place `uncrypt_key` next to the launcher.";
            // 
            // keyStatusValueLabel
            // 
            keyStatusValueLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            keyStatusValueLabel.ForeColor = Color.FromArgb(15, 23, 42);
            keyStatusValueLabel.Location = new Point(24, 339);
            keyStatusValueLabel.Name = "keyStatusValueLabel";
            keyStatusValueLabel.Size = new Size(170, 27);
            keyStatusValueLabel.TabIndex = 6;
            keyStatusValueLabel.Text = "Key missing";
            // 
            // keyStatusTitleLabel
            // 
            keyStatusTitleLabel.ForeColor = Color.FromArgb(100, 116, 139);
            keyStatusTitleLabel.Location = new Point(24, 316);
            keyStatusTitleLabel.Name = "keyStatusTitleLabel";
            keyStatusTitleLabel.Size = new Size(90, 23);
            keyStatusTitleLabel.TabIndex = 5;
            keyStatusTitleLabel.Text = "KEY STATUS";
            // 
            // libraryGameLabel
            // 
            libraryGameLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            libraryGameLabel.ForeColor = Color.FromArgb(15, 23, 42);
            libraryGameLabel.Location = new Point(72, 76);
            libraryGameLabel.Name = "libraryGameLabel";
            libraryGameLabel.Size = new Size(170, 38);
            libraryGameLabel.TabIndex = 1;
            libraryGameLabel.Text = "KSP";
            // 
            // libraryTitleLabel
            // 
            libraryTitleLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            libraryTitleLabel.ForeColor = Color.FromArgb(100, 116, 139);
            libraryTitleLabel.Location = new Point(24, 35);
            libraryTitleLabel.Name = "libraryTitleLabel";
            libraryTitleLabel.Size = new Size(96, 23);
            libraryTitleLabel.TabIndex = 0;
            libraryTitleLabel.Text = "LIBRARY";
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.White;
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
            contentPanel.Location = new Point(230, 0);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(690, 520);
            contentPanel.TabIndex = 1;
            // 
            // launchPanel
            // 
            launchPanel.BackColor = Color.FromArgb(248, 250, 252);
            launchPanel.Controls.Add(launchStatusValueLabel);
            launchPanel.Controls.Add(launchStatusTitleLabel);
            launchPanel.Controls.Add(launchHintLabel);
            launchPanel.Controls.Add(launchKspButton);
            launchPanel.Controls.Add(cleanArchivesButton);
            launchPanel.Controls.Add(openGameFolderButton);
            launchPanel.Location = new Point(39, 136);
            launchPanel.Name = "launchPanel";
            launchPanel.Size = new Size(621, 138);
            launchPanel.TabIndex = 9;
            // 
            // launchStatusValueLabel
            // 
            launchStatusValueLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            launchStatusValueLabel.ForeColor = Color.FromArgb(15, 23, 42);
            launchStatusValueLabel.Location = new Point(33, 51);
            launchStatusValueLabel.Name = "launchStatusValueLabel";
            launchStatusValueLabel.Size = new Size(245, 31);
            launchStatusValueLabel.TabIndex = 2;
            launchStatusValueLabel.Text = "Install not detected";
            // 
            // launchStatusTitleLabel
            // 
            launchStatusTitleLabel.ForeColor = Color.FromArgb(100, 116, 139);
            launchStatusTitleLabel.Location = new Point(33, 26);
            launchStatusTitleLabel.Name = "launchStatusTitleLabel";
            launchStatusTitleLabel.Size = new Size(111, 23);
            launchStatusTitleLabel.TabIndex = 1;
            launchStatusTitleLabel.Text = "PLAY STATUS";
            // 
            // launchHintLabel
            // 
            launchHintLabel.ForeColor = Color.FromArgb(71, 85, 105);
            launchHintLabel.Location = new Point(33, 84);
            launchHintLabel.Name = "launchHintLabel";
            launchHintLabel.Size = new Size(341, 38);
            launchHintLabel.TabIndex = 4;
            launchHintLabel.Text = "Start here to download KSP into this launcher folder.";
            // 
            // launchKspButton
            // 
            launchKspButton.BackColor = Color.FromArgb(37, 99, 235);
            launchKspButton.Enabled = false;
            launchKspButton.FlatAppearance.BorderSize = 0;
            launchKspButton.FlatStyle = FlatStyle.Flat;
            launchKspButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            launchKspButton.ForeColor = Color.White;
            launchKspButton.Location = new Point(412, 77);
            launchKspButton.Name = "launchKspButton";
            launchKspButton.Size = new Size(198, 51);
            launchKspButton.TabIndex = 0;
            launchKspButton.Text = "Launch KSP";
            launchKspButton.UseVisualStyleBackColor = false;
            launchKspButton.Click += LaunchKspButton_Click;
            // 
            // cleanArchivesButton
            // 
            cleanArchivesButton.BackColor = Color.FromArgb(226, 232, 240);
            cleanArchivesButton.FlatAppearance.BorderSize = 0;
            cleanArchivesButton.FlatStyle = FlatStyle.Flat;
            cleanArchivesButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            cleanArchivesButton.ForeColor = Color.FromArgb(15, 23, 42);
            cleanArchivesButton.Location = new Point(412, 9);
            cleanArchivesButton.Name = "cleanArchivesButton";
            cleanArchivesButton.Size = new Size(198, 28);
            cleanArchivesButton.TabIndex = 3;
            cleanArchivesButton.Text = "Clean Archives";
            cleanArchivesButton.UseVisualStyleBackColor = false;
            cleanArchivesButton.Click += CleanArchivesButton_Click;
            // 
            // openGameFolderButton
            // 
            openGameFolderButton.BackColor = Color.FromArgb(226, 232, 240);
            openGameFolderButton.Enabled = false;
            openGameFolderButton.FlatAppearance.BorderSize = 0;
            openGameFolderButton.FlatStyle = FlatStyle.Flat;
            openGameFolderButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            openGameFolderButton.ForeColor = Color.FromArgb(15, 23, 42);
            openGameFolderButton.Location = new Point(412, 43);
            openGameFolderButton.Name = "openGameFolderButton";
            openGameFolderButton.Size = new Size(198, 28);
            openGameFolderButton.TabIndex = 5;
            openGameFolderButton.Text = "Open Game Folder";
            openGameFolderButton.UseVisualStyleBackColor = false;
            openGameFolderButton.Click += OpenGameFolderButton_Click;
            // 
            // footerLabel
            // 
            footerLabel.ForeColor = Color.FromArgb(100, 116, 139);
            footerLabel.Location = new Point(39, 476);
            footerLabel.Name = "footerLabel";
            footerLabel.Size = new Size(621, 35);
            footerLabel.TabIndex = 8;
            footerLabel.Text = "Tip: install CKAN for one-click mod management.";
            // 
            // detailsPanel
            // 
            detailsPanel.BackColor = Color.FromArgb(248, 250, 252);
            detailsPanel.Controls.Add(modsStatusValueLabel);
            detailsPanel.Controls.Add(modsStatusTitleLabel);
            detailsPanel.Controls.Add(installStatusValueLabel);
            detailsPanel.Controls.Add(installStatusTitleLabel);
            detailsPanel.Location = new Point(39, 285);
            detailsPanel.Name = "detailsPanel";
            detailsPanel.Size = new Size(621, 126);
            detailsPanel.TabIndex = 7;
            // 
            // modsStatusValueLabel
            // 
            modsStatusValueLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            modsStatusValueLabel.ForeColor = Color.FromArgb(15, 23, 42);
            modsStatusValueLabel.Location = new Point(317, 52);
            modsStatusValueLabel.Name = "modsStatusValueLabel";
            modsStatusValueLabel.Size = new Size(236, 37);
            modsStatusValueLabel.TabIndex = 3;
            modsStatusValueLabel.Text = "CKAN not found";
            // 
            // modsStatusTitleLabel
            // 
            modsStatusTitleLabel.ForeColor = Color.FromArgb(100, 116, 139);
            modsStatusTitleLabel.Location = new Point(317, 29);
            modsStatusTitleLabel.Name = "modsStatusTitleLabel";
            modsStatusTitleLabel.Size = new Size(92, 23);
            modsStatusTitleLabel.TabIndex = 2;
            modsStatusTitleLabel.Text = "MODS";
            // 
            // installStatusValueLabel
            // 
            installStatusValueLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            installStatusValueLabel.ForeColor = Color.FromArgb(15, 23, 42);
            installStatusValueLabel.Location = new Point(34, 52);
            installStatusValueLabel.Name = "installStatusValueLabel";
            installStatusValueLabel.Size = new Size(236, 37);
            installStatusValueLabel.TabIndex = 1;
            installStatusValueLabel.Text = "Ready to download";
            // 
            // installStatusTitleLabel
            // 
            installStatusTitleLabel.ForeColor = Color.FromArgb(100, 116, 139);
            installStatusTitleLabel.Location = new Point(34, 29);
            installStatusTitleLabel.Name = "installStatusTitleLabel";
            installStatusTitleLabel.Size = new Size(139, 23);
            installStatusTitleLabel.TabIndex = 0;
            installStatusTitleLabel.Text = "INSTALL STATUS";
            // 
            // refreshButton
            // 
            refreshButton.BackColor = Color.FromArgb(226, 232, 240);
            refreshButton.FlatAppearance.BorderSize = 0;
            refreshButton.FlatStyle = FlatStyle.Flat;
            refreshButton.ForeColor = Color.FromArgb(15, 23, 42);
            refreshButton.Location = new Point(485, 422);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(175, 46);
            refreshButton.TabIndex = 6;
            refreshButton.Text = "Refresh Status";
            refreshButton.UseVisualStyleBackColor = false;
            refreshButton.Click += RefreshButton_Click;
            // 
            // exitButton
            // 
            exitButton.BackColor = Color.FromArgb(254, 226, 226);
            exitButton.FlatAppearance.BorderSize = 0;
            exitButton.FlatStyle = FlatStyle.Flat;
            exitButton.ForeColor = Color.FromArgb(153, 27, 27);
            exitButton.Location = new Point(485, 422);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(81, 46);
            exitButton.TabIndex = 5;
            exitButton.Text = "Exit";
            exitButton.UseVisualStyleBackColor = false;
            exitButton.Click += ExitButton_Click;
            // 
            // openDownloadsButton
            // 
            openDownloadsButton.BackColor = Color.FromArgb(226, 232, 240);
            openDownloadsButton.FlatAppearance.BorderSize = 0;
            openDownloadsButton.FlatStyle = FlatStyle.Flat;
            openDownloadsButton.ForeColor = Color.FromArgb(15, 23, 42);
            openDownloadsButton.Location = new Point(262, 422);
            openDownloadsButton.Name = "openDownloadsButton";
            openDownloadsButton.Size = new Size(205, 46);
            openDownloadsButton.TabIndex = 4;
            openDownloadsButton.Text = "Open Download Folder";
            openDownloadsButton.UseVisualStyleBackColor = false;
            openDownloadsButton.Click += OpenDownloadsButton_Click;
            // 
            // openCkanButton
            // 
            openCkanButton.BackColor = Color.FromArgb(226, 232, 240);
            openCkanButton.FlatAppearance.BorderSize = 0;
            openCkanButton.FlatStyle = FlatStyle.Flat;
            openCkanButton.ForeColor = Color.FromArgb(15, 23, 42);
            openCkanButton.Location = new Point(39, 422);
            openCkanButton.Name = "openCkanButton";
            openCkanButton.Size = new Size(205, 46);
            openCkanButton.TabIndex = 3;
            openCkanButton.Text = "Open CKAN (Mods)";
            openCkanButton.UseVisualStyleBackColor = false;
            openCkanButton.Click += OpenCkanButton_Click;
            // 
            // downloadKspButton
            // 
            downloadKspButton.BackColor = Color.FromArgb(37, 99, 235);
            downloadKspButton.FlatAppearance.BorderSize = 0;
            downloadKspButton.FlatStyle = FlatStyle.Flat;
            downloadKspButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            downloadKspButton.ForeColor = Color.White;
            downloadKspButton.Location = new Point(579, 422);
            downloadKspButton.Name = "downloadKspButton";
            downloadKspButton.Size = new Size(81, 46);
            downloadKspButton.TabIndex = 2;
            downloadKspButton.Text = "Get KSP";
            downloadKspButton.UseVisualStyleBackColor = false;
            downloadKspButton.Click += DownloadKspButton_Click;
            // 
            // subtitleLabel
            // 
            subtitleLabel.ForeColor = Color.FromArgb(71, 85, 105);
            subtitleLabel.Location = new Point(43, 74);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(606, 41);
            subtitleLabel.TabIndex = 1;
            subtitleLabel.Text = "Launch your installed copy, manage mods with CKAN, and download KSP files into the same launcher folder.";
            // 
            // titleLabel
            // 
            titleLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(15, 23, 42);
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
            BackColor = Color.White;
            ClientSize = new Size(920, 520);
            Controls.Add(contentPanel);
            Controls.Add(sidebarPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LauncherForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "KSP Launcher";
            Load += LauncherForm_Load;
            sidebarPanel.ResumeLayout(false);
            contentPanel.ResumeLayout(false);
            launchPanel.ResumeLayout(false);
            detailsPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel sidebarPanel;
        private Label heroBadgeLabel;
        private Label libraryStatusBadge;
        private Label libraryStatusLabel;
        private Label keySourceLabel;
        private Label keyStatusValueLabel;
        private Label keyStatusTitleLabel;
        private Label libraryGameLabel;
        private Label libraryTitleLabel;
        private Panel contentPanel;
        private Panel launchPanel;
        private Label launchStatusValueLabel;
        private Label launchStatusTitleLabel;
        private Label launchHintLabel;
        private Label footerLabel;
        private Panel detailsPanel;
        private Button launchKspButton;
        private Button cleanArchivesButton;
        private Button openGameFolderButton;
        private Label modsStatusValueLabel;
        private Label modsStatusTitleLabel;
        private Label installStatusValueLabel;
        private Label installStatusTitleLabel;
        private Button refreshButton;
        private Button exitButton;
        private Button openDownloadsButton;
        private Button openCkanButton;
        private Button downloadKspButton;
        private Label subtitleLabel;
        private Label titleLabel;

        private Label LibraryStatusLabel => libraryStatusLabel;
        private Label InstallStatusValueLabel => installStatusValueLabel;
        private Label ModsStatusValueLabel => modsStatusValueLabel;
        private Label LaunchStatusValueLabel => launchStatusValueLabel;
        private Label KeyStatusValueLabel => keyStatusValueLabel;
        private Label KeySourceLabel => keySourceLabel;
        private Label FooterLabel => footerLabel;
    }
}
