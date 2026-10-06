using System;
using System.Drawing;
using System.Windows.Forms;

namespace AshkanHotelManager
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            Localize();
            App.ApplyDirection(this);
            heroPanel.Dock = App.Persian ? DockStyle.Right : DockStyle.Left;
            var art = PremiumAssets.TryLoad("hotel-hero.jpg");
            if (art != null) { heroPanel.BackgroundImage = art; heroPanel.BackgroundImageLayout = ImageLayout.Zoom; }
            Ui.PolishTree(this);
        }

        private void Localize()
        {
            loginTitle.Text = App.T("login");
            usernameLabel.Text = App.T("user");
            passwordLabel.Text = App.T("pass");
            loginButton.Text = App.T("login");
            languageButton.Text = App.Persian ? "🌐  English" : "🌐  فارسی";
            loginSubtitle.Text = App.Persian
                ? "برای مدیریت رزروها، اتاق‌ها و عملیات هتل وارد شوید."
                : "Welcome back. Sign in to manage hotel operations.";
            demoHint.Text = App.Persian ? "حساب نمایشی: admin / 1234" : "Demo account: admin / 1234";
            heroSubtitle.Text = App.Persian
                ? "رزرو • پذیرش • حساب مهمان\r\nخانه‌داری • صورتحساب • عملیات"
                : "Reservations • Front Desk • Guest Folio\r\nHousekeeping • Billing • Operations";
            loginTitle.TextAlign = usernameLabel.TextAlign = passwordLabel.TextAlign =
                App.Persian ? ContentAlignment.MiddleRight : ContentAlignment.MiddleLeft;
            loginSubtitle.TextAlign = App.Persian ? ContentAlignment.MiddleRight : ContentAlignment.MiddleLeft;
        }

        private void ChangeLanguage(object sender, EventArgs e)
        {
            App.SetLanguage(!App.Persian);
            Localize();
            App.ApplyDirection(this);
            heroPanel.Dock = App.Persian ? DockStyle.Right : DockStyle.Left;
            loginPanel.Left = App.Persian ? 60 : 500;
            languageButton.Left = App.Persian ? 34 : 235;
            Refresh();
        }

        private void Login(object sender, EventArgs e)
        {
            string role;
            if (DataStore.Authenticate(usernameBox.Text.Trim(), passwordBox.Text, out role))
            {
                Hide();
                using (var main = new MainForm()) main.ShowDialog();
                Close();
                return;
            }

            DataStore.Log("Sign in failed", "Security", usernameBox.Text.Trim());
            MessageBox.Show(App.T("invalidLogin"), App.T("login"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            passwordBox.SelectAll();
            passwordBox.Focus();
        }
    }
}
