using System;
using System.Drawing;
using System.Windows.Forms;

namespace ReelRent
{
    partial class CatalogForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel topPanel;
        private Button btnBack;
        private DataGridView dgvMovies;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();

            // Создание элементов
            this.topPanel = new Panel();
            this.btnBack = new Button();
            this.dgvMovies = new DataGridView();

            // CatalogForm
            this.ClientSize = new Size(1000, 600);
            this.Text = "Каталог фильмов";
            this.BackColor = Theme.BackColor;
            this.ForeColor = Theme.ForeColor;
            this.StartPosition = FormStartPosition.CenterParent;

            // topPanel
            this.topPanel.Dock = DockStyle.Top;
            this.topPanel.Height = 50;
            this.topPanel.BackColor = Theme.PanelColor;

            // btnBack
            this.btnBack.Text = "← Назад";
            this.btnBack.Size = new Size(100, 30);
            this.btnBack.Location = new Point(10, 10);
            this.btnBack.FlatStyle = FlatStyle.Flat;
            this.btnBack.BackColor = Theme.ButtonBackColor;
            this.btnBack.ForeColor = Theme.ForeColor;
            this.btnBack.Cursor = Cursors.Hand;
            this.topPanel.Controls.Add(this.btnBack);

            // dgvMovies
            this.dgvMovies.Dock = DockStyle.Fill;
            this.dgvMovies.BackgroundColor = Theme.BackColor;
            this.dgvMovies.ForeColor = Theme.ForeColor;
            this.dgvMovies.GridColor = Theme.PanelColor;
            this.dgvMovies.AllowUserToAddRows = false;
            this.dgvMovies.ReadOnly = true;
            this.dgvMovies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovies.RowHeadersVisible = false;

            // Добавление на форму
            this.Controls.Add(this.dgvMovies);
            this.Controls.Add(this.topPanel);

            this.ResumeLayout(false);
        }
    }
}