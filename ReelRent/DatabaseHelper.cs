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
        public static List<Movie> GetAllMovies(bool includeDeleted = false)
        {
            var movies = new List<Movie>();
            string sql = "SELECT id, title, genre, year, director, actors, description, poster_filename, total_copies, available_copies, rental_price, is_deleted FROM movies";
            if (!includeDeleted)
                sql += " WHERE is_deleted = false";
            sql += " ORDER BY id";

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
                            RentalPrice = reader.IsDBNull(10) ? 0 : reader.GetDecimal(10),
                            IsDeleted = reader.GetBoolean(11)
                        });
                    }
                }
            }
            return movies;
        }

        // Получить фильм по ID
        public static Movie GetMovieById(int id)
        {
            string sql = "SELECT id, title, genre, year, director, actors, description, poster_filename, total_copies, available_copies, rental_price, is_deleted FROM movies WHERE id = @id";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Movie
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
                                RentalPrice = reader.IsDBNull(10) ? 0 : reader.GetDecimal(10),
                                IsDeleted = reader.GetBoolean(11)
                            };
                        }
                        return null;
                    }
                }
            }
        }

        // Добавление нового фильма
        public static void AddMovie(Movie movie)
        {
            string sql = @"INSERT INTO movies (title, description, genre, year, director, actors, poster_filename, total_copies, available_copies, rental_price, is_deleted)
                           VALUES (@title, @description, @genre, @year, @director, @actors, @poster_filename, @total_copies, @available_copies, @rental_price, false)";
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

        // Обновление фильма
        public static void UpdateMovie(Movie movie)
        {
            string sql = @"UPDATE movies SET title=@title, description=@description, genre=@genre, year=@year, 
                           director=@director, actors=@actors, poster_filename=@poster_filename, 
                           total_copies=@total_copies, available_copies=@available_copies, rental_price=@rental_price 
                           WHERE id = @id";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", movie.Id);
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

        // Мягкое удаление фильма
        public static void SoftDeleteMovie(int movieId)
        {
            string sql = "UPDATE movies SET is_deleted = true WHERE id = @id";
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

        public static List<Movie> SearchMoviesByTitle(string query)
        {
            var movies = new List<Movie>();
            string sql = "SELECT id, title, genre, year, director, actors, description, poster_filename, total_copies, available_copies, rental_price, is_deleted FROM movies WHERE title ILIKE @query AND is_deleted = false ORDER BY title";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@query", $"%{query}%");
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
                                RentalPrice = reader.IsDBNull(10) ? 0 : reader.GetDecimal(10),
                                IsDeleted = reader.GetBoolean(11)
                            });
                        }
                    }
                }
            }
            return movies;
        }
        // Проверка существования пользователя по логину или email
        public static bool UserExists(string username, string email)
        {
            string sql = "SELECT COUNT(*) FROM users WHERE username = @username OR email = @email";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@email", email);
                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        // Регистрация нового пользователя
        public static bool RegisterUser(string username, string password, string fullName, string email, string phone)
        {
            string sql = @"INSERT INTO users (username, password_hash, full_name, email, phone, is_admin, is_blocked)
                   VALUES (@username, @password, @full_name, @email, @phone, false, false)";
            using (var conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@full_name", string.IsNullOrEmpty(fullName) ? DBNull.Value : (object)fullName);
                        cmd.Parameters.AddWithValue("@email", string.IsNullOrEmpty(email) ? DBNull.Value : (object)email);
                        cmd.Parameters.AddWithValue("@phone", string.IsNullOrEmpty(phone) ? DBNull.Value : (object)phone);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    return false;
                }
            }
        }
    }

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
        public bool IsDeleted { get; set; }
    }

    public class Banner
    {
        public int Id { get; set; }
        public string ImageFileName { get; set; }
        public int OrderIndex { get; set; }
    }

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