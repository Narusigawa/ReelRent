using System.Drawing;
using System.Windows.Forms;

namespace ReelRent
{
    partial class EditProfileForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel borderPanel;
        private Panel contentPanel;
        private Button btnClose;
        private Label lblTitle;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblAddress;
        private TextBox txtAddress;
        private Button btnSave;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.borderPanel = new Panel();
            this.contentPanel = new Panel();
            this.btnClose = new Button();
            this.lblTitle = new Label();
            this.lblFullName = new Label();
            this.txtFullName = new TextBox();
            this.lblEmail = new Label();
            this.txtEmail = new TextBox();
            this.lblPhone = new Label();
            this.txtPhone = new TextBox();
            this.lblAddress = new Label();
            this.txtAddress = new TextBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(500, 500);
            this.BackColor = Theme.BackColor;

            // borderPanel
            this.borderPanel.Dock = DockStyle.Fill;
            this.borderPanel.BackColor = Color.White;
            this.borderPanel.Padding = new Padding(1);

            // contentPanel
            this.contentPanel.Dock = DockStyle.Fill;
            this.contentPanel.BackColor = Theme.BackColor;
            this.contentPanel.Padding = new Padding(20);

            // btnClose
            this.btnClose.Text = "✖";
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.BackColor = Color.Transparent;
            this.btnClose.ForeColor = Theme.ForeColor;
            this.btnClose.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnClose.Size = new Size(40, 40);
            this.btnClose.Cursor = Cursors.Hand;
            this.btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnClose.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
            this.btnClose.MouseEnter += (s, e) => btnClose.BackColor = Theme.ButtonHoverColor;
            this.btnClose.MouseLeave += (s, e) => btnClose.BackColor = Color.Transparent;

            // lblTitle
            this.lblTitle.Text = "Редактирование профиля";
            this.lblTitle.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            this.lblTitle.ForeColor = Theme.AccentForeColor;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(20, 20);

            int y = 90;
            int labelWidth = 120;
            int fieldWidth = 300;

            // FullName
            this.lblFullName.Text = "ФИО:";
            this.lblFullName.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.lblFullName.ForeColor = Theme.ForeColor;
            this.lblFullName.Location = new Point(20, y);
            this.lblFullName.Size = new Size(labelWidth, 30);

            this.txtFullName.Font = new Font("Segoe UI", 12);
            this.txtFullName.Location = new Point(140, y);
            this.txtFullName.Size = new Size(fieldWidth, 30);
            this.txtFullName.BackColor = Theme.PanelColor;
            this.txtFullName.ForeColor = Theme.ForeColor;
            this.txtFullName.BorderStyle = BorderStyle.FixedSingle;

            y += 50;
            // Email
            this.lblEmail.Text = "Email:";
            this.lblEmail.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.lblEmail.ForeColor = Theme.ForeColor;
            this.lblEmail.Location = new Point(20, y);
            this.lblEmail.Size = new Size(labelWidth, 30);

            this.txtEmail.Font = new Font("Segoe UI", 12);
            this.txtEmail.Location = new Point(140, y);
            this.txtEmail.Size = new Size(fieldWidth, 30);
            this.txtEmail.BackColor = Theme.PanelColor;
            this.txtEmail.ForeColor = Theme.ForeColor;
            this.txtEmail.BorderStyle = BorderStyle.FixedSingle;

            y += 50;
            // Phone
            this.lblPhone.Text = "Телефон:";
            this.lblPhone.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.lblPhone.ForeColor = Theme.ForeColor;
            this.lblPhone.Location = new Point(20, y);
            this.lblPhone.Size = new Size(labelWidth, 30);

            this.txtPhone.Font = new Font("Segoe UI", 12);
            this.txtPhone.Location = new Point(140, y);
            this.txtPhone.Size = new Size(fieldWidth, 30);
            this.txtPhone.BackColor = Theme.PanelColor;
            this.txtPhone.ForeColor = Theme.ForeColor;
            this.txtPhone.BorderStyle = BorderStyle.FixedSingle;

            y += 50;
            // Address
            this.lblAddress.Text = "Адрес доставки:";
            this.lblAddress.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.lblAddress.ForeColor = Theme.ForeColor;
            this.lblAddress.Location = new Point(20, y);
            this.lblAddress.Size = new Size(labelWidth, 30);

            this.txtAddress.Font = new Font("Segoe UI", 12);
            this.txtAddress.Location = new Point(140, y);
            this.txtAddress.Size = new Size(fieldWidth, 30);
            this.txtAddress.BackColor = Theme.PanelColor;
            this.txtAddress.ForeColor = Theme.ForeColor;
            this.txtAddress.BorderStyle = BorderStyle.FixedSingle;

            y += 70;
            // Buttons
            this.btnSave.Text = "Сохранить";
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.BackColor = Theme.ButtonHoverColor;
            this.btnSave.ForeColor = Theme.ForeColor;
            this.btnSave.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnSave.Size = new Size(130, 40);
            this.btnSave.Location = new Point(100, y);
            this.btnSave.Cursor = Cursors.Hand;
            this.btnSave.Click += BtnSave_Click;

            this.btnCancel.Text = "Отмена";
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.BackColor = Theme.PanelColor;
            this.btnCancel.ForeColor = Theme.ForeColor;
            this.btnCancel.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnCancel.Size = new Size(130, 40);
            this.btnCancel.Location = new Point(250, y);
            this.btnCancel.Cursor = Cursors.Hand;
            this.btnCancel.Click += BtnCancel_Click;

            this.contentPanel.Controls.Add(this.btnClose);
            this.contentPanel.Controls.Add(this.lblTitle);
            this.contentPanel.Controls.Add(this.lblFullName);
            this.contentPanel.Controls.Add(this.txtFullName);
            this.contentPanel.Controls.Add(this.lblEmail);
            this.contentPanel.Controls.Add(this.txtEmail);
            this.contentPanel.Controls.Add(this.lblPhone);
            this.contentPanel.Controls.Add(this.txtPhone);
            this.contentPanel.Controls.Add(this.lblAddress);
            this.contentPanel.Controls.Add(this.txtAddress);
            this.contentPanel.Controls.Add(this.btnSave);
            this.contentPanel.Controls.Add(this.btnCancel);

            this.borderPanel.Controls.Add(this.contentPanel);
            this.Controls.Add(this.borderPanel);

            this.contentPanel.Resize += (s, e) => btnClose.Location = new Point(contentPanel.Width - btnClose.Width - 10, 10);
            this.ResumeLayout(false);
        }
    }
}