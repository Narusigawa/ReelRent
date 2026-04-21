using System;
using System.Linq;
using System.Windows.Forms;

namespace ReelRent
{
    public partial class CartControl : UserControl
    {
        public event EventHandler BackButtonClicked;

        public CartControl()
        {
            InitializeComponent();
        }

        public void SetSidePanelWidth(int width)
        {
            CartControl_Resize(null, null);
        }

        public void RefreshCart()
        {
            LoadCart();
        }

        private void LoadCart()
        {
            if (!Session.IsAuthenticated)
            {
                MessageBox.Show("Для просмотра корзины необходимо войти в систему.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cartItemsPanel.Controls.Clear();
                UpdateSummary(new System.Collections.Generic.List<CartItem>());
                return;
            }

            cartItemsPanel.Controls.Clear();
            var items = DatabaseHelper.GetCartItems(Session.CurrentUser.Id);
            foreach (var item in items)
            {
                var itemControl = new CartItemControl(item);
                itemControl.ItemRemoved += removedItem => LoadCart();
                itemControl.DaysChanged += changedItem => LoadCart();
                cartItemsPanel.Controls.Add(itemControl);
                // Растягиваем элемент на всю ширину контейнера
                itemControl.Width = cartItemsPanel.ClientSize.Width - 20;
            }
            cartItemsPanel.Resize -= CartItemsPanel_Resize;
            cartItemsPanel.Resize += CartItemsPanel_Resize;
            UpdateSummary(items);
        }

        private void CartItemsPanel_Resize(object sender, EventArgs e)
        {
            foreach (CartItemControl item in cartItemsPanel.Controls)
            {
                item.Width = cartItemsPanel.ClientSize.Width - 20;
            }
        }

        private void UpdateSummary(System.Collections.Generic.List<CartItem> items)
        {
            decimal totalSum = items.Sum(i => i.TotalPrice);
            lblTotalAmount.Text = $"{totalSum:F2} руб.";
        }

        private void BtnCheckout_Click(object sender, EventArgs e)
        {
            if (!Session.IsAuthenticated)
            {
                MessageBox.Show("Необходимо войти в систему.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var items = DatabaseHelper.GetCartItems(Session.CurrentUser.Id);
            if (items.Count == 0)
            {
                MessageBox.Show("Корзина пуста.", "Оформление заказа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var checkoutForm = new CheckoutForm(items))
            {
                if (checkoutForm.ShowDialog() == DialogResult.OK)
                {
                    DatabaseHelper.ClearCart(Session.CurrentUser.Id);
                    LoadCart();
                    MessageBox.Show("Заказ успешно оформлен! Спасибо за покупку.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}