using System.Drawing;
using System.Windows.Forms;

namespace ReelRent
{
    partial class ReorderBannersForm
    {
        private System.ComponentModel.IContainer components = null;
        private ListBox listBoxBanners;
        private Button btnUp, btnDown, btnSave, btnCancel, btnClose;
        private Panel borderPanel, contentPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.listBoxBanners = new ListBox();
            this.btnUp = new Button();
            this.btnDown = new Button();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.btnClose = new Button();
            this.borderPanel = new Panel();
            this.contentPanel = new Panel();
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
            this.contentPanel.Controls.Add(this.listBoxBanners);
            this.contentPanel.Controls.Add(this.btnUp);
            this.contentPanel.Controls.Add(this.btnDown);
            this.contentPanel.Controls.Add(this.btnSave);
            this.contentPanel.Controls.Add(this.btnCancel);

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

            // listBoxBanners
            this.listBoxBanners.Size = new Size(400, 300);
            this.listBoxBanners.Location = new Point(20, 50);
            this.listBoxBanners.BackColor = Theme.PanelColor;
            this.listBoxBanners.ForeColor = Theme.ForeColor;
            this.listBoxBanners.Font = new Font("Segoe UI", 11);

            // btnUp
            this.btnUp.Text = "↑ Вверх";
            this.btnUp.FlatStyle = FlatStyle.Flat;
            this.btnUp.BackColor = Theme.PanelColor;
            this.btnUp.ForeColor = Theme.ForeColor;
            this.btnUp.Size = new Size(100, 40);
            this.btnUp.Location = new Point(440, 50);
            this.btnUp.Click += btnUp_Click;

            // btnDown
            this.btnDown.Text = "↓ Вниз";
            this.btnDown.FlatStyle = FlatStyle.Flat;
            this.btnDown.BackColor = Theme.PanelColor;
            this.btnDown.ForeColor = Theme.ForeColor;
            this.btnDown.Size = new Size(100, 40);
            this.btnDown.Location = new Point(440, 100);
            this.btnDown.Click += btnDown_Click;

            // btnSave
            this.btnSave.Text = "Сохранить";
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.BackColor = Theme.ButtonHoverColor;
            this.btnSave.ForeColor = Theme.ForeColor;
            this.btnSave.Size = new Size(120, 45);
            this.btnSave.Location = new Point(20, 370);
            this.btnSave.Click += btnSave_Click;

            // btnCancel
            this.btnCancel.Text = "Отмена";
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.BackColor = Theme.PanelColor;
            this.btnCancel.ForeColor = Theme.ForeColor;
            this.btnCancel.Size = new Size(120, 45);
            this.btnCancel.Location = new Point(160, 370);
            this.btnCancel.Click += btnCancel_Click;

            // форма
            this.ClientSize = new Size(600, 480);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Theme.BackColor;
            this.Controls.Add(this.borderPanel);
            this.borderPanel.Controls.Add(this.contentPanel);

            this.contentPanel.Resize += (s, e) =>
            {
                btnClose.Location = new Point(this.contentPanel.Width - btnClose.Width - 10, 10);
            };

            this.ResumeLayout(false);
        }
    }
}