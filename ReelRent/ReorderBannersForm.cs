using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ReelRent
{
    public partial class ReorderBannersForm : Form
    {
        private List<Banner> _banners;

        public ReorderBannersForm()
        {
            InitializeComponent();
            LoadBanners();
        }

        private void LoadBanners()
        {
            _banners = DatabaseHelper.GetAllBanners(true); // включая неактивные
            _banners.Sort((a, b) => a.OrderIndex.CompareTo(b.OrderIndex));
            RefreshList();
        }

        private void RefreshList()
        {
            listBoxBanners.Items.Clear();
            foreach (var banner in _banners)
            {
                string status = banner.IsActive ? "✓" : "✗";
                listBoxBanners.Items.Add($"{status} [{banner.OrderIndex}] {banner.Description}");
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (listBoxBanners.SelectedIndex > 0)
            {
                int index = listBoxBanners.SelectedIndex;
                var temp = _banners[index];
                _banners[index] = _banners[index - 1];
                _banners[index - 1] = temp;
                RefreshList();
                listBoxBanners.SelectedIndex = index - 1;
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (listBoxBanners.SelectedIndex >= 0 && listBoxBanners.SelectedIndex < _banners.Count - 1)
            {
                int index = listBoxBanners.SelectedIndex;
                var temp = _banners[index];
                _banners[index] = _banners[index + 1];
                _banners[index + 1] = temp;
                RefreshList();
                listBoxBanners.SelectedIndex = index + 1;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _banners.Count; i++)
            {
                _banners[i].OrderIndex = i + 1;
                DatabaseHelper.UpdateBanner(_banners[i]);
            }
            MessageBox.Show("Порядок баннеров сохранён.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}