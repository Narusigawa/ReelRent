using System.Drawing;
using System.Windows.Forms;

namespace ReelRent
{
    partial class CartControl
    {
        private System.ComponentModel.IContainer components = null;
        private Panel cartContainer;
        private FlowLayoutPanel cartItemsPanel;
        private Panel summaryPanel;
        private Label lblTotalAmount;
        private Button btnCheckout;
        private Label lblCartTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.BackColor = Theme.BackColor;
            this.AutoScroll = true;

            // Заголовок
            this.lblCartTitle = new Label();
            this.lblCartTitle.Text = "Корзина";
            this.lblCartTitle.Font = new Font("Segoe UI", 28, FontStyle.Bold);
            this.lblCartTitle.ForeColor = Theme.AccentForeColor;
            this.lblCartTitle.AutoSize = true;

            // Контейнер товаров с обводкой
            this.cartContainer = new Panel();
            this.cartContainer.BackColor = Theme.BackColor;
            this.cartContainer.BorderStyle = BorderStyle.FixedSingle;
            this.cartContainer.Padding = new Padding(5);

            // Панель для списка товаров (со скроллом)
            this.cartItemsPanel = new FlowLayoutPanel();
            this.cartItemsPanel.FlowDirection = FlowDirection.TopDown;
            this.cartItemsPanel.WrapContents = false;
            this.cartItemsPanel.AutoScroll = true;
            this.cartItemsPanel.BackColor = Color.Transparent;
            this.cartItemsPanel.Padding = new Padding(10);
            this.cartItemsPanel.Dock = DockStyle.Fill;
            this.cartContainer.Controls.Add(this.cartItemsPanel);

            // Правая панель с итогами
            this.summaryPanel = new Panel();
            this.summaryPanel.BackColor = Theme.PanelColor;
            this.summaryPanel.Padding = new Padding(20);
            this.summaryPanel.Size = new Size(420, 280);

            Label lblYourCart = new Label();
            lblYourCart.Text = "Ваша корзина";
            lblYourCart.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblYourCart.ForeColor = Theme.AccentForeColor;
            lblYourCart.AutoSize = true;
            lblYourCart.Location = new Point(20, 20);

            Label lblTotalLabel = new Label();
            lblTotalLabel.Text = "Итого:";
            lblTotalLabel.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTotalLabel.ForeColor = Theme.AccentForeColor;
            lblTotalLabel.AutoSize = true;
            lblTotalLabel.Location = new Point(20, 100);

            this.lblTotalAmount = new Label();
            this.lblTotalAmount.Text = "0 руб.";
            this.lblTotalAmount.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            this.lblTotalAmount.ForeColor = Theme.AccentForeColor;
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Location = new Point(20, 140);

            this.btnCheckout = new Button();
            this.btnCheckout.Text = "Оформить заказ";
            this.btnCheckout.FlatStyle = FlatStyle.Flat;
            this.btnCheckout.BackColor = Theme.ButtonHoverColor;
            this.btnCheckout.ForeColor = Theme.ForeColor;
            this.btnCheckout.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.btnCheckout.Size = new Size(340, 50);
            this.btnCheckout.Location = new Point(40, 210);
            this.btnCheckout.Cursor = Cursors.Hand;
            this.btnCheckout.Click += BtnCheckout_Click;

            this.summaryPanel.Controls.Add(lblYourCart);
            this.summaryPanel.Controls.Add(lblTotalLabel);
            this.summaryPanel.Controls.Add(this.lblTotalAmount);
            this.summaryPanel.Controls.Add(this.btnCheckout);

            this.Controls.Add(this.lblCartTitle);
            this.Controls.Add(this.cartContainer);
            this.Controls.Add(this.summaryPanel);

            this.Resize += CartControl_Resize;
            this.Load += (s, e) => CartControl_Resize(null, null);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void CartControl_Resize(object sender, System.EventArgs e)
        {
            int leftMargin = 250;   // отступ для контейнера товаров
            int availableWidth = this.ClientSize.Width - leftMargin - 20;
            if (availableWidth < 500) availableWidth = 500;

            // Центрируем заголовок по всей форме
            int titleCenter = (this.ClientSize.Width - lblCartTitle.Width) / 2 - 100;
            lblCartTitle.Location = new Point(titleCenter, 30);

            int summaryWidth = 420;
            int spacing = 30;
            int cartWidth = availableWidth - summaryWidth - spacing;
            if (cartWidth < 500) cartWidth = 500;

            cartContainer.SetBounds(leftMargin, lblCartTitle.Bottom + 30, cartWidth, this.ClientSize.Height - lblCartTitle.Bottom - 60);
            summaryPanel.SetBounds(leftMargin + cartWidth + spacing, lblCartTitle.Bottom + 30, summaryWidth, 320);
        }
    }
}