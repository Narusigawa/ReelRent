using System;
using System.Drawing;
using System.Windows.Forms;

namespace ReelRent
{
    partial class AdminControl
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnBack;
        private Label lblTitle;
        private Button btnManageMovies;
        private Button btnManageUsers;
        private Button btnManageBanners;
        private Panel panelContainer; // контейнер для переключения содержимого

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnBack = new Button();
            this.lblTitle = new Label();
            this.btnManageMovies = new Button();
            this.btnManageUsers = new Button();
            this.btnManageBanners = new Button();
            this.panelContainer = new Panel();
            this.SuspendLayout();

            // AdminControl
            this.BackColor = Theme.BackColor;
            this.AutoScroll = true;
            this.Padding = new Padding(70, 0, 0, 0);

            // panelContainer – заполняет всю область
            this.panelContainer.Dock = DockStyle.Fill;
            this.panelContainer.BackColor = Color.Transparent;

            // btnBack – слева с отступом
            this.btnBack.Text = "← Назад";
            this.btnBack.FlatStyle = FlatStyle.Flat;
            this.btnBack.BackColor = Theme.PanelColor;
            this.btnBack.ForeColor = Theme.ForeColor;
            this.btnBack.Size = new Size(120, 50);
            this.btnBack.Location = new Point(200, 20);
            this.btnBack.Cursor = Cursors.Hand;
            this.btnBack.Click += btnBack_Click;

            // lblTitle – заголовок
            this.lblTitle.Text = "Панель администратора";
            this.lblTitle.Font = new Font("Segoe UI", 28, FontStyle.Bold);
            this.lblTitle.ForeColor = Theme.AccentForeColor;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(20, 100);

            // Кнопки управления
            this.btnManageMovies.Text = "Управление фильмами";
            this.btnManageMovies.FlatStyle = FlatStyle.Flat;
            this.btnManageMovies.BackColor = Theme.PanelColor;
            this.btnManageMovies.ForeColor = Theme.ForeColor;
            this.btnManageMovies.Size = new Size(300, 70);
            this.btnManageMovies.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.btnManageMovies.Cursor = Cursors.Hand;
            this.btnManageMovies.Click += btnManageMovies_Click;

            this.btnManageUsers.Text = "Управление пользователями";
            this.btnManageUsers.FlatStyle = FlatStyle.Flat;
            this.btnManageUsers.BackColor = Theme.PanelColor;
            this.btnManageUsers.ForeColor = Theme.ForeColor;
            this.btnManageUsers.Size = new Size(300, 70);
            this.btnManageUsers.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.btnManageUsers.Cursor = Cursors.Hand;
            this.btnManageUsers.Click += btnManageUsers_Click;

            this.btnManageBanners.Text = "Управление баннерами";
            this.btnManageBanners.FlatStyle = FlatStyle.Flat;
            this.btnManageBanners.BackColor = Theme.PanelColor;
            this.btnManageBanners.ForeColor = Theme.ForeColor;
            this.btnManageBanners.Size = new Size(300, 70);
            this.btnManageBanners.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.btnManageBanners.Cursor = Cursors.Hand;
            this.btnManageBanners.Click += btnManageBanners_Click;

            // Добавляем панель-контейнер
            this.Controls.Add(this.panelContainer);
            this.panelContainer.Controls.Add(this.btnBack);
            this.panelContainer.Controls.Add(this.lblTitle);
            this.panelContainer.Controls.Add(this.btnManageMovies);
            this.panelContainer.Controls.Add(this.btnManageBanners);
            this.panelContainer.Controls.Add(this.btnManageUsers);

            // Подписываемся на изменение размера для центрирования
            this.Resize += AdminControl_Resize;
            this.Load += (s, e) => AdminControl_Resize(null, null);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void AdminControl_Resize(object sender, EventArgs e)
        {
            // Центрируем заголовок по горизонтали
            int centerX = (this.ClientSize.Width - lblTitle.Width) / 2;
            lblTitle.Location = new Point(centerX, 100);

            // Центрируем кнопки вертикально и горизонтально
            int buttonSpacing = 20;
            int totalHeight = btnManageMovies.Height + btnManageBanners.Height + btnManageUsers.Height + buttonSpacing * 2;
            int startY = (this.ClientSize.Height - totalHeight) / 2;
            if (startY < lblTitle.Bottom + 40) startY = lblTitle.Bottom + 40;

            int btnCenterX = (this.ClientSize.Width - btnManageMovies.Width) / 2;

            btnManageMovies.Location = new Point(btnCenterX, startY);
            btnManageBanners.Location = new Point(btnCenterX, btnManageMovies.Bottom + buttonSpacing);
            btnManageUsers.Location = new Point(btnCenterX, btnManageBanners.Bottom + buttonSpacing);
        }
    }
}