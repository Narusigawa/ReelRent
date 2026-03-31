using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ReelRent
{
    public partial class MovieCard : UserControl
    {
        private Movie movieData;

        public event EventHandler<Movie> MovieClicked;

        public MovieCard(Movie movie)
        {
            movieData = movie;
            InitializeComponent();

            // Фиксируем размер, чтобы не менялся при добавлении в панель
            this.AutoSize = false;
            this.Size = new Size(280, 420);
            this.MinimumSize = new Size(280, 420);
            this.MaximumSize = new Size(280, 420);

            // Загрузка постера из файла, если он существует
            string postersPath = Path.Combine(Application.StartupPath, "Images", "Posters");
            if (!string.IsNullOrEmpty(movieData.PosterFileName))
            {
                string fullPath = Path.Combine(postersPath, movieData.PosterFileName);
                if (File.Exists(fullPath))
                {
                    try
                    {
                        posterBox.Image = Image.FromFile(fullPath);
                    }
                    catch { /* не удалось загрузить */ }
                }
            }

            // Если постера нет – рисуем заглушку
            if (posterBox.Image == null)
            {
                Bitmap bmp = new Bitmap(posterBox.Width, posterBox.Height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.FromArgb(80, 80, 80));
                    using (Font font = new Font("Segoe UI", 12))
                    using (Brush brush = new SolidBrush(Color.LightGray))
                    {
                        string text = "Нет постера";
                        SizeF textSize = g.MeasureString(text, font);
                        g.DrawString(text, font, brush,
                            (posterBox.Width - textSize.Width) / 2,
                            (posterBox.Height - textSize.Height) / 2);
                    }
                }
                posterBox.Image = bmp;
            }

            titleLabel.Text = movieData.Title;
        }

        public void UpdatePoster(Image posterImage)
        {
            if (posterImage != null)
                posterBox.Image = posterImage;
        }
    }
}