using System.Drawing;
using System.Windows.Forms;

namespace ReelRent
{
    partial class PaymentCardForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtCardNumber;
        private TextBox txtExpiry;
        private TextBox txtCvv;
        private Button btnConfirm;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(450, 320);
            this.BackColor = Theme.BackColor;

            // borderPanel
            Panel borderPanel = new Panel();
            borderPanel.Dock = DockStyle.Fill;
            borderPanel.BackColor = Color.White;
            borderPanel.Padding = new Padding(1);

            // contentPanel
            Panel contentPanel = new Panel();
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.BackColor = Theme.BackColor;
            contentPanel.Padding = new Padding(20);

            // btnClose
            this.btnClose = new Button();
            this.btnClose.Text = "✖";
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.BackColor = Color.Transparent;
            this.btnClose.ForeColor = Theme.ForeColor;
            this.btnClose.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnClose.Size = new Size(40, 40);
            this.btnClose.Cursor = Cursors.Hand;
            this.btnClose.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
            this.btnClose.MouseEnter += (s, e) => btnClose.BackColor = Theme.ButtonHoverColor;
            this.btnClose.MouseLeave += (s, e) => btnClose.BackColor = Color.Transparent;

            // lblTitle
            Label lblTitle = new Label();
            lblTitle.Text = "Оплата картой";
            lblTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblTitle.ForeColor = Theme.AccentForeColor;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 20);

            int y = 80;
            int labelWidth = 120;
            int fieldWidth = 250;

            // Номер карты
            Label lblCardNumber = new Label();
            lblCardNumber.Text = "Номер карты:";
            lblCardNumber.Location = new Point(20, y);
            lblCardNumber.Size = new Size(labelWidth, 25);
            lblCardNumber.ForeColor = Theme.ForeColor;

            this.txtCardNumber = new TextBox();
            this.txtCardNumber.Location = new Point(140, y);
            this.txtCardNumber.Size = new Size(fieldWidth, 25);
            this.txtCardNumber.BackColor = Theme.PanelColor;
            this.txtCardNumber.ForeColor = Theme.ForeColor;
            this.txtCardNumber.BorderStyle = BorderStyle.FixedSingle;
            this.txtCardNumber.MaxLength = 19;
            this.txtCardNumber.TextChanged += (s, e) => FormatCardNumber();

            y += 40;
            Label lblExpiry = new Label();
            lblExpiry.Text = "Срок (ММ/ГГ):";
            lblExpiry.Location = new Point(20, y);
            lblExpiry.Size = new Size(labelWidth, 25);
            lblExpiry.ForeColor = Theme.ForeColor;

            this.txtExpiry = new TextBox();
            this.txtExpiry.Location = new Point(140, y);
            this.txtExpiry.Size = new Size(100, 25);
            this.txtExpiry.BackColor = Theme.PanelColor;
            this.txtExpiry.ForeColor = Theme.ForeColor;
            this.txtExpiry.BorderStyle = BorderStyle.FixedSingle;
            this.txtExpiry.MaxLength = 5;

            y += 40;
            Label lblCvv = new Label();
            lblCvv.Text = "CVV:";
            lblCvv.Location = new Point(20, y);
            lblCvv.Size = new Size(labelWidth, 25);
            lblCvv.ForeColor = Theme.ForeColor;

            this.txtCvv = new TextBox();
            this.txtCvv.Location = new Point(140, y);
            this.txtCvv.Size = new Size(60, 25);
            this.txtCvv.BackColor = Theme.PanelColor;
            this.txtCvv.ForeColor = Theme.ForeColor;
            this.txtCvv.BorderStyle = BorderStyle.FixedSingle;
            this.txtCvv.MaxLength = 3;
            this.txtCvv.PasswordChar = '*';

            y += 50;
            this.btnConfirm = new Button();
            this.btnConfirm.Text = "Подтвердить";
            this.btnConfirm.FlatStyle = FlatStyle.Flat;
            this.btnConfirm.BackColor = Theme.ButtonHoverColor;
            this.btnConfirm.ForeColor = Theme.ForeColor;
            this.btnConfirm.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnConfirm.Size = new Size(150, 40);
            this.btnConfirm.Location = new Point(20, y);
            this.btnConfirm.Cursor = Cursors.Hand;
            this.btnConfirm.Click += BtnConfirm_Click;

            contentPanel.Controls.Add(this.btnClose);
            contentPanel.Controls.Add(lblTitle);
            contentPanel.Controls.Add(lblCardNumber);
            contentPanel.Controls.Add(this.txtCardNumber);
            contentPanel.Controls.Add(lblExpiry);
            contentPanel.Controls.Add(this.txtExpiry);
            contentPanel.Controls.Add(lblCvv);
            contentPanel.Controls.Add(this.txtCvv);
            contentPanel.Controls.Add(this.btnConfirm);

            borderPanel.Controls.Add(contentPanel);
            this.Controls.Add(borderPanel);

            contentPanel.Resize += (s, e) => this.btnClose.Location = new Point(contentPanel.Width - this.btnClose.Width - 10, 10);
            this.ResumeLayout(false);
        }
    }
}