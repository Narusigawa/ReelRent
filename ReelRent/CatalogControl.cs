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
                moviesFlowLayoutPanel.Controls.Add(movieCard);
            }
        }

        private void LoadMoviesFromDatabase()
        {
            moviesFlowLayoutPanel.Controls.Clear();
            var movies = DatabaseHelper.GetAllMovies();
            foreach (var movie in movies)
            {
                var movieCard = new MovieCard(movie);
                movieCard.MovieClicked += (s, m) => ShowMovieDetail(m);
                moviesFlowLayoutPanel.Controls.Add(movieCard);
            }
        }

        private void ShowMovieDetail(Movie movie)
        {
            var detailForm = new MovieDetailForm(movie.Title, movie.Genre, movie.Year.ToString(),
                movie.Director, movie.Actors, movie.Description, movie.AvailableCopies);
            detailForm.ShowDialog();
        }

        // Публичный метод для фильтрации из MainForm
        public void FilterMovies(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                // Показываем все фильмы
                if (DatabaseHelper.TestConnection())
                    LoadMoviesFromDatabase();
                else
                    LoadTestMovies();
                return;
            }

            moviesFlowLayoutPanel.Controls.Clear();
            var allMovies = DatabaseHelper.TestConnection() ? DatabaseHelper.GetAllMovies() : null;
            if (allMovies != null)
            {
                foreach (var movie in allMovies)
                {
                    if (movie.Title.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        var movieCard = new MovieCard(movie);
                        movieCard.MovieClicked += (s, m) => ShowMovieDetail(m);
                        moviesFlowLayoutPanel.Controls.Add(movieCard);
                    }
                }
            }
            else
            {
                for (int i = 1; i <= 15; i++)
                {
                    string title = $"Фильм {i}";
                    if (title.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        var movie = new Movie { Title = title, Genre = "Жанр", Year = 2020, AvailableCopies = 5 };
                        var movieCard = new MovieCard(movie);
                        movieCard.MovieClicked += (s, m) => ShowMovieDetail(m);
                        moviesFlowLayoutPanel.Controls.Add(movieCard);
                    }
                }
            }
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