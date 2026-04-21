using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ReelRent
{
    public partial class CartItemControl : UserControl
    {
        public event Action<CartItem> ItemRemoved;
        public event Action<CartItem> DaysChanged;

        private CartItem item;

        public CartItemControl(CartItem cartItem)
        {
            item = cartItem;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            // Обрезка названия, если длиннее 60 символов (можно настроить)
            string title = item.Title;
            if (title.Length > 60)
                title = title.Substring(0, 57) + "...";
            lblTitle.Text = title;
            lblPricePerDay.Text = $"Цена за день: {item.RentalPrice:F2} руб.";
            nudDays.Value = item.Days;
            UpdateTotal();

            if (!string.IsNullOrEmpty(item.PosterFileName))
            {
                string postersPath = Path.Combine(Application.StartupPath, "Images", "Posters");
                string fullPath = Path.Combine(postersPath, item.PosterFileName);
                if (File.Exists(fullPath))
                {
                    try
                    {
                        posterBox.Image = Image.FromFile(fullPath);
                    }
                    catch { }
                }
            }
            if (posterBox.Image == null)
            {
                Bitmap bmp = new Bitmap(100, 120);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.FromArgb(80, 80, 80));
                    g.DrawString("Нет постера", new Font("Segoe UI", 8), Brushes.White, new PointF(10, 50));
                }
                posterBox.Image = bmp;
            }
        }

        private void UpdateTotal()
        {
            decimal total = item.RentalPrice * nudDays.Value;
            lblTotalPrice.Text = $"{total:F2} руб.";
        }

        private void NudDays_ValueChanged(object sender, EventArgs e)
        {
            int newDays = (int)nudDays.Value;
            if (newDays != item.Days)
            {
                item.Days = newDays;
                DatabaseHelper.UpdateCartItemDays(item.Id, newDays);
                UpdateTotal();
                DaysChanged?.Invoke(item);
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            DatabaseHelper.RemoveFromCart(item.Id);
            ItemRemoved?.Invoke(item);
        }
    }
}