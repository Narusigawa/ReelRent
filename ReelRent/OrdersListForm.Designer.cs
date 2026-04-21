using System.Drawing;
using System.Windows.Forms;

namespace ReelRent
{
    partial class OrdersListForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnClose;
        private Label lblTitle;
        private DataGridView dgvOrders;
        private Label lblHint;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnClose = new Button();
            this.lblTitle = new Label();
            this.dgvOrders = new DataGridView();
            this.lblHint = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.SuspendLayout();

            // Form
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(800, 500);
            this.MinimumSize = new Size(600, 400);
            this.BackColor = Theme.BackColor;
            this.Text = _onlyActive ? "Текущие аренды" : "История заказов";
            this.Paint += OrdersListForm_Paint;

            // btnClose
            this.btnClose.Text = "✖";
            this.btnClose.FlatStyle = FlatStyle.Flat;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.BackColor = Color.Transparent;
            this.btnClose.ForeColor = Theme.ForeColor;
            this.btnClose.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.btnClose.Size = new Size(40, 40);
            this.btnClose.Cursor = Cursors.Hand;
            this.btnClose.Click += BtnClose_Click;
            this.btnClose.MouseEnter += (s, e) => btnClose.BackColor = Theme.ButtonHoverColor;
            this.btnClose.MouseLeave += (s, e) => btnClose.BackColor = Color.Transparent;

            // lblTitle
            this.lblTitle.Text = _onlyActive ? "Текущие аренды" : "История заказов";
            this.lblTitle.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            this.lblTitle.ForeColor = Theme.AccentForeColor;
            this.lblTitle.AutoSize = true;

            // dgvOrders
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.BackgroundColor = Theme.PanelColor;
            this.dgvOrders.GridColor = Color.DarkGray;
            this.dgvOrders.ColumnHeadersDefaultCellStyle.BackColor = Theme.PanelColor;
            this.dgvOrders.ColumnHeadersDefaultCellStyle.ForeColor = Theme.ForeColor;
            this.dgvOrders.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.dgvOrders.DefaultCellStyle.BackColor = Theme.PanelColor;
            this.dgvOrders.DefaultCellStyle.ForeColor = Theme.ForeColor;
            this.dgvOrders.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            this.dgvOrders.RowTemplate.Height = 35;
            // Увеличиваем высоту заголовков и запрещаем изменение размера
            this.dgvOrders.ColumnHeadersHeight = 40;
            this.dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOrders.CellDoubleClick += DgvOrders_CellDoubleClick;

            // Columns
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn
            {
                Name = "OrderId",
                HeaderText = "ID",
                FillWeight = 5
            };
            DataGridViewTextBoxColumn colDate = new DataGridViewTextBoxColumn
            {
                Name = "RentDate",
                HeaderText = "Дата аренды",
                FillWeight = 20
            };
            DataGridViewTextBoxColumn colDueReturn = new DataGridViewTextBoxColumn
            {
                Name = "DueReturnDate",
                HeaderText = _onlyActive ? "Срок возврата" : "Дата возврата",
                FillWeight = 20
            };
            DataGridViewTextBoxColumn colCount = new DataGridViewTextBoxColumn
            {
                Name = "MoviesCount",
                HeaderText = "Кол-во фильмов",
                FillWeight = 15
            };
            DataGridViewTextBoxColumn colTotal = new DataGridViewTextBoxColumn
            {
                Name = "Total",
                HeaderText = "Сумма, руб",
                FillWeight = 20
            };
            this.dgvOrders.Columns.AddRange(colId, colDate, colDueReturn, colCount, colTotal);

            // lblHint
            this.lblHint.Text = "Дважды нажмите на строку для просмотра деталей";
            this.lblHint.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            this.lblHint.ForeColor = Theme.ForeColor;
            this.lblHint.AutoSize = true;

            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.lblHint);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void OrdersListForm_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.White, 1))
            {
                Rectangle rect = new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
                e.Graphics.DrawRectangle(pen, rect);
            }
        }
    }
}