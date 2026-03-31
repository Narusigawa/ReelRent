using System;
using System.Windows.Forms;

namespace ReelRent
{
    public partial class CartControl : UserControl
    {
        public event EventHandler BackButtonClicked;

        public CartControl()
        {
            InitializeComponent();
            LoadCartItems();
        }

        private void LoadCartItems()
        {
            // Временная заглушка: добавим несколько тестовых элементов
            lstCart.Items.Clear();
            lstCart.Items.Add("Начало - 3 дня - 300 руб.");
            lstCart.Items.Add("Матрица - 5 дней - 500 руб.");
            lstCart.Items.Add("Зеленая миля - 2 дня - 200 руб.");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            BackButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstCart.SelectedItem != null)
            {
                lstCart.Items.Remove(lstCart.SelectedItem);
            }
            else
            {
                MessageBox.Show("Выберите фильм для удаления.", "Корзина", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (lstCart.Items.Count == 0)
            {
                MessageBox.Show("Корзина пуста.", "Оформление заказа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Здесь будет логика оформления заказа
            MessageBox.Show("Заказ оформлен (заглушка).", "Оформление заказа", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Очищаем корзину после оформления
            lstCart.Items.Clear();
        }
    }
}