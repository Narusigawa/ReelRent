using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ReelRent
{
    public partial class MovieEditForm : Form
    {
        private Movie _movie; // null для добавления
        private string _posterPath = null;

        public MovieEditForm(Movie movie = null)
        {
            InitializeComponent();
            _movie = movie;
            if (_movie != null)
            {
                LoadMovieData();
            }
        }

        private void LoadMovieData()
        {
            txtTitle.Text = _movie.Title;
            txtGenre.Text = _movie.Genre;
            txtYear.Text = _movie.Year.ToString();
            txtDirector.Text = _movie.Director;
            txtActors.Text = _movie.Actors;
            txtDuration.Text = _movie.Duration > 0 ? _movie.Duration.ToString() : "";

            // Установка выбранного значения в ComboBox
            if (!string.IsNullOrEmpty(_movie.AgeRating))
                cmbAgeRating.SelectedItem = _movie.AgeRating;
            else
                cmbAgeRating.SelectedIndex = -1;

            if (!string.IsNullOrEmpty(_movie.MediaFormat))
                cmbMediaFormat.SelectedItem = _movie.MediaFormat;
            else
                cmbMediaFormat.SelectedIndex = -1;

            txtLanguage.Text = _movie.Language;
            txtDescription.Text = _movie.Description;
            txtTotalCopies.Text = _movie.TotalCopies.ToString();
            txtAvailableCopies.Text = _movie.AvailableCopies.ToString();
            txtRentalPrice.Text = _movie.RentalPrice.ToString("0.00");

            if (!string.IsNullOrEmpty(_movie.PosterFileName))
            {
                string postersPath = Path.Combine(Application.StartupPath, "Images", "Posters");
                string fullPath = Path.Combine(postersPath, _movie.PosterFileName);
                if (File.Exists(fullPath))
                {
                    try
                    {
                        using (var fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                        {
                            var img = Image.FromStream(fs);
                            picturePoster.Image = new Bitmap(img);
                            img.Dispose();
                        }
                    }
                    catch { picturePoster.Image = null; }
                }
            }
        }

        private void btnSelectPoster_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Выберите постер";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _posterPath = ofd.FileName;
                    try
                    {
                        if (picturePoster.Image != null)
                        {
                            picturePoster.Image.Dispose();
                            picturePoster.Image = null;
                        }
                        using (var fs = new FileStream(_posterPath, FileMode.Open, FileAccess.Read))
                        {
                            var img = Image.FromStream(fs);
                            picturePoster.Image = new Bitmap(img);
                            img.Dispose();
                        }
                    }
                    catch { }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Проверка обязательных полей
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Введите название фильма.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtYear.Text, out int year))
            {
                MessageBox.Show("Год должен быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtTotalCopies.Text, out int totalCopies))
            {
                MessageBox.Show("Количество копий должно быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txtAvailableCopies.Text, out int availableCopies))
            {
                MessageBox.Show("Доступные копии должны быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(txtRentalPrice.Text, out decimal rentalPrice))
            {
                MessageBox.Show("Цена аренды должна быть числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int duration = 0;
            if (!string.IsNullOrWhiteSpace(txtDuration.Text) && !int.TryParse(txtDuration.Text, out duration))
            {
                MessageBox.Show("Длительность должна быть числом (в минутах).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ageRating = cmbAgeRating.SelectedItem?.ToString();
            string mediaFormat = cmbMediaFormat.SelectedItem?.ToString();

            string posterFileName = _movie?.PosterFileName;
            if (_posterPath != null)
            {
                string postersDir = Path.Combine(Application.StartupPath, "Images", "Posters");
                if (!Directory.Exists(postersDir))
                    Directory.CreateDirectory(postersDir);

                string originalFileName = Path.GetFileName(_posterPath);
                string destPath = Path.Combine(postersDir, originalFileName);

                if (_movie != null && !string.IsNullOrEmpty(_movie.PosterFileName) && _movie.PosterFileName != originalFileName)
                {
                    string oldPath = Path.Combine(postersDir, _movie.PosterFileName);
                    if (File.Exists(oldPath))
                        File.Delete(oldPath);
                }

                if (picturePoster.Image != null)
                {
                    picturePoster.Image.Dispose();
                    picturePoster.Image = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();

                File.Copy(_posterPath, destPath, true);
                posterFileName = originalFileName;
            }
            else if (string.IsNullOrEmpty(posterFileName))
            {
                MessageBox.Show("Выберите постер для фильма.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Movie movie = new Movie
            {
                Id = _movie?.Id ?? 0,
                Title = txtTitle.Text,
                Genre = txtGenre.Text,
                Year = year,
                Director = txtDirector.Text,
                Actors = txtActors.Text,
                Duration = duration,
                AgeRating = ageRating,
                MediaFormat = mediaFormat,
                Language = txtLanguage.Text,
                Description = txtDescription.Text,
                PosterFileName = posterFileName,
                TotalCopies = totalCopies,
                AvailableCopies = availableCopies,
                RentalPrice = rentalPrice
            };

            if (_movie == null)
                DatabaseHelper.AddMovie(movie);
            else
                DatabaseHelper.UpdateMovie(movie);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}