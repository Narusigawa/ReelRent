using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ReelRent.Properties;

namespace ReelRent
{
    public partial class CatalogControl : UserControl
    {
        private List<Image> banners = new List<Image>();
        private int currentBannerIndex = 0;

        public CatalogControl()
        {
            InitializeComponent();
            LoadBanners();
            bannerTimer.Interval = 10000;
            bannerTimer.Tick += (s, e) => NextBanner();
            bannerTimer.Start();

            if (DatabaseHelper.TestConnection())
                LoadMoviesFromDatabase();
            else
                LoadTestMovies();
        }

        private void LoadBanners()
        {
            banners.Clear();
            try
            {
                banners.Add(Resources.banner1);
                banners.Add(Resources.banner2);
                banners.Add(Resources.banner3);
            }
            catch
            {
                for (int i = 1; i <= 3; i++)
                {
                    Bitmap bmp = new Bitmap(800, 300);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.FromArgb(80, 80, 80));
                        g.DrawString($"Баннер {i}", new Font("Segoe UI", 20), Brushes.White, new PointF(20, 20));
                    }
                    banners.Add(bmp);
                }
            }

            if (banners.Count > 0)
            {
                bannerPicture.Image = banners[0];
                currentBannerIndex = 0;
                UpdateIndicators();
            }
        }

        private void UpdateIndicators()
        {
            indicatorPanel.Controls.Clear();
            int count = banners.Count;
            int dotSize = 10;
            int margin = 5;
            int spacing = dotSize + 2 * margin;
            int totalWidth = count * spacing;

            indicatorPanel.Width = totalWidth;
            int centerX = (bannerPanel.Width - totalWidth) / 2;
            indicatorPanel.Location = new Point(centerX, bannerPicture.Height + 15);
            indicatorPanel.Height = 30;

            for (int i = 0; i < count; i++)
            {
                Button dot = new Button();
                dot.FlatStyle = FlatStyle.Flat;
                dot.FlatAppearance.BorderSize = 0;
                dot.BackColor = i == currentBannerIndex ? Theme.ButtonHoverColor : Color.FromArgb(100, 100, 100);
                dot.Size = new Size(dotSize, dotSize);
                dot.Margin = new Padding(margin);
                dot.Click += (s, e) => SetBannerIndex(i);
                dot.Cursor = Cursors.Hand;
                dot.Location = new Point(i * spacing, 0);
                indicatorPanel.Controls.Add(dot);
            }
            indicatorPanel.Visible = true;
        }

        private void SetBannerIndex(int index)
        {
            if (index < 0) index = banners.Count - 1;
            if (index >= banners.Count) index = 0;
            currentBannerIndex = index;
            bannerPicture.Image = banners[currentBannerIndex];
            UpdateIndicators();
            bannerTimer.Stop();
            bannerTimer.Start();
        }

        private void NextBanner() => SetBannerIndex(currentBannerIndex + 1);
        private void PrevBanner() => SetBannerIndex(currentBannerIndex - 1);

        private void LoadTestMovies()
        {
            moviesFlowLayoutPanel.SuspendLayout();
            moviesFlowLayoutPanel.Controls.Clear();
            for (int i = 1; i <= 15; i++)
            {
                var movie = new Movie
                {
                    Id = i,
                    Title = $"Фильм {i}",
                    Genre = "Жанр",
                    Year = 2020 + (i % 5),
                    Director = "Режиссёр",
                    Actors = "Актёры",
                    Description = "Описание фильма...",
                    PosterFileName = null,
                    TotalCopies = 5,
                    AvailableCopies = 5
                };
                var movieCard = new MovieCard(movie);
                movieCard.MovieClicked += (s, m) => ShowMovieDetail(m);
                EnsureCardSize(movieCard);
                moviesFlowLayoutPanel.Controls.Add(movieCard);
            }
            moviesFlowLayoutPanel.ResumeLayout(true);
            moviesFlowLayoutPanel.PerformLayout();
        }

        private void LoadMoviesFromDatabase()
        {
            moviesFlowLayoutPanel.SuspendLayout();
            moviesFlowLayoutPanel.Controls.Clear();
            var movies = DatabaseHelper.GetAllMovies();
            foreach (var movie in movies)
            {
                var movieCard = new MovieCard(movie);
                movieCard.MovieClicked += (s, m) => ShowMovieDetail(m);
                EnsureCardSize(movieCard);
                moviesFlowLayoutPanel.Controls.Add(movieCard);
            }
            moviesFlowLayoutPanel.ResumeLayout(true);
            moviesFlowLayoutPanel.PerformLayout();
        }

        private void ShowMovieDetail(Movie movie)
        {
            var detailForm = new MovieDetailForm(movie.Title, movie.Genre, movie.Year.ToString(),
                movie.Director, movie.Actors, movie.Description, movie.AvailableCopies);
            detailForm.ShowDialog();
        }

        // Метод, гарантирующий фиксированный размер карточки
        private void EnsureCardSize(MovieCard card)
        {
            card.Size = new Size(280, 420);
            card.MinimumSize = new Size(280, 420);
            card.MaximumSize = new Size(280, 420);
            card.PerformLayout();
        }

        public void FilterMovies(string query)
        {
            moviesFlowLayoutPanel.SuspendLayout();
            moviesFlowLayoutPanel.Controls.Clear();

            if (!DatabaseHelper.TestConnection())
            {
                MessageBox.Show("База данных недоступна. Поиск невозможен.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                moviesFlowLayoutPanel.ResumeLayout(false);
                moviesFlowLayoutPanel.PerformLayout();
                return;
            }

            var allMovies = DatabaseHelper.GetAllMovies();
            var moviesToShow = new List<Movie>();

            if (string.IsNullOrWhiteSpace(query))
                moviesToShow = allMovies;
            else
                moviesToShow = allMovies.FindAll(m => m.Title.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0);

            foreach (var movie in moviesToShow)
            {
                var movieCard = new MovieCard(movie);
                movieCard.MovieClicked += (s, m) => ShowMovieDetail(m);
                EnsureCardSize(movieCard);
                moviesFlowLayoutPanel.Controls.Add(movieCard);
            }

            moviesFlowLayoutPanel.ResumeLayout(true);
            moviesFlowLayoutPanel.PerformLayout();

            // Принудительная перерисовка
            moviesFlowLayoutPanel.Refresh();
            this.Refresh();
        }

        public void RefreshCatalog()
        {
            if (DatabaseHelper.TestConnection())
                LoadMoviesFromDatabase();
            else
                LoadTestMovies();
        }
    }
}