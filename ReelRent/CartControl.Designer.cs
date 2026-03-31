using System;
using System.Drawing;
using System.Windows.Forms;

namespace ReelRent
{
    partial class CartControl
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnBack;
        private Label lblTitle;
        private ListBox lstCart;
        private Button btnRemove;
        private Button btnCheckout;
        private Panel contentPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.contentPanel = new Panel();
            this.btnBack = new Button();
            this.lblTitle = new Label();
            this.lstCart = new ListBox();
            this.btnRemove = new Button();
            this.btnCheckout = new Button();
            this.SuspendLayout();

            this.BackColor = Theme.BackColor;
            this.AutoScroll = true;
            this.Padding = new Padding(70, 0, 0, 0);

            this.contentPanel.BackColor = Color.Transparent;
            this.contentPanel.AutoSize = true;
            this.contentPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.contentPanel.Location = new Point(20, 20);
            this.contentPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            this.btnBack.Text = "← Назад";
            this.btnBack.FlatStyle = FlatStyle.Flat;
            this.btnBack.BackColor = Theme.PanelColor;
            this.btnBack.ForeColor = Theme.ForeColor;
            this.btnBack.Size = new Size(100, 40);
            this.btnBack.Location = new Point(0, 0);
            this.btnBack.Cursor = Cursors.Hand;
            this.btnBack.Click += btnBack_Click;

            this.lblTitle.Text = "Корзина";
            this.lblTitle.Font = new Font("Segoe UI", 28, FontStyle.Bold);
            this.lblTitle.ForeColor = Theme.AccentForeColor;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(0, 50);

            this.lstCart.Size = new Size(500, 200);
            this.lstCart.Location = new Point(0, 120);
            this.lstCart.BackColor = Theme.PanelColor;
            this.lstCart.ForeColor = Theme.ForeColor;
            this.lstCart.Font = new Font("Segoe UI", 11);

            this.btnRemove.Text = "Удалить выбранное";
            this.btnRemove.FlatStyle = FlatStyle.Flat;
            this.btnRemove.BackColor = Theme.PanelColor;
            this.btnRemove.ForeColor = Theme.ForeColor;
            this.btnRemove.Size = new Size(150, 35);
            this.btnRemove.Location = new Point(0, 340);
            this.btnRemove.Cursor = Cursors.Hand;
            this.btnRemove.Click += btnRemove_Click;

            this.btnCheckout.Text = "Оформить заказ";
            this.btnCheckout.FlatStyle = FlatStyle.Flat;
            this.btnCheckout.BackColor = Theme.ButtonHoverColor;
            this.btnCheckout.ForeColor = Theme.ForeColor;
            this.btnCheckout.Size = new Size(150, 40);
            this.btnCheckout.Location = new Point(170, 340);
            this.btnCheckout.Cursor = Cursors.Hand;
            this.btnCheckout.Click += btnCheckout_Click;

            this.contentPanel.Controls.Add(this.btnBack);
            this.contentPanel.Controls.Add(this.lblTitle);
            this.contentPanel.Controls.Add(this.lstCart);
            this.contentPanel.Controls.Add(this.btnRemove);
            this.contentPanel.Controls.Add(this.btnCheckout);

            this.Controls.Add(this.contentPanel);

            this.Resize += (s, e) =>
            {
                this.contentPanel.Left = (this.ClientSize.Width - this.contentPanel.Width) / 2;
            };

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}