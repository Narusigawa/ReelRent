using System.Drawing;
using System.Windows.Forms;

namespace ReelRent
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel borderPanel;
        private Panel contentPanel;
        private Label lblTitle;
        private Label lblLogin;
        private TextBox txtLogin;
        private Label lblPassword;
        private TextBox txtPassword;
        private LinkLabel linkRegister;
        private Button btnLogin;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.borderPanel = new Panel();
            this.contentPanel = new Panel();
            this.lblTitle = new Label();
            this.lblLogin = new Label();
            this.txtLogin = new TextBox();
            this.lblPassword = new Label();
            this.txtPassword = new TextBox();
            this.linkRegister = new LinkLabel();
            this.btnLogin = new Button();
            this.btnClose = new Button();

            this.SuspendLayout();

            // LoginForm
            this.ClientSize = new Size(400, 450);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Theme.BackColor;

            // borderPanel – белая рамка по краям
            this.borderPanel.Dock = DockStyle.Fill;
            this.borderPanel.BackColor = Color.White;
            this.borderPanel.Padding = new Padding(1); // толщина рамки

            // contentPanel – внутренний контент с тёмным фоном
            this.contentPanel.Dock = DockStyle.Fill;
            this.contentPanel.BackColor = Theme.BackColor;
            this.contentPanel.Padding = new Padding(20);

            // lblTitle
            this.lblTitle.Text = "Авторизация";
            this.lblTitle.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            this.lblTitle.ForeColor = Theme.AccentForeColor;
            this.lblTitle.AutoSize = true;

            // lblLogin
            this.lblLogin.Text = "Логин:";
            this.lblLogin.Font = new Font("Segoe UI", 12);
            this.lblLogin.ForeColor = Theme.AccentForeColor;
            this.lblLogin.AutoSize = true;

            // txtLogin
            this.txtLogin.Font = new Font("Segoe UI", 12);
            this.txtLogin.Size = new Size(280, 30);
            this.txtLogin.BackColor = Theme.PanelColor;
            this.txtLogin.ForeColor = Theme.ForeColor;
            this.txtLogin.BorderStyle = BorderStyle.FixedSingle;

            // lblPassword
            this.lblPassword.Text = "Пароль:";
            this.lblPassword.Font = new Font("Segoe UI", 12);
            this.lblPassword.ForeColor = Theme.AccentForeColor;
            this.lblPassword.AutoSize = true;

            // txtPassword
            this.txtPassword.Font = new Font("Segoe UI", 12);
            this.txtPassword.Size = new Size(280, 30);
            this.txtPassword.BackColor = Theme.PanelColor;
            this.txtPassword.ForeColor = Theme.ForeColor;
            this.txtPassword.BorderStyle = BorderStyle.FixedSingle;
            this.txtPassword.PasswordChar = '*';

            // linkRegister
            this.linkRegister.Text = "Нет аккаунта? Зарегистрироваться";
            this.linkRegister.LinkColor = Theme.AccentForeColor;
            this.linkRegister.ActiveLinkColor = Theme.ButtonHoverColor;
            this.linkRegister.Font = new Font("Segoe UI", 10);
            this.linkRegister.AutoSize = true;
            this.linkRegister.Cursor = Cursors.Hand;
            this.linkRegister.LinkClicked += LinkRegister_LinkClicked;

            // btnLogin
            this.btnLogin.Text = "Войти";
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.BackColor = Theme.ButtonHoverColor;
            this.btnLogin.ForeColor = Theme.ForeColor;
            this.btnLogin.Size = new Size(120, 40);
            this.btnLogin.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnLogin.Cursor = Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.Click += BtnLogin_Click;

            // btnClose – крестик
            this.btnClose.Text = "✖";
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.BackColor = Color.Transparent;
            this.btnClose.ForeColor = Theme.ForeColor;
            this.btnClose.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnClose.Size = new Size(40, 40);
            this.btnClose.Cursor = Cursors.Hand;
            this.btnClose.Click += BtnClose_Click;
            this.btnClose.MouseEnter += (s, e) => btnClose.BackColor = Theme.ButtonHoverColor;
            this.btnClose.MouseLeave += (s, e) => btnClose.BackColor = Color.Transparent;

            // Добавляем элементы в contentPanel
            this.contentPanel.Controls.Add(this.lblTitle);
            this.contentPanel.Controls.Add(this.lblLogin);
            this.contentPanel.Controls.Add(this.txtLogin);
            this.contentPanel.Controls.Add(this.lblPassword);
            this.contentPanel.Controls.Add(this.txtPassword);
            this.contentPanel.Controls.Add(this.linkRegister);
            this.contentPanel.Controls.Add(this.btnLogin);
            this.contentPanel.Controls.Add(this.btnClose);

            // Добавляем панели
            this.borderPanel.Controls.Add(this.contentPanel);
            this.Controls.Add(this.borderPanel);

            // Центрирование
            this.Resize += (s, e) => CenterControls();
            CenterControls();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void CenterControls()
        {
            if (contentPanel == null) return;

            int centerX = contentPanel.ClientSize.Width / 2;
            int currentY = 60;

            // Заголовок
            lblTitle.Location = new Point(centerX - lblTitle.Width / 2, currentY);
            currentY += lblTitle.Height + 40;

            // Логин (надпись слева, поле под ней)
            lblLogin.Location = new Point(centerX - txtLogin.Width / 2, currentY);
            currentY += lblLogin.Height + 5;
            txtLogin.Location = new Point(centerX - txtLogin.Width / 2, currentY);
            currentY += txtLogin.Height + 20;

            // Пароль
            lblPassword.Location = new Point(centerX - txtPassword.Width / 2, currentY);
            currentY += lblPassword.Height + 5;
            txtPassword.Location = new Point(centerX - txtPassword.Width / 2, currentY);
            currentY += txtPassword.Height + 25;

            // Ссылка на регистрацию (теперь над кнопкой)
            linkRegister.Location = new Point(centerX - linkRegister.Width / 2, currentY);
            currentY += linkRegister.Height + 15;

            // Кнопка входа
            btnLogin.Location = new Point(centerX - btnLogin.Width / 2, currentY);

            // Крестик – правый верхний угол
            btnClose.Location = new Point(contentPanel.ClientSize.Width - btnClose.Width - 5, 5);
        }
    }
}