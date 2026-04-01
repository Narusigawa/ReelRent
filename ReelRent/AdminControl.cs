using System;
using System.Windows.Forms;

namespace ReelRent
{
    public partial class AdminControl : UserControl
    {
        public event EventHandler BackButtonClicked;

        private ManageMoviesControl _manageMoviesControl;

        public AdminControl()
        {
            InitializeComponent();
            _manageMoviesControl = new ManageMoviesControl();
            _manageMoviesControl.BackButtonClicked += (s, e) => ShowMenu();
            ShowMenu();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            BackButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnManageMovies_Click(object sender, EventArgs e)
        {
            ShowManageMovies();
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

        private void ShowMenu()
        {
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(btnBack);
            panelContainer.Controls.Add(lblTitle);
            panelContainer.Controls.Add(btnManageMovies);
            panelContainer.Controls.Add(btnManageBanners);
            panelContainer.Controls.Add(btnManageUsers);
        }

        private void ShowManageMovies()
        {
            panelContainer.Controls.Clear();
            _manageMoviesControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(_manageMoviesControl);
        }
    }
}