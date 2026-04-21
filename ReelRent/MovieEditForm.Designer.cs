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
        private TextBox txtDuration;
        private ComboBox cmbAgeRating;
        private ComboBox cmbMediaFormat;
        private TextBox txtLanguage;
        private TextBox txtDescription;
        private TextBox txtTotalCopies;
        private TextBox txtAvailableCopies;
        private TextBox txtRentalPrice;
        private Label lblTitle;
        private Label lblGenre;
        private Label lblYear;
        private Label lblDirector;
        private Label lblActors;
        private Label lblDuration;
        private Label lblAgeRating;
        private Label lblMediaFormat;
        private Label lblLanguage;
        private Label lblDescription;
        private Label lblTotalCopies;
        private Label lblAvailableCopies;
        private Label lblRentalPrice;
        private Button btnSelectPoster;
        private PictureBox picturePoster;
        private Button btnSave;
        private Button btnCancel;
        private Button btnClose;
        private Panel borderPanel;
        private Panel contentPanel;
        private TableLayoutPanel mainLayout;
        private Panel leftPanel;
        private Panel rightPanel;
        private TableLayoutPanel fieldsLayout;
        private Panel buttonPanel;

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
            this.mainLayout = new TableLayoutPanel();
            this.leftPanel = new Panel();
            this.picturePoster = new PictureBox();
            this.btnSelectPoster = new Button();
            this.rightPanel = new Panel();
            this.fieldsLayout = new TableLayoutPanel();
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
            this.lblDuration = new Label();
            this.txtDuration = new TextBox();
            this.lblAgeRating = new Label();
            this.cmbAgeRating = new ComboBox();
            this.lblMediaFormat = new Label();
            this.cmbMediaFormat = new ComboBox();
            this.lblLanguage = new Label();
            this.txtLanguage = new TextBox();
            this.lblDescription = new Label();
            this.txtDescription = new TextBox();
            this.lblTotalCopies = new Label();
            this.txtTotalCopies = new TextBox();
            this.lblAvailableCopies = new Label();
            this.txtAvailableCopies = new TextBox();
            this.lblRentalPrice = new Label();
            this.txtRentalPrice = new TextBox();
            this.buttonPanel = new Panel();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.borderPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.mainLayout.SuspendLayout();
            this.leftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturePoster)).BeginInit();
            this.rightPanel.SuspendLayout();
            this.fieldsLayout.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.SuspendLayout();

            // borderPanel
            this.borderPanel.Dock = DockStyle.Fill;
            this.borderPanel.BackColor = Color.White;
            this.borderPanel.Padding = new Padding(1);

            // contentPanel
            this.contentPanel.Dock = DockStyle.Fill;
            this.contentPanel.BackColor = Theme.BackColor;
            this.contentPanel.Padding = new Padding(20);
            this.contentPanel.Controls.Add(this.btnClose);
            this.contentPanel.Controls.Add(this.mainLayout);

            // btnClose
            this.btnClose.Text = "✖";
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.BackColor = Color.Transparent;
            this.btnClose.ForeColor = Theme.ForeColor;
            this.btnClose.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnClose.Size = new Size(40, 40);
            this.btnClose.Cursor = Cursors.Hand;
            this.btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnClose.Click += (s, e) => this.Close();
            this.btnClose.MouseEnter += (s, e) => btnClose.BackColor = Theme.ButtonHoverColor;
            this.btnClose.MouseLeave += (s, e) => btnClose.BackColor = Color.Transparent;

            // mainLayout
            this.mainLayout.Dock = DockStyle.Fill;
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.RowCount = 1;
            this.mainLayout.Padding = new Padding(5);
            this.mainLayout.BackColor = Color.Transparent;
            this.mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300));
            this.mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            // leftPanel
            this.leftPanel.BackColor = Color.Transparent;
            this.leftPanel.Dock = DockStyle.Fill;
            this.leftPanel.Padding = new Padding(5);
            this.leftPanel.Controls.Add(this.picturePoster);
            this.leftPanel.Controls.Add(this.btnSelectPoster);
            this.mainLayout.Controls.Add(this.leftPanel, 0, 0);

            // picturePoster
            this.picturePoster.SizeMode = PictureBoxSizeMode.StretchImage;
            this.picturePoster.BorderStyle = BorderStyle.FixedSingle;
            this.picturePoster.Size = new Size(280, 370);
            this.picturePoster.BackColor = Color.FromArgb(60, 60, 60);
            this.picturePoster.Location = new Point(5, 10);
            this.picturePoster.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // btnSelectPoster
            this.btnSelectPoster.Text = "Выбрать постер";
            this.btnSelectPoster.FlatStyle = FlatStyle.Flat;
            this.btnSelectPoster.BackColor = Theme.PanelColor;
            this.btnSelectPoster.ForeColor = Theme.ForeColor;
            this.btnSelectPoster.Size = new Size(280, 40);
            this.btnSelectPoster.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnSelectPoster.Cursor = Cursors.Hand;
            this.btnSelectPoster.Location = new Point(5, 390);
            this.btnSelectPoster.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.btnSelectPoster.Click += btnSelectPoster_Click;

            // rightPanel
            this.rightPanel.BackColor = Color.Transparent;
            this.rightPanel.Dock = DockStyle.Fill;
            this.rightPanel.AutoScroll = true;
            this.rightPanel.Padding = new Padding(5, 0, 5, 0);
            this.rightPanel.Controls.Add(this.fieldsLayout);
            this.mainLayout.Controls.Add(this.rightPanel, 1, 0);

            // fieldsLayout
            this.fieldsLayout.Dock = DockStyle.Top;
            this.fieldsLayout.ColumnCount = 1;
            this.fieldsLayout.RowCount = 27;
            this.fieldsLayout.Padding = new Padding(0);
            this.fieldsLayout.BackColor = Color.Transparent;
            this.fieldsLayout.AutoSize = true;
            this.fieldsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            for (int i = 0; i < 27; i++)
                this.fieldsLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // Общие стили
            Font labelFont = new Font("Segoe UI", 12, FontStyle.Bold);
            Font fieldFont = new Font("Segoe UI", 12);
            Color labelColor = Theme.ForeColor;
            Color fieldBackColor = Theme.PanelColor;
            Color fieldForeColor = Theme.ForeColor;

            // Название
            this.lblTitle.Text = "Название:";
            this.lblTitle.Font = labelFont;
            this.lblTitle.ForeColor = labelColor;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Margin = new Padding(0, 5, 0, 2);
            this.fieldsLayout.Controls.Add(this.lblTitle, 0, 0);

            this.txtTitle.Font = fieldFont;
            this.txtTitle.BackColor = fieldBackColor;
            this.txtTitle.ForeColor = fieldForeColor;
            this.txtTitle.BorderStyle = BorderStyle.FixedSingle;
            this.txtTitle.Dock = DockStyle.Fill;
            this.txtTitle.Margin = new Padding(0, 0, 0, 10);
            this.fieldsLayout.Controls.Add(this.txtTitle, 0, 1);

            // Жанр
            this.lblGenre.Text = "Жанр:";
            this.lblGenre.Font = labelFont;
            this.lblGenre.ForeColor = labelColor;
            this.lblGenre.AutoSize = true;
            this.lblGenre.Margin = new Padding(0, 5, 0, 2);
            this.fieldsLayout.Controls.Add(this.lblGenre, 0, 2);

            this.txtGenre.Font = fieldFont;
            this.txtGenre.BackColor = fieldBackColor;
            this.txtGenre.ForeColor = fieldForeColor;
            this.txtGenre.BorderStyle = BorderStyle.FixedSingle;
            this.txtGenre.Dock = DockStyle.Fill;
            this.txtGenre.Margin = new Padding(0, 0, 0, 10);
            this.fieldsLayout.Controls.Add(this.txtGenre, 0, 3);

            // Год
            this.lblYear.Text = "Год:";
            this.lblYear.Font = labelFont;
            this.lblYear.ForeColor = labelColor;
            this.lblYear.AutoSize = true;
            this.lblYear.Margin = new Padding(0, 5, 0, 2);
            this.fieldsLayout.Controls.Add(this.lblYear, 0, 4);

            this.txtYear.Font = fieldFont;
            this.txtYear.BackColor = fieldBackColor;
            this.txtYear.ForeColor = fieldForeColor;
            this.txtYear.BorderStyle = BorderStyle.FixedSingle;
            this.txtYear.Dock = DockStyle.Fill;
            this.txtYear.Margin = new Padding(0, 0, 0, 10);
            this.fieldsLayout.Controls.Add(this.txtYear, 0, 5);

            // Режиссёр
            this.lblDirector.Text = "Режиссёры:";
            this.lblDirector.Font = labelFont;
            this.lblDirector.ForeColor = labelColor;
            this.lblDirector.AutoSize = true;
            this.lblDirector.Margin = new Padding(0, 5, 0, 2);
            this.fieldsLayout.Controls.Add(this.lblDirector, 0, 6);

            this.txtDirector.Font = fieldFont;
            this.txtDirector.BackColor = fieldBackColor;
            this.txtDirector.ForeColor = fieldForeColor;
            this.txtDirector.BorderStyle = BorderStyle.FixedSingle;
            this.txtDirector.Dock = DockStyle.Fill;
            this.txtDirector.Margin = new Padding(0, 0, 0, 10);
            this.fieldsLayout.Controls.Add(this.txtDirector, 0, 7);

            // Актёры
            this.lblActors.Text = "В главных ролях (актёры):";
            this.lblActors.Font = labelFont;
            this.lblActors.ForeColor = labelColor;
            this.lblActors.AutoSize = true;
            this.lblActors.Margin = new Padding(0, 5, 0, 2);
            this.fieldsLayout.Controls.Add(this.lblActors, 0, 8);

            this.txtActors.Font = fieldFont;
            this.txtActors.BackColor = fieldBackColor;
            this.txtActors.ForeColor = fieldForeColor;
            this.txtActors.BorderStyle = BorderStyle.FixedSingle;
            this.txtActors.Dock = DockStyle.Fill;
            this.txtActors.Margin = new Padding(0, 0, 0, 10);
            this.fieldsLayout.Controls.Add(this.txtActors, 0, 9);

            // Длительность
            this.lblDuration.Text = "Длительность (мин):";
            this.lblDuration.Font = labelFont;
            this.lblDuration.ForeColor = labelColor;
            this.lblDuration.AutoSize = true;
            this.lblDuration.Margin = new Padding(0, 5, 0, 2);
            this.fieldsLayout.Controls.Add(this.lblDuration, 0, 10);

            this.txtDuration.Font = fieldFont;
            this.txtDuration.BackColor = fieldBackColor;
            this.txtDuration.ForeColor = fieldForeColor;
            this.txtDuration.BorderStyle = BorderStyle.FixedSingle;
            this.txtDuration.Dock = DockStyle.Fill;
            this.txtDuration.Margin = new Padding(0, 0, 0, 10);
            this.fieldsLayout.Controls.Add(this.txtDuration, 0, 11);

            // Возрастной рейтинг (ComboBox)
            this.lblAgeRating.Text = "Возрастной рейтинг:";
            this.lblAgeRating.Font = labelFont;
            this.lblAgeRating.ForeColor = labelColor;
            this.lblAgeRating.AutoSize = true;
            this.lblAgeRating.Margin = new Padding(0, 5, 0, 2);
            this.fieldsLayout.Controls.Add(this.lblAgeRating, 0, 12);

            this.cmbAgeRating.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbAgeRating.Font = fieldFont;
            this.cmbAgeRating.BackColor = fieldBackColor;
            this.cmbAgeRating.ForeColor = fieldForeColor;
            this.cmbAgeRating.FlatStyle = FlatStyle.Flat;
            this.cmbAgeRating.Dock = DockStyle.Fill;
            this.cmbAgeRating.Margin = new Padding(0, 0, 0, 10);
            this.cmbAgeRating.Items.AddRange(new object[] {
                "0+", "6+", "12+", "16+", "18+"
            });
            this.fieldsLayout.Controls.Add(this.cmbAgeRating, 0, 13);

            // Формат носителя (ComboBox)
            this.lblMediaFormat.Text = "Формат носителя:";
            this.lblMediaFormat.Font = labelFont;
            this.lblMediaFormat.ForeColor = labelColor;
            this.lblMediaFormat.AutoSize = true;
            this.lblMediaFormat.Margin = new Padding(0, 5, 0, 2);
            this.fieldsLayout.Controls.Add(this.lblMediaFormat, 0, 14);

            this.cmbMediaFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbMediaFormat.Font = fieldFont;
            this.cmbMediaFormat.BackColor = fieldBackColor;
            this.cmbMediaFormat.ForeColor = fieldForeColor;
            this.cmbMediaFormat.FlatStyle = FlatStyle.Flat;
            this.cmbMediaFormat.Dock = DockStyle.Fill;
            this.cmbMediaFormat.Margin = new Padding(0, 0, 0, 10);
            this.cmbMediaFormat.Items.AddRange(new object[] {
                "DVD", "Blu-ray", "DVD + Blu-ray", "VHS", "Цифровая копия"
            });
            this.fieldsLayout.Controls.Add(this.cmbMediaFormat, 0, 15);

            // Язык / субтитры
            this.lblLanguage.Text = "Язык / субтитры:";
            this.lblLanguage.Font = labelFont;
            this.lblLanguage.ForeColor = labelColor;
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Margin = new Padding(0, 5, 0, 2);
            this.fieldsLayout.Controls.Add(this.lblLanguage, 0, 16);

            this.txtLanguage.Font = fieldFont;
            this.txtLanguage.BackColor = fieldBackColor;
            this.txtLanguage.ForeColor = fieldForeColor;
            this.txtLanguage.BorderStyle = BorderStyle.FixedSingle;
            this.txtLanguage.Dock = DockStyle.Fill;
            this.txtLanguage.Margin = new Padding(0, 0, 0, 10);
            this.fieldsLayout.Controls.Add(this.txtLanguage, 0, 17);

            // Описание (с прокруткой)
            this.lblDescription.Text = "Описание:";
            this.lblDescription.Font = labelFont;
            this.lblDescription.ForeColor = labelColor;
            this.lblDescription.AutoSize = true;
            this.lblDescription.Margin = new Padding(0, 5, 0, 2);
            this.fieldsLayout.Controls.Add(this.lblDescription, 0, 18);

            this.txtDescription.Font = fieldFont;
            this.txtDescription.Multiline = true;
            this.txtDescription.ScrollBars = ScrollBars.Vertical;
            this.txtDescription.Height = 120;
            this.txtDescription.BackColor = fieldBackColor;
            this.txtDescription.ForeColor = fieldForeColor;
            this.txtDescription.BorderStyle = BorderStyle.FixedSingle;
            this.txtDescription.Dock = DockStyle.Fill;
            this.txtDescription.Margin = new Padding(0, 0, 0, 10);
            this.fieldsLayout.Controls.Add(this.txtDescription, 0, 19);

            // Всего копий
            this.lblTotalCopies.Text = "Всего копий:";
            this.lblTotalCopies.Font = labelFont;
            this.lblTotalCopies.ForeColor = labelColor;
            this.lblTotalCopies.AutoSize = true;
            this.lblTotalCopies.Margin = new Padding(0, 5, 0, 2);
            this.fieldsLayout.Controls.Add(this.lblTotalCopies, 0, 20);

            this.txtTotalCopies.Font = fieldFont;
            this.txtTotalCopies.BackColor = fieldBackColor;
            this.txtTotalCopies.ForeColor = fieldForeColor;
            this.txtTotalCopies.BorderStyle = BorderStyle.FixedSingle;
            this.txtTotalCopies.Dock = DockStyle.Fill;
            this.txtTotalCopies.Margin = new Padding(0, 0, 0, 10);
            this.fieldsLayout.Controls.Add(this.txtTotalCopies, 0, 21);

            // Доступно копий
            this.lblAvailableCopies.Text = "Доступно копий:";
            this.lblAvailableCopies.Font = labelFont;
            this.lblAvailableCopies.ForeColor = labelColor;
            this.lblAvailableCopies.AutoSize = true;
            this.lblAvailableCopies.Margin = new Padding(0, 5, 0, 2);
            this.fieldsLayout.Controls.Add(this.lblAvailableCopies, 0, 22);

            this.txtAvailableCopies.Font = fieldFont;
            this.txtAvailableCopies.BackColor = fieldBackColor;
            this.txtAvailableCopies.ForeColor = fieldForeColor;
            this.txtAvailableCopies.BorderStyle = BorderStyle.FixedSingle;
            this.txtAvailableCopies.Dock = DockStyle.Fill;
            this.txtAvailableCopies.Margin = new Padding(0, 0, 0, 10);
            this.fieldsLayout.Controls.Add(this.txtAvailableCopies, 0, 23);

            // Цена аренды
            this.lblRentalPrice.Text = "Цена аренды (руб):";
            this.lblRentalPrice.Font = labelFont;
            this.lblRentalPrice.ForeColor = labelColor;
            this.lblRentalPrice.AutoSize = true;
            this.lblRentalPrice.Margin = new Padding(0, 5, 0, 2);
            this.fieldsLayout.Controls.Add(this.lblRentalPrice, 0, 24);

            this.txtRentalPrice.Font = fieldFont;
            this.txtRentalPrice.BackColor = fieldBackColor;
            this.txtRentalPrice.ForeColor = fieldForeColor;
            this.txtRentalPrice.BorderStyle = BorderStyle.FixedSingle;
            this.txtRentalPrice.Dock = DockStyle.Fill;
            this.txtRentalPrice.Margin = new Padding(0, 0, 0, 10);
            this.fieldsLayout.Controls.Add(this.txtRentalPrice, 0, 25);

            // Кнопки
            this.buttonPanel.Dock = DockStyle.Fill;
            this.buttonPanel.Height = 70;
            this.buttonPanel.BackColor = Color.Transparent;
            this.buttonPanel.Margin = new Padding(0, 10, 0, 0);
            this.btnSave.Text = "Сохранить";
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.BackColor = Theme.ButtonHoverColor;
            this.btnSave.ForeColor = Theme.ForeColor;
            this.btnSave.Size = new Size(160, 45);
            this.btnSave.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnSave.Cursor = Cursors.Hand;
            this.btnSave.Click += btnSave_Click;

            this.btnCancel.Text = "Отмена";
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.BackColor = Theme.PanelColor;
            this.btnCancel.ForeColor = Theme.ForeColor;
            this.btnCancel.Size = new Size(160, 45);
            this.btnCancel.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnCancel.Cursor = Cursors.Hand;
            this.btnCancel.Click += btnCancel_Click;

            this.buttonPanel.Controls.Add(this.btnSave);
            this.buttonPanel.Controls.Add(this.btnCancel);
            this.buttonPanel.Resize += (s, e) =>
            {
                int totalWidth = btnSave.Width + btnCancel.Width + 20;
                int x = (buttonPanel.Width - totalWidth) / 2;
                btnSave.Location = new Point(x, 10);
                btnCancel.Location = new Point(x + btnSave.Width + 20, 10);
            };
            this.fieldsLayout.Controls.Add(this.buttonPanel, 0, 26);

            // Форма
            this.ClientSize = new Size(1100, 850);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Theme.BackColor;
            this.ForeColor = Theme.ForeColor;
            this.Controls.Add(this.borderPanel);
            this.borderPanel.Controls.Add(this.contentPanel);

            // Завершение иерархии
            this.borderPanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.mainLayout.ResumeLayout(false);
            this.leftPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picturePoster)).EndInit();
            this.rightPanel.ResumeLayout(false);
            this.fieldsLayout.ResumeLayout(false);
            this.fieldsLayout.PerformLayout();
            this.buttonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

            this.contentPanel.Resize += (s, e) =>
            {
                btnClose.Location = new Point(this.contentPanel.Width - btnClose.Width - 10, 10);
            };
        }
    }
}