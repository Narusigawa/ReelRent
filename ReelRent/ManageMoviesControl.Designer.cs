using System.Drawing;
using System.Windows.Forms;

namespace ReelRent
{
    partial class ManageMoviesControl
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvMovies;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
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
            this.dgvMovies = new DataGridView();
            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();
            this.btnBack = new Button();
            this.contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovies)).BeginInit();
            this.SuspendLayout();

            // ManageMoviesControl
            this.BackColor = Theme.BackColor;
            this.AutoScroll = true;
            this.Padding = new Padding(70, 0, 0, 0);

            // contentPanel
            this.contentPanel.BackColor = Color.Transparent;
            this.contentPanel.AutoSize = false;
            this.contentPanel.Size = new Size(1200, 800);
            this.contentPanel.Location = new Point(20, 20);
            this.contentPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // dgvMovies
            this.dgvMovies.AllowUserToAddRows = false;
            this.dgvMovies.AllowUserToDeleteRows = false;
            this.dgvMovies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovies.BackgroundColor = Theme.PanelColor;
            this.dgvMovies.GridColor = Color.DarkGray;
            this.dgvMovies.Size = new Size(1100, 650);
            this.dgvMovies.Location = new Point(20, 60);
            this.dgvMovies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovies.ReadOnly = true;
            this.dgvMovies.RowHeadersVisible = false;

            // Настройка заголовков
            this.dgvMovies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovies.ColumnHeadersDefaultCellStyle.BackColor = Theme.PanelColor;
            this.dgvMovies.ColumnHeadersDefaultCellStyle.ForeColor = Theme.ForeColor;
            this.dgvMovies.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.dgvMovies.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Стиль ячеек
            this.dgvMovies.DefaultCellStyle.BackColor = Theme.PanelColor;
            this.dgvMovies.DefaultCellStyle.ForeColor = Theme.ForeColor;
            this.dgvMovies.DefaultCellStyle.SelectionBackColor = Theme.ButtonHoverColor;
            this.dgvMovies.DefaultCellStyle.Font = new Font("Segoe UI", 11);
            this.dgvMovies.RowTemplate.Height = 35;

            // Колонки (порядок: ID, Название, Жанр, Год, Всего копий, Доступно, Цена)
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "Id";
            colId.HeaderText = "ID";
            colId.MinimumWidth = 80;
            colId.FillWeight = 10;

            DataGridViewTextBoxColumn colTitle = new DataGridViewTextBoxColumn();
            colTitle.Name = "Title";
            colTitle.HeaderText = "Название";
            colTitle.MinimumWidth = 250;
            colTitle.FillWeight = 40;

            DataGridViewTextBoxColumn colGenre = new DataGridViewTextBoxColumn();
            colGenre.Name = "Genre";
            colGenre.HeaderText = "Жанр";
            colGenre.MinimumWidth = 150;
            colGenre.FillWeight = 20;

            DataGridViewTextBoxColumn colYear = new DataGridViewTextBoxColumn();
            colYear.Name = "Year";
            colYear.HeaderText = "Год";
            colYear.MinimumWidth = 100;
            colYear.FillWeight = 10;

            DataGridViewTextBoxColumn colTotalCopies = new DataGridViewTextBoxColumn();
            colTotalCopies.Name = "TotalCopies";
            colTotalCopies.HeaderText = "Всего копий";
            colTotalCopies.MinimumWidth = 120;
            colTotalCopies.FillWeight = 15;

            DataGridViewTextBoxColumn colAvailable = new DataGridViewTextBoxColumn();
            colAvailable.Name = "AvailableCopies";
            colAvailable.HeaderText = "Доступно";
            colAvailable.MinimumWidth = 100;
            colAvailable.FillWeight = 15;

            DataGridViewTextBoxColumn colRentalPrice = new DataGridViewTextBoxColumn();
            colRentalPrice.Name = "RentalPrice";
            colRentalPrice.HeaderText = "Цена (руб)";
            colRentalPrice.MinimumWidth = 100;
            colRentalPrice.FillWeight = 15;

            this.dgvMovies.Columns.AddRange(new DataGridViewColumn[] {
                colId, colTitle, colGenre, colYear, colTotalCopies, colAvailable, colRentalPrice
            });

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

            // Добавляем элементы в contentPanel
            this.contentPanel.Controls.Add(this.btnBack);
            this.contentPanel.Controls.Add(this.dgvMovies);
            this.contentPanel.Controls.Add(this.btnAdd);
            this.contentPanel.Controls.Add(this.btnEdit);
            this.contentPanel.Controls.Add(this.btnDelete);

            this.Controls.Add(this.contentPanel);

            this.Resize += (s, e) => RepositionElements();

            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            RepositionElements();
        }

        private void RepositionElements()
        {
            if (this.contentPanel == null || this.dgvMovies == null) return;

            int panelWidth = this.ClientSize.Width - 140;
            if (panelWidth < 900) panelWidth = 900;
            this.contentPanel.Width = panelWidth;

            this.contentPanel.Left = (this.ClientSize.Width - this.contentPanel.Width) / 2;

            this.dgvMovies.Width = this.contentPanel.Width - 40;
            this.dgvMovies.Location = new Point(20, 60);

            int buttonSpacing = 20;
            int buttonTop = this.dgvMovies.Bottom + 20;
            int buttonRight = this.contentPanel.Width - 20;

            this.btnDelete.Location = new Point(buttonRight - this.btnDelete.Width, buttonTop);
            this.btnEdit.Location = new Point(buttonRight - this.btnDelete.Width - this.btnEdit.Width - buttonSpacing, buttonTop);
            this.btnAdd.Location = new Point(buttonRight - this.btnDelete.Width - this.btnEdit.Width - this.btnAdd.Width - buttonSpacing * 2, buttonTop);
        }
    }
}