using System;
using System.Drawing;
using System.Windows.Forms;

namespace ReelRent
{
    public partial class MainForm : Form
    {
        private Timer animationTimer;
        private Timer delayTimer;
        private bool expanding = false;

        private CatalogControl catalogControl;
        private CartControl cartControl;
        private ProfileControl profileControl;
        private AdminControl adminControl;

        public MainForm()
        {
            InitializeComponent();

            // Подписки на события для боковой панели и кнопок
            sidePanel.MouseEnter += PanelOrButton_MouseEnter;
            sidePanel.MouseLeave += PanelOrButton_MouseLeave;
            btnCatalog.MouseEnter += PanelOrButton_MouseEnter;
            btnCatalog.MouseLeave += PanelOrButton_MouseLeave;
            btnProfile.MouseEnter += PanelOrButton_MouseEnter;
            btnProfile.MouseLeave += PanelOrButton_MouseLeave;
            btnCart.MouseEnter += PanelOrButton_MouseEnter;
            btnCart.MouseLeave += PanelOrButton_MouseLeave;
            btnAbout.MouseEnter += PanelOrButton_MouseEnter;
            btnAbout.MouseLeave += PanelOrButton_MouseLeave;
            btnManage.MouseEnter += PanelOrButton_MouseEnter;
            btnManage.MouseLeave += PanelOrButton_MouseLeave;

            animationTimer = new Timer();
            animationTimer.Interval = 10;
            animationTimer.Tick += AnimationTimer_Tick;

            delayTimer = new Timer();
            delayTimer.Interval = 100;
            delayTimer.Tick += DelayTimer_Tick;

            // Создаём контролы
            catalogControl = new CatalogControl();
            cartControl = new CartControl();
            profileControl = new ProfileControl();
            adminControl = new AdminControl();

            // Подписываемся на события возврата
            cartControl.BackButtonClicked += (s, e) => ShowCatalog();
            profileControl.BackButtonClicked += (s, e) => ShowCatalog();
            adminControl.BackButtonClicked += (s, e) => ShowCatalog();

            // Показываем каталог по умолчанию
            ShowCatalog();

            // Показать/скрыть кнопку управления в зависимости от прав
            UpdateSidePanelForUser();
        }

        private void ShowCatalog()
        {
            ShowControl(catalogControl);
            catalogControl.RefreshCatalog(); // Обновляем содержимое каталога
        }

        private void ShowControl(UserControl control)
        {
            contentContainer.Controls.Clear();
            control.Dock = DockStyle.Fill;
            contentContainer.Controls.Add(control);
        }

        private void UpdateSidePanelForUser()
        {
            btnManage.Visible = Session.IsAdmin;
            CenterButtonsInPanel();
        }

        private void BtnCatalog_Click(object sender, EventArgs e)
        {
            ShowCatalog();
        }

        private void BtnProfile_Click(object sender, EventArgs e)
        {
            if (Session.IsAuthenticated)
            {
                profileControl = new ProfileControl(); // обновляем данные
                profileControl.BackButtonClicked += (s, ev) => ShowCatalog();
                ShowControl(profileControl);
            }
            else
            {
                LoginForm loginForm = new LoginForm();
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    UpdateSidePanelForUser();
                    // После входа показываем профиль
                    profileControl = new ProfileControl();
                    profileControl.BackButtonClicked += (s, ev) => ShowCatalog();
                    ShowControl(profileControl);
                }
            }
        }

        private void BtnCart_Click(object sender, EventArgs e)
        {
            cartControl = new CartControl();
            cartControl.BackButtonClicked += (s, ev) => ShowCatalog();
            ShowControl(cartControl);
        }

        private void BtnManage_Click(object sender, EventArgs e)
        {
            if (Session.IsAdmin)
            {
                adminControl = new AdminControl();
                adminControl.BackButtonClicked += (s, ev) => ShowCatalog();
                ShowControl(adminControl);
            }
            else
            {
                MessageBox.Show("Доступ запрещён.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            string info = "Видеопрокат «КиноПрокат»\nВерсия 1.0\nРазработано студентом\n\nПриложение позволяет просматривать каталог фильмов, брать их в аренду, управлять личным кабинетом.\nДля связи: example@mail.ru";
            MessageBox.Show(info, "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ========== Анимация боковой панели (без изменений) ==========
        private void PanelOrButton_MouseEnter(object sender, EventArgs e)
        {
            delayTimer.Stop();
            expanding = true;
            animationTimer.Start();
            sidePanel.BringToFront();
            pictureBoxLogo.BringToFront();
            titleLabel.BringToFront();
            btnMinimize.BringToFront();
            btnClose.BringToFront();
        }

        private void PanelOrButton_MouseLeave(object sender, EventArgs e)
        {
            delayTimer.Start();
        }

        private void DelayTimer_Tick(object sender, EventArgs e)
        {
            delayTimer.Stop();
            if (IsMouseOverPanelOrButtons())
                return;
            expanding = false;
            animationTimer.Start();
        }

        private bool IsMouseOverPanelOrButtons()
        {
            Point cursorPos = this.PointToClient(Cursor.Position);
            if (sidePanel.ClientRectangle.Contains(sidePanel.PointToClient(cursorPos)))
                return true;
            if (btnCatalog.ClientRectangle.Contains(btnCatalog.PointToClient(cursorPos)))
                return true;
            if (btnProfile.ClientRectangle.Contains(btnProfile.PointToClient(cursorPos)))
                return true;
            if (btnCart.ClientRectangle.Contains(btnCart.PointToClient(cursorPos)))
                return true;
            if (btnManage.ClientRectangle.Contains(btnManage.PointToClient(cursorPos)))
                return true;
            if (btnAbout.ClientRectangle.Contains(btnAbout.PointToClient(cursorPos)))
                return true;
            return false;
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            int targetWidth = expanding ? 300 : 70;
            if (sidePanel.Width == targetWidth)
            {
                animationTimer.Stop();
                if (expanding)
                    SetButtonsTextWithLabels();
                else
                    SetButtonsTextOnlyIcons();
                CenterButtonsInPanel();
                return;
            }
            int step = expanding ? 20 : -20;
            int newWidth = sidePanel.Width + step;
            newWidth = Math.Max(70, Math.Min(300, newWidth));
            sidePanel.Width = newWidth;
            CenterButtonsInPanel();

            if (expanding && newWidth > 120 && btnCatalog.Text == "📀")
                SetButtonsTextWithLabels();
            else if (!expanding && newWidth < 120 && btnCatalog.Text != "📀")
                SetButtonsTextOnlyIcons();
        }

        private void SetButtonsTextWithLabels()
        {
            btnCatalog.Text = "📀 Каталог";
            btnProfile.Text = "👤 Личный кабинет";
            btnCart.Text = "🛒 Корзина";
            btnManage.Text = "⚙️ Управление";
            btnAbout.Text = "ℹ️ О программе";

            btnCatalog.TextAlign = ContentAlignment.MiddleLeft;
            btnProfile.TextAlign = ContentAlignment.MiddleLeft;
            btnCart.TextAlign = ContentAlignment.MiddleLeft;
            btnManage.TextAlign = ContentAlignment.MiddleLeft;
            btnAbout.TextAlign = ContentAlignment.MiddleLeft;

            btnCatalog.Padding = new Padding(25, 0, 0, 0);
            btnProfile.Padding = new Padding(25, 0, 0, 0);
            btnCart.Padding = new Padding(25, 0, 0, 0);
            btnManage.Padding = new Padding(25, 0, 0, 0);
            btnAbout.Padding = new Padding(25, 0, 0, 0);
        }

        private void SetButtonsTextOnlyIcons()
        {
            btnCatalog.Text = "📀";
            btnProfile.Text = "👤";
            btnCart.Text = "🛒";
            btnManage.Text = "⚙️";
            btnAbout.Text = "ℹ️";

            btnCatalog.TextAlign = ContentAlignment.MiddleCenter;
            btnProfile.TextAlign = ContentAlignment.MiddleCenter;
            btnCart.TextAlign = ContentAlignment.MiddleCenter;
            btnManage.TextAlign = ContentAlignment.MiddleCenter;
            btnAbout.TextAlign = ContentAlignment.MiddleCenter;

            btnCatalog.Padding = new Padding(0);
            btnProfile.Padding = new Padding(0);
            btnCart.Padding = new Padding(0);
            btnManage.Padding = new Padding(0);
            btnAbout.Padding = new Padding(0);
        }

        private void CenterButtonsInPanel()
        {
            if (sidePanel == null) return;

            var buttons = new System.Collections.Generic.List<Button>();
            if (btnManage.Visible) buttons.Add(btnManage);
            buttons.Add(btnCatalog);
            buttons.Add(btnProfile);
            buttons.Add(btnCart);
            buttons.Add(btnAbout);

            int panelHeight = sidePanel.ClientSize.Height;
            int totalHeight = 0;
            foreach (var btn in buttons)
                totalHeight += btn.Height;

            int startY = (panelHeight - totalHeight) / 2;
            if (startY < 0) startY = 0;

            int currentY = startY;
            foreach (var btn in buttons)
            {
                btn.Top = currentY;
                btn.Width = sidePanel.Width;
                currentY += btn.Height;
            }
        }
        private void SearchMovies()
        {
            string query = searchBox.Text.Trim();
            if (string.IsNullOrEmpty(query) || query == "Поиск фильмов...")
                query = "";

            if (contentContainer.Controls.Count > 0 && contentContainer.Controls[0] is CatalogControl catalog)
            {
                catalog.FilterMovies(query);
            }
        }

        private void ShowFilterDialog()
        {
            MessageBox.Show("Форма фильтров будет открыта", "Фильтры", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}