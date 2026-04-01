using System;
using System.Windows.Forms;

namespace ReelRent
{
    public partial class ManageMoviesControl : UserControl
    {
        public event EventHandler BackButtonClicked;

        public ManageMoviesControl()
        {
            InitializeComponent();
            LoadMovies();
        }

        private void LoadMovies()
        {
            dgvMovies.Rows.Clear();
            var movies = DatabaseHelper.GetAllMovies(false); // только активные
            foreach (var movie in movies)
            {
                // Порядок колонок: ID, Название, Жанр, Год, Всего копий, Доступно, Цена
                dgvMovies.Rows.Add(
                    movie.Id,
                    movie.Title,
                    movie.Genre,
                    movie.Year,
                    movie.TotalCopies,
                    movie.AvailableCopies,
                    movie.RentalPrice
                );
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new MovieEditForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadMovies();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvMovies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите фильм для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id = Convert.ToInt32(dgvMovies.SelectedRows[0].Cells[0].Value);
            var movie = DatabaseHelper.GetMovieById(id);
            if (movie != null)
            {
                using (var form = new MovieEditForm(movie))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadMovies();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMovies.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите фильм для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id = Convert.ToInt32(dgvMovies.SelectedRows[0].Cells[0].Value);
            if (MessageBox.Show("Удалить фильм? (он будет скрыт из каталога, но останется в истории)", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DatabaseHelper.SoftDeleteMovie(id);
                LoadMovies();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            BackButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}