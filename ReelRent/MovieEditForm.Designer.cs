using System.Drawing;
using System.Windows.Forms;

namespace ReelRent
{
    partial class MovieEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtTitle;
        private TextBox txtGenre;
        private TextBox txtYear;
        private TextBox txtDirector;
        private TextBox txtActors;
        private TextBox txtDescription;
        private TextBox txtTotalCopies;
        private TextBox txtAvailableCopies;
        private TextBox txtRentalPrice;
        private Label lblTitle;
        private Label lblGenre;
        private Label lblYear;
        private Label lblDirector;
        private Label lblActors;
        private Label lblDescription;
        private Label lblTotalCopies;
        private Label lblAvailableCopies;
        private Label lblRentalPrice;
        private Button btnSelectPoster;
        private PictureBox picturePoster;
        private Button btnSave;
        private Button btnCancel;
        private Button btnClose;
        private TableLayoutPanel mainTable;
        private Panel borderPanel;
        private Panel contentPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.borderPanel = new Panel();
            this.contentPanel = new Panel();
            this.btnClose = new Button();
            this.mainTable = new TableLayoutPanel();
            this.picturePoster = new PictureBox();
            this.btnSelectPoster = new Button();
            this.lblTitle = new Label();
            this.txtTitle = new TextBox();
            this.lblGenre = new Label();
            this.txtGenre = new TextBox();
            this.lblYear = new Label();
            this.txtYear = new TextBox();
            this.lblDirector = new Label();
            this.txtDirector = new TextBox();
            this.lblActors = new Label();
            this.txtActors = new TextBox();
            this.lblDescription = new Label();
            this.txtDescription = new TextBox();
            this.lblTotalCopies = new Label();
            this.txtTotalCopies = new TextBox();
            this.lblAvailableCopies = new Label();
            this.txtAvailableCopies = new TextBox();
            this.lblRentalPrice = new Label();
            this.txtRentalPrice = new TextBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.borderPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.mainTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturePoster)).BeginInit();
            this.SuspendLayout();

            // borderPanel – белая рамка по краям
            this.borderPanel.Dock = DockStyle.Fill;
            this.borderPanel.BackColor = Color.White;
            this.borderPanel.Padding = new Padding(1); // толщина рамки

            // contentPanel – внутренний контент с тёмным фоном
            this.contentPanel.Dock = DockStyle.Fill;
            this.contentPanel.BackColor = Theme.BackColor;
            this.contentPanel.Padding = new Padding(20);
            this.contentPanel.Controls.Add(this.btnClose);
            this.contentPanel.Controls.Add(this.mainTable);

            // btnClose – крестик в правом верхнем углу
            this.btnClose.Text = "✖";
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.BackColor = Color.Transparent;
            this.btnClose.ForeColor = Theme.ForeColor;
            this.btnClose.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnClose.Size = new Size(40, 40);
            this.btnClose.Cursor = Cursors.Hand;
            this.btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnClose.Location = new Point(0, 0);
            this.btnClose.Click += (s, e) => this.Close();
            this.btnClose.MouseEnter += (s, e) => btnClose.BackColor = Theme.ButtonHoverColor;
            this.btnClose.MouseLeave += (s, e) => btnClose.BackColor = Color.Transparent;

            // mainTable
            this.mainTable.Dock = DockStyle.Fill;
            this.mainTable.ColumnCount = 2;
            this.mainTable.RowCount = 12;
            this.mainTable.Padding = new Padding(30);
            this.mainTable.BackColor = Theme.BackColor;
            this.mainTable.AutoSize = false;

            // Настройка столбцов: первый – для меток (фиксированная ширина), второй – для полей
            this.mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
            this.mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            // Все строки – AutoSize
            for (int i = 0; i < 12; i++)
                this.mainTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // Строка 0: постер и кнопка (объединяем две колонки)
            Panel posterPanel = new Panel { Dock = DockStyle.Fill, Height = 320, Margin = new Padding(0, 0, 0, 10) };
            posterPanel.BackColor = Color.Transparent;

            // Постер
            this.picturePoster.SizeMode = PictureBoxSizeMode.StretchImage;
            this.picturePoster.BorderStyle = BorderStyle.FixedSingle;
            this.picturePoster.Size = new Size(230, 270);
            this.picturePoster.BackColor = Color.FromArgb(60, 60, 60);
            this.picturePoster.Location = new Point(30, 0);

            // Кнопка выбора постера
            this.btnSelectPoster.Text = "Выбрать постер";
            this.btnSelectPoster.FlatStyle = FlatStyle.Flat;
            this.btnSelectPoster.BackColor = Theme.PanelColor;
            this.btnSelectPoster.ForeColor = Theme.ForeColor;
            this.btnSelectPoster.Size = new Size(150, 40);
            this.btnSelectPoster.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnSelectPoster.Cursor = Cursors.Hand;
            this.btnSelectPoster.Location = new Point(210, 0);
            this.btnSelectPoster.Click += btnSelectPoster_Click;

            posterPanel.Controls.Add(this.picturePoster);
            posterPanel.Controls.Add(this.btnSelectPoster);
            posterPanel.Resize += (s, e) => CenterPosterPanel(posterPanel);

            this.mainTable.SetColumnSpan(posterPanel, 2);
            this.mainTable.Controls.Add(posterPanel, 0, 0);

            // Строка 1: Название
            this.mainTable.Controls.Add(this.lblTitle, 0, 1);
            this.mainTable.Controls.Add(this.txtTitle, 1, 1);

            // Строка 2: Жанр
            this.mainTable.Controls.Add(this.lblGenre, 0, 2);
            this.mainTable.Controls.Add(this.txtGenre, 1, 2);

            // Строка 3: Год
            this.mainTable.Controls.Add(this.lblYear, 0, 3);
            this.mainTable.Controls.Add(this.txtYear, 1, 3);

            // Строка 4: Режиссёр
            this.mainTable.Controls.Add(this.lblDirector, 0, 4);
            this.mainTable.Controls.Add(this.txtDirector, 1, 4);

            // Строка 5: Актёры
            this.mainTable.Controls.Add(this.lblActors, 0, 5);
            this.mainTable.Controls.Add(this.txtActors, 1, 5);

            // Строка 6: Описание (объединяем колонки)
            this.mainTable.SetColumnSpan(this.lblDescription, 2);
            this.mainTable.Controls.Add(this.lblDescription, 0, 6);
            this.mainTable.SetColumnSpan(this.txtDescription, 2);
            this.mainTable.Controls.Add(this.txtDescription, 0, 7);

            // Строка 8: Всего копий
            this.mainTable.Controls.Add(this.lblTotalCopies, 0, 8);
            this.mainTable.Controls.Add(this.txtTotalCopies, 1, 8);

            // Строка 9: Доступно копий
            this.mainTable.Controls.Add(this.lblAvailableCopies, 0, 9);
            this.mainTable.Controls.Add(this.txtAvailableCopies, 1, 9);

            // Строка 10: Цена аренды
            this.mainTable.Controls.Add(this.lblRentalPrice, 0, 10);
            this.mainTable.Controls.Add(this.txtRentalPrice, 1, 10);

            // Строка 11: Кнопки (объединяем колонки)
            Panel buttonPanel = new Panel { Dock = DockStyle.Fill, Height = 70, Margin = new Padding(0, 20, 0, 0) };
            buttonPanel.BackColor = Color.Transparent;
            buttonPanel.Controls.Add(this.btnSave);
            buttonPanel.Controls.Add(this.btnCancel);
            this.mainTable.SetColumnSpan(buttonPanel, 2);
            this.mainTable.Controls.Add(buttonPanel, 0, 11);
            buttonPanel.Resize += (s, e) => CenterButtons(buttonPanel);

            // Оформление меток и полей
            var labelFont = new Font("Segoe UI", 12, FontStyle.Bold);
            var fieldFont = new Font("Segoe UI", 12);

            this.lblTitle.Text = "Название:";
            this.lblTitle.Font = labelFont;
            this.lblTitle.ForeColor = Theme.ForeColor;
            this.lblTitle.AutoSize = true;

            this.txtTitle.Font = fieldFont;
            this.txtTitle.BackColor = Theme.PanelColor;
            this.txtTitle.ForeColor = Theme.ForeColor;
            this.txtTitle.BorderStyle = BorderStyle.FixedSingle;
            this.txtTitle.Dock = DockStyle.Fill;

            this.lblGenre.Text = "Жанр:";
            this.lblGenre.Font = labelFont;
            this.lblGenre.ForeColor = Theme.ForeColor;
            this.lblGenre.AutoSize = true;

            this.txtGenre.Font = fieldFont;
            this.txtGenre.BackColor = Theme.PanelColor;
            this.txtGenre.ForeColor = Theme.ForeColor;
            this.txtGenre.BorderStyle = BorderStyle.FixedSingle;
            this.txtGenre.Dock = DockStyle.Fill;

            this.lblYear.Text = "Год:";
            this.lblYear.Font = labelFont;
            this.lblYear.ForeColor = Theme.ForeColor;
            this.lblYear.AutoSize = true;

            this.txtYear.Font = fieldFont;
            this.txtYear.BackColor = Theme.PanelColor;
            this.txtYear.ForeColor = Theme.ForeColor;
            this.txtYear.BorderStyle = BorderStyle.FixedSingle;
            this.txtYear.Dock = DockStyle.Fill;

            this.lblDirector.Text = "Режиссёр:";
            this.lblDirector.Font = labelFont;
            this.lblDirector.ForeColor = Theme.ForeColor;
            this.lblDirector.AutoSize = true;

            this.txtDirector.Font = fieldFont;
            this.txtDirector.BackColor = Theme.PanelColor;
            this.txtDirector.ForeColor = Theme.ForeColor;
            this.txtDirector.BorderStyle = BorderStyle.FixedSingle;
            this.txtDirector.Dock = DockStyle.Fill;

            this.lblActors.Text = "Актёры:";
            this.lblActors.Font = labelFont;
            this.lblActors.ForeColor = Theme.ForeColor;
            this.lblActors.AutoSize = true;

            this.txtActors.Font = fieldFont;
            this.txtActors.BackColor = Theme.PanelColor;
            this.txtActors.ForeColor = Theme.ForeColor;
            this.txtActors.BorderStyle = BorderStyle.FixedSingle;
            this.txtActors.Dock = DockStyle.Fill;

            this.lblDescription.Text = "Описание:";
            this.lblDescription.Font = labelFont;
            this.lblDescription.ForeColor = Theme.ForeColor;
            this.lblDescription.AutoSize = true;
            this.lblDescription.Margin = new Padding(3, 10, 3, 5);

            this.txtDescription.Font = fieldFont;
            this.txtDescription.Multiline = true;
            this.txtDescription.Height = 140;
            this.txtDescription.BackColor = Theme.PanelColor;
            this.txtDescription.ForeColor = Theme.ForeColor;
            this.txtDescription.BorderStyle = BorderStyle.FixedSingle;
            this.txtDescription.Dock = DockStyle.Fill;

            this.lblTotalCopies.Text = "Всего копий:";
            this.lblTotalCopies.Font = labelFont;
            this.lblTotalCopies.ForeColor = Theme.ForeColor;
            this.lblTotalCopies.AutoSize = true;

            this.txtTotalCopies.Font = fieldFont;
            this.txtTotalCopies.BackColor = Theme.PanelColor;
            this.txtTotalCopies.ForeColor = Theme.ForeColor;
            this.txtTotalCopies.BorderStyle = BorderStyle.FixedSingle;
            this.txtTotalCopies.Dock = DockStyle.Fill;

            this.lblAvailableCopies.Text = "Доступно копий:";
            this.lblAvailableCopies.Font = labelFont;
            this.lblAvailableCopies.ForeColor = Theme.ForeColor;
            this.lblAvailableCopies.AutoSize = true;

            this.txtAvailableCopies.Font = fieldFont;
            this.txtAvailableCopies.BackColor = Theme.PanelColor;
            this.txtAvailableCopies.ForeColor = Theme.ForeColor;
            this.txtAvailableCopies.BorderStyle = BorderStyle.FixedSingle;
            this.txtAvailableCopies.Dock = DockStyle.Fill;

            this.lblRentalPrice.Text = "Цена аренды (руб):";
            this.lblRentalPrice.Font = labelFont;
            this.lblRentalPrice.ForeColor = Theme.ForeColor;
            this.lblRentalPrice.AutoSize = true;

            this.txtRentalPrice.Font = fieldFont;
            this.txtRentalPrice.BackColor = Theme.PanelColor;
            this.txtRentalPrice.ForeColor = Theme.ForeColor;
            this.txtRentalPrice.BorderStyle = BorderStyle.FixedSingle;
            this.txtRentalPrice.Dock = DockStyle.Fill;

            // Кнопки
            this.btnSave.Text = "Сохранить";
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.BackColor = Theme.ButtonHoverColor;
            this.btnSave.ForeColor = Theme.ForeColor;
            this.btnSave.Size = new Size(160, 50);
            this.btnSave.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnSave.Cursor = Cursors.Hand;
            this.btnSave.Click += btnSave_Click;

            this.btnCancel.Text = "Отмена";
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.BackColor = Theme.PanelColor;
            this.btnCancel.ForeColor = Theme.ForeColor;
            this.btnCancel.Size = new Size(160, 50);
            this.btnCancel.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnCancel.Cursor = Cursors.Hand;
            this.btnCancel.Click += btnCancel_Click;

            // Форма
            this.ClientSize = new Size(950, 955);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Theme.BackColor;
            this.ForeColor = Theme.ForeColor;
            this.Controls.Add(this.borderPanel);
            this.borderPanel.Controls.Add(this.contentPanel);

            this.mainTable.ResumeLayout(false);
            this.mainTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturePoster)).EndInit();
            this.borderPanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

            // Центрируем панель с постером при загрузке
            CenterPosterPanel(posterPanel);

            // Подписываемся на изменение размера для пересчёта положения крестика
            this.contentPanel.Resize += (s, e) =>
            {
                btnClose.Location = new Point(this.contentPanel.Width - btnClose.Width - 10, 10);
            };
        }

        private void CenterPosterPanel(Panel panel)
        {
            if (panel == null || panel.Parent == null) return;
            int totalWidth = picturePoster.Width + btnSelectPoster.Width + 20; // 20 – отступ между ними
            int x = (panel.Width - totalWidth) / 2;
            if (x < 0) x = 0;
            picturePoster.Location = new Point(x, (panel.Height - picturePoster.Height) / 2);
            btnSelectPoster.Location = new Point(x + picturePoster.Width + 20, (panel.Height - btnSelectPoster.Height) / 2);
        }

        private void CenterButtons(Panel panel)
        {
            if (panel == null) return;
            int totalWidth = btnSave.Width + btnCancel.Width + 20;
            int x = (panel.Width - totalWidth) / 2;
            if (x < 0) x = 0;
            btnSave.Location = new Point(x, (panel.Height - btnSave.Height) / 2);
            btnCancel.Location = new Point(x + btnSave.Width + 20, (panel.Height - btnCancel.Height) / 2);
        }
    }
}