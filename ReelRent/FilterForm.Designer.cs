using System.Drawing;
using System.Windows.Forms;

namespace ReelRent
{
    partial class FilterForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel borderPanel;
        private Panel contentPanel;
        private Button btnClose;
        private TableLayoutPanel mainLayout;
        private Label lblTitle;
        private Label lblTitleSearch;
        private TextBox txtTitle;
        private Label lblYear;
        private NumericUpDown numYearFrom;
        private NumericUpDown numYearTo;
        private Label lblYearTo;
        private Label lblGenre;
        private ListBox lstGenres;
        private Label lblMediaFormat;
        private ListBox lstMediaFormats;
        private Label lblDirector;
        private TextBox txtDirector;
        private Label lblActors;
        private TextBox txtActors;
        private Label lblAgeRating;
        private ComboBox cmbAgeRating;
        private Button btnSearch;
        private Button btnReset;
        private Button btnCancel;

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
            this.lblTitle = new Label();
            this.lblTitleSearch = new Label();
            this.txtTitle = new TextBox();
            this.lblYear = new Label();
            this.numYearFrom = new NumericUpDown();
            this.numYearTo = new NumericUpDown();
            this.lblYearTo = new Label();
            this.lblGenre = new Label();
            this.lstGenres = new ListBox();
            this.lblMediaFormat = new Label();
            this.lstMediaFormats = new ListBox();
            this.lblDirector = new Label();
            this.txtDirector = new TextBox();
            this.lblActors = new Label();
            this.txtActors = new TextBox();
            this.lblAgeRating = new Label();
            this.cmbAgeRating = new ComboBox();
            this.btnSearch = new Button();
            this.btnReset = new Button();
            this.btnCancel = new Button();

            this.borderPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.mainLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYearFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYearTo)).BeginInit();
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
            this.mainLayout.RowCount = 9;
            this.mainLayout.Padding = new Padding(10);
            this.mainLayout.BackColor = Color.Transparent;
            this.mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
            this.mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            for (int i = 0; i < 9; i++)
                this.mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // Заголовок
            this.lblTitle.Text = "Расширенный поиск";
            this.lblTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            this.lblTitle.ForeColor = Theme.AccentForeColor;
            this.lblTitle.AutoSize = true;
            this.mainLayout.SetColumnSpan(this.lblTitle, 2);
            this.mainLayout.Controls.Add(this.lblTitle, 0, 0);

            // Название
            this.lblTitleSearch.Text = "Название:";
            this.lblTitleSearch.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.lblTitleSearch.ForeColor = Theme.ForeColor;
            this.lblTitleSearch.AutoSize = true;
            this.mainLayout.Controls.Add(this.lblTitleSearch, 0, 1);

            this.txtTitle.Font = new Font("Segoe UI", 12);
            this.txtTitle.BackColor = Theme.PanelColor;
            this.txtTitle.ForeColor = Theme.ForeColor;
            this.txtTitle.BorderStyle = BorderStyle.FixedSingle;
            this.txtTitle.Dock = DockStyle.Fill;
            this.mainLayout.Controls.Add(this.txtTitle, 1, 1);

            // Год
            this.lblYear.Text = "Год:";
            this.lblYear.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.lblYear.ForeColor = Theme.ForeColor;
            this.lblYear.AutoSize = true;
            this.mainLayout.Controls.Add(this.lblYear, 0, 2);

            Panel yearPanel = new Panel { Height = 35, Dock = DockStyle.Fill };
            this.numYearFrom.Font = new Font("Segoe UI", 12);
            this.numYearFrom.BackColor = Theme.PanelColor;
            this.numYearFrom.ForeColor = Theme.ForeColor;
            this.numYearFrom.Maximum = 2100;
            this.numYearFrom.Width = 80;
            this.numYearFrom.Location = new Point(0, 0);

            this.lblYearTo.Text = "—";
            this.lblYearTo.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.lblYearTo.ForeColor = Theme.ForeColor;
            this.lblYearTo.AutoSize = true;
            this.lblYearTo.Location = new Point(85, 5);

            this.numYearTo.Font = new Font("Segoe UI", 12);
            this.numYearTo.BackColor = Theme.PanelColor;
            this.numYearTo.ForeColor = Theme.ForeColor;
            this.numYearTo.Maximum = 2100;
            this.numYearTo.Width = 80;
            this.numYearTo.Location = new Point(110, 0);

            yearPanel.Controls.Add(this.numYearFrom);
            yearPanel.Controls.Add(this.lblYearTo);
            yearPanel.Controls.Add(this.numYearTo);
            this.mainLayout.Controls.Add(yearPanel, 1, 2);

            // Жанр (множественный выбор)
            this.lblGenre.Text = "Жанр (Ctrl+клик):";
            this.lblGenre.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.lblGenre.ForeColor = Theme.ForeColor;
            this.lblGenre.AutoSize = true;
            this.mainLayout.Controls.Add(this.lblGenre, 0, 3);

            this.lstGenres.SelectionMode = SelectionMode.MultiExtended;
            this.lstGenres.BackColor = Theme.PanelColor;
            this.lstGenres.ForeColor = Theme.ForeColor;
            this.lstGenres.Font = new Font("Segoe UI", 11);
            this.lstGenres.Height = 150;
            this.lstGenres.Dock = DockStyle.Fill;
            this.mainLayout.Controls.Add(this.lstGenres, 1, 3);

            // Носитель (множественный выбор)
            this.lblMediaFormat.Text = "Носитель (Ctrl+клик):";
            this.lblMediaFormat.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.lblMediaFormat.ForeColor = Theme.ForeColor;
            this.lblMediaFormat.AutoSize = true;
            this.mainLayout.Controls.Add(this.lblMediaFormat, 0, 4);

            this.lstMediaFormats.SelectionMode = SelectionMode.MultiExtended;
            this.lstMediaFormats.BackColor = Theme.PanelColor;
            this.lstMediaFormats.ForeColor = Theme.ForeColor;
            this.lstMediaFormats.Font = new Font("Segoe UI", 11);
            this.lstMediaFormats.Height = 80;
            this.lstMediaFormats.Dock = DockStyle.Fill;
            this.mainLayout.Controls.Add(this.lstMediaFormats, 1, 4);

            // Режиссёр
            this.lblDirector.Text = "Режиссёр:";
            this.lblDirector.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.lblDirector.ForeColor = Theme.ForeColor;
            this.lblDirector.AutoSize = true;
            this.mainLayout.Controls.Add(this.lblDirector, 0, 5);

            this.txtDirector.Font = new Font("Segoe UI", 12);
            this.txtDirector.BackColor = Theme.PanelColor;
            this.txtDirector.ForeColor = Theme.ForeColor;
            this.txtDirector.BorderStyle = BorderStyle.FixedSingle;
            this.txtDirector.Dock = DockStyle.Fill;
            this.mainLayout.Controls.Add(this.txtDirector, 1, 5);

            // Актёры
            this.lblActors.Text = "В ролях:";
            this.lblActors.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.lblActors.ForeColor = Theme.ForeColor;
            this.lblActors.AutoSize = true;
            this.mainLayout.Controls.Add(this.lblActors, 0, 6);

            this.txtActors.Font = new Font("Segoe UI", 12);
            this.txtActors.BackColor = Theme.PanelColor;
            this.txtActors.ForeColor = Theme.ForeColor;
            this.txtActors.BorderStyle = BorderStyle.FixedSingle;
            this.txtActors.Dock = DockStyle.Fill;
            this.mainLayout.Controls.Add(this.txtActors, 1, 6);

            // Возрастной рейтинг
            this.lblAgeRating.Text = "Возрастной рейтинг:";
            this.lblAgeRating.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.lblAgeRating.ForeColor = Theme.ForeColor;
            this.lblAgeRating.AutoSize = true;
            this.mainLayout.Controls.Add(this.lblAgeRating, 0, 7);

            this.cmbAgeRating.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbAgeRating.Font = new Font("Segoe UI", 12);
            this.cmbAgeRating.BackColor = Theme.PanelColor;
            this.cmbAgeRating.ForeColor = Theme.ForeColor;
            this.cmbAgeRating.FlatStyle = FlatStyle.Flat;
            this.cmbAgeRating.Dock = DockStyle.Fill;
            this.mainLayout.Controls.Add(this.cmbAgeRating, 1, 7);

            // Кнопки
            Panel buttonPanel = new Panel { Height = 50, Dock = DockStyle.Fill };
            this.btnSearch.Text = "Поиск";
            this.btnSearch.FlatStyle = FlatStyle.Flat;
            this.btnSearch.BackColor = Theme.ButtonHoverColor;
            this.btnSearch.ForeColor = Theme.ForeColor;
            this.btnSearch.Size = new Size(120, 40);
            this.btnSearch.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnSearch.Cursor = Cursors.Hand;
            this.btnSearch.Click += btnSearch_Click;

            this.btnReset.Text = "Сбросить";
            this.btnReset.FlatStyle = FlatStyle.Flat;
            this.btnReset.BackColor = Theme.PanelColor;
            this.btnReset.ForeColor = Theme.ForeColor;
            this.btnReset.Size = new Size(120, 40);
            this.btnReset.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnReset.Cursor = Cursors.Hand;
            this.btnReset.Click += btnReset_Click;

            this.btnCancel.Text = "Отмена";
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.BackColor = Theme.PanelColor;
            this.btnCancel.ForeColor = Theme.ForeColor;
            this.btnCancel.Size = new Size(120, 40);
            this.btnCancel.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnCancel.Cursor = Cursors.Hand;
            this.btnCancel.Click += btnCancel_Click;

            buttonPanel.Controls.Add(this.btnSearch);
            buttonPanel.Controls.Add(this.btnReset);
            buttonPanel.Controls.Add(this.btnCancel);
            buttonPanel.Resize += (s, e) =>
            {
                int totalWidth = btnSearch.Width + btnReset.Width + btnCancel.Width + 40;
                int x = (buttonPanel.Width - totalWidth) / 2;
                btnSearch.Location = new Point(x, 5);
                btnReset.Location = new Point(x + btnSearch.Width + 20, 5);
                btnCancel.Location = new Point(x + btnSearch.Width + btnReset.Width + 40, 5);
            };
            this.mainLayout.SetColumnSpan(buttonPanel, 2);
            this.mainLayout.Controls.Add(buttonPanel, 0, 8);

            // Форма
            this.ClientSize = new Size(800, 650);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Theme.BackColor;
            this.Controls.Add(this.borderPanel);
            this.borderPanel.Controls.Add(this.contentPanel);

            this.borderPanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYearFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYearTo)).EndInit();
            this.ResumeLayout(false);

            this.contentPanel.Resize += (s, e) =>
            {
                btnClose.Location = new Point(this.contentPanel.Width - btnClose.Width - 10, 10);
            };
        }
    }
}