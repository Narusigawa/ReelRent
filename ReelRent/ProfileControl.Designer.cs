using System;
using System.Drawing;
using System.Windows.Forms;

namespace ReelRent
{
    partial class ProfileControl
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnBack;
        private Label lblTitle;
        private Label lblInfo;
        private Label lblCurrentRentals;
        private ListBox lstCurrentRentals;
        private Label lblHistory;
        private ListBox lstHistory;
        private Panel contentPanel; // контейнер для центрирования

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
            this.lblInfo = new Label();
            this.lblCurrentRentals = new Label();
            this.lstCurrentRentals = new ListBox();
            this.lblHistory = new Label();
            this.lstHistory = new ListBox();
            this.SuspendLayout();

            // ProfileControl
            this.BackColor = Theme.BackColor;
            this.AutoScroll = true;
            this.Padding = new Padding(70, 0, 0, 0); // отступ слева под боковую панель

            // contentPanel – контейнер для центрирования по горизонтали
            this.contentPanel.BackColor = Color.Transparent;
            this.contentPanel.AutoSize = true;
            this.contentPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.contentPanel.Location = new Point(20, 20);
            this.contentPanel.Width = this.ClientSize.Width - 40;
            this.contentPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // btnBack
            this.btnBack.Text = "← Назад";
            this.btnBack.FlatStyle = FlatStyle.Flat;
            this.btnBack.BackColor = Theme.PanelColor;
            this.btnBack.ForeColor = Theme.ForeColor;
            this.btnBack.Size = new Size(100, 40);
            this.btnBack.Location = new Point(0, 0);
            this.btnBack.Cursor = Cursors.Hand;
            this.btnBack.Click += btnBack_Click;

            // lblTitle
            this.lblTitle.Text = "Личный кабинет";
            this.lblTitle.Font = new Font("Segoe UI", 28, FontStyle.Bold);
            this.lblTitle.ForeColor = Theme.AccentForeColor;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(0, 50);

            // lblInfo
            this.lblInfo.Font = new Font("Segoe UI", 12);
            this.lblInfo.ForeColor = Theme.ForeColor;
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new Point(0, 120);
            this.lblInfo.Text = "Загрузка...";

            // lblCurrentRentals
            this.lblCurrentRentals.Text = "Текущие аренды";
            this.lblCurrentRentals.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            this.lblCurrentRentals.ForeColor = Theme.AccentForeColor;
            this.lblCurrentRentals.AutoSize = true;
            this.lblCurrentRentals.Location = new Point(0, 220);

            // lstCurrentRentals
            this.lstCurrentRentals.Size = new Size(500, 150);
            this.lstCurrentRentals.Location = new Point(0, 260);
            this.lstCurrentRentals.BackColor = Theme.PanelColor;
            this.lstCurrentRentals.ForeColor = Theme.ForeColor;
            this.lstCurrentRentals.Font = new Font("Segoe UI", 10);

            // lblHistory
            this.lblHistory.Text = "История аренд";
            this.lblHistory.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            this.lblHistory.ForeColor = Theme.AccentForeColor;
            this.lblHistory.AutoSize = true;
            this.lblHistory.Location = new Point(0, 440);

            // lstHistory
            this.lstHistory.Size = new Size(500, 150);
            this.lstHistory.Location = new Point(0, 480);
            this.lstHistory.BackColor = Theme.PanelColor;
            this.lstHistory.ForeColor = Theme.ForeColor;
            this.lstHistory.Font = new Font("Segoe UI", 10);

            // Добавляем элементы в contentPanel
            this.contentPanel.Controls.Add(this.btnBack);
            this.contentPanel.Controls.Add(this.lblTitle);
            this.contentPanel.Controls.Add(this.lblInfo);
            this.contentPanel.Controls.Add(this.lblCurrentRentals);
            this.contentPanel.Controls.Add(this.lstCurrentRentals);
            this.contentPanel.Controls.Add(this.lblHistory);
            this.contentPanel.Controls.Add(this.lstHistory);

            // Добавляем contentPanel на форму
            this.Controls.Add(this.contentPanel);

            this.Resize += (s, e) =>
            {
                // Центрируем contentPanel по горизонтали
                this.contentPanel.Left = (this.ClientSize.Width - this.contentPanel.Width) / 2;
            };

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}