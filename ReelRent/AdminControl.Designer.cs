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
        private Button btnAddMovie;
        private Button btnManageUsers;
        private Button btnManageBanners;
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
            this.btnAddMovie = new Button();
            this.btnManageUsers = new Button();
            this.btnManageBanners = new Button();
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

            this.lblTitle.Text = "Панель администратора";
            this.lblTitle.Font = new Font("Segoe UI", 28, FontStyle.Bold);
            this.lblTitle.ForeColor = Theme.AccentForeColor;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(0, 50);

            this.btnAddMovie.Text = "Добавить фильм";
            this.btnAddMovie.FlatStyle = FlatStyle.Flat;
            this.btnAddMovie.BackColor = Theme.PanelColor;
            this.btnAddMovie.ForeColor = Theme.ForeColor;
            this.btnAddMovie.Size = new Size(250, 50);
            this.btnAddMovie.Location = new Point(0, 120);
            this.btnAddMovie.Cursor = Cursors.Hand;
            this.btnAddMovie.Click += btnAddMovie_Click;

            this.btnManageUsers.Text = "Управление пользователями";
            this.btnManageUsers.FlatStyle = FlatStyle.Flat;
            this.btnManageUsers.BackColor = Theme.PanelColor;
            this.btnManageUsers.ForeColor = Theme.ForeColor;
            this.btnManageUsers.Size = new Size(250, 50);
            this.btnManageUsers.Location = new Point(0, 190);
            this.btnManageUsers.Cursor = Cursors.Hand;
            this.btnManageUsers.Click += btnManageUsers_Click;

            this.btnManageBanners.Text = "Управление баннерами";
            this.btnManageBanners.FlatStyle = FlatStyle.Flat;
            this.btnManageBanners.BackColor = Theme.PanelColor;
            this.btnManageBanners.ForeColor = Theme.ForeColor;
            this.btnManageBanners.Size = new Size(250, 50);
            this.btnManageBanners.Location = new Point(0, 260);
            this.btnManageBanners.Cursor = Cursors.Hand;
            this.btnManageBanners.Click += btnManageBanners_Click;

            this.contentPanel.Controls.Add(this.btnBack);
            this.contentPanel.Controls.Add(this.lblTitle);
            this.contentPanel.Controls.Add(this.btnAddMovie);
            this.contentPanel.Controls.Add(this.btnManageUsers);
            this.contentPanel.Controls.Add(this.btnManageBanners);

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