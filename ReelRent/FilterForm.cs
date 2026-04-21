using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ReelRent
{
    public partial class FilterForm : Form
    {
        public FilterCriteria Criteria { get; private set; }

        public FilterForm()
        {
            InitializeComponent();
            LoadFilterOptions();
            SetYearRange();
        }
        private void SetYearRange()
        {
            var (minYear, maxYear) = DatabaseHelper.GetYearRange();
            numYearFrom.Minimum = minYear;
            numYearFrom.Maximum = maxYear;
            numYearTo.Minimum = minYear;
            numYearTo.Maximum = maxYear;
            numYearFrom.Value = minYear;
            numYearTo.Value = maxYear;
        }
        private void LoadFilterOptions()
        {
            // Загружаем жанры
            var genres = DatabaseHelper.GetDistinctGenres();
            lstGenres.Items.Clear();
            foreach (var g in genres)
                lstGenres.Items.Add(g);

            // Загружаем носители
            var formats = DatabaseHelper.GetDistinctMediaFormats();
            lstMediaFormats.Items.Clear();
            foreach (var f in formats)
                lstMediaFormats.Items.Add(f);

            // Загружаем возрастные рейтинги
            var ratings = DatabaseHelper.GetDistinctAgeRatings();
            cmbAgeRating.Items.Clear();
            cmbAgeRating.Items.Add("");
            foreach (var r in ratings)
                cmbAgeRating.Items.Add(r);
            cmbAgeRating.SelectedIndex = 0;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var criteria = new FilterCriteria
            {
                Title = txtTitle.Text.Trim(),
                YearFrom = (int?)numYearFrom.Value,
                YearTo = (int?)numYearTo.Value,
                Director = txtDirector.Text.Trim(),
                Actors = txtActors.Text.Trim(),
                AgeRating = cmbAgeRating.SelectedItem?.ToString() == "" ? null : cmbAgeRating.SelectedItem?.ToString()
            };

            // Собираем выбранные жанры
            foreach (var item in lstGenres.SelectedItems)
            {
                if (item != null)
                    criteria.Genres.Add(item.ToString());
            }

            // Собираем выбранные носители
            foreach (var item in lstMediaFormats.SelectedItems)
            {
                if (item != null)
                    criteria.MediaFormats.Add(item.ToString());
            }

            Criteria = criteria;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            numYearFrom.Value = 0;
            numYearTo.Value = 0;
            txtDirector.Clear();
            txtActors.Clear();
            cmbAgeRating.SelectedIndex = 0;
            lstGenres.ClearSelected();
            lstMediaFormats.ClearSelected();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}