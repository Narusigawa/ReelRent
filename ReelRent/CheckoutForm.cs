using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ReelRent
{
    public partial class CheckoutForm : Form
    {
        private List<CartItem> items;

        public CheckoutForm(List<CartItem> cartItems)
        {
            items = cartItems;
            InitializeComponent();
            LoadUserData();
            CalculateTotal();
        }

        private void LoadUserData()
        {
            if (Session.CurrentUser != null)
            {
                txtFullName.Text = Session.CurrentUser.FullName ?? "";
                txtPhone.Text = Session.CurrentUser.Phone ?? "";
                txtAddress.Text = Session.CurrentUser.DeliveryAddress ?? "";
            }
        }

        private void CalculateTotal()
        {
            decimal total = items.Sum(i => i.TotalPrice);
            lblTotal.Text = $"{total:F2} руб.";
        }

        private void BtnPay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Введите адрес доставки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Введите ФИО получателя.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Введите номер телефона.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string paymentMethod = cmbPayment.SelectedItem.ToString();
            decimal totalAmount = items.Sum(i => i.TotalPrice);
            string promoCode = txtPromoCode.Text.Trim();

            if (paymentMethod == "Банковская карта")
            {
                using (var cardForm = new PaymentCardForm())
                {
                    if (cardForm.ShowDialog() != DialogResult.OK)
                        return;
                }
            }

            // Сохраняем адрес, если чекбокс отмечен
            if (chkSaveAddress.Checked && !string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                DatabaseHelper.UpdateUserDeliveryAddress(Session.CurrentUser.Id, txtAddress.Text);
                Session.CurrentUser.DeliveryAddress = txtAddress.Text;
            }

            int orderId = DatabaseHelper.CreateOrder(Session.CurrentUser.Id, txtAddress.Text, txtFullName.Text, txtPhone.Text, paymentMethod, promoCode, totalAmount, items);
            if (orderId > 0)
            {
                MessageBox.Show("Оплата прошла успешно! Заказ оформлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка при оформлении заказа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}