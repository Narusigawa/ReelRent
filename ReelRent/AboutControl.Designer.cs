using System.Drawing;
using System.Windows.Forms;

namespace ReelRent
{
    partial class AboutControl
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnBack;
        private Label lblTitle;
        private Panel contentPanel;
        private FlowLayoutPanel flowLayout;

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
            this.contentPanel = new Panel();
            this.flowLayout = new FlowLayoutPanel();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();

            // AboutControl
            this.BackColor = Theme.BackColor;
            this.Dock = DockStyle.Fill;

            // btnBack
            this.btnBack.Text = "← Назад";
            this.btnBack.FlatStyle = FlatStyle.Flat;
            this.btnBack.BackColor = Theme.PanelColor;
            this.btnBack.ForeColor = Theme.ForeColor;
            this.btnBack.Size = new Size(120, 45);
            this.btnBack.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnBack.Cursor = Cursors.Hand;
            this.btnBack.Click += BtnBack_Click;
            this.btnBack.MouseEnter += (s, e) => btnBack.BackColor = Theme.ButtonHoverColor;
            this.btnBack.MouseLeave += (s, e) => btnBack.BackColor = Theme.PanelColor;

            // lblTitle
            this.lblTitle.Text = "О видеопрокате";
            this.lblTitle.Font = new Font("Segoe UI", 32, FontStyle.Bold);
            this.lblTitle.ForeColor = Theme.AccentForeColor;
            this.lblTitle.AutoSize = true;

            // contentPanel
            this.contentPanel.BackColor = Color.Transparent;
            this.contentPanel.AutoScroll = true;

            // flowLayout
            this.flowLayout.FlowDirection = FlowDirection.TopDown;
            this.flowLayout.WrapContents = false;
            this.flowLayout.AutoSize = true;
            this.flowLayout.Padding = new Padding(20);
            this.flowLayout.BackColor = Color.Transparent;

            // Блок 1: Добро пожаловать
            Panel welcomeBlock = CreateBlock("🎬 Добро пожаловать в КиноПрокат!",
                "Ваш надёжный сервис для аренды фильмов на любой вкус.\n" +
                "Удобный поиск, выгодные цены и быстрая доставка.");

            // Блок 2: Возможности
            Panel featuresBlock = CreateBlock("✨ Возможности приложения",
                "• 📀 Просмотр каталога фильмов с удобной фильтрацией\n" +
                "• 🛒 Аренда фильмов на выбранное количество дней\n" +
                "• 🚚 Оформление заказов с доставкой\n" +
                "• 📋 Отслеживание текущих аренд и истории заказов\n" +
                "• 👤 Управление личным профилем\n" +
                "• ⚙️ Администрирование (для сотрудников)");

            // Блок 3: Условия аренды
            Panel termsBlock = CreateBlock("📋 Условия аренды",
                "• Аренда доступна только авторизованным пользователям\n" +
                "• Стоимость аренды указана на карточке фильма\n" +
                "• Максимальный срок аренды — 30 дней\n" +
                "• По истечении срока заказ считается просроченным\n" +
                "• Для оформления заказа нужны: ФИО, телефон и адрес доставки\n" +
                "• Оплата производится при получении (наличными или картой)");

            // Блок 4: Контакты поддержки
            Panel contactsBlock = CreateBlock("📞 Техническая поддержка",
                "Email: support@kinoprokat.ru\n" +
                "Время работы: Пн-Пт с 10:00 до 19:00\n");

            // Блок 5: О приложении
            Panel aboutBlock = CreateBlock("ℹ️ О приложении",
                "Версия: 1.0.0\n" +
                "Разработано с любовью для вас ❤️\n" +
                "© 2025 КиноПрокат. Все права защищены.");

            this.flowLayout.Controls.Add(welcomeBlock);
            this.flowLayout.Controls.Add(featuresBlock);
            this.flowLayout.Controls.Add(termsBlock);
            this.flowLayout.Controls.Add(contactsBlock);
            this.flowLayout.Controls.Add(aboutBlock);

            this.contentPanel.Controls.Add(this.flowLayout);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.contentPanel);

            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Panel CreateBlock(string title, string content)
        {
            Panel block = new Panel();
            block.BackColor = Theme.PanelColor;
            block.BorderStyle = BorderStyle.FixedSingle;
            block.Padding = new Padding(15);
            block.Margin = new Padding(0, 0, 0, 15);
            block.Width = 700;

            // Заголовок блока
            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitle.ForeColor = Theme.AccentForeColor;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(10, 10);

            // Разделитель
            Panel separator = new Panel();
            separator.BackColor = Theme.AccentForeColor;
            separator.Height = 2;
            separator.Width = block.Width - 30;
            separator.Location = new Point(10, lblTitle.Bottom + 8);

            // Содержание
            Label lblContent = new Label();
            lblContent.Text = content;
            lblContent.Font = new Font("Segoe UI", 11);
            lblContent.ForeColor = Theme.ForeColor;
            lblContent.AutoSize = false;
            lblContent.Width = block.Width - 30;
            lblContent.TextAlign = ContentAlignment.TopLeft;

            // Вычисляем высоту текста
            Size textSize = TextRenderer.MeasureText(content, lblContent.Font, new Size(lblContent.Width, int.MaxValue), TextFormatFlags.WordBreak);
            lblContent.Height = textSize.Height + 10;
            lblContent.Location = new Point(10, separator.Bottom + 10);

            block.Height = lblContent.Bottom + 15;
            block.Controls.Add(lblTitle);
            block.Controls.Add(separator);
            block.Controls.Add(lblContent);

            return block;
        }
    }
}