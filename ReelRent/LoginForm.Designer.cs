using System;
using System.Drawing;
using System.Windows.Forms;

namespace ReelRent
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblLogin;
        private TextBox txtLogin;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnCancel;
        private Label lblTitle;
        private Panel titlePanel;
        private Panel contentPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // ========== Форма ==========
            this.ClientSize = new Size(450, 380);
            this.Text = "Вход в личный кабинет";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Theme.BackColor;
            this.ForeColor = Theme.ForeColor;

            // ========== Верхняя панель (заголовок) ==========
            this.titlePanel = new Panel();
            this.titlePanel.Dock = DockStyle.Top;
            this.titlePanel.Height = 70;
            this.titlePanel.BackColor = Theme.PanelColor;

            this.lblTitle = new Label();
            this.lblTitle.Text = "Авторизация";
            this.lblTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            this.lblTitle.ForeColor = Theme.AccentForeColor;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(20, 15);
            this.titlePanel.Controls.Add(this.lblTitle);

            // ========== Контентная панель ==========
            this.contentPanel = new Panel();
            this.contentPanel.Dock = DockStyle.Fill;
            this.contentPanel.BackColor = Color.Transparent;
            this.contentPanel.Padding = new Padding(30, 20, 30, 20);

            // Логин
            this.lblLogin = new Label();
            this.lblLogin.Text = "Логин:";
            this.lblLogin.Font = new Font("Segoe UI", 11);
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new Point(0, 10);
            this.lblLogin.ForeColor = Theme.ForeColor;

            this.txtLogin = new TextBox();
            this.txtLogin.Font = new Font("Segoe UI", 11);
            this.txtLogin.Width = 380;
            this.txtLogin.BackColor = Theme.PanelColor;
            this.txtLogin.ForeColor = Theme.ForeColor;
            this.txtLogin.BorderStyle = BorderStyle.FixedSingle;
            this.txtLogin.Location = new Point(0, 35);

            // Пароль
            this.lblPassword = new Label();
            this.lblPassword.Text = "Пароль:";
            this.lblPassword.Font = new Font("Segoe UI", 11);
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new Point(0, 75);
            this.lblPassword.ForeColor = Theme.ForeColor;

            this.txtPassword = new TextBox();
            this.txtPassword.Font = new Font("Segoe UI", 11);
            this.txtPassword.Width = 380;
            this.txtPassword.BackColor = Theme.PanelColor;
            this.txtPassword.ForeColor = Theme.ForeColor;
            this.txtPassword.BorderStyle = BorderStyle.FixedSingle;
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Location = new Point(0, 100);

            // Кнопки
            this.btnLogin = new Button();
            this.btnLogin.Text = "Войти";
            this.btnLogin.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.BackColor = Theme.ButtonHoverColor;
            this.btnLogin.ForeColor = Theme.ForeColor;
            this.btnLogin.Size = new Size(120, 40);
            this.btnLogin.Cursor = Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.Location = new Point(0, 150);

            this.btnCancel = new Button();
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Font = new Font("Segoe UI", 11);
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.BackColor = Theme.PanelColor;
            this.btnCancel.ForeColor = Theme.ForeColor;
            this.btnCancel.Size = new Size(120, 40);
            this.btnCancel.Cursor = Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Location = new Point(130, 150);

            // Размещение кнопок рядом
            this.btnLogin.Location = new Point(0, 150);
            this.btnCancel.Location = new Point(130, 150);

            // Добавляем элементы в contentPanel
            this.contentPanel.Controls.Add(this.lblLogin);
            this.contentPanel.Controls.Add(this.txtLogin);
            this.contentPanel.Controls.Add(this.lblPassword);
            this.contentPanel.Controls.Add(this.txtPassword);
            this.contentPanel.Controls.Add(this.btnLogin);
            this.contentPanel.Controls.Add(this.btnCancel);

            // Добавляем панели на форму
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.titlePanel);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}