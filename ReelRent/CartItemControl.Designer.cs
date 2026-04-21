using System.Drawing;
using System.Windows.Forms;

namespace ReelRent
{
    partial class CartItemControl
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel mainLayout;
        private PictureBox posterBox;
        private TableLayoutPanel infoLayout;
        private Label lblTitle;
        private Label lblPricePerDay;
        private Button btnRemove;
        private Panel daysPanel;
        private Label lblDaysCaption;
        private NumericUpDown nudDays;
        private Label lblTotalPrice;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.mainLayout = new TableLayoutPanel();
            this.posterBox = new PictureBox();
            this.infoLayout = new TableLayoutPanel();
            this.lblTitle = new Label();
            this.lblPricePerDay = new Label();
            this.btnRemove = new Button();
            this.daysPanel = new Panel();
            this.lblDaysCaption = new Label();
            this.nudDays = new NumericUpDown();
            this.lblTotalPrice = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.posterBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDays)).BeginInit();
            this.SuspendLayout();

            // CartItemControl
            this.Size = new Size(800, 140);
            this.Margin = new Padding(5);
            this.BackColor = Theme.PanelColor;
            this.BorderStyle = BorderStyle.FixedSingle;

            // mainLayout: 4 колонки (постер, информация, дни, итог)
            this.mainLayout.ColumnCount = 4;
            this.mainLayout.RowCount = 1;
            this.mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110));   // постер
            this.mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));    // информация (название, цена, кнопка)
            this.mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));            // блок с выбором дней
            this.mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160));  // итоговая цена
            this.mainLayout.Dock = DockStyle.Fill;
            this.mainLayout.Padding = new Padding(5);
            this.mainLayout.BackColor = Color.Transparent;

            // posterBox
            this.posterBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.posterBox.Dock = DockStyle.Fill;
            this.posterBox.BackColor = Color.FromArgb(60, 60, 60);

            // infoLayout: вертикальное расположение (название, цена, кнопка)
            this.infoLayout.ColumnCount = 1;
            this.infoLayout.RowCount = 3;
            this.infoLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.infoLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.infoLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            this.infoLayout.Dock = DockStyle.Fill;
            this.infoLayout.Padding = new Padding(5);
            this.infoLayout.BackColor = Color.Transparent;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.lblTitle.ForeColor = Theme.ForeColor;
            this.lblTitle.Dock = DockStyle.Fill;
            this.lblTitle.Margin = new Padding(0, 5, 0, 5);
            this.lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // Обрезка длинного названия с троеточием (делаем в коде)

            // lblPricePerDay
            this.lblPricePerDay.AutoSize = true;
            this.lblPricePerDay.Font = new Font("Segoe UI", 12);
            this.lblPricePerDay.ForeColor = Theme.ForeColor;
            this.lblPricePerDay.Dock = DockStyle.Fill;
            this.lblPricePerDay.Margin = new Padding(0, 5, 0, 5);
            this.lblPricePerDay.TextAlign = ContentAlignment.MiddleLeft;

            // btnRemove
            this.btnRemove.Text = "Удалить";
            this.btnRemove.FlatStyle = FlatStyle.Flat;
            this.btnRemove.BackColor = Color.FromArgb(200, 70, 70);
            this.btnRemove.ForeColor = Color.White;
            this.btnRemove.Size = new Size(100, 35);
            this.btnRemove.Margin = new Padding(0, 10, 0, 5);
            this.btnRemove.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.btnRemove.Cursor = Cursors.Hand;
            this.btnRemove.Click += BtnRemove_Click;

            this.infoLayout.Controls.Add(this.lblTitle, 0, 0);
            this.infoLayout.Controls.Add(this.lblPricePerDay, 0, 1);
            this.infoLayout.Controls.Add(this.btnRemove, 0, 2);

            // daysPanel: вертикальное расположение (надпись + поле)
            this.daysPanel.BackColor = Color.Transparent;
            this.daysPanel.Dock = DockStyle.Fill;
            this.daysPanel.Padding = new Padding(5);

            this.lblDaysCaption.Text = "Кол-во дней\n(макс. 30):";
            this.lblDaysCaption.AutoSize = true;
            this.lblDaysCaption.Font = new Font("Segoe UI", 9);
            this.lblDaysCaption.ForeColor = Theme.ForeColor;
            this.lblDaysCaption.TextAlign = ContentAlignment.MiddleCenter;
            this.lblDaysCaption.Dock = DockStyle.Top;
            this.lblDaysCaption.Height = 40;

            this.nudDays.Minimum = 1;
            this.nudDays.Maximum = 30;
            this.nudDays.Value = 1;
            this.nudDays.Size = new Size(70, 26);
            this.nudDays.Location = new Point(10, 45);
            this.nudDays.BackColor = Theme.BackColor;
            this.nudDays.ForeColor = Theme.ForeColor;
            this.nudDays.Font = new Font("Segoe UI", 14);
            this.nudDays.ValueChanged += NudDays_ValueChanged;

            this.daysPanel.Controls.Add(this.lblDaysCaption);
            this.daysPanel.Controls.Add(this.nudDays);

            // lblTotalPrice
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.lblTotalPrice.ForeColor = Theme.AccentForeColor;
            this.lblTotalPrice.Dock = DockStyle.Fill;
            this.lblTotalPrice.TextAlign = ContentAlignment.MiddleRight;
            this.lblTotalPrice.Padding = new Padding(5, 0, 5, 0);

            // Добавление в mainLayout
            this.mainLayout.Controls.Add(this.posterBox, 0, 0);
            this.mainLayout.Controls.Add(this.infoLayout, 1, 0);
            this.mainLayout.Controls.Add(this.daysPanel, 2, 0);
            this.mainLayout.Controls.Add(this.lblTotalPrice, 3, 0);

            this.Controls.Add(this.mainLayout);

            ((System.ComponentModel.ISupportInitialize)(this.posterBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDays)).EndInit();
            this.ResumeLayout(false);
        }
    }
}