using System.Drawing;
using System.Windows.Forms;

namespace ReelRent
{
    partial class MovieDetailForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel borderPanel;
        private Panel contentPanel;
        private Button btnCloseForm;
        private TableLayoutPanel mainLayout;
        private PictureBox picturePoster;
        private Label lblTitle;
        private FlowLayoutPanel rightFlow;          // вместо обычного Panel
        private Label lblGenre;
        private Label lblYear;
        private Label lblDirector;
        private Label lblActors;
        private Label lblDuration;
        private Label lblAgeRating;
        private Label lblMediaFormat;
        private Label lblLanguage;
        private Label lblDescription;
        private Label lblPrice;
        private Label lblCopies;
        private Button btnAddToCart;

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
            this.btnCloseForm = new Button();
            this.mainLayout = new TableLayoutPanel();
            this.picturePoster = new PictureBox();
            this.lblPrice = new Label();
            this.lblCopies = new Label();
            this.btnAddToCart = new Button();
            this.rightFlow = new FlowLayoutPanel();
            this.lblTitle = new Label();
            this.lblGenre = new Label();
            this.lblYear = new Label();
            this.lblDirector = new Label();
            this.lblActors = new Label();
            this.lblDuration = new Label();
            this.lblAgeRating = new Label();
            this.lblMediaFormat = new Label();
            this.lblLanguage = new Label();
            this.lblDescription = new Label();
            this.borderPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.mainLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturePoster)).BeginInit();
            this.rightFlow.SuspendLayout();
            this.SuspendLayout();

            // borderPanel
            this.borderPanel.Dock = DockStyle.Fill;
            this.borderPanel.BackColor = Color.White;
            this.borderPanel.Padding = new Padding(1);

            // contentPanel
            this.contentPanel.Dock = DockStyle.Fill;
            this.contentPanel.BackColor = Theme.BackColor;
            this.contentPanel.Padding = new Padding(20);
            this.contentPanel.Controls.Add(this.btnCloseForm);
            this.contentPanel.Controls.Add(this.mainLayout);

            // btnCloseForm
            this.btnCloseForm.Text = "✖";
            this.btnCloseForm.FlatStyle = FlatStyle.Flat;
            this.btnCloseForm.FlatAppearance.BorderSize = 0;
            this.btnCloseForm.BackColor = Color.Transparent;
            this.btnCloseForm.ForeColor = Theme.ForeColor;
            this.btnCloseForm.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnCloseForm.Size = new Size(40, 40);
            this.btnCloseForm.Cursor = Cursors.Hand;
            this.btnCloseForm.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnCloseForm.Click += (s, e) => this.Close();
            this.btnCloseForm.MouseEnter += (s, e) => btnCloseForm.BackColor = Theme.ButtonHoverColor;
            this.btnCloseForm.MouseLeave += (s, e) => btnCloseForm.BackColor = Color.Transparent;

            // mainLayout
            this.mainLayout.Dock = DockStyle.Fill;
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.RowCount = 1;
            this.mainLayout.Padding = new Padding(10);
            this.mainLayout.BackColor = Theme.BackColor;
            this.mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 300));
            this.mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            this.mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            // ========== Левая колонка ==========
            TableLayoutPanel leftPanel = new TableLayoutPanel();
            leftPanel.ColumnCount = 1;
            leftPanel.RowCount = 4;
            leftPanel.Dock = DockStyle.Fill;
            leftPanel.BackColor = Color.Transparent;
            leftPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            leftPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            leftPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            leftPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            this.picturePoster.SizeMode = PictureBoxSizeMode.StretchImage;
            this.picturePoster.BorderStyle = BorderStyle.FixedSingle;
            this.picturePoster.Size = new Size(280, 370);
            this.picturePoster.BackColor = Color.FromArgb(60, 60, 60);
            this.picturePoster.Margin = new Padding(0, 10, 0, 10);
            leftPanel.Controls.Add(this.picturePoster, 0, 0);

            this.lblPrice.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            this.lblPrice.ForeColor = Theme.AccentForeColor;
            this.lblPrice.AutoSize = true;
            this.lblPrice.Margin = new Padding(0, 5, 0, 5);
            leftPanel.Controls.Add(this.lblPrice, 0, 1);

            this.lblCopies.Font = new Font("Segoe UI", 12);
            this.lblCopies.ForeColor = Theme.ForeColor;
            this.lblCopies.AutoSize = true;
            this.lblCopies.Margin = new Padding(0, 0, 0, 10);
            leftPanel.Controls.Add(this.lblCopies, 0, 2);

            this.btnAddToCart.Text = "Добавить в корзину";
            this.btnAddToCart.FlatStyle = FlatStyle.Flat;
            this.btnAddToCart.BackColor = Theme.ButtonHoverColor;
            this.btnAddToCart.ForeColor = Theme.ForeColor;
            this.btnAddToCart.Size = new Size(280, 45);
            this.btnAddToCart.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnAddToCart.Cursor = Cursors.Hand;
            this.btnAddToCart.Anchor = AnchorStyles.Bottom;
            this.btnAddToCart.Click += btnAddToCart_Click;
            leftPanel.Controls.Add(this.btnAddToCart, 0, 3);

            this.mainLayout.Controls.Add(leftPanel, 0, 0);

            // ========== Правая колонка: FlowLayoutPanel с вертикальным направлением ==========
            this.rightFlow.Dock = DockStyle.Fill;
            this.rightFlow.FlowDirection = FlowDirection.TopDown;
            this.rightFlow.WrapContents = false;      // запрещаем перенос по горизонтали
            this.rightFlow.AutoScroll = true;         // включаем вертикальную прокрутку
            this.rightFlow.BackColor = Color.Transparent;
            this.rightFlow.Padding = new Padding(10, 5, 10, 5);

            // 1. Название
            this.lblTitle.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            this.lblTitle.ForeColor = Theme.AccentForeColor;
            this.lblTitle.AutoSize = true;
            this.lblTitle.MaximumSize = new Size(580, 0);
            this.lblTitle.Margin = new Padding(0, 0, 0, 15);
            this.rightFlow.Controls.Add(this.lblTitle);

            // 2. Контейнер с информацией (снова используем Panel, но он встанет в поток)
            Panel infoContainer = new Panel();
            infoContainer.BackColor = Color.FromArgb(45, 38, 72);
            infoContainer.Padding = new Padding(15);
            infoContainer.AutoSize = true;
            infoContainer.Margin = new Padding(0, 0, 0, 15);
            infoContainer.MinimumSize = new Size(560, 0);

            TableLayoutPanel infoLayout = new TableLayoutPanel();
            infoLayout.ColumnCount = 1;
            infoLayout.RowCount = 8;
            infoLayout.AutoSize = true;
            infoLayout.Dock = DockStyle.Top;
            infoLayout.BackColor = Color.Transparent;
            infoLayout.Padding = new Padding(0);
            infoLayout.Margin = new Padding(0);

            for (int i = 0; i < 8; i++)
                infoLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            Font fieldFont = new Font("Segoe UI", 12);
            int maxWidth = 540;

            this.lblGenre.Font = fieldFont;
            this.lblYear.Font = fieldFont;
            this.lblDirector.Font = fieldFont;
            this.lblActors.Font = fieldFont;
            this.lblDuration.Font = fieldFont;
            this.lblAgeRating.Font = fieldFont;
            this.lblMediaFormat.Font = fieldFont;
            this.lblLanguage.Font = fieldFont;

            this.lblGenre.AutoSize = true;
            this.lblYear.AutoSize = true;
            this.lblDirector.AutoSize = true;
            this.lblActors.AutoSize = true;
            this.lblDuration.AutoSize = true;
            this.lblAgeRating.AutoSize = true;
            this.lblMediaFormat.AutoSize = true;
            this.lblLanguage.AutoSize = true;

            this.lblGenre.MaximumSize = new Size(maxWidth, 0);
            this.lblYear.MaximumSize = new Size(maxWidth, 0);
            this.lblDirector.MaximumSize = new Size(maxWidth, 0);
            this.lblActors.MaximumSize = new Size(maxWidth, 0);
            this.lblDuration.MaximumSize = new Size(maxWidth, 0);
            this.lblAgeRating.MaximumSize = new Size(maxWidth, 0);
            this.lblMediaFormat.MaximumSize = new Size(maxWidth, 0);
            this.lblLanguage.MaximumSize = new Size(maxWidth, 0);

            this.lblGenre.Margin = new Padding(0, 0, 0, 5);
            this.lblYear.Margin = new Padding(0, 0, 0, 5);
            this.lblDirector.Margin = new Padding(0, 0, 0, 5);
            this.lblActors.Margin = new Padding(0, 0, 0, 5);
            this.lblDuration.Margin = new Padding(0, 0, 0, 5);
            this.lblAgeRating.Margin = new Padding(0, 0, 0, 5);
            this.lblMediaFormat.Margin = new Padding(0, 0, 0, 5);
            this.lblLanguage.Margin = new Padding(0, 0, 0, 5);

            infoLayout.Controls.Add(this.lblGenre, 0, 0);
            infoLayout.Controls.Add(this.lblYear, 0, 1);
            infoLayout.Controls.Add(this.lblDirector, 0, 2);
            infoLayout.Controls.Add(this.lblActors, 0, 3);
            infoLayout.Controls.Add(this.lblDuration, 0, 4);
            infoLayout.Controls.Add(this.lblAgeRating, 0, 5);
            infoLayout.Controls.Add(this.lblMediaFormat, 0, 6);
            infoLayout.Controls.Add(this.lblLanguage, 0, 7);

            infoContainer.Controls.Add(infoLayout);
            this.rightFlow.Controls.Add(infoContainer);

            // 3. Описание
            this.lblDescription.Font = new Font("Segoe UI", 11);
            this.lblDescription.ForeColor = Theme.ForeColor;
            this.lblDescription.AutoSize = true;
            this.lblDescription.MaximumSize = new Size(maxWidth, 0);
            this.lblDescription.Margin = new Padding(0, 0, 0, 10);
            this.rightFlow.Controls.Add(this.lblDescription);

            this.mainLayout.Controls.Add(this.rightFlow, 1, 0);

            // Центрирование в левой колонке
            leftPanel.Layout += (s, e) =>
            {
                int w = leftPanel.Width;
                int posterLeft = (w - picturePoster.Width) / 2;
                if (posterLeft < 0) posterLeft = 5;
                picturePoster.Location = new Point(posterLeft, picturePoster.Margin.Top);
                int btnLeft = (w - btnAddToCart.Width) / 2;
                if (btnLeft < 0) btnLeft = 5;
                btnAddToCart.Location = new Point(btnLeft, btnAddToCart.Margin.Top);
            };

            this.Controls.Add(this.borderPanel);
            this.borderPanel.Controls.Add(this.contentPanel);

            this.ClientSize = new Size(1000, 650);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Theme.BackColor;
            this.ForeColor = Theme.ForeColor;

            this.borderPanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.mainLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picturePoster)).EndInit();
            this.rightFlow.ResumeLayout(false);
            this.rightFlow.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            this.contentPanel.Resize += (s, e) =>
            {
                btnCloseForm.Location = new Point(this.contentPanel.Width - btnCloseForm.Width - 10, 10);
            };
        }
    }
}