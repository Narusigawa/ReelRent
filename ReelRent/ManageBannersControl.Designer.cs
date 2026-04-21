using System.Drawing;
using System.Windows.Forms;

namespace ReelRent
{
    partial class ManageBannersControl
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvBanners;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnReorder;
        private Button btnBack;
        private Panel contentPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.contentPanel = new Panel();
            this.dgvBanners = new DataGridView();
            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();
            this.btnReorder = new Button();
            this.btnBack = new Button();
            this.contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBanners)).BeginInit();
            this.SuspendLayout();

            // ManageBannersControl
            this.BackColor = Theme.BackColor;
            this.AutoScroll = true;
            this.Padding = new Padding(70, 0, 0, 0);

            // contentPanel
            this.contentPanel.BackColor = Color.Transparent;
            this.contentPanel.AutoSize = false;
            this.contentPanel.Size = new Size(1200, 800);
            this.contentPanel.Location = new Point(20, 20);
            this.contentPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // dgvBanners
            this.dgvBanners.AllowUserToAddRows = false;
            this.dgvBanners.AllowUserToDeleteRows = false;
            this.dgvBanners.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBanners.BackgroundColor = Theme.PanelColor;
            this.dgvBanners.GridColor = Color.DarkGray;
            this.dgvBanners.Size = new Size(1100, 650);
            this.dgvBanners.Location = new Point(20, 60);
            this.dgvBanners.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvBanners.ReadOnly = true;
            this.dgvBanners.RowHeadersVisible = false;

            this.dgvBanners.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBanners.ColumnHeadersDefaultCellStyle.BackColor = Theme.PanelColor;
            this.dgvBanners.ColumnHeadersDefaultCellStyle.ForeColor = Theme.ForeColor;
            this.dgvBanners.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.dgvBanners.DefaultCellStyle.BackColor = Theme.PanelColor;
            this.dgvBanners.DefaultCellStyle.ForeColor = Theme.ForeColor;
            this.dgvBanners.DefaultCellStyle.SelectionBackColor = Theme.ButtonHoverColor;
            this.dgvBanners.DefaultCellStyle.Font = new Font("Segoe UI", 11);
            this.dgvBanners.RowTemplate.Height = 35;

            // Колонки: ID, Описание, Активен
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "Id";
            colId.HeaderText = "ID";
            colId.MinimumWidth = 80;
            colId.FillWeight = 10;

            DataGridViewTextBoxColumn colDescription = new DataGridViewTextBoxColumn();
            colDescription.Name = "Description";
            colDescription.HeaderText = "Описание";
            colDescription.MinimumWidth = 300;
            colDescription.FillWeight = 70;

            DataGridViewCheckBoxColumn colActive = new DataGridViewCheckBoxColumn();
            colActive.Name = "IsActive";
            colActive.HeaderText = "Активен";
            colActive.MinimumWidth = 80;
            colActive.FillWeight = 20;

            this.dgvBanners.Columns.AddRange(new DataGridViewColumn[] { colId, colDescription, colActive });

            // btnBack
            this.btnBack.Text = "← Назад";
            this.btnBack.FlatStyle = FlatStyle.Flat;
            this.btnBack.BackColor = Theme.PanelColor;
            this.btnBack.ForeColor = Theme.ForeColor;
            this.btnBack.Size = new Size(120, 50);
            this.btnBack.Location = new Point(20, 0);
            this.btnBack.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnBack.Cursor = Cursors.Hand;
            this.btnBack.Click += btnBack_Click;

            // btnAdd
            this.btnAdd.Text = "Добавить";
            this.btnAdd.FlatStyle = FlatStyle.Flat;
            this.btnAdd.BackColor = Theme.PanelColor;
            this.btnAdd.ForeColor = Theme.ForeColor;
            this.btnAdd.Size = new Size(150, 50);
            this.btnAdd.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnAdd.Cursor = Cursors.Hand;
            this.btnAdd.Click += btnAdd_Click;

            // btnEdit
            this.btnEdit.Text = "Редактировать";
            this.btnEdit.FlatStyle = FlatStyle.Flat;
            this.btnEdit.BackColor = Theme.PanelColor;
            this.btnEdit.ForeColor = Theme.ForeColor;
            this.btnEdit.Size = new Size(150, 50);
            this.btnEdit.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnEdit.Cursor = Cursors.Hand;
            this.btnEdit.Click += btnEdit_Click;

            // btnDelete
            this.btnDelete.Text = "Удалить";
            this.btnDelete.FlatStyle = FlatStyle.Flat;
            this.btnDelete.BackColor = Theme.PanelColor;
            this.btnDelete.ForeColor = Theme.ForeColor;
            this.btnDelete.Size = new Size(150, 50);
            this.btnDelete.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnDelete.Cursor = Cursors.Hand;
            this.btnDelete.Click += btnDelete_Click;

            // btnReorder
            this.btnReorder.Text = "Настроить порядок";
            this.btnReorder.FlatStyle = FlatStyle.Flat;
            this.btnReorder.BackColor = Theme.PanelColor;
            this.btnReorder.ForeColor = Theme.ForeColor;
            this.btnReorder.Size = new Size(180, 50);
            this.btnReorder.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnReorder.Cursor = Cursors.Hand;
            this.btnReorder.Click += btnReorder_Click;

            this.contentPanel.Controls.Add(this.btnBack);
            this.contentPanel.Controls.Add(this.dgvBanners);
            this.contentPanel.Controls.Add(this.btnAdd);
            this.contentPanel.Controls.Add(this.btnEdit);
            this.contentPanel.Controls.Add(this.btnDelete);
            this.contentPanel.Controls.Add(this.btnReorder);
            this.Controls.Add(this.contentPanel);

            this.Resize += (s, e) => RepositionElements();
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBanners)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            RepositionElements();
        }

        private void RepositionElements()
        {
            if (this.contentPanel == null || this.dgvBanners == null) return;

            int panelWidth = this.ClientSize.Width - 140;
            if (panelWidth < 900) panelWidth = 900;
            this.contentPanel.Width = panelWidth;
            this.contentPanel.Left = (this.ClientSize.Width - this.contentPanel.Width) / 2;

            this.dgvBanners.Width = this.contentPanel.Width - 40;
            this.dgvBanners.Location = new Point(20, 60);

            int buttonSpacing = 20;
            int buttonTop = this.dgvBanners.Bottom + 20;
            int buttonRight = this.contentPanel.Width - 20;

            this.btnDelete.Location = new Point(buttonRight - this.btnDelete.Width, buttonTop);
            this.btnEdit.Location = new Point(buttonRight - this.btnDelete.Width - this.btnEdit.Width - buttonSpacing, buttonTop);
            this.btnAdd.Location = new Point(buttonRight - this.btnDelete.Width - this.btnEdit.Width - this.btnAdd.Width - buttonSpacing, buttonTop);
            this.btnReorder.Location = new Point(this.btnAdd.Left - this.btnReorder.Width - buttonSpacing, buttonTop);
        }
    }
}