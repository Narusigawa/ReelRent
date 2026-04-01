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
                        picturePoster.Image = Image.FromFile(fullPath);
                    }
                    catch { }
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
                        picturePoster.Image = Image.FromFile(_posterPath);
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

            string posterFileName = _movie?.PosterFileName;
            if (_posterPath != null)
            {
                // Копируем файл постера в папку приложения
                string postersDir = Path.Combine(Application.StartupPath, "Images", "Posters");
                if (!Directory.Exists(postersDir))
                    Directory.CreateDirectory(postersDir);
                string newFileName = Guid.NewGuid().ToString() + Path.GetExtension(_posterPath);
                string destPath = Path.Combine(postersDir, newFileName);
                File.Copy(_posterPath, destPath, true);
                posterFileName = newFileName;
            }

            Movie movie = new Movie
            {
                Id = _movie?.Id ?? 0,
                Title = txtTitle.Text,
                Genre = txtGenre.Text,
                Year = year,
                Director = txtDirector.Text,
                Actors = txtActors.Text,
                Description = txtDescription.Text,
                PosterFileName = posterFileName,
                TotalCopies = totalCopies,
                AvailableCopies = availableCopies,
                RentalPrice = rentalPrice
            };

            if (_movie == null)
            {
                DatabaseHelper.AddMovie(movie);
            }
            else
            {
                DatabaseHelper.UpdateMovie(movie);
            }

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