    using System;
    using System.Drawing;
    using System.Windows.Forms;

    namespace ReelRent
    {
        public partial class ProfileControl : UserControl
        {
            public event EventHandler BackButtonClicked;

            public ProfileControl()
            {
                InitializeComponent();
                LoadUserData();
                LoadRentals();
            }

            private void LoadUserData()
            {
                if (Session.CurrentUser != null)
                {
                    lblInfo.Text = $"Пользователь: {Session.CurrentUser.Username}\n" +
                                   $"Имя: {Session.CurrentUser.FullName ?? "—"}\n" +
                                   $"Email: {Session.CurrentUser.Email ?? "—"}\n" +
                                   $"Телефон: {Session.CurrentUser.Phone ?? "—"}";
                }
                else
                {
                    lblInfo.Text = "Не авторизован";
                }
            }

            private void LoadRentals()
            {
                // Пока заглушка, позже запрос к БД
                lstCurrentRentals.Items.Clear();
                lstHistory.Items.Clear();

                lstCurrentRentals.Items.Add("Фильм 1 (до 01.04.2025)");
                lstCurrentRentals.Items.Add("Фильм 2 (до 15.04.2025)");

                lstHistory.Items.Add("Фильм 3 (возвращён 10.03.2025)");
                lstHistory.Items.Add("Фильм 4 (возвращён 20.02.2025)");
            }

            private void btnBack_Click(object sender, EventArgs e)
            {
                BackButtonClicked?.Invoke(this, EventArgs.Empty);
            }
        }
    }