using System;
using System.Drawing;
using System.Windows.Forms;

namespace ReelRent
{
    partial class SearchResultsControl
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel mainFlowPanel;
        private Panel titlePanel;
        private Label lblResultTitle;
        private FlowLayoutPanel filtersPanel;
        private FlowLayoutPanel moviesFlowPanel;
        private Button btnClearFilters;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.mainFlowPanel = new FlowLayoutPanel();
            this.titlePanel = new Panel();
            this.lblResultTitle = new Label();
            this.filtersPanel = new FlowLayoutPanel();
            this.moviesFlowPanel = new FlowLayoutPanel();
            this.btnClearFilters = new Button();
            this.mainFlowPanel.SuspendLayout();
            this.titlePanel.SuspendLayout();
            this.SuspendLayout();

            // SearchResultsControl
            this.BackColor = Theme.BackColor;
            this.AutoScroll = true;
            this.Padding = new Padding(0, 0, 0, 0);

            // mainFlowPanel – вертикальный контейнер
            this.mainFlowPanel.Dock = DockStyle.Fill;
            this.mainFlowPanel.FlowDirection = FlowDirection.TopDown;
            this.mainFlowPanel.WrapContents = false;
            this.mainFlowPanel.AutoScroll = true;
            this.mainFlowPanel.BackColor = Color.Transparent;
            this.mainFlowPanel.Padding = new Padding(70, 20, 10, 20);

            // titlePanel
            this.titlePanel.BackColor = Color.Transparent;
            this.titlePanel.AutoSize = false;
            this.titlePanel.Height = 70;
            this.titlePanel.Margin = new Padding(0, 0, 0, 20);
            this.titlePanel.Resize += (s, e) => CenterTitle();

            this.lblResultTitle.Text = "-- Результат поиска --";
            this.lblResultTitle.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            this.lblResultTitle.ForeColor = Theme.AccentForeColor;
            this.lblResultTitle.AutoSize = true;
            this.titlePanel.Controls.Add(this.lblResultTitle);
            this.mainFlowPanel.Controls.Add(this.titlePanel);

            // filtersPanel
            this.filtersPanel.AutoSize = true;
            this.filtersPanel.BackColor = Color.FromArgb(45, 38, 72);
            this.filtersPanel.Padding = new Padding(15);
            this.filtersPanel.Margin = new Padding(70, 0, 0, 20);
            this.filtersPanel.FlowDirection = FlowDirection.LeftToRight;
            this.filtersPanel.WrapContents = true;
            this.mainFlowPanel.Controls.Add(this.filtersPanel);

            // moviesFlowPanel
            this.moviesFlowPanel.AutoSize = true;
            this.moviesFlowPanel.FlowDirection = FlowDirection.LeftToRight;
            this.moviesFlowPanel.WrapContents = true;
            this.moviesFlowPanel.BackColor = Color.Transparent;
            this.moviesFlowPanel.Padding = new Padding(0, 10, 0, 10);
            this.moviesFlowPanel.Margin = new Padding(0);
            this.mainFlowPanel.Controls.Add(this.moviesFlowPanel);

            // btnClearFilters – увеличен до 200px
            this.btnClearFilters.Text = "Отменить фильтры";
            this.btnClearFilters.FlatStyle = FlatStyle.Flat;
            this.btnClearFilters.BackColor = Theme.PanelColor;
            this.btnClearFilters.ForeColor = Theme.ForeColor;
            this.btnClearFilters.Size = new Size(200, 40);
            this.btnClearFilters.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.btnClearFilters.Cursor = Cursors.Hand;
            this.btnClearFilters.Click += (s, e) => BackButtonClicked?.Invoke(this, EventArgs.Empty);
            this.btnClearFilters.Location = new Point(20, 20);
            this.btnClearFilters.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            this.Controls.Add(this.btnClearFilters);
            this.Controls.Add(this.mainFlowPanel);
            this.btnClearFilters.BringToFront();

            this.Resize += (s, e) => CenterTitle();
            this.Load += (s, e) => CenterTitle();

            this.mainFlowPanel.ResumeLayout(false);
            this.mainFlowPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void CenterTitle()
        {
            if (titlePanel == null || lblResultTitle == null) return;
            int availableWidth = this.ClientSize.Width - 40;
            titlePanel.Width = availableWidth;
            int centerX = (titlePanel.Width - lblResultTitle.Width) / 2;
            lblResultTitle.Location = new Point(centerX, (titlePanel.Height - lblResultTitle.Height) / 2);
        }
    }
}