using System;
using System.Drawing;
using System.Windows.Forms;

namespace ReelRent
{
    public partial class MovieDetailForm : Form
    {
        public MovieDetailForm(string title, string genre, string year, string director, string actors, string description, int copiesAvailable)
        {
            InitializeComponent();
            this.Text = title;
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Theme.BackColor;
            this.ForeColor = Theme.ForeColor;

            // Создаём элементы
            Label lblTitle = new Label() { Text = title, Font = new Font("Segoe UI", 18, FontStyle.Bold), ForeColor = Theme.AccentForeColor, AutoSize = true };
            Label lblGenre = new Label() { Text = $"Жанр: {genre}", AutoSize = true };
            Label lblYear = new Label() { Text = $"Год: {year}", AutoSize = true };
            Label lblDirector = new Label() { Text = $"Режиссёр: {director}", AutoSize = true };
            Label lblActors = new Label() { Text = $"Актёры: {actors}", AutoSize = true };
            Label lblDescription = new Label() { Text = $"Описание: {description}", AutoSize = true, MaximumSize = new Size(400, 0) };
            Label lblCopies = new Label() { Text = $"Доступно копий: {copiesAvailable}", Font = new Font("Segoe UI", 8), ForeColor = Color.LightGray, AutoSize = true };

            Button btnAddToCart = new Button() { Text = "Добавить в корзину", FlatStyle = FlatStyle.Flat, BackColor = Theme.ButtonHoverColor, ForeColor = Theme.ForeColor, Size = new Size(150, 40), Cursor = Cursors.Hand };
            btnAddToCart.Click += (s, e) => MessageBox.Show("Фильм добавлен в корзину (заглушка)", "Корзина", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Button btnClose = new Button() { Text = "Закрыть", FlatStyle = FlatStyle.Flat, BackColor = Theme.PanelColor, ForeColor = Theme.ForeColor, Size = new Size(100, 40), Cursor = Cursors.Hand };
            btnClose.Click += (s, e) => this.Close();

            // Размещение с помощью TableLayoutPanel
            TableLayoutPanel table = new TableLayoutPanel() { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 9, Padding = new Padding(20), AutoSize = true };
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            table.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            table.Controls.Add(lblTitle, 0, 0);
            table.Controls.Add(lblGenre, 0, 1);
            table.Controls.Add(lblYear, 0, 2);
            table.Controls.Add(lblDirector, 0, 3);
            table.Controls.Add(lblActors, 0, 4);
            table.Controls.Add(lblDescription, 0, 5);
            table.Controls.Add(lblCopies, 0, 6);
            table.Controls.Add(btnAddToCart, 0, 7);
            table.Controls.Add(btnClose, 0, 8);

            this.Controls.Add(table);
            this.Size = new Size(500, 500);
        }

   
    }
}