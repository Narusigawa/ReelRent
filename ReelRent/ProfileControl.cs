using System;
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
        }

        private void LoadUserData()
        {
            if (Session.CurrentUser != null)
            {
                lblUsername.Text = Session.CurrentUser.Username;
                lblFullName.Text = Session.CurrentUser.FullName ?? "—";
                lblEmail.Text = Session.CurrentUser.Email ?? "—";
                lblPhone.Text = Session.CurrentUser.Phone ?? "—";
                lblAddress.Text = Session.CurrentUser.DeliveryAddress ?? "—";
            }
            else
            {
                lblUsername.Text = "Не авторизован";
                lblFullName.Text = "—";
                lblEmail.Text = "—";
                lblPhone.Text = "—";
                lblAddress.Text = "—";
            }
        }

        private void BtnEditProfile_Click(object sender, EventArgs e)
        {
            using (var editForm = new EditProfileForm())
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadUserData();
                }
            }
        }

        private void BtnActiveOrders_Click(object sender, EventArgs e)
        {
            using (var ordersForm = new OrdersListForm(onlyActive: true))
            {
                ordersForm.ShowDialog();
            }
        }

        private void BtnHistoryOrders_Click(object sender, EventArgs e)
        {
            using (var ordersForm = new OrdersListForm(onlyActive: false))
            {
                ordersForm.ShowDialog();
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти из аккаунта?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Session.CurrentUser = null; // этого достаточно, IsAuthenticated сам станет false
                MessageBox.Show("Вы вышли из аккаунта.", "Выход", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Вызываем событие, чтобы основная форма переключилась на каталог
                BackButtonClicked?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}