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
            sidebarPanel = new Panel();
            libraryStatusBadge = new Label();
            libraryStatusLabel = new Label();
            libraryGameLabel = new Label();
            libraryTitleLabel = new Label();
            contentPanel = new Panel();
            launchPanel = new Panel();
            launchStatusValueLabel = new Label();
            launchStatusTitleLabel = new Label();
            footerLabel = new Label();
            detailsPanel = new Panel();
            launchKspButton = new Button();
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
            sidebarPanel.BackColor = Color.FromArgb(22, 28, 37);
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
            // libraryStatusBadge
            // 
            libraryStatusBadge.BackColor = Color.FromArgb(51, 160, 44);
            libraryStatusBadge.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            libraryStatusBadge.ForeColor = Color.White;
            libraryStatusBadge.Location = new Point(24, 128);
            libraryStatusBadge.Name = "libraryStatusBadge";
            libraryStatusBadge.Size = new Size(74, 24);
            libraryStatusBadge.TabIndex = 3;
            libraryStatusBadge.Text = "ONLINE";
            libraryStatusBadge.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // libraryStatusLabel
            // 
            libraryStatusLabel.ForeColor = Color.FromArgb(186, 197, 209);
            libraryStatusLabel.Location = new Point(24, 176);
            libraryStatusLabel.Name = "libraryStatusLabel";
            libraryStatusLabel.Size = new Size(170, 83);
            libraryStatusLabel.TabIndex = 2;
            libraryStatusLabel.Text = "Official backup downloader and mod launcher for Kerbal Space Program.";
            // 
            // libraryGameLabel
            // 
            libraryGameLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            libraryGameLabel.ForeColor = Color.White;
            libraryGameLabel.Location = new Point(24, 79);
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
            // launchKspButton
            // 
            launchKspButton.BackColor = Color.FromArgb(80, 164, 76);
            launchKspButton.Enabled = false;
            launchKspButton.FlatAppearance.BorderSize = 0;
            launchKspButton.FlatStyle = FlatStyle.Flat;
            launchKspButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            launchKspButton.ForeColor = Color.White;
            launchKspButton.Location = new Point(388, 24);
            launchKspButton.Name = "launchKspButton";
            launchKspButton.Size = new Size(198, 64);
            launchKspButton.TabIndex = 0;
            launchKspButton.Text = "Launch KSP";
            launchKspButton.UseVisualStyleBackColor = false;
            launchKspButton.Click += LaunchKspButton_Click;
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
            refreshButton.Location = new Point(485, 412);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(175, 46);
            refreshButton.TabIndex = 6;
            refreshButton.Text = "Refresh Status";
            refreshButton.UseVisualStyleBackColor = false;
            refreshButton.Click += RefreshButton_Click;
            // 
            // exitButton
            // 
            exitButton.BackColor = Color.FromArgb(28, 36, 48);
            exitButton.FlatAppearance.BorderSize = 0;
            exitButton.FlatStyle = FlatStyle.Flat;
            exitButton.ForeColor = Color.White;
            exitButton.Location = new Point(485, 412);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(81, 46);
            exitButton.TabIndex = 5;
            exitButton.Text = "Exit";
            exitButton.UseVisualStyleBackColor = false;
            exitButton.Click += ExitButton_Click;
            // 
            // openDownloadsButton
            // 
            openDownloadsButton.BackColor = Color.FromArgb(28, 36, 48);
            openDownloadsButton.FlatAppearance.BorderSize = 0;
            openDownloadsButton.FlatStyle = FlatStyle.Flat;
            openDownloadsButton.ForeColor = Color.White;
            openDownloadsButton.Location = new Point(262, 412);
            openDownloadsButton.Name = "openDownloadsButton";
            openDownloadsButton.Size = new Size(205, 46);
            openDownloadsButton.TabIndex = 4;
            openDownloadsButton.Text = "Open Download Folder";
            openDownloadsButton.UseVisualStyleBackColor = false;
            openDownloadsButton.Click += OpenDownloadsButton_Click;
            // 
            // openCkanButton
            // 
            openCkanButton.BackColor = Color.FromArgb(28, 36, 48);
            openCkanButton.FlatAppearance.BorderSize = 0;
            openCkanButton.FlatStyle = FlatStyle.Flat;
            openCkanButton.ForeColor = Color.White;
            openCkanButton.Location = new Point(39, 412);
            openCkanButton.Name = "openCkanButton";
            openCkanButton.Size = new Size(205, 46);
            openCkanButton.TabIndex = 3;
            openCkanButton.Text = "Open CKAN (Mods)";
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
            downloadKspButton.Location = new Point(579, 412);
            downloadKspButton.Name = "downloadKspButton";
            downloadKspButton.Size = new Size(81, 46);
            downloadKspButton.TabIndex = 2;
            downloadKspButton.Text = "Get KSP";
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
        private Button launchKspButton;
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
        private Label FooterLabel => footerLabel;
    }
}
