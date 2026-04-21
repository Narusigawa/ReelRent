using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ReelRent
{
    public partial class OrderDetailsForm : Form
    {
        private List<OrderItemDetail> _items;
        private OrderDeliveryInfo _deliveryInfo;

        public OrderDetailsForm(List<OrderItemDetail> items, OrderDeliveryInfo deliveryInfo)
        {
            _items = items;
            _deliveryInfo = deliveryInfo;
            InitializeComponent();
            this.Load += OrderDetailsForm_Load;
            this.Resize += OrderDetailsForm_Resize;
            LoadInfo();
            LoadItems();
        }

        private void OrderDetailsForm_Load(object sender, EventArgs e)
        {
            Relayout();
            ResizeItemPanels();
        }

        private void OrderDetailsForm_Resize(object sender, EventArgs e)
        {
            Relayout();
            ResizeItemPanels();
        }

        private void Relayout()
        {
            if (this.ClientSize.Width <= 0 || this.ClientSize.Height <= 0) return;
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            btnClose.Location = new Point(w - 50, 10);
            lblTitle.Location = new Point((w - lblTitle.Width) / 2, 20);
            groupInfo.Location = new Point(20, lblTitle.Bottom + 20);
            groupInfo.Width = w - 40;
            lblItemsTitle.Location = new Point(20, groupInfo.Bottom + 20);
            flowLayoutPanel.Location = new Point(20, lblItemsTitle.Bottom + 10);
            flowLayoutPanel.Width = w - 40;
            flowLayoutPanel.Height = h - flowLayoutPanel.Top - 20;
        }

        private void ResizeItemPanels()
        {
            if (flowLayoutPanel == null || flowLayoutPanel.Controls == null) return;
            int panelWidth = flowLayoutPanel.Width - 20; // учитываем отступы внутри FlowLayoutPanel
            if (panelWidth <= 0) panelWidth = 500; // минимальная ширина
            foreach (Control ctrl in flowLayoutPanel.Controls)
            {
                if (ctrl is Panel panel)
                {
                    panel.Width = panelWidth;
                    // Перемещаем итоговую цену к правому краю
                    foreach (Control subCtrl in panel.Controls)
                    {
                        if (subCtrl is Label lbl && lbl.Font.Bold && lbl.Font.Size >= 14)
                        {
                            lbl.Location = new Point(panel.Width - lbl.Width - 15, 40);
                            break;
                        }
                    }
                }
            }
        }

        private void LoadInfo()
        {
            lblTotalAmount.Text = $"{_deliveryInfo.TotalAmount:F2} руб.";
            lblCustomerName.Text = _deliveryInfo.CustomerName ?? "—";
            lblCustomerPhone.Text = _deliveryInfo.CustomerPhone ?? "—";
            lblDeliveryAddress.Text = _deliveryInfo.DeliveryAddress ?? "—";
            lblPaymentMethod.Text = _deliveryInfo.PaymentMethod ?? "—";
        }

        private void LoadItems()
        {
            flowLayoutPanel.Controls.Clear();
            if (_items == null || _items.Count == 0)
            {
                Label emptyLabel = new Label
                {
                    Text = "Нет товаров в заказе",
                    Font = new Font("Segoe UI", 12),
                    ForeColor = Theme.ForeColor,
                    AutoSize = true,
                    Location = new Point(10, 10)
                };
                flowLayoutPanel.Controls.Add(emptyLabel);
                return;
            }

            foreach (var item in _items)
            {
                Panel itemPanel = new Panel
                {
                    Height = 120,
                    BackColor = Theme.PanelColor,
                    Margin = new Padding(0, 0, 0, 10),
                    Padding = new Padding(5)
                };
                // Временная ширина, потом скорректируется
                itemPanel.Width = 500;

                // Постер
                PictureBox poster = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Size = new Size(80, 100),
                    Location = new Point(10, 10),
                    BackColor = Color.FromArgb(60, 60, 60)
                };
                if (!string.IsNullOrEmpty(item.PosterFileName))
                {
                    string path = Path.Combine(Application.StartupPath, "Images", "Posters", item.PosterFileName);
                    if (File.Exists(path))
                    {
                        try { poster.Image = Image.FromFile(path); } catch { }
                    }
                }
                if (poster.Image == null)
                {
                    Bitmap bmp = new Bitmap(80, 100);
                    using (Graphics g = Graphics.FromImage(bmp))
                        g.Clear(Color.FromArgb(80, 80, 80));
                    poster.Image = bmp;
                }

                // Название
                Label lblTitle = new Label
                {
                    Text = item.Title,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Theme.ForeColor,
                    Location = new Point(100, 10),
                    AutoSize = true,
                    MaximumSize = new Size(400, 0)
                };

                // Цена за день
                Label lblPricePerDay = new Label
                {
                    Text = $"Цена за день: {item.RentalPrice:F2} руб.",
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Theme.ForeColor,
                    Location = new Point(100, 40),
                    AutoSize = true
                };

                // Количество дней
                Label lblDays = new Label
                {
                    Text = $"Количество дней: {item.Days}",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Theme.ForeColor,
                    Location = new Point(100, 65),
                    AutoSize = true
                };

                // Итоговая цена
                Label lblTotal = new Label
                {
                    Text = $"{item.TotalPrice:F2} руб.",
                    Font = new Font("Segoe UI", 14, FontStyle.Bold),
                    ForeColor = Theme.AccentForeColor,
                    Location = new Point(itemPanel.Width - 150, 40),
                    AutoSize = true
                };

                itemPanel.Controls.Add(poster);
                itemPanel.Controls.Add(lblTitle);
                itemPanel.Controls.Add(lblPricePerDay);
                itemPanel.Controls.Add(lblDays);
                itemPanel.Controls.Add(lblTotal);

                flowLayoutPanel.Controls.Add(itemPanel);
            }

            // Принудительно обновим размеры и перерисуем
            ResizeItemPanels();
            flowLayoutPanel.PerformLayout();
            flowLayoutPanel.Invalidate();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}