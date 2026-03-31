using System.Drawing;
using System.Windows.Forms;

namespace ReelRent
{
    partial class MovieCard
    {
        private PictureBox posterBox;
        private Label titleLabel;

        private void InitializeComponent()
        {
            this.posterBox = new PictureBox();
            this.titleLabel = new Label();
            this.SuspendLayout();

            // posterBox
            this.posterBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.posterBox.Dock = DockStyle.Fill;
            this.posterBox.BackColor = Color.FromArgb(60, 60, 60);
            this.posterBox.Cursor = Cursors.Hand;
            this.posterBox.Click += (s, e) => MovieClicked?.Invoke(this, movieData);

            // titleLabel
            this.titleLabel.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            this.titleLabel.ForeColor = Theme.ForeColor;
            this.titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.titleLabel.BackColor = Color.FromArgb(128, 0, 0, 0);
            this.titleLabel.Dock = DockStyle.Bottom;
            this.titleLabel.Height = 50;
            this.titleLabel.AutoEllipsis = true;
            this.titleLabel.Padding = new Padding(5);
            this.titleLabel.Cursor = Cursors.Hand;
            this.titleLabel.Click += (s, e) => MovieClicked?.Invoke(this, movieData);

            // MovieCard
            this.Size = new Size(280, 420);
            this.MinimumSize = new Size(280, 420);
            this.Margin = new Padding(30);
            this.BackColor = Color.Transparent;
            this.Controls.Add(this.posterBox);
            this.Controls.Add(this.titleLabel);
            this.ResumeLayout(false);
        }
    }
}