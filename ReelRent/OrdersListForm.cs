using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ReelRent
{
    public partial class OrdersListForm : Form
    {
        private bool _onlyActive;
        private List<OrderInfo> _orders;

        public OrdersListForm(bool onlyActive)
        {
            _onlyActive = onlyActive;
            InitializeComponent();
            this.Load += OrdersListForm_Load;
            this.Resize += OrdersListForm_Resize;
            LoadOrders();
        }

        private void OrdersListForm_Load(object sender, EventArgs e)
        {
            Relayout();
        }

        private void OrdersListForm_Resize(object sender, EventArgs e)
        {
            Relayout();
        }

        private void Relayout()
        {
            if (this.ClientSize.Width <= 0 || this.ClientSize.Height <= 0) return;
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            btnClose.Location = new System.Drawing.Point(w - 50, 10);
            lblTitle.Location = new System.Drawing.Point((w - lblTitle.Width) / 2, 20);

            int tableTop = 80;
            int tableHeight = h - tableTop - 50;
            dgvOrders.Location = new System.Drawing.Point(20, tableTop);
            dgvOrders.Size = new System.Drawing.Size(w - 40, tableHeight);

            lblHint.Location = new System.Drawing.Point((w - lblHint.Width) / 2, h - 35);
        }

        private void LoadOrders()
        {
            if (!Session.IsAuthenticated) return;
            _orders = DatabaseHelper.GetUserOrders(Session.CurrentUser.Id, onlyActive: _onlyActive);
            dgvOrders.Rows.Clear();
            foreach (var order in _orders)
            {
                int moviesCount = DatabaseHelper.GetOrderItems(order.Id).Count;
                dgvOrders.Rows.Add(
                    order.Id,
                    order.RentDate.ToString("dd.MM.yyyy"),
                    _onlyActive ? order.DueDate.ToString("dd.MM.yyyy") : (order.ReturnDate?.ToString("dd.MM.yyyy") ?? "—"),
                    moviesCount,
                    order.TotalAmount.ToString("F2")
                );
            }
        }

        private void DgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int orderId = Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells[0].Value);
                var items = DatabaseHelper.GetOrderItems(orderId);
                var deliveryInfo = DatabaseHelper.GetOrderDeliveryInfo(orderId);
                using (var detailsForm = new OrderDetailsForm(items, deliveryInfo))
                {
                    detailsForm.ShowDialog();
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}