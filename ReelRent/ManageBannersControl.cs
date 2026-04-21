using System;
using System.Windows.Forms;

namespace ReelRent
{
    public partial class ManageBannersControl : UserControl
    {
        public event EventHandler BackButtonClicked;

        public ManageBannersControl()
        {
            InitializeComponent();
            LoadBanners();
        }

        private void LoadBanners()
        {
            dgvBanners.Rows.Clear();
            var banners = DatabaseHelper.GetAllBanners(true); // показываем все, включая неактивные
            foreach (var banner in banners)
            {
                dgvBanners.Rows.Add(banner.Id, banner.Description ?? "", banner.IsActive);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new BannerEditForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadBanners();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvBanners.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите баннер для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id = Convert.ToInt32(dgvBanners.SelectedRows[0].Cells[0].Value);
            var banner = DatabaseHelper.GetBannerById(id);
            if (banner != null)
            {
                using (var form = new BannerEditForm(banner))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                        LoadBanners();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBanners.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите баннер для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id = Convert.ToInt32(dgvBanners.SelectedRows[0].Cells[0].Value);
            if (MessageBox.Show("Удалить баннер полностью? Это действие необратимо.", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DatabaseHelper.DeleteBanner(id);
                LoadBanners();
            }
        }

        private void btnReorder_Click(object sender, EventArgs e)
        {
            using (var reorderForm = new ReorderBannersForm())
            {
                reorderForm.ShowDialog();
                LoadBanners();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            BackButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}