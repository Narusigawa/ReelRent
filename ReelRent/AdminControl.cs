using System;
using System.Windows.Forms;

namespace ReelRent
{
    public partial class AdminControl : UserControl
    {
        public event EventHandler BackButtonClicked;

        private ManageMoviesControl _manageMoviesControl;
        private ManageBannersControl _manageBannersControl;

        public AdminControl()
        {
            InitializeComponent();
            _manageMoviesControl = new ManageMoviesControl();
            _manageMoviesControl.BackButtonClicked += (s, e) => ShowMenu();
            _manageBannersControl = new ManageBannersControl();
            _manageBannersControl.BackButtonClicked += (s, e) => ShowMenu();
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

        private void btnManageBanners_Click(object sender, EventArgs e)
        {
            ShowManageBanners();
        }

        private void ShowManageBanners()
        {
            panelContainer.Controls.Clear();
            _manageBannersControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(_manageBannersControl);
        }

        private void ShowMenu()
        {
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(btnBack);
            panelContainer.Controls.Add(lblTitle);
            panelContainer.Controls.Add(btnManageMovies);
            panelContainer.Controls.Add(btnManageBanners);
        }

        private void ShowManageMovies()
        {
            panelContainer.Controls.Clear();
            _manageMoviesControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(_manageMoviesControl);
        }
    }
}