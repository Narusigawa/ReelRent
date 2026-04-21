using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ReelRent
{
    public partial class BannerEditForm : Form
    {
        private Banner _banner;
        private string _imagePath = null;

        public BannerEditForm(Banner banner = null)
        {
            InitializeComponent();
            _banner = banner;
            if (_banner != null)
            {
                LoadBannerData();
            }
            // По умолчанию чекбокс "Активен" включён
            chkActive.Checked = true;
        }

        private void LoadBannerData()
        {
            txtDescription.Text = _banner.Description ?? "";
            chkActive.Checked = _banner.IsActive;

            if (!string.IsNullOrEmpty(_banner.ImageFileName))
            {
                string imagesPath = Path.Combine(Application.StartupPath, "Images", "Banners");
                string fullPath = Path.Combine(imagesPath, _banner.ImageFileName);
                if (File.Exists(fullPath))
                {
                    try
                    {
                        using (var fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                        {
                            var img = Image.FromStream(fs);
                            pictureBanner.Image = new Bitmap(img);
                            img.Dispose();
                        }
                    }
                    catch { pictureBanner.Image = null; }
                }
            }
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Выберите изображение баннера";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _imagePath = ofd.FileName;
                    try
                    {
                        if (pictureBanner.Image != null)
                        {
                            pictureBanner.Image.Dispose();
                            pictureBanner.Image = null;
                        }
                        using (var fs = new FileStream(_imagePath, FileMode.Open, FileAccess.Read))
                        {
                            var img = Image.FromStream(fs);
                            pictureBanner.Image = new Bitmap(img);
                            img.Dispose();
                        }
                    }
                    catch { }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Введите описание баннера.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string imageFileName = _banner?.ImageFileName;

            if (_imagePath != null)
            {
                string bannersDir = Path.Combine(Application.StartupPath, "Images", "Banners");
                if (!Directory.Exists(bannersDir))
                    Directory.CreateDirectory(bannersDir);

                string originalFileName = Path.GetFileName(_imagePath);
                string destPath = Path.Combine(bannersDir, originalFileName);

                if (_banner != null && !string.IsNullOrEmpty(_banner.ImageFileName) && _banner.ImageFileName != originalFileName)
                {
                    string oldPath = Path.Combine(bannersDir, _banner.ImageFileName);
                    if (File.Exists(oldPath))
                    {
                        try { File.Delete(oldPath); } catch { }
                    }
                }

                if (pictureBanner.Image != null)
                {
                    pictureBanner.Image.Dispose();
                    pictureBanner.Image = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();

                File.Copy(_imagePath, destPath, true);
                imageFileName = originalFileName;
            }
            else if (string.IsNullOrEmpty(imageFileName))
            {
                MessageBox.Show("Выберите изображение для баннера.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Banner banner = new Banner
            {
                Id = _banner?.Id ?? 0,
                ImageFileName = imageFileName,
                Description = txtDescription.Text,
                // OrderIndex не задаём – база сама присвоит при добавлении, при редактировании оставляем старый
                OrderIndex = _banner?.OrderIndex ?? 0,
                IsActive = chkActive.Checked
            };

            if (_banner == null)
                DatabaseHelper.AddBanner(banner);
            else
                DatabaseHelper.UpdateBanner(banner);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}