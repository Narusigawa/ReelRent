using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ReelRent
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            txtPhone.KeyPress += TxtPhone_KeyPress;
        }

        private void TxtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Только цифры, Backspace, Delete
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string confirm = txtConfirmPassword.Text;
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();

            var errors = new System.Collections.Generic.List<string>();

            // --- Логин ---
            if (string.IsNullOrWhiteSpace(username))
                errors.Add("Логин обязателен.");
            else if (username.Length > 20)
                errors.Add("Логин не должен превышать 20 символов.");

            // --- Пароль ---
            if (string.IsNullOrWhiteSpace(password))
                errors.Add("Пароль обязателен.");
            else
            {
                if (password.Length < 6)
                    errors.Add("Пароль должен содержать не менее 6 символов.");
                if (!Regex.IsMatch(password, @"[A-Za-z]"))
                    errors.Add("Пароль должен содержать хотя бы одну букву.");
                if (!Regex.IsMatch(password, @"\d"))
                    errors.Add("Пароль должен содержать хотя бы одну цифру.");
            }

            // --- Подтверждение пароля ---
            if (password != confirm)
                errors.Add("Пароли не совпадают.");

            // --- Email с проверкой домена ---
            if (!string.IsNullOrEmpty(email))
            {
                // Базовая проверка формата
                if (!email.Contains("@") || !email.Contains(".") || email.IndexOf('@') == 0 || email.LastIndexOf('.') < email.IndexOf('@') + 2)
                {
                    errors.Add("Введите корректный email (например, name@domain.ru).");
                }
                else
                {
                    string domain = email.Substring(email.IndexOf('@') + 1).ToLower();
                    // Список разрешённых доменов
                    string[] allowedDomains = { "gmail.com", "yandex.ru", "mail.ru", "outlook.com", "rambler.ru", "inbox.ru", "list.ru", "bk.ru" };
                    if (!Array.Exists(allowedDomains, d => d == domain))
                    {
                        errors.Add($"Разрешены только следующие домены email: {string.Join(", ", allowedDomains)}.");
                    }
                }
            }

            // --- Телефон (ровно 11 цифр, если заполнен) ---
            if (!string.IsNullOrEmpty(phone))
            {
                string digitsOnly = Regex.Replace(phone, @"\D", "");
                if (digitsOnly.Length != 11)
                    errors.Add("Телефон должен содержать ровно 11 цифр (например, 91234567890).");
            }

            // Если есть ошибки – показываем одно окно
            if (errors.Count > 0)
            {
                MessageBox.Show(string.Join("\n\n", errors), "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка существования пользователя в БД
            if (DatabaseHelper.UserExists(username, email))
            {
                MessageBox.Show("Пользователь с таким логином или email уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Регистрация
            bool success = DatabaseHelper.RegisterUser(username, password, fullName, email, phone);
            if (success)
            {
                MessageBox.Show("Регистрация прошла успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Ошибка при регистрации. Попробуйте позже.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}