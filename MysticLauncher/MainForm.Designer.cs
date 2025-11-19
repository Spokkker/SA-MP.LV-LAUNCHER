using System.Drawing;
using System.Windows.Forms;

namespace MysticLauncher;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.navPanel = new System.Windows.Forms.Panel();
        this.discordButton = new System.Windows.Forms.Button();
        this.settingsButton = new System.Windows.Forms.Button();
        this.updateButton = new System.Windows.Forms.Button();
        this.playButton = new System.Windows.Forms.Button();
        this.brandLabel = new System.Windows.Forms.Label();
        this.brandTagline = new System.Windows.Forms.Label();
        this.footerPanel = new System.Windows.Forms.Panel();
        this.versionLabel = new System.Windows.Forms.Label();
        this.statusIndicator = new System.Windows.Forms.Label();
        this.statusDot = new System.Windows.Forms.Panel();
        this.contentPanel = new System.Windows.Forms.Panel();
        this.heroPanel = new System.Windows.Forms.Panel();
        this.heroCallout = new System.Windows.Forms.Label();
        this.heroTitle = new System.Windows.Forms.Label();
        this.sectionHeader = new System.Windows.Forms.Label();
        this.serverCard = new System.Windows.Forms.Panel();
        this.serverActionButton = new System.Windows.Forms.Button();
        this.serverSubtitle = new System.Windows.Forms.Label();
        this.serverTitle = new System.Windows.Forms.Label();
        this.navPanel.SuspendLayout();
        this.footerPanel.SuspendLayout();
        this.contentPanel.SuspendLayout();
        this.heroPanel.SuspendLayout();
        this.serverCard.SuspendLayout();
        this.SuspendLayout();
        // 
        // navPanel
        // 
        this.navPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(20)))), ((int)(((byte)(28)))));
        this.navPanel.Controls.Add(this.discordButton);
        this.navPanel.Controls.Add(this.settingsButton);
        this.navPanel.Controls.Add(this.updateButton);
        this.navPanel.Controls.Add(this.playButton);
        this.navPanel.Controls.Add(this.brandLabel);
        this.navPanel.Controls.Add(this.brandTagline);
        this.navPanel.Controls.Add(this.footerPanel);
        this.navPanel.Dock = System.Windows.Forms.DockStyle.Left;
        this.navPanel.Location = new System.Drawing.Point(0, 0);
        this.navPanel.Name = "navPanel";
        this.navPanel.Padding = new System.Windows.Forms.Padding(20, 24, 20, 20);
        this.navPanel.Size = new System.Drawing.Size(260, 720);
        this.navPanel.TabIndex = 0;
        // 
        // discordButton
        // 
        this.discordButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.discordButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(97)))), ((int)(((byte)(242)))));
        this.discordButton.FlatAppearance.BorderSize = 0;
        this.discordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.discordButton.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.discordButton.ForeColor = System.Drawing.Color.White;
        this.discordButton.Location = new System.Drawing.Point(20, 600);
        this.discordButton.Name = "discordButton";
        this.discordButton.Size = new System.Drawing.Size(220, 40);
        this.discordButton.TabIndex = 5;
        this.discordButton.Text = "Discord community";
        this.discordButton.UseVisualStyleBackColor = false;
        this.discordButton.Click += new System.EventHandler(this.OnButtonClicked);
        // 
        // settingsButton
        // 
        this.settingsButton.BackColor = System.Drawing.Color.Transparent;
        this.settingsButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(78)))));
        this.settingsButton.FlatAppearance.BorderSize = 1;
        this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.settingsButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.settingsButton.ForeColor = System.Drawing.Color.White;
        this.settingsButton.Location = new System.Drawing.Point(20, 280);
        this.settingsButton.Name = "settingsButton";
        this.settingsButton.Size = new System.Drawing.Size(220, 42);
        this.settingsButton.TabIndex = 3;
        this.settingsButton.Text = "Iestatījumi";
        this.settingsButton.UseVisualStyleBackColor = false;
        this.settingsButton.Click += new System.EventHandler(this.OnButtonClicked);
        // 
        // updateButton
        // 
        this.updateButton.BackColor = System.Drawing.Color.Transparent;
        this.updateButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(64)))), ((int)(((byte)(78)))));
        this.updateButton.FlatAppearance.BorderSize = 1;
        this.updateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.updateButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.updateButton.ForeColor = System.Drawing.Color.White;
        this.updateButton.Location = new System.Drawing.Point(20, 232);
        this.updateButton.Name = "updateButton";
        this.updateButton.Size = new System.Drawing.Size(220, 42);
        this.updateButton.TabIndex = 2;
        this.updateButton.Text = "Atjauninājumi";
        this.updateButton.UseVisualStyleBackColor = false;
        this.updateButton.Click += new System.EventHandler(this.OnButtonClicked);
        // 
        // playButton
        // 
        this.playButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(186)))), ((int)(((byte)(142)))));
        this.playButton.FlatAppearance.BorderSize = 0;
        this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.playButton.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.playButton.ForeColor = System.Drawing.Color.White;
        this.playButton.Location = new System.Drawing.Point(20, 176);
        this.playButton.Name = "playButton";
        this.playButton.Size = new System.Drawing.Size(220, 48);
        this.playButton.TabIndex = 1;
        this.playButton.Text = "Spēlēt";
        this.playButton.UseVisualStyleBackColor = false;
        this.playButton.Click += new System.EventHandler(this.OnButtonClicked);
        // 
        // brandLabel
        // 
        this.brandLabel.AutoSize = true;
        this.brandLabel.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.brandLabel.ForeColor = System.Drawing.Color.White;
        this.brandLabel.Location = new System.Drawing.Point(16, 24);
        this.brandLabel.Name = "brandLabel";
        this.brandLabel.Size = new System.Drawing.Size(206, 32);
        this.brandLabel.TabIndex = 0;
        this.brandLabel.Text = "Mystic Launcher";
        // 
        // brandTagline
        // 
        this.brandTagline.AutoSize = true;
        this.brandTagline.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.brandTagline.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(132)))), ((int)(((byte)(150)))));
        this.brandTagline.Location = new System.Drawing.Point(20, 64);
        this.brandTagline.Name = "brandTagline";
        this.brandTagline.Size = new System.Drawing.Size(188, 19);
        this.brandTagline.TabIndex = 0;
        this.brandTagline.Text = "Mystic SA-MP kopienai Latvijā";
        // 
        // footerPanel
        // 
        this.footerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(14)))), ((int)(((byte)(22)))));
        this.footerPanel.Controls.Add(this.versionLabel);
        this.footerPanel.Controls.Add(this.statusIndicator);
        this.footerPanel.Controls.Add(this.statusDot);
        this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.footerPanel.Location = new System.Drawing.Point(20, 660);
        this.footerPanel.Margin = new System.Windows.Forms.Padding(0);
        this.footerPanel.Name = "footerPanel";
        this.footerPanel.Size = new System.Drawing.Size(220, 40);
        this.footerPanel.TabIndex = 6;
        // 
        // versionLabel
        // 
        this.versionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.versionLabel.AutoSize = true;
        this.versionLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.versionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(150)))), ((int)(((byte)(166)))));
        this.versionLabel.Location = new System.Drawing.Point(132, 12);
        this.versionLabel.Name = "versionLabel";
        this.versionLabel.Size = new System.Drawing.Size(76, 15);
        this.versionLabel.TabIndex = 2;
        this.versionLabel.Text = "v0.1 – vizuāls";
        this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // statusIndicator
        // 
        this.statusIndicator.AutoSize = true;
        this.statusIndicator.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.statusIndicator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(214)))), ((int)(((byte)(230)))));
        this.statusIndicator.Location = new System.Drawing.Point(32, 12);
        this.statusIndicator.Name = "statusIndicator";
        this.statusIndicator.Size = new System.Drawing.Size(66, 15);
        this.statusIndicator.TabIndex = 1;
        this.statusIndicator.Text = "Serveris ON";
        // 
        // statusDot
        // 
        this.statusDot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(186)))), ((int)(((byte)(142)))));
        this.statusDot.Location = new System.Drawing.Point(12, 14);
        this.statusDot.Name = "statusDot";
        this.statusDot.Size = new System.Drawing.Size(12, 12);
        this.statusDot.TabIndex = 0;
        // 
        // contentPanel
        // 
        this.contentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(16)))), ((int)(((byte)(24)))));
        this.contentPanel.Controls.Add(this.serverCard);
        this.contentPanel.Controls.Add(this.sectionHeader);
        this.contentPanel.Controls.Add(this.heroPanel);
        this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.contentPanel.Location = new System.Drawing.Point(260, 0);
        this.contentPanel.Name = "contentPanel";
        this.contentPanel.Padding = new System.Windows.Forms.Padding(28, 24, 28, 24);
        this.contentPanel.Size = new System.Drawing.Size(940, 720);
        this.contentPanel.TabIndex = 1;
        // 
        // heroPanel
        // 
        this.heroPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(23)))), ((int)(((byte)(32)))));
        this.heroPanel.Controls.Add(this.heroCallout);
        this.heroPanel.Controls.Add(this.heroTitle);
        this.heroPanel.Location = new System.Drawing.Point(28, 24);
        this.heroPanel.Name = "heroPanel";
        this.heroPanel.Padding = new System.Windows.Forms.Padding(24);
        this.heroPanel.Size = new System.Drawing.Size(884, 220);
        this.heroPanel.TabIndex = 0;
        // 
        // heroCallout
        // 
        this.heroCallout.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.heroCallout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
        this.heroCallout.Location = new System.Drawing.Point(28, 82);
        this.heroCallout.Name = "heroCallout";
        this.heroCallout.Size = new System.Drawing.Size(820, 104);
        this.heroCallout.TabIndex = 1;
        this.heroCallout.Text = "Moderns SA-MP palaidējs ar jaunu vizuālo stilu. Uzstādījumi, statusi un jaunumi tiek parādīti vienuviet, gatavs turpmākai funkcionalitātei.";
        // 
        // heroTitle
        // 
        this.heroTitle.AutoSize = true;
        this.heroTitle.Font = new System.Drawing.Font("Segoe UI Black", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.heroTitle.ForeColor = System.Drawing.Color.White;
        this.heroTitle.Location = new System.Drawing.Point(24, 24);
        this.heroTitle.Name = "heroTitle";
        this.heroTitle.Size = new System.Drawing.Size(523, 47);
        this.heroTitle.TabIndex = 0;
        this.heroTitle.Text = "Mystic – vizuālais prototips";
        // 
        // sectionHeader
        // 
        this.sectionHeader.AutoSize = true;
        this.sectionHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.sectionHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(169)))), ((int)(((byte)(189)))));
        this.sectionHeader.Location = new System.Drawing.Point(32, 272);
        this.sectionHeader.Name = "sectionHeader";
        this.sectionHeader.Size = new System.Drawing.Size(189, 21);
        this.sectionHeader.TabIndex = 2;
        this.sectionHeader.Text = "Servera informācija";
        // 
        // serverCard
        // 
        this.serverCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(23)))), ((int)(((byte)(32)))));
        this.serverCard.Controls.Add(this.serverActionButton);
        this.serverCard.Controls.Add(this.serverSubtitle);
        this.serverCard.Controls.Add(this.serverTitle);
        this.serverCard.Location = new System.Drawing.Point(28, 308);
        this.serverCard.Name = "serverCard";
        this.serverCard.Padding = new System.Windows.Forms.Padding(24);
        this.serverCard.Size = new System.Drawing.Size(884, 180);
        this.serverCard.TabIndex = 3;
        // 
        // serverActionButton
        // 
        this.serverActionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.serverActionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(186)))), ((int)(((byte)(142)))));
        this.serverActionButton.FlatAppearance.BorderSize = 0;
        this.serverActionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.serverActionButton.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.serverActionButton.ForeColor = System.Drawing.Color.White;
        this.serverActionButton.Location = new System.Drawing.Point(724, 28);
        this.serverActionButton.Name = "serverActionButton";
        this.serverActionButton.Size = new System.Drawing.Size(136, 40);
        this.serverActionButton.TabIndex = 2;
        this.serverActionButton.Text = "Pievienoties";
        this.serverActionButton.UseVisualStyleBackColor = false;
        this.serverActionButton.Click += new System.EventHandler(this.OnButtonClicked);
        // 
        // serverSubtitle
        // 
        this.serverSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        this.serverSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
        this.serverSubtitle.Location = new System.Drawing.Point(28, 80);
        this.serverSubtitle.Name = "serverSubtitle";
        this.serverSubtitle.Size = new System.Drawing.Size(690, 80);
        this.serverSubtitle.TabIndex = 1;
        this.serverSubtitle.Text = "Detalizēta servera karte ar spēlētāju skaitu, servera IP un statusu. Reālais savienojums un datu ielāde tiks pievienota nākamajos etapos.";
        // 
        // serverTitle
        // 
        this.serverTitle.AutoSize = true;
        this.serverTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.serverTitle.ForeColor = System.Drawing.Color.White;
        this.serverTitle.Location = new System.Drawing.Point(24, 28);
        this.serverTitle.Name = "serverTitle";
        this.serverTitle.Size = new System.Drawing.Size(249, 30);
        this.serverTitle.TabIndex = 0;
        this.serverTitle.Text = "Mystic RP — SA-MP LV";
        // 
        // MainForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(13)))), ((int)(((byte)(18)))));
        this.ClientSize = new System.Drawing.Size(1200, 720);
        this.Controls.Add(this.contentPanel);
        this.Controls.Add(this.navPanel);
        this.DoubleBuffered = true;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "MainForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Mystic Launcher";
        this.navPanel.ResumeLayout(false);
        this.navPanel.PerformLayout();
        this.footerPanel.ResumeLayout(false);
        this.footerPanel.PerformLayout();
        this.contentPanel.ResumeLayout(false);
        this.contentPanel.PerformLayout();
        this.heroPanel.ResumeLayout(false);
        this.heroPanel.PerformLayout();
        this.serverCard.ResumeLayout(false);
        this.serverCard.PerformLayout();
        this.ResumeLayout(false);

    }

    #endregion

    private Panel navPanel;
    private Button playButton;
    private Label brandLabel;
    private Label brandTagline;
    private Button settingsButton;
    private Button updateButton;
    private Panel footerPanel;
    private Label versionLabel;
    private Label statusIndicator;
    private Panel statusDot;
    private Button discordButton;
    private Panel contentPanel;
    private Panel heroPanel;
    private Label heroCallout;
    private Label heroTitle;
    private Label sectionHeader;
    private Panel serverCard;
    private Button serverActionButton;
    private Label serverSubtitle;
    private Label serverTitle;
}
