using System.Drawing;
using System.Windows.Forms;

namespace ReelRent
{
    partial class BannerEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel mainTable;
        private PictureBox pictureBanner;
        private Button btnSelectImage;
        private Label lblDescription;
        private TextBox txtDescription;
        private CheckBox chkActive;
        private Button btnSave;
        private Button btnCancel;
        private Button btnClose;
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
            this.pictureBanner = new PictureBox();
            this.btnSelectImage = new Button();
            this.lblDescription = new Label();
            this.txtDescription = new TextBox();
            this.chkActive = new CheckBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.borderPanel.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.mainTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBanner)).BeginInit();
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
            this.contentPanel.Controls.Add(this.mainTable);

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

            // mainTable
            this.mainTable.Dock = DockStyle.Fill;
            this.mainTable.ColumnCount = 1;
            this.mainTable.RowCount = 6;
            this.mainTable.Padding = new Padding(20);
            this.mainTable.BackColor = Theme.BackColor;
            this.mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            for (int i = 0; i < 6; i++)
                this.mainTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            // строка 0: изображение
            this.pictureBanner.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureBanner.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBanner.Size = new Size(400, 250);
            this.pictureBanner.BackColor = Color.FromArgb(60, 60, 60);
            this.pictureBanner.Anchor = AnchorStyles.None;
            this.mainTable.Controls.Add(this.pictureBanner, 0, 0);

            // строка 1: кнопка выбора
            this.btnSelectImage.Text = "Выбрать изображение";
            this.btnSelectImage.FlatStyle = FlatStyle.Flat;
            this.btnSelectImage.BackColor = Theme.PanelColor;
            this.btnSelectImage.ForeColor = Theme.ForeColor;
            this.btnSelectImage.Size = new Size(200, 40);
            this.btnSelectImage.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            this.btnSelectImage.Cursor = Cursors.Hand;
            this.btnSelectImage.Anchor = AnchorStyles.None;
            this.btnSelectImage.Click += btnSelectImage_Click;
            this.mainTable.Controls.Add(this.btnSelectImage, 0, 1);

            // строка 2: описание
            this.lblDescription.Text = "Описание:";
            this.lblDescription.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.lblDescription.ForeColor = Theme.ForeColor;
            this.lblDescription.AutoSize = true;
            this.mainTable.Controls.Add(this.lblDescription, 0, 2);

            this.txtDescription.Font = new Font("Segoe UI", 12);
            this.txtDescription.Multiline = true;
            this.txtDescription.Height = 80;
            this.txtDescription.BackColor = Theme.PanelColor;
            this.txtDescription.ForeColor = Theme.ForeColor;
            this.txtDescription.BorderStyle = BorderStyle.FixedSingle;
            this.txtDescription.Dock = DockStyle.Fill;
            this.mainTable.Controls.Add(this.txtDescription, 0, 3);

            // строка 4: активен
            this.chkActive.Text = "Активен";
            this.chkActive.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.chkActive.ForeColor = Theme.ForeColor;
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.mainTable.Controls.Add(this.chkActive, 0, 4);

            // строка 5: кнопки
            Panel buttonPanel = new Panel { Dock = DockStyle.Fill, Height = 60 };
            this.btnSave.Text = "Сохранить";
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.BackColor = Theme.ButtonHoverColor;
            this.btnSave.ForeColor = Theme.ForeColor;
            this.btnSave.Size = new Size(140, 45);
            this.btnSave.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnSave.Cursor = Cursors.Hand;
            this.btnSave.Click += btnSave_Click;

            this.btnCancel.Text = "Отмена";
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.BackColor = Theme.PanelColor;
            this.btnCancel.ForeColor = Theme.ForeColor;
            this.btnCancel.Size = new Size(140, 45);
            this.btnCancel.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnCancel.Cursor = Cursors.Hand;
            this.btnCancel.Click += btnCancel_Click;

            buttonPanel.Controls.Add(this.btnSave);
            buttonPanel.Controls.Add(this.btnCancel);
            this.mainTable.Controls.Add(buttonPanel, 0, 5);

            // форма
            this.ClientSize = new Size(700, 650);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Theme.BackColor;
            this.Controls.Add(this.borderPanel);
            this.borderPanel.Controls.Add(this.contentPanel);

            // центрирование
            this.mainTable.Layout += (s, e) =>
            {
                int cellWidth = this.mainTable.Width - this.mainTable.Padding.Horizontal;
                this.pictureBanner.Location = new Point((cellWidth - this.pictureBanner.Width) / 2, 5);
                this.btnSelectImage.Location = new Point((cellWidth - this.btnSelectImage.Width) / 2, 5);
            };

            this.mainTable.ResumeLayout(false);
            this.mainTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBanner)).EndInit();
            this.borderPanel.ResumeLayout(false);
            this.contentPanel.ResumeLayout(false);
            this.ResumeLayout(false);

            this.contentPanel.Resize += (s, e) =>
            {
                btnClose.Location = new Point(this.contentPanel.Width - btnClose.Width - 10, 10);
            };
        }
    }
}