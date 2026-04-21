using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ReelRent
{
    public partial class SearchResultsControl : UserControl
    {
        public event EventHandler BackButtonClicked;

        private FilterCriteria _criteria;
        private List<Movie> _results;

        public SearchResultsControl(FilterCriteria criteria)
        {
            _criteria = criteria;
            InitializeComponent();
            DisplayFilters();
            PerformSearch();
        }

        private void DisplayFilters()
        {
            filtersPanel.Controls.Clear();

            void AddFilterLine(string label, string value)
            {
                if (string.IsNullOrEmpty(value)) return;
                Label lbl = new Label
                {
                    Text = $"{label}:",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Theme.AccentForeColor,
                    AutoSize = true,
                    Margin = new Padding(0, 5, 5, 5)
                };
                Label val = new Label
                {
                    Text = value,
                    Font = new Font("Segoe UI", 12, FontStyle.Regular),
                    ForeColor = Theme.ForeColor,
                    AutoSize = true,
                    Margin = new Padding(0, 5, 0, 5)
                };
                filtersPanel.Controls.Add(lbl);
                filtersPanel.Controls.Add(val);
            }

            if (!string.IsNullOrWhiteSpace(_criteria.Title))
                AddFilterLine("Название", _criteria.Title);

            if (_criteria.YearFrom.HasValue || _criteria.YearTo.HasValue)
            {
                string yearRange = "";
                if (_criteria.YearFrom.HasValue && _criteria.YearTo.HasValue)
                    yearRange = $"{_criteria.YearFrom} — {_criteria.YearTo}";
                else if (_criteria.YearFrom.HasValue)
                    yearRange = $"от {_criteria.YearFrom}";
                else if (_criteria.YearTo.HasValue)
                    yearRange = $"до {_criteria.YearTo}";
                AddFilterLine("Год", yearRange);
            }

            if (_criteria.Genres.Count > 0)
                AddFilterLine("Жанр", string.Join(", ", _criteria.Genres));

            if (_criteria.MediaFormats.Count > 0)
                AddFilterLine("Носитель", string.Join(", ", _criteria.MediaFormats));

            if (!string.IsNullOrWhiteSpace(_criteria.Director))
                AddFilterLine("Режиссёр", _criteria.Director);

            if (!string.IsNullOrWhiteSpace(_criteria.Actors))
                AddFilterLine("В ролях", _criteria.Actors);

            if (!string.IsNullOrWhiteSpace(_criteria.AgeRating))
                AddFilterLine("Возрастной рейтинг", _criteria.AgeRating);

            if (filtersPanel.Controls.Count == 0)
            {
                Label noFilter = new Label
                {
                    Text = "Фильтры не заданы",
                    Font = new Font("Segoe UI", 12, FontStyle.Italic),
                    ForeColor = Theme.ForeColor,
                    AutoSize = true,
                    Margin = new Padding(0, 5, 0, 5)
                };
                filtersPanel.Controls.Add(noFilter);
            }
        }

        // ВАШ ВАРИАНТ МЕТОДА PerformSearch (с card.PerformLayout)
        private void PerformSearch()
        {
            moviesFlowPanel.SuspendLayout();
            moviesFlowPanel.Controls.Clear();
            _results = DatabaseHelper.SearchMoviesWithFilters(_criteria);

            if (_results.Count == 0)
            {
                Label noResults = new Label
                {
                    Text = "По вашему запросу ничего не удалось найти :(",
                    Font = new Font("Segoe UI", 16, FontStyle.Bold),
                    ForeColor = Theme.ForeColor,
                    AutoSize = true,
                    Margin = new Padding(20, 50, 0, 0)
                };
                moviesFlowPanel.Controls.Add(noResults);
                moviesFlowPanel.ResumeLayout(false);
                return;
            }

            foreach (var movie in _results)
            {
                var card = new MovieCard(movie);
                card.MovieClicked += (s, m) => ShowMovieDetail(m);
                // Фиксируем размер карточки, как в CatalogControl
                card.Size = new Size(280, 420);
                card.MinimumSize = new Size(280, 420);
                card.MaximumSize = new Size(280, 420);
                card.Margin = new Padding(10);
                card.PerformLayout(); // принудительная разметка (ваше требование)
                moviesFlowPanel.Controls.Add(card);
            }

            moviesFlowPanel.ResumeLayout(true);
            moviesFlowPanel.PerformLayout();
            this.PerformLayout();
        }

        private void ShowMovieDetail(Movie movie)
        {
            var detailForm = new MovieDetailForm(
                movie.Id, movie.Title, movie.Genre, movie.Year.ToString(), movie.Director,
                movie.Actors, movie.Description, movie.AvailableCopies,
                movie.RentalPrice, movie.Duration, movie.AgeRating,
                movie.PosterFileName, movie.MediaFormat, movie.Language
            );
            detailForm.ShowDialog();
        }
    }
}