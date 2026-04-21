using System.Drawing;
using System.Windows.Forms;

namespace ReelRent
{
    partial class CheckoutForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtAddress;
        private TextBox txtFullName;
        private TextBox txtPhone;
        private ComboBox cmbPayment;
        private TextBox txtPromoCode;
        private Label lblTotal;
        private Button btnPay;
        private Button btnClose;
        private CheckBox chkSaveAddress;

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
            this.Size = new Size(600, 620);
            this.BackColor = Theme.BackColor;

            Panel borderPanel = new Panel();
            borderPanel.Dock = DockStyle.Fill;
            borderPanel.BackColor = Color.White;
            borderPanel.Padding = new Padding(1);

            Panel contentPanel = new Panel();
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.BackColor = Theme.BackColor;
            contentPanel.Padding = new Padding(20);

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

            Label lblTitle = new Label();
            lblTitle.Text = "Оформление заказа";
            lblTitle.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblTitle.ForeColor = Theme.AccentForeColor;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(20, 20);

            // Список товаров
            FlowLayoutPanel itemsPanel = new FlowLayoutPanel();
            itemsPanel.FlowDirection = FlowDirection.TopDown;
            itemsPanel.WrapContents = false;
            itemsPanel.AutoScroll = true;
            itemsPanel.Size = new Size(540, 150);
            itemsPanel.Location = new Point(20, 80);
            itemsPanel.BackColor = Color.FromArgb(45, 38, 72);
            itemsPanel.Padding = new Padding(10);
            // заполнение itemsPanel будет в коде логики

            int y = 250;
            int labelWidth = 120;
            int fieldWidth = 380;

            Label lblAddress = new Label();
            lblAddress.Text = "Адрес доставки:";
            lblAddress.Location = new Point(20, y);
            lblAddress.Size = new Size(labelWidth, 25);
            lblAddress.ForeColor = Theme.ForeColor;
            lblAddress.Font = new Font("Segoe UI", 10);

            this.txtAddress = new TextBox();
            this.txtAddress.Location = new Point(140, y);
            this.txtAddress.Size = new Size(fieldWidth, 25);
            this.txtAddress.BackColor = Theme.PanelColor;
            this.txtAddress.ForeColor = Theme.ForeColor;
            this.txtAddress.BorderStyle = BorderStyle.FixedSingle;

            y += 35;
            Label lblFullName = new Label();
            lblFullName.Text = "ФИО:";
            lblFullName.Location = new Point(20, y);
            lblFullName.Size = new Size(labelWidth, 25);
            lblFullName.ForeColor = Theme.ForeColor;
            lblFullName.Font = new Font("Segoe UI", 10);

            this.txtFullName = new TextBox();
            this.txtFullName.Location = new Point(140, y);
            this.txtFullName.Size = new Size(fieldWidth, 25);
            this.txtFullName.BackColor = Theme.PanelColor;
            this.txtFullName.ForeColor = Theme.ForeColor;
            this.txtFullName.BorderStyle = BorderStyle.FixedSingle;

            y += 35;
            Label lblPhone = new Label();
            lblPhone.Text = "Телефон:";
            lblPhone.Location = new Point(20, y);
            lblPhone.Size = new Size(labelWidth, 25);
            lblPhone.ForeColor = Theme.ForeColor;
            lblPhone.Font = new Font("Segoe UI", 10);

            this.txtPhone = new TextBox();
            this.txtPhone.Location = new Point(140, y);
            this.txtPhone.Size = new Size(fieldWidth, 25);
            this.txtPhone.BackColor = Theme.PanelColor;
            this.txtPhone.ForeColor = Theme.ForeColor;
            this.txtPhone.BorderStyle = BorderStyle.FixedSingle;

            y += 35;
            Label lblPayment = new Label();
            lblPayment.Text = "Способ оплаты:";
            lblPayment.Location = new Point(20, y);
            lblPayment.Size = new Size(labelWidth, 25);
            lblPayment.ForeColor = Theme.ForeColor;
            lblPayment.Font = new Font("Segoe UI", 10);

            this.cmbPayment = new ComboBox();
            this.cmbPayment.Location = new Point(140, y);
            this.cmbPayment.Size = new Size(fieldWidth, 25);
            this.cmbPayment.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbPayment.BackColor = Theme.PanelColor;
            this.cmbPayment.ForeColor = Theme.ForeColor;
            this.cmbPayment.Items.AddRange(new object[] { "Наличные курьеру", "Банковская карта" });
            this.cmbPayment.SelectedIndex = 0;

            y += 35;
            Label lblPromo = new Label();
            lblPromo.Text = "Промокод:";
            lblPromo.Location = new Point(20, y);
            lblPromo.Size = new Size(labelWidth, 25);
            lblPromo.ForeColor = Theme.ForeColor;
            lblPromo.Font = new Font("Segoe UI", 10);

            this.txtPromoCode = new TextBox();
            this.txtPromoCode.Location = new Point(140, y);
            this.txtPromoCode.Size = new Size(fieldWidth, 25);
            this.txtPromoCode.BackColor = Theme.PanelColor;
            this.txtPromoCode.ForeColor = Theme.ForeColor;
            this.txtPromoCode.BorderStyle = BorderStyle.FixedSingle;

            y += 35;
            this.chkSaveAddress = new CheckBox();
            this.chkSaveAddress.Text = "Сохранить этот адрес для следующих заказов";
            this.chkSaveAddress.ForeColor = Theme.ForeColor;
            this.chkSaveAddress.AutoSize = true;
            this.chkSaveAddress.Location = new Point(140, y);
            this.chkSaveAddress.Checked = true;

            y += 40;
            Label lblTotalLabel = new Label();
            lblTotalLabel.Text = "Итого к оплате:";
            lblTotalLabel.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTotalLabel.ForeColor = Theme.AccentForeColor;
            lblTotalLabel.AutoSize = true;
            lblTotalLabel.Location = new Point(20, y);

            this.lblTotal = new Label();
            this.lblTotal.Text = "0 руб.";
            this.lblTotal.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.lblTotal.ForeColor = Theme.AccentForeColor;
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new Point(220, y);
            this.lblTotal.TextAlign = ContentAlignment.MiddleRight;

            y += 50;
            this.btnPay = new Button();
            this.btnPay.Text = "Оплатить";
            this.btnPay.FlatStyle = FlatStyle.Flat;
            this.btnPay.BackColor = Theme.ButtonHoverColor;
            this.btnPay.ForeColor = Theme.ForeColor;
            this.btnPay.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnPay.Size = new Size(200, 45);
            this.btnPay.Location = new Point(20, y);
            this.btnPay.Cursor = Cursors.Hand;
            this.btnPay.Click += BtnPay_Click;

            // Добавляем элементы в itemsPanel (в коде логики)
            // Здесь просто добавим все контролы в contentPanel
            contentPanel.Controls.Add(this.btnClose);
            contentPanel.Controls.Add(lblTitle);
            contentPanel.Controls.Add(itemsPanel);
            contentPanel.Controls.Add(lblAddress);
            contentPanel.Controls.Add(this.txtAddress);
            contentPanel.Controls.Add(lblFullName);
            contentPanel.Controls.Add(this.txtFullName);
            contentPanel.Controls.Add(lblPhone);
            contentPanel.Controls.Add(this.txtPhone);
            contentPanel.Controls.Add(lblPayment);
            contentPanel.Controls.Add(this.cmbPayment);
            contentPanel.Controls.Add(lblPromo);
            contentPanel.Controls.Add(this.txtPromoCode);
            contentPanel.Controls.Add(this.chkSaveAddress);
            contentPanel.Controls.Add(lblTotalLabel);
            contentPanel.Controls.Add(this.lblTotal);
            contentPanel.Controls.Add(this.btnPay);

            borderPanel.Controls.Add(contentPanel);
            this.Controls.Add(borderPanel);

            // Заполнение itemsPanel
            foreach (var item in items)
            {
                Label lblItem = new Label
                {
                    Text = $"{item.Title} — {item.Days} дн. × {item.RentalPrice:F2} руб. = {item.TotalPrice:F2} руб.",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 11),
                    ForeColor = Theme.ForeColor,
                    Margin = new Padding(0, 0, 0, 5)
                };
                itemsPanel.Controls.Add(lblItem);
            }

            contentPanel.Resize += (s, e) => this.btnClose.Location = new Point(contentPanel.Width - this.btnClose.Width - 10, 10);
            this.ResumeLayout(false);
        }
    }
}