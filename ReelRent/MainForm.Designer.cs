using System;
using System.Drawing;
using System.Windows.Forms;
using ReelRent.Properties;

namespace ReelRent
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label titleLabel;
        private Button btnCatalog;
        private Button btnProfile;
        private Button btnCart;
        private Button btnManage;
        private Button btnAbout;
        private Button btnMinimize;
        private Button btnClose;
        private Panel contentContainer;

        // Новые элементы для поиска
        private Panel searchPanel;
        private TextBox searchBox;
        private Button btnSearch;
        private Button btnFilter;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();

            // ========== Контейнер для UserControl ==========
            this.contentContainer = new Panel();
            this.contentContainer.Dock = DockStyle.Fill;
            this.contentContainer.BackColor = Theme.BackColor;
            this.contentContainer.Padding = new Padding(120, 120, 0, 0); // отступ сверху 120

            // ========== Боковая панель ==========
            this.sidePanel = new Panel();
            this.sidePanel.BackColor = Theme.PanelColor;
            this.sidePanel.Width = 70;
            this.sidePanel.Height = this.ClientSize.Height;
            this.sidePanel.Location = new Point(0, 0);
            this.sidePanel.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;
            this.sidePanel.ForeColor = Theme.ForeColor;
            this.sidePanel.Resize += (s, e) => CenterButtonsInPanel();

            // Кнопка "Управление" (админ)
            this.btnManage = new Button();
            this.btnManage.Text = "⚙️";
            this.btnManage.FlatStyle = FlatStyle.Flat;
            this.btnManage.FlatAppearance.BorderSize = 0;
            this.btnManage.BackColor = Color.Transparent;
            this.btnManage.ForeColor = Theme.ForeColor;
            this.btnManage.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            this.btnManage.TextAlign = ContentAlignment.MiddleCenter;
            this.btnManage.Width = this.sidePanel.Width;
            this.btnManage.Height = 70;
            this.btnManage.Cursor = Cursors.Hand;
            this.btnManage.Click += BtnManage_Click;
            this.btnManage.MouseEnter += (s, e) => btnManage.BackColor = Theme.ButtonHoverColor;
            this.btnManage.MouseLeave += (s, e) => btnManage.BackColor = Color.Transparent;
            this.btnManage.Visible = false;
            this.sidePanel.Controls.Add(this.btnManage);

            // Кнопка "Каталог"
            this.btnCatalog = new Button();
            this.btnCatalog.Text = "📀";
            this.btnCatalog.FlatStyle = FlatStyle.Flat;
            this.btnCatalog.FlatAppearance.BorderSize = 0;
            this.btnCatalog.BackColor = Color.Transparent;
            this.btnCatalog.ForeColor = Theme.ForeColor;
            this.btnCatalog.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            this.btnCatalog.TextAlign = ContentAlignment.MiddleCenter;
            this.btnCatalog.Width = this.sidePanel.Width;
            this.btnCatalog.Height = 70;
            this.btnCatalog.Cursor = Cursors.Hand;
            this.btnCatalog.Click += BtnCatalog_Click;
            this.btnCatalog.MouseEnter += (s, e) => btnCatalog.BackColor = Theme.ButtonHoverColor;
            this.btnCatalog.MouseLeave += (s, e) => btnCatalog.BackColor = Color.Transparent;
            this.sidePanel.Controls.Add(this.btnCatalog);

            // Кнопка "Личный кабинет"
            this.btnProfile = new Button();
            this.btnProfile.Text = "👤";
            this.btnProfile.FlatStyle = FlatStyle.Flat;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.BackColor = Color.Transparent;
            this.btnProfile.ForeColor = Theme.ForeColor;
            this.btnProfile.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            this.btnProfile.TextAlign = ContentAlignment.MiddleCenter;
            this.btnProfile.Width = this.sidePanel.Width;
            this.btnProfile.Height = 70;
            this.btnProfile.Cursor = Cursors.Hand;
            this.btnProfile.Click += BtnProfile_Click;
            this.btnProfile.MouseEnter += (s, e) => btnProfile.BackColor = Theme.ButtonHoverColor;
            this.btnProfile.MouseLeave += (s, e) => btnProfile.BackColor = Color.Transparent;
            this.sidePanel.Controls.Add(this.btnProfile);

            // Кнопка "Корзина"
            this.btnCart = new Button();
            this.btnCart.Text = "🛒";
            this.btnCart.FlatStyle = FlatStyle.Flat;
            this.btnCart.FlatAppearance.BorderSize = 0;
            this.btnCart.BackColor = Color.Transparent;
            this.btnCart.ForeColor = Theme.ForeColor;
            this.btnCart.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            this.btnCart.TextAlign = ContentAlignment.MiddleCenter;
            this.btnCart.Width = this.sidePanel.Width;
            this.btnCart.Height = 70;
            this.btnCart.Cursor = Cursors.Hand;
            this.btnCart.Click += BtnCart_Click;
            this.btnCart.MouseEnter += (s, e) => btnCart.BackColor = Theme.ButtonHoverColor;
            this.btnCart.MouseLeave += (s, e) => btnCart.BackColor = Color.Transparent;
            this.sidePanel.Controls.Add(this.btnCart);

            // Кнопка "О программе"
            this.btnAbout = new Button();
            this.btnAbout.Text = "ℹ️";
            this.btnAbout.FlatStyle = FlatStyle.Flat;
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.BackColor = Color.Transparent;
            this.btnAbout.ForeColor = Theme.ForeColor;
            this.btnAbout.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            this.btnAbout.TextAlign = ContentAlignment.MiddleCenter;
            this.btnAbout.Width = this.sidePanel.Width;
            this.btnAbout.Height = 70;
            this.btnAbout.Cursor = Cursors.Hand;
            this.btnAbout.Click += BtnAbout_Click;
            this.btnAbout.MouseEnter += (s, e) => btnAbout.BackColor = Theme.ButtonHoverColor;
            this.btnAbout.MouseLeave += (s, e) => btnAbout.BackColor = Color.Transparent;
            this.sidePanel.Controls.Add(this.btnAbout);

            // ========== Логотип и название ==========
            this.pictureBoxLogo = new PictureBox();
            this.pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.Image = Resources.logo2;
            this.pictureBoxLogo.Width = 100;
            this.pictureBoxLogo.Height = 100;
            this.pictureBoxLogo.BackColor = Color.Transparent;

            this.titleLabel = new Label();
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new Font("Segoe UI", 30, FontStyle.Bold);
            this.titleLabel.ForeColor = Theme.AccentForeColor;
            this.titleLabel.Text = "КиноПрокат";

            // ========== Поисковая панель (располагается справа от логотипа) ==========
            this.searchPanel = new Panel();
            this.searchPanel.BackColor = Color.White;
            this.searchPanel.Size = new Size(700, 50);
            this.searchPanel.BorderStyle = BorderStyle.FixedSingle;
            this.searchPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            this.searchBox = new TextBox();
            this.searchBox.BorderStyle = BorderStyle.None;
            this.searchBox.Font = new Font("Segoe UI", 18);
            this.searchBox.BackColor = Color.White;
            this.searchBox.ForeColor = Color.Gray;
            this.searchBox.Size = new Size(600, 40);
            this.searchBox.Text = "Поиск фильмов...";
            this.searchBox.Location = new Point(10, 5);
            this.searchBox.GotFocus += (s, e) =>
            {
                if (this.searchBox.Text == "Поиск фильмов...")
                {
                    this.searchBox.Text = "";
                    this.searchBox.ForeColor = Color.Black;
                }
            };
            this.searchBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(this.searchBox.Text))
                {
                    this.searchBox.Text = "Поиск фильмов...";
                    this.searchBox.ForeColor = Color.Gray;
                }
            };
            this.searchPanel.Controls.Add(this.searchBox);

            this.btnSearch = new Button();
            this.btnSearch.FlatStyle = FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.BackColor = Color.White;
            this.btnSearch.Size = new Size(40, 40);
            try { this.btnSearch.Image = Properties.Resources.search_icon; } catch { this.btnSearch.Text = "🔍"; }
            this.btnSearch.Cursor = Cursors.Hand;
            this.btnSearch.Click += (s, e) => SearchMovies();
            this.searchPanel.Controls.Add(this.btnSearch);

            this.btnFilter = new Button();
            this.btnFilter.FlatStyle = FlatStyle.Flat;
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.BackColor = Color.White;
            this.btnFilter.Size = new Size(40, 40);
            try { this.btnFilter.Image = Properties.Resources.filter_icon; } catch { this.btnFilter.Text = "⚙️"; }
            this.btnFilter.Cursor = Cursors.Hand;
            this.btnFilter.Click += (s, e) => ShowFilterDialog();
            this.searchPanel.Controls.Add(this.btnFilter);

            this.btnSearch.Location = new Point(this.searchPanel.Width - 45, 5);
            this.btnFilter.Location = new Point(this.searchPanel.Width - 90, 5);

            // ========== Кнопки управления окном ==========
            this.btnMinimize = new Button();
            this.btnMinimize.Text = "─";
            this.btnMinimize.FlatStyle = FlatStyle.Flat;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.BackColor = Color.Transparent;
            this.btnMinimize.ForeColor = Theme.ForeColor;
            this.btnMinimize.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnMinimize.Size = new Size(50, 50);
            this.btnMinimize.Click += (s, e) => this.WindowState = FormWindowState.Minimized;
            this.btnMinimize.MouseEnter += (s, e) => btnMinimize.BackColor = Theme.ButtonHoverColor;
            this.btnMinimize.MouseLeave += (s, e) => btnMinimize.BackColor = Color.Transparent;

            this.btnClose = new Button();
            this.btnClose.Text = "✖";
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.BackColor = Color.Transparent;
            this.btnClose.ForeColor = Theme.ForeColor;
            this.btnClose.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnClose.Size = new Size(50, 50);
            this.btnClose.Click += (s, e) => Application.Exit();
            this.btnClose.MouseEnter += (s, e) => btnClose.BackColor = Theme.ButtonHoverColor;
            this.btnClose.MouseLeave += (s, e) => btnClose.BackColor = Color.Transparent;

            // ========== Форма ==========
            this.ClientSize = new Size(1000, 600);
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Theme.BackColor;
            this.ForeColor = Theme.ForeColor;
            this.Resize += (s, e) =>
            {
                CenterButtonsInPanel();
                PositionTopElements();
                PositionButtonsInCorner();
                sidePanel.Height = this.ClientSize.Height;
            };

            this.Controls.Add(this.contentContainer);
            this.Controls.Add(this.sidePanel);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnClose);

            this.sidePanel.BringToFront();
            this.pictureBoxLogo.BringToFront();
            this.titleLabel.BringToFront();
            this.searchPanel.BringToFront();
            this.btnMinimize.BringToFront();
            this.btnClose.BringToFront();

            this.ResumeLayout(false);
            this.PerformLayout();

            CenterButtonsInPanel();
            PositionTopElements();
            PositionButtonsInCorner();
            sidePanel.Height = this.ClientSize.Height;
        }

        private void PositionTopElements()
        {
            if (pictureBoxLogo == null || titleLabel == null || searchPanel == null) return;
            int topMargin = 10;
            int leftMargin = 300;

            pictureBoxLogo.Location = new Point(leftMargin, topMargin);
            titleLabel.Location = new Point(leftMargin + pictureBoxLogo.Width + 10,
                                            topMargin + (pictureBoxLogo.Height - titleLabel.Height) / 2);

            // Поиск справа от названия, на том же уровне
            int searchX = titleLabel.Right + 30;
            int searchY = topMargin + (pictureBoxLogo.Height - searchPanel.Height) / 2;
            searchPanel.Location = new Point(searchX, searchY);
        }

        private void PositionButtonsInCorner()
        {
            if (btnMinimize == null || btnClose == null) return;
            int margin = 0;
            int buttonSize = 50;
            btnClose.Location = new Point(this.ClientSize.Width - buttonSize - margin, margin);
            btnMinimize.Location = new Point(btnClose.Left - buttonSize - 5, margin);
        }
    }
}