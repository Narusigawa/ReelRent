using System;
using System.Windows.Forms;

namespace ReelRent
{
    public partial class EditProfileForm : Form
    {
        public EditProfileForm()
        {
            InitializeComponent();
            LoadCurrentData();
        }

        private void LoadCurrentData()
        {
            if (Session.CurrentUser != null)
            {
                txtFullName.Text = Session.CurrentUser.FullName ?? "";
                txtEmail.Text = Session.CurrentUser.Email ?? "";
                txtPhone.Text = Session.CurrentUser.Phone ?? "";
                txtAddress.Text = Session.CurrentUser.DeliveryAddress ?? "";
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Session.CurrentUser == null) return;

            bool success = DatabaseHelper.UpdateUserProfile(
                Session.CurrentUser.Id,
                txtFullName.Text.Trim(),
                txtEmail.Text.Trim(),
                txtPhone.Text.Trim(),
                txtAddress.Text.Trim()
            );

            if (success)
            {
                // Обновляем данные в сессии
                Session.CurrentUser.FullName = txtFullName.Text.Trim();
                Session.CurrentUser.Email = txtEmail.Text.Trim();
                Session.CurrentUser.Phone = txtPhone.Text.Trim();
                Session.CurrentUser.DeliveryAddress = txtAddress.Text.Trim();

                MessageBox.Show("Данные успешно обновлены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Ошибка при сохранении данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}