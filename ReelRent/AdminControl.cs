using System;
using System.Windows.Forms;

namespace ReelRent
{
    public partial class AdminControl : UserControl
    {
        public event EventHandler BackButtonClicked;

        public AdminControl()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            BackButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            // Пока заглушка – позже откроем форму добавления фильма
            MessageBox.Show("Форма добавления фильма (в разработке).", "Администрирование",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Управление пользователями (в разработке).", "Администрирование",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnManageBanners_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Управление баннерами (в разработке).", "Администрирование",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}