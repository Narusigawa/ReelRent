using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ReelRent
{
    public partial class MovieDetailForm : Form
    {
        private int movieId; // добавлено поле для хранения ID фильма

        public MovieDetailForm(int movieId, string title, string genre, string year, string director,
                               string actors, string description, int copiesAvailable,
                               decimal price, int duration, string ageRating, string posterFileName,
                               string mediaFormat, string language)
        {
            this.movieId = movieId; // сохраняем ID
            InitializeComponent();
            LoadData(title, genre, year, director, actors, description,
                     copiesAvailable, price, duration, ageRating, posterFileName,
                     mediaFormat, language);
        }

        private void LoadData(string title, string genre, string year, string director,
                              string actors, string description, int copiesAvailable,
                              decimal price, int duration, string ageRating, string posterFileName,
                              string mediaFormat, string language)
        {
            this.Text = title;
            lblTitle.Text = title;
            lblGenre.Text = $"Жанр: {genre ?? "—"}";
            lblYear.Text = $"Год: {year}";
            lblDirector.Text = $"Режиссёр: {director ?? "—"}";
            lblActors.Text = $"В ролях: {actors ?? "—"}";
            lblDuration.Text = duration > 0 ? $"Продолжительность: {duration} мин" : "Продолжительность: —";
            lblAgeRating.Text = $"Возрастной рейтинг: {ageRating ?? "—"}";
            lblMediaFormat.Text = $"Формат: {mediaFormat ?? "—"}";
            lblLanguage.Text = $"Язык/субтитры: {language ?? "—"}";

            lblDescription.Text = description ?? "—";
            lblPrice.Text = $"{price:F2} руб/сутки";
            lblCopies.Text = $"Доступно копий: {copiesAvailable}";

            // Загрузка постера
            if (!string.IsNullOrEmpty(posterFileName))
            {
                string postersPath = Path.Combine(Application.StartupPath, "Images", "Posters");
                string fullPath = Path.Combine(postersPath, posterFileName);
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

            if (picturePoster.Image == null)
            {
                Bitmap bmp = new Bitmap(280, 370);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.FromArgb(60, 60, 60));
                    g.DrawString("Нет постера", new Font("Segoe UI", 10), Brushes.White, new PointF(20, 110));
                }
                picturePoster.Image = bmp;
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (!Session.IsAuthenticated)
            {
                MessageBox.Show("Для добавления в корзину необходимо войти в систему.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Добавляем фильм в корзину с количеством дней = 1
            DatabaseHelper.AddToCart(Session.CurrentUser.Id, movieId, 1);
            MessageBox.Show($"Фильм \"{lblTitle.Text}\" добавлен в корзину.", "Корзина", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}