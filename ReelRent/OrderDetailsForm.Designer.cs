using System.Drawing;
using System.Windows.Forms;

namespace ReelRent
{
    partial class OrderDetailsForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnClose;
        private Label lblTitle;
        private GroupBox groupInfo;
        private Label lblTotalCaption, lblTotalAmount;
        private Label lblNameCaption, lblCustomerName;
        private Label lblPhoneCaption, lblCustomerPhone;
        private Label lblAddressCaption, lblDeliveryAddress;
        private Label lblPaymentCaption, lblPaymentMethod;
        private Label lblItemsTitle;
        private FlowLayoutPanel flowLayoutPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnClose = new Button();
            this.lblTitle = new Label();
            this.groupInfo = new GroupBox();
            this.lblTotalCaption = new Label();
            this.lblTotalAmount = new Label();
            this.lblNameCaption = new Label();
            this.lblCustomerName = new Label();
            this.lblPhoneCaption = new Label();
            this.lblCustomerPhone = new Label();
            this.lblAddressCaption = new Label();
            this.lblDeliveryAddress = new Label();
            this.lblPaymentCaption = new Label();
            this.lblPaymentMethod = new Label();
            this.lblItemsTitle = new Label();
            this.flowLayoutPanel = new FlowLayoutPanel();
            this.groupInfo.SuspendLayout();
            this.SuspendLayout();

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(700, 600);
            this.MinimumSize = new Size(600, 500);
            this.BackColor = Theme.BackColor;
            this.Text = "Детали заказа";
            this.Paint += OrderDetailsForm_Paint;

            this.btnClose.Text = "✖";
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.BackColor = Color.Transparent;
            this.btnClose.ForeColor = Theme.ForeColor;
            this.btnClose.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.btnClose.Size = new Size(40, 40);
            this.btnClose.Cursor = Cursors.Hand;
            this.btnClose.Click += BtnClose_Click;
            this.btnClose.MouseEnter += (s, e) => btnClose.BackColor = Theme.ButtonHoverColor;
            this.btnClose.MouseLeave += (s, e) => btnClose.BackColor = Color.Transparent;

            this.lblTitle.Text = "Детали заказа";
            this.lblTitle.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            this.lblTitle.ForeColor = Theme.AccentForeColor;
            this.lblTitle.AutoSize = true;

            this.groupInfo.Text = "Информация о доставке";
            this.groupInfo.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.groupInfo.ForeColor = Theme.AccentForeColor;
            this.groupInfo.BackColor = Color.Transparent;
            this.groupInfo.Padding = new Padding(10);
            this.groupInfo.Size = new Size(660, 220);
            this.groupInfo.AutoSize = false;

            int y = 30;
            int labelWidth = 120;

            this.lblTotalCaption = CreateDesignerLabel("Итого:", labelWidth, y, true);
            this.lblTotalAmount = CreateDesignerLabel("", 200, y, false);
            y += 30;
            this.lblNameCaption = CreateDesignerLabel("ФИО:", labelWidth, y, true);
            this.lblCustomerName = CreateDesignerLabel("", 400, y, false);
            y += 30;
            this.lblPhoneCaption = CreateDesignerLabel("Телефон:", labelWidth, y, true);
            this.lblCustomerPhone = CreateDesignerLabel("", 200, y, false);
            y += 30;
            this.lblAddressCaption = CreateDesignerLabel("Адрес доставки:", labelWidth, y, true);
            this.lblDeliveryAddress = CreateDesignerLabel("", 450, y, false);
            y += 30;
            this.lblPaymentCaption = CreateDesignerLabel("Способ оплаты:", labelWidth, y, true);
            this.lblPaymentMethod = CreateDesignerLabel("", 200, y, false);

            this.groupInfo.Controls.AddRange(new Control[] {
                lblTotalCaption, lblTotalAmount,
                lblNameCaption, lblCustomerName,
                lblPhoneCaption, lblCustomerPhone,
                lblAddressCaption, lblDeliveryAddress,
                lblPaymentCaption, lblPaymentMethod
            });

            this.lblItemsTitle.Text = "Состав заказа:";
            this.lblItemsTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.lblItemsTitle.ForeColor = Theme.AccentForeColor;
            this.lblItemsTitle.AutoSize = true;

            this.flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            this.flowLayoutPanel.WrapContents = false;
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.BackColor = Color.Transparent;

            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.groupInfo);
            this.Controls.Add(this.lblItemsTitle);
            this.Controls.Add(this.flowLayoutPanel);

            this.groupInfo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label CreateDesignerLabel(string text, int width, int top, bool isBold)
        {
            Label lbl = new Label();
            lbl.Text = text;
            lbl.Font = new Font("Segoe UI", 11, isBold ? FontStyle.Bold : FontStyle.Regular);
            lbl.ForeColor = Theme.ForeColor;
            lbl.Location = new Point(isBold ? 10 : 130, top);
            lbl.Size = new Size(width, 25);
            return lbl;
        }

        private void OrderDetailsForm_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.White, 1))
            {
                Rectangle rect = new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }
    }
}