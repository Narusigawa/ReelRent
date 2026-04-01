using System.Drawing;
using System.Windows.Forms;

namespace ReelRent
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblConfirmPassword;
        private TextBox txtConfirmPassword;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPhone;
        private TextBox txtPhone;
        private Button btnRegister;
        private Button btnBack;
        private Button btnClose;
        private Panel mainPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.mainPanel = new Panel();
            this.lblTitle = new Label();
            this.lblUsername = new Label();
            this.txtUsername = new TextBox();
            this.lblPassword = new Label();
            this.txtPassword = new TextBox();
            this.lblConfirmPassword = new Label();
            this.txtConfirmPassword = new TextBox();
            this.lblFullName = new Label();
            this.txtFullName = new TextBox();
            this.lblEmail = new Label();
            this.txtEmail = new TextBox();
            this.lblPhone = new Label();
            this.txtPhone = new TextBox();
            this.btnRegister = new Button();
            this.btnBack = new Button();
            this.btnClose = new Button();
            this.SuspendLayout();

            // RegisterForm
            this.ClientSize = new Size(500, 620);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Theme.BackColor;
            this.ForeColor = Theme.ForeColor;
            this.Padding = new Padding(1); // для рамки

            // mainPanel – фон формы, отступы для рамки
            this.mainPanel.Dock = DockStyle.Fill;
            this.mainPanel.BackColor = Color.White;
            this.mainPanel.Padding = new Padding(1); // внутренняя рамка (белая)

            // Панель с содержимым (чтобы отделить от белой рамки)
            Panel contentPanel = new Panel();
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.BackColor = Theme.BackColor;
            contentPanel.Padding = new Padding(10);

            // lblTitle
            this.lblTitle.Text = "Регистрация";
            this.lblTitle.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            this.lblTitle.ForeColor = Theme.AccentForeColor;
            this.lblTitle.AutoSize = true;

            // Поля (стили общие)
            var fieldFont = new Font("Segoe UI", 12);
            var fieldSize = new Size(300, 30);
            foreach (var txt in new TextBox[] { txtUsername, txtPassword, txtConfirmPassword, txtFullName, txtEmail, txtPhone })
            {
                txt.Font = fieldFont;
                txt.Size = fieldSize;
                txt.BackColor = Theme.PanelColor;
                txt.ForeColor = Theme.ForeColor;
                txt.BorderStyle = BorderStyle.FixedSingle;
            }
            foreach (var lbl in new Label[] { lblUsername, lblPassword, lblConfirmPassword, lblFullName, lblEmail, lblPhone })
            {
                lbl.Font = fieldFont;
                lbl.AutoSize = true;
                lbl.ForeColor = Theme.ForeColor;
            }

            // Тексты меток
            this.lblUsername.Text = "Логин *:";
            this.lblPassword.Text = "Пароль *:";
            this.lblConfirmPassword.Text = "Подтверждение пароля *:";
            this.lblFullName.Text = "ФИО:";
            this.lblEmail.Text = "Email:";
            this.lblPhone.Text = "Телефон:";

            this.txtPassword.PasswordChar = '*';
            this.txtConfirmPassword.PasswordChar = '*';

            // Кнопка регистрации
            this.btnRegister.Text = "Зарегистрироваться";
            this.btnRegister.FlatStyle = FlatStyle.Flat;
            this.btnRegister.BackColor = Theme.ButtonHoverColor;
            this.btnRegister.ForeColor = Theme.ForeColor;
            this.btnRegister.Size = new Size(200, 40);
            this.btnRegister.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnRegister.Cursor = Cursors.Hand;
            this.btnRegister.FlatAppearance.BorderSize = 0;

            // Кнопка "Назад" (левая верхняя)
            this.btnBack.Text = "← Назад";
            this.btnBack.FlatStyle = FlatStyle.Flat;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.BackColor = Color.Transparent;
            this.btnBack.ForeColor = Theme.ForeColor;
            this.btnBack.Size = new Size(80, 35);
            this.btnBack.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnBack.Cursor = Cursors.Hand;
            this.btnBack.Location = new Point(10, 10);
            this.btnBack.MouseEnter += (s, e) => btnBack.BackColor = Theme.ButtonHoverColor;
            this.btnBack.MouseLeave += (s, e) => btnBack.BackColor = Color.Transparent;
            this.btnBack.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            // Кнопка закрытия (правая верхняя)
            this.btnClose.Text = "✖";
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.BackColor = Color.Transparent;
            this.btnClose.ForeColor = Theme.ForeColor;
            this.btnClose.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnClose.Size = new Size(35, 35);
            this.btnClose.Cursor = Cursors.Hand;
            this.btnClose.MouseEnter += (s, e) => btnClose.BackColor = Theme.ButtonHoverColor;
            this.btnClose.MouseLeave += (s, e) => btnClose.BackColor = Color.Transparent;
            this.btnClose.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            // Добавление элементов в contentPanel
            contentPanel.Controls.Add(this.lblTitle);
            contentPanel.Controls.Add(this.lblUsername);
            contentPanel.Controls.Add(this.txtUsername);
            contentPanel.Controls.Add(this.lblPassword);
            contentPanel.Controls.Add(this.txtPassword);
            contentPanel.Controls.Add(this.lblConfirmPassword);
            contentPanel.Controls.Add(this.txtConfirmPassword);
            contentPanel.Controls.Add(this.lblFullName);
            contentPanel.Controls.Add(this.txtFullName);
            contentPanel.Controls.Add(this.lblEmail);
            contentPanel.Controls.Add(this.txtEmail);
            contentPanel.Controls.Add(this.lblPhone);
            contentPanel.Controls.Add(this.txtPhone);
            contentPanel.Controls.Add(this.btnRegister);
            contentPanel.Controls.Add(this.btnBack);
            contentPanel.Controls.Add(this.btnClose);

            this.mainPanel.Controls.Add(contentPanel);
            this.Controls.Add(this.mainPanel);

            // Центрирование элементов (кроме кнопок в углах)
            this.Resize += (s, e) => CenterControls(contentPanel);

            // Обновление позиции крестика при изменении размера окна
            this.Resize += (s, e) => btnClose.Location = new Point(contentPanel.ClientSize.Width - btnClose.Width - 10, 10);

            CenterControls(contentPanel);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void CenterControls(Panel contentPanel)
        {
            if (contentPanel == null) return;

            int centerX = contentPanel.ClientSize.Width / 2;
            int currentY = 30; // отступ сверху, чтобы не налезать на кнопку «Назад»

            lblTitle.Location = new Point(centerX - lblTitle.Width / 2, currentY);
            currentY += lblTitle.Height + 25;

            // Функция центрирования пары (метка, поле)
            void PlaceField(Label label, TextBox textBox)
            {
                label.Location = new Point(centerX - textBox.Width / 2, currentY);
                currentY += label.Height + 5;
                textBox.Location = new Point(centerX - textBox.Width / 2, currentY);
                currentY += textBox.Height + 12;
            }

            PlaceField(lblUsername, txtUsername);
            PlaceField(lblPassword, txtPassword);
            PlaceField(lblConfirmPassword, txtConfirmPassword);
            PlaceField(lblFullName, txtFullName);
            PlaceField(lblEmail, txtEmail);
            PlaceField(lblPhone, txtPhone);

            // Увеличиваем отступ перед кнопкой
            currentY += 20;
            btnRegister.Location = new Point(centerX - btnRegister.Width / 2, currentY);
        }
    }
}