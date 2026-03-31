using System.Drawing;
using System.Windows.Forms;

namespace ReelRent
{
    partial class CatalogControl
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Panel bannerPanel;
        private System.Windows.Forms.PictureBox bannerPicture;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel indicatorPanel;
        private System.Windows.Forms.Timer bannerTimer;
        private System.Windows.Forms.FlowLayoutPanel moviesFlowLayoutPanel;
        private System.Windows.Forms.Label labelNewReleases;
        private System.Windows.Forms.Label labelCatalogTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.labelNewReleases = new System.Windows.Forms.Label();
            this.bannerPanel = new System.Windows.Forms.Panel();
            this.bannerPicture = new System.Windows.Forms.PictureBox();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.indicatorPanel = new System.Windows.Forms.Panel();
            this.labelCatalogTitle = new System.Windows.Forms.Label();
            this.moviesFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.bannerTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();

            // flowLayoutPanel
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel.WrapContents = false;
            this.flowLayoutPanel.BackColor = Theme.BackColor;
            this.flowLayoutPanel.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);

            // labelNewReleases
            this.labelNewReleases.Text = "-- Новинки этой недели --";
            this.labelNewReleases.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            this.labelNewReleases.ForeColor = Theme.AccentForeColor;
            this.labelNewReleases.AutoSize = true;
            this.labelNewReleases.Margin = new Padding(643, 0, 0, 20);

            // bannerPanel
            this.bannerPanel.BackColor = Theme.BackColor;
            this.bannerPanel.Height = 550;
            this.bannerPanel.Margin = new Padding(30, 0, 0, 0);
            this.bannerPanel.Resize += (s, e) => AdjustBannerSize();

            // bannerPicture
            this.bannerPicture.SizeMode = PictureBoxSizeMode.Zoom;
            this.bannerPicture.Dock = DockStyle.Top;
            this.bannerPicture.Height = 520;
            this.bannerPicture.BackColor = Color.FromArgb(17, 15, 30);
            this.bannerPicture.Cursor = Cursors.Hand;
            this.bannerPanel.Controls.Add(this.bannerPicture);

            // btnPrev
            this.btnPrev.Text = "◀";
            this.btnPrev.FlatStyle = FlatStyle.Flat;
            this.btnPrev.FlatAppearance.BorderSize = 0;
            this.btnPrev.BackColor = Color.FromArgb(17, 15, 30);
            this.btnPrev.ForeColor = Theme.ForeColor;
            this.btnPrev.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            this.btnPrev.Size = new Size(50, 50);
            this.btnPrev.Cursor = Cursors.Hand;
            this.btnPrev.Click += (s, e) => PrevBanner();
            this.btnPrev.MouseEnter += (s, e) => btnPrev.BackColor = Theme.ButtonHoverColor;
            this.btnPrev.MouseLeave += (s, e) => btnPrev.BackColor = Color.FromArgb(17, 15, 30);
            this.bannerPanel.Controls.Add(this.btnPrev);

            // btnNext
            this.btnNext.Text = "▶";
            this.btnNext.FlatStyle = FlatStyle.Flat;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.BackColor = Color.FromArgb(17, 15, 30);
            this.btnNext.ForeColor = Theme.ForeColor;
            this.btnNext.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            this.btnNext.Size = new Size(50, 50);
            this.btnNext.Cursor = Cursors.Hand;
            this.btnNext.Click += (s, e) => NextBanner();
            this.btnNext.MouseEnter += (s, e) => btnNext.BackColor = Theme.ButtonHoverColor;
            this.btnNext.MouseLeave += (s, e) => btnNext.BackColor = Color.FromArgb(17, 15, 30);
            this.bannerPanel.Controls.Add(this.btnNext);

            // indicatorPanel
            this.indicatorPanel.BackColor = Color.Transparent;
            this.indicatorPanel.Height = 30;
            this.bannerPanel.Controls.Add(this.indicatorPanel);

            // labelCatalogTitle
            this.labelCatalogTitle.Text = "-- Каталог фильмов --";
            this.labelCatalogTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            this.labelCatalogTitle.ForeColor = Theme.AccentForeColor;
            this.labelCatalogTitle.AutoSize = true;
            this.labelCatalogTitle.TextAlign = ContentAlignment.MiddleCenter;

            // moviesFlowLayoutPanel
            this.moviesFlowLayoutPanel.AutoSize = true;
            this.moviesFlowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            this.moviesFlowLayoutPanel.WrapContents = true;
            this.moviesFlowLayoutPanel.BackColor = Color.Transparent;
            this.moviesFlowLayoutPanel.Padding = new Padding(0);
            this.moviesFlowLayoutPanel.Margin = new Padding(0, 20, 0, 0);

            // Добавление элементов в flowLayoutPanel
            this.flowLayoutPanel.Controls.Add(this.labelNewReleases);
            this.flowLayoutPanel.Controls.Add(this.bannerPanel);
            Panel catalogTitlePanel = new Panel();
            catalogTitlePanel.AutoSize = true;
            catalogTitlePanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            catalogTitlePanel.BackColor = Color.Transparent;
            catalogTitlePanel.Margin = new Padding(720, 10, 0, 0);
            catalogTitlePanel.Controls.Add(this.labelCatalogTitle);
            this.flowLayoutPanel.Controls.Add(catalogTitlePanel);
            this.flowLayoutPanel.Controls.Add(this.moviesFlowLayoutPanel);

            // CatalogControl
            this.Controls.Add(this.flowLayoutPanel);
            this.BackColor = Theme.BackColor;
            this.Padding = new Padding(0); // убираем отступы
            this.Resize += (s, e) => AdjustBannerSize();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void AdjustBannerSize()
        {
            if (bannerPanel == null || flowLayoutPanel == null) return;
            int targetWidth = flowLayoutPanel.ClientSize.Width - 160;
            if (targetWidth > 0) bannerPanel.Width = targetWidth;

            int btnY = (bannerPicture.Height - 50) / 2;
            btnPrev.Location = new Point(0, btnY);
            btnNext.Location = new Point(bannerPanel.Width - 50, btnY);
            btnPrev.BringToFront();
            btnNext.BringToFront();

            if (indicatorPanel != null && indicatorPanel.Controls.Count > 0)
            {
                int totalWidth = indicatorPanel.Controls.Count * 20;
                indicatorPanel.Width = totalWidth;
                int centerX = (bannerPanel.Width - totalWidth) / 2;
                indicatorPanel.Location = new Point(centerX, bannerPicture.Height + 15);
            }
        }
    }
}