using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Npgsql;

namespace ReelRent
{
    public static class DatabaseHelper
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }

        public static bool TestConnection()
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
        }

        // Получить список всех фильмов из БД
        public static List<Movie> GetAllMovies()
        {
            var movies = new List<Movie>();
            string sql = "SELECT id, title, genre, year, director, actors, description, poster_filename, total_copies, available_copies, rental_price FROM movies ORDER BY id";

            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        movies.Add(new Movie
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Genre = reader.IsDBNull(2) ? null : reader.GetString(2),
                            Year = reader.IsDBNull(3) ? 0 : reader.GetInt32(3),
                            Director = reader.IsDBNull(4) ? null : reader.GetString(4),
                            Actors = reader.IsDBNull(5) ? null : reader.GetString(5),
                            Description = reader.IsDBNull(6) ? null : reader.GetString(6),
                            PosterFileName = reader.IsDBNull(7) ? null : reader.GetString(7),
                            TotalCopies = reader.GetInt32(8),
                            AvailableCopies = reader.GetInt32(9),
                            RentalPrice = reader.IsDBNull(10) ? 0 : reader.GetDecimal(10)
                        });
                    }
                }
            }
            return movies;
        }

        // Вспомогательный метод для проверки существования пользователя (авторизация)
        public static User GetUser(string username, string password)
        {
            string sql = "SELECT id, username, password_hash, full_name, email, phone, is_admin, is_blocked FROM users WHERE username = @username AND password_hash = @password";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                PasswordHash = reader.GetString(2),
                                FullName = reader.IsDBNull(3) ? null : reader.GetString(3),
                                Email = reader.IsDBNull(4) ? null : reader.GetString(4),
                                Phone = reader.IsDBNull(5) ? null : reader.GetString(5),
                                IsAdmin = reader.GetBoolean(6),
                                IsBlocked = reader.GetBoolean(7)
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        // Добавление нового фильма (админ)
        public static void AddMovie(Movie movie)
        {
            string sql = @"INSERT INTO movies (title, description, genre, year, director, actors, poster_filename, total_copies, available_copies, rental_price)
                           VALUES (@title, @description, @genre, @year, @director, @actors, @poster_filename, @total_copies, @available_copies, @rental_price)";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@title", movie.Title);
                    cmd.Parameters.AddWithValue("@description", (object)movie.Description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@genre", (object)movie.Genre ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@year", movie.Year);
                    cmd.Parameters.AddWithValue("@director", (object)movie.Director ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@actors", (object)movie.Actors ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@poster_filename", (object)movie.PosterFileName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@total_copies", movie.TotalCopies);
                    cmd.Parameters.AddWithValue("@available_copies", movie.AvailableCopies);
                    cmd.Parameters.AddWithValue("@rental_price", movie.RentalPrice);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Удаление фильма
        public static void DeleteMovie(int movieId)
        {
            string sql = "DELETE FROM movies WHERE id = @id";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", movieId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Получение баннеров
        public static List<Banner> GetActiveBanners()
        {
            var banners = new List<Banner>();
            string sql = "SELECT id, image_filename, order_index FROM banners WHERE is_active = true ORDER BY order_index";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        banners.Add(new Banner
                        {
                            Id = reader.GetInt32(0),
                            ImageFileName = reader.GetString(1),
                            OrderIndex = reader.GetInt32(2)
                        });
                    }
                }
            }
            return banners;
        }
    }

    // Класс-модель фильма
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public string Description { get; set; }
        public string PosterFileName { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }
        public decimal RentalPrice { get; set; }
    }

    // Класс для баннеров
    public class Banner
    {
        public int Id { get; set; }
        public string ImageFileName { get; set; }
        public int OrderIndex { get; set; }
    }

    // Класс для пользователя (добавим для авторизации)
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsBlocked { get; set; }
    }


}