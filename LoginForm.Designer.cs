namespace AshkanHotelManager
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel heroPanel;
        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.Label brandMark;
        private System.Windows.Forms.Label heroTitle;
        private System.Windows.Forms.Label heroSubtitle;
        private System.Windows.Forms.Label loginTitle;
        private System.Windows.Forms.Label loginSubtitle;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label demoHint;
        private System.Windows.Forms.Button languageButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.heroPanel = new System.Windows.Forms.Panel();
            this.loginPanel = new System.Windows.Forms.Panel();
            this.brandMark = new System.Windows.Forms.Label();
            this.heroTitle = new System.Windows.Forms.Label();
            this.heroSubtitle = new System.Windows.Forms.Label();
            this.loginTitle = new System.Windows.Forms.Label();
            this.loginSubtitle = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.demoHint = new System.Windows.Forms.Label();
            this.languageButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // heroPanel
            this.heroPanel.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.heroPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.heroPanel.Width = 430;
            this.heroPanel.Controls.Add(this.heroSubtitle);
            this.heroPanel.Controls.Add(this.heroTitle);
            this.heroPanel.Controls.Add(this.brandMark);
            // brandMark
            this.brandMark.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.brandMark.ForeColor = System.Drawing.Color.White;
            this.brandMark.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.brandMark.Location = new System.Drawing.Point(52, 72);
            this.brandMark.Size = new System.Drawing.Size(62, 62);
            this.brandMark.Text = "A";
            this.brandMark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // heroTitle
            this.heroTitle.ForeColor = System.Drawing.Color.White;
            this.heroTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.heroTitle.Location = new System.Drawing.Point(50, 166);
            this.heroTitle.Size = new System.Drawing.Size(330, 110);
            this.heroTitle.Text = "AuroraStay\r\nHotel Operations Suite";
            // heroSubtitle
            this.heroSubtitle.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.heroSubtitle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.heroSubtitle.Location = new System.Drawing.Point(53, 300);
            this.heroSubtitle.Size = new System.Drawing.Size(320, 90);
            this.heroSubtitle.Text = "Reservations • Front Desk • Guest Folio\r\nHousekeeping • Billing • Operations";
            // loginPanel
            this.loginPanel.BackColor = System.Drawing.Color.FromArgb(24, 35, 56);
            this.loginPanel.Location = new System.Drawing.Point(500, 62);
            this.loginPanel.Size = new System.Drawing.Size(390, 475);
            this.loginPanel.Padding = new System.Windows.Forms.Padding(34);
            this.loginPanel.Controls.Add(this.languageButton);
            this.loginPanel.Controls.Add(this.demoHint);
            this.loginPanel.Controls.Add(this.loginButton);
            this.loginPanel.Controls.Add(this.passwordBox);
            this.loginPanel.Controls.Add(this.passwordLabel);
            this.loginPanel.Controls.Add(this.usernameBox);
            this.loginPanel.Controls.Add(this.usernameLabel);
            this.loginPanel.Controls.Add(this.loginSubtitle);
            this.loginPanel.Controls.Add(this.loginTitle);
            // languageButton
            this.languageButton.BackColor = System.Drawing.Color.FromArgb(30, 45, 70);
            this.languageButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.languageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.languageButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(65, 82, 110);
            this.languageButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.languageButton.ForeColor = System.Drawing.Color.White;
            this.languageButton.Location = new System.Drawing.Point(235, 18);
            this.languageButton.Size = new System.Drawing.Size(116, 34);
            this.languageButton.Text = "English";
            this.languageButton.UseVisualStyleBackColor = false;
            this.languageButton.Click += new System.EventHandler(this.ChangeLanguage);
            // loginTitle
            this.loginTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.loginTitle.ForeColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.loginTitle.Location = new System.Drawing.Point(34, 36);
            this.loginTitle.Size = new System.Drawing.Size(320, 46);
            this.loginTitle.Text = "Sign in";
            // loginSubtitle
            this.loginSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.loginSubtitle.ForeColor = System.Drawing.Color.FromArgb(166, 181, 203);
            this.loginSubtitle.Location = new System.Drawing.Point(36, 88);
            this.loginSubtitle.Size = new System.Drawing.Size(315, 45);
            this.loginSubtitle.Text = "Welcome back. Sign in to manage hotel operations.";
            // usernameLabel
            this.usernameLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.usernameLabel.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.usernameLabel.Location = new System.Drawing.Point(36, 151);
            this.usernameLabel.Size = new System.Drawing.Size(315, 25);
            this.usernameLabel.Text = "Username";
            // usernameBox
            this.usernameBox.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.usernameBox.Location = new System.Drawing.Point(39, 180);
            this.usernameBox.Size = new System.Drawing.Size(312, 32);
            this.usernameBox.Text = "admin";
            // passwordLabel
            this.passwordLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.passwordLabel.ForeColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.passwordLabel.Location = new System.Drawing.Point(36, 235);
            this.passwordLabel.Size = new System.Drawing.Size(315, 25);
            this.passwordLabel.Text = "Password";
            // passwordBox
            this.passwordBox.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.passwordBox.Location = new System.Drawing.Point(39, 264);
            this.passwordBox.Size = new System.Drawing.Size(312, 32);
            this.passwordBox.UseSystemPasswordChar = true;
            // loginButton
            this.loginButton.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.loginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton.FlatAppearance.BorderSize = 0;
            this.loginButton.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.loginButton.ForeColor = System.Drawing.Color.White;
            this.loginButton.Location = new System.Drawing.Point(39, 326);
            this.loginButton.Size = new System.Drawing.Size(312, 48);
            this.loginButton.Text = "Sign in";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.Login);
            // demoHint
            this.demoHint.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.demoHint.ForeColor = System.Drawing.Color.FromArgb(166, 181, 203);
            this.demoHint.Location = new System.Drawing.Point(39, 397);
            this.demoHint.Size = new System.Drawing.Size(312, 40);
            this.demoHint.Text = "Demo account: admin / 1234";
            this.demoHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // LoginForm
            this.AcceptButton = this.loginButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(13, 22, 40);
            this.ClientSize = new System.Drawing.Size(950, 600);
            this.Controls.Add(this.loginPanel);
            this.Controls.Add(this.heroPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AuroraStay — Hotel Operations Suite";
            this.ResumeLayout(false);
        }
    }
}
