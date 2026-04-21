using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ReelRent
{
    public partial class PaymentCardForm : Form
    {
        public PaymentCardForm()
        {
            InitializeComponent();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCardNumber.Text) || txtCardNumber.Text.Replace(" ", "").Length < 16)
            {
                MessageBox.Show("Введите корректный номер карты (16 цифр).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Regex.IsMatch(txtExpiry.Text, @"^(0[1-9]|1[0-2])\/\d{2}$"))
            {
                MessageBox.Show("Введите срок в формате ММ/ГГ.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtCvv.Text.Length != 3 || !txtCvv.Text.All(char.IsDigit))
            {
                MessageBox.Show("CVV должен состоять из 3 цифр.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormatCardNumber()
        {
            string raw = new string(txtCardNumber.Text.Where(char.IsDigit).ToArray());
            if (raw.Length > 16) raw = raw.Substring(0, 16);
            if (raw.Length <= 4)
                txtCardNumber.Text = raw;
            else if (raw.Length <= 8)
                txtCardNumber.Text = raw.Substring(0, 4) + " " + raw.Substring(4);
            else if (raw.Length <= 12)
                txtCardNumber.Text = raw.Substring(0, 4) + " " + raw.Substring(4, 4) + " " + raw.Substring(8);
            else
                txtCardNumber.Text = raw.Substring(0, 4) + " " + raw.Substring(4, 4) + " " + raw.Substring(8, 4) + " " + raw.Substring(12);
            txtCardNumber.SelectionStart = txtCardNumber.Text.Length;
        }
    }
}