using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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

        // ==================== MOVIES ====================

        public static List<Movie> GetAllMovies(bool includeDeleted = false)
        {
            var movies = new List<Movie>();
            string sql = "SELECT id, title, genre, year, director, actors, duration, age_rating, media_format, language, description, poster_filename, total_copies, available_copies, rental_price, is_deleted FROM movies";
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
                            Duration = reader.IsDBNull(6) ? 0 : reader.GetInt32(6),
                            AgeRating = reader.IsDBNull(7) ? null : reader.GetString(7),
                            MediaFormat = reader.IsDBNull(8) ? null : reader.GetString(8),
                            Language = reader.IsDBNull(9) ? null : reader.GetString(9),
                            Description = reader.IsDBNull(10) ? null : reader.GetString(10),
                            PosterFileName = reader.IsDBNull(11) ? null : reader.GetString(11),
                            TotalCopies = reader.GetInt32(12),
                            AvailableCopies = reader.GetInt32(13),
                            RentalPrice = reader.IsDBNull(14) ? 0 : reader.GetDecimal(14),
                            IsDeleted = reader.GetBoolean(15)
                        });
                    }
                }
            }
            return movies;
        }

        public static Movie GetMovieById(int id)
        {
            string sql = "SELECT id, title, genre, year, director, actors, duration, age_rating, media_format, language, description, poster_filename, total_copies, available_copies, rental_price, is_deleted FROM movies WHERE id = @id";
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
                                Duration = reader.IsDBNull(6) ? 0 : reader.GetInt32(6),
                                AgeRating = reader.IsDBNull(7) ? null : reader.GetString(7),
                                MediaFormat = reader.IsDBNull(8) ? null : reader.GetString(8),
                                Language = reader.IsDBNull(9) ? null : reader.GetString(9),
                                Description = reader.IsDBNull(10) ? null : reader.GetString(10),
                                PosterFileName = reader.IsDBNull(11) ? null : reader.GetString(11),
                                TotalCopies = reader.GetInt32(12),
                                AvailableCopies = reader.GetInt32(13),
                                RentalPrice = reader.IsDBNull(14) ? 0 : reader.GetDecimal(14),
                                IsDeleted = reader.GetBoolean(15)
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public static void AddMovie(Movie movie)
        {
            string sql = @"INSERT INTO movies (title, description, genre, year, director, actors, duration, age_rating, media_format, language, poster_filename, total_copies, available_copies, rental_price, is_deleted)
                           VALUES (@title, @description, @genre, @year, @director, @actors, @duration, @age_rating, @media_format, @language, @poster_filename, @total_copies, @available_copies, @rental_price, false)";
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
                    cmd.Parameters.AddWithValue("@duration", movie.Duration > 0 ? (object)movie.Duration : DBNull.Value);
                    cmd.Parameters.AddWithValue("@age_rating", (object)movie.AgeRating ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@media_format", (object)movie.MediaFormat ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@language", (object)movie.Language ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@poster_filename", (object)movie.PosterFileName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@total_copies", movie.TotalCopies);
                    cmd.Parameters.AddWithValue("@available_copies", movie.AvailableCopies);
                    cmd.Parameters.AddWithValue("@rental_price", movie.RentalPrice);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateMovie(Movie movie)
        {
            string sql = @"UPDATE movies SET title=@title, description=@description, genre=@genre, year=@year, 
                           director=@director, actors=@actors, duration=@duration, age_rating=@age_rating,
                           media_format=@media_format, language=@language, poster_filename=@poster_filename, 
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
                    cmd.Parameters.AddWithValue("@duration", movie.Duration > 0 ? (object)movie.Duration : DBNull.Value);
                    cmd.Parameters.AddWithValue("@age_rating", (object)movie.AgeRating ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@media_format", (object)movie.MediaFormat ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@language", (object)movie.Language ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@poster_filename", (object)movie.PosterFileName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@total_copies", movie.TotalCopies);
                    cmd.Parameters.AddWithValue("@available_copies", movie.AvailableCopies);
                    cmd.Parameters.AddWithValue("@rental_price", movie.RentalPrice);
                    cmd.ExecuteNonQuery();
                }
            }
        }

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

        // ==================== USERS ====================

        public static User GetUser(string username, string password)
        {
            string sql = "SELECT id, username, password_hash, full_name, email, phone, delivery_address, is_admin, is_blocked FROM users WHERE username = @username AND password_hash = @password";
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
                                DeliveryAddress = reader.IsDBNull(6) ? null : reader.GetString(6),
                                IsAdmin = reader.GetBoolean(7),
                                IsBlocked = reader.GetBoolean(8)
                            };
                        }
                        return null;
                    }
                }
            }
        }

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

        public static void UpdateUserDeliveryAddress(int userId, string address)
        {
            string sql = "UPDATE users SET delivery_address = @address WHERE id = @userId";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@address", (object)address ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ==================== BANNERS ====================

        public static void EnsureDefaultBanners()
        {
            var existing = GetAllBanners(true);
            if (existing.Count > 0) return;

            string bannersDir = Path.Combine(Application.StartupPath, "Images", "Banners");
            if (!Directory.Exists(bannersDir))
                Directory.CreateDirectory(bannersDir);

            for (int i = 1; i <= 3; i++)
            {
                string fileName = $"banner{i}.jpg";
                string fullPath = Path.Combine(bannersDir, fileName);
                if (!File.Exists(fullPath))
                {
                    using (var bmp = new Bitmap(800, 300))
                    using (var g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.FromArgb(80, 80, 80));
                        g.DrawString($"Баннер {i}", new Font("Segoe UI", 20), Brushes.White, new PointF(20, 20));
                        bmp.Save(fullPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }

                var banner = new Banner
                {
                    ImageFileName = fileName,
                    Description = $"Баннер {i}",
                    OrderIndex = i,
                    IsActive = true
                };
                AddBanner(banner);
            }
        }

        public static List<Banner> GetActiveBanners()
        {
            var banners = new List<Banner>();
            string sql = "SELECT id, image_filename, description, order_index, is_active FROM banners WHERE is_active = true ORDER BY order_index";
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
                            Description = reader.IsDBNull(2) ? null : reader.GetString(2),
                            OrderIndex = reader.GetInt32(3),
                            IsActive = reader.GetBoolean(4)
                        });
                    }
                }
            }
            return banners;
        }

        public static List<Banner> GetAllBanners(bool includeInactive = false)
        {
            var banners = new List<Banner>();
            string sql = "SELECT id, image_filename, description, order_index, is_active FROM banners";
            if (!includeInactive)
                sql += " WHERE is_active = true";
            sql += " ORDER BY order_index";

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
                            Description = reader.IsDBNull(2) ? null : reader.GetString(2),
                            OrderIndex = reader.GetInt32(3),
                            IsActive = reader.GetBoolean(4)
                        });
                    }
                }
            }
            return banners;
        }

        public static Banner GetBannerById(int id)
        {
            string sql = "SELECT id, image_filename, description, order_index, is_active FROM banners WHERE id = @id";
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
                            return new Banner
                            {
                                Id = reader.GetInt32(0),
                                ImageFileName = reader.GetString(1),
                                Description = reader.IsDBNull(2) ? null : reader.GetString(2),
                                OrderIndex = reader.GetInt32(3),
                                IsActive = reader.GetBoolean(4)
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public static void AddBanner(Banner banner)
        {
            int nextOrder = 1;
            string sqlMax = "SELECT COALESCE(MAX(order_index), 0) + 1 FROM banners";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sqlMax, conn))
                {
                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                        nextOrder = Convert.ToInt32(result);
                }
            }

            string sql = @"INSERT INTO banners (image_filename, description, order_index, is_active)
                           VALUES (@image_filename, @description, @order_index, @is_active)";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@image_filename", banner.ImageFileName);
                    cmd.Parameters.AddWithValue("@description", (object)banner.Description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@order_index", nextOrder);
                    cmd.Parameters.AddWithValue("@is_active", banner.IsActive);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void UpdateBanner(Banner banner)
        {
            string sql = @"UPDATE banners SET image_filename = @image_filename, description = @description,
                           order_index = @order_index, is_active = @is_active WHERE id = @id";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", banner.Id);
                    cmd.Parameters.AddWithValue("@image_filename", banner.ImageFileName);
                    cmd.Parameters.AddWithValue("@description", (object)banner.Description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@order_index", banner.OrderIndex);
                    cmd.Parameters.AddWithValue("@is_active", banner.IsActive);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteBanner(int id)
        {
            string imageFileName = null;
            string sqlSelect = "SELECT image_filename FROM banners WHERE id = @id";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sqlSelect, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                        imageFileName = result.ToString();
                }
            }

            string sqlDelete = "DELETE FROM banners WHERE id = @id";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sqlDelete, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }

            if (!string.IsNullOrEmpty(imageFileName))
            {
                string bannersDir = Path.Combine(Application.StartupPath, "Images", "Banners");
                string fullPath = Path.Combine(bannersDir, imageFileName);
                if (File.Exists(fullPath))
                {
                    try { File.Delete(fullPath); } catch { }
                }
            }
        }

        // ==================== CART ====================

        public static void AddToCart(int userId, int movieId, int days = 1)
        {
            string checkSql = "SELECT id, quantity FROM cart WHERE user_id = @userId AND movie_id = @movieId";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(checkSql, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@movieId", movieId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int cartId = reader.GetInt32(0);
                            int currentDays = reader.GetInt32(1);
                            reader.Close();
                            string updateSql = "UPDATE cart SET quantity = @days WHERE id = @id";
                            using (var updateCmd = new NpgsqlCommand(updateSql, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@days", currentDays + days);
                                updateCmd.Parameters.AddWithValue("@id", cartId);
                                updateCmd.ExecuteNonQuery();
                            }
                            return;
                        }
                    }
                }
            }

            string insertSql = "INSERT INTO cart (user_id, movie_id, quantity) VALUES (@userId, @movieId, @days)";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(insertSql, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@movieId", movieId);
                    cmd.Parameters.AddWithValue("@days", days);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<CartItem> GetCartItems(int userId)
        {
            var items = new List<CartItem>();
            string sql = @"SELECT c.id, c.movie_id, c.quantity, m.title, m.poster_filename, m.rental_price 
                   FROM cart c
                   JOIN movies m ON c.movie_id = m.id
                   WHERE c.user_id = @userId AND m.is_deleted = false
                   ORDER BY c.added_at ASC";  // ← добавлено
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add(new CartItem
                            {
                                Id = reader.GetInt32(0),
                                MovieId = reader.GetInt32(1),
                                Days = reader.GetInt32(2),
                                Title = reader.GetString(3),
                                PosterFileName = reader.IsDBNull(4) ? null : reader.GetString(4),
                                RentalPrice = reader.GetDecimal(5)
                            });
                        }
                    }
                }
            }
            return items;
        }

        public static void UpdateCartItemDays(int cartItemId, int days)
        {
            string sql = "UPDATE cart SET quantity = @days WHERE id = @id";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@days", days);
                    cmd.Parameters.AddWithValue("@id", cartItemId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void RemoveFromCart(int cartItemId)
        {
            string sql = "DELETE FROM cart WHERE id = @id";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", cartItemId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void ClearCart(int userId)
        {
            string sql = "DELETE FROM cart WHERE user_id = @userId";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ==================== ORDERS ====================

        public static int CreateOrder(int userId, string deliveryAddress, string fullName, string phone, string paymentMethod, string promoCode, decimal totalAmount, List<CartItem> items)
        {
            int maxDays = items.Count > 0 ? items.Max(i => i.Days) : 0;
            DateTime dueDate = DateTime.Now.AddDays(maxDays);

            string orderSql = @"INSERT INTO orders (user_id, rent_date, due_date, status, total_amount, delivery_address, customer_name, customer_phone, payment_method, promo_code)
                                VALUES (@userId, @rentDate, @dueDate, 'active', @totalAmount, @deliveryAddress, @customerName, @customerPhone, @paymentMethod, @promoCode)
                                RETURNING id";
            int orderId;
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(orderSql, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Parameters.AddWithValue("@rentDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@dueDate", dueDate);
                    cmd.Parameters.AddWithValue("@totalAmount", totalAmount);
                    cmd.Parameters.AddWithValue("@deliveryAddress", (object)deliveryAddress ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@customerName", (object)fullName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@customerPhone", (object)phone ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@paymentMethod", (object)paymentMethod ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@promoCode", string.IsNullOrEmpty(promoCode) ? DBNull.Value : (object)promoCode);
                    orderId = (int)cmd.ExecuteScalar();
                }

                string itemSql = @"INSERT INTO order_items (order_id, movie_id, rental_price, quantity)
                                   VALUES (@orderId, @movieId, @rentalPrice, @quantity)";
                foreach (var item in items)
                {
                    using (var cmd = new NpgsqlCommand(itemSql, conn))
                    {
                        cmd.Parameters.AddWithValue("@orderId", orderId);
                        cmd.Parameters.AddWithValue("@movieId", item.MovieId);
                        cmd.Parameters.AddWithValue("@rentalPrice", item.RentalPrice);
                        cmd.Parameters.AddWithValue("@quantity", item.Days);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            return orderId;
        }

        // ==================== FILTERS ====================

        public static List<string> GetDistinctGenres()
        {
            var genres = new List<string>();
            string sql = "SELECT DISTINCT genre FROM movies WHERE is_deleted = false AND genre IS NOT NULL AND genre != ''";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string val = reader.GetString(0);
                        var parts = val.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var p in parts)
                        {
                            string trimmed = p.Trim();
                            if (!genres.Contains(trimmed))
                                genres.Add(trimmed);
                        }
                    }
                }
            }
            genres.Sort();
            return genres;
        }

        public static List<string> GetDistinctMediaFormats()
        {
            var formats = new List<string>();
            string sql = "SELECT DISTINCT media_format FROM movies WHERE is_deleted = false AND media_format IS NOT NULL AND media_format != ''";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string val = reader.GetString(0);
                        var parts = val.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var p in parts)
                        {
                            string trimmed = p.Trim();
                            if (!formats.Contains(trimmed))
                                formats.Add(trimmed);
                        }
                    }
                }
            }
            formats.Sort();
            return formats;
        }

        public static List<string> GetDistinctAgeRatings()
        {
            var ratings = new List<string>();
            string sql = "SELECT DISTINCT age_rating FROM movies WHERE is_deleted = false AND age_rating IS NOT NULL AND age_rating != '' ORDER BY age_rating";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ratings.Add(reader.GetString(0));
                    }
                }
            }
            return ratings;
        }

        public static (int minYear, int maxYear) GetYearRange()
        {
            int minYear = DateTime.Now.Year;
            int maxYear = DateTime.Now.Year;
            string sql = "SELECT MIN(year), MAX(year) FROM movies WHERE is_deleted = false AND year IS NOT NULL";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        minYear = reader.IsDBNull(0) ? DateTime.Now.Year - 50 : reader.GetInt32(0);
                        maxYear = reader.IsDBNull(1) ? DateTime.Now.Year : reader.GetInt32(1);
                    }
                }
            }
            return (minYear, maxYear);
        }

        public static List<Movie> SearchMoviesWithFilters(FilterCriteria criteria)
        {
            var movies = new List<Movie>();
            var conditions = new List<string>();
            var parameters = new List<(string name, object value)>();

            string sql = @"SELECT id, title, genre, year, director, actors, duration, age_rating, media_format, language, 
                          description, poster_filename, total_copies, available_copies, rental_price, is_deleted 
                   FROM movies WHERE is_deleted = false";

            if (!string.IsNullOrWhiteSpace(criteria.Title))
            {
                conditions.Add("title ILIKE @title");
                parameters.Add(("@title", $"%{criteria.Title}%"));
            }

            if (criteria.YearFrom.HasValue && criteria.YearFrom.Value > 0)
            {
                conditions.Add("year >= @yearFrom");
                parameters.Add(("@yearFrom", criteria.YearFrom.Value));
            }

            if (criteria.YearTo.HasValue && criteria.YearTo.Value > 0)
            {
                conditions.Add("year <= @yearTo");
                parameters.Add(("@yearTo", criteria.YearTo.Value));
            }

            int genreIndex = 0;
            foreach (var genre in criteria.Genres)
            {
                if (!string.IsNullOrWhiteSpace(genre))
                {
                    string paramName = $"@genre{genreIndex}";
                    conditions.Add($"genre ILIKE {paramName}");
                    parameters.Add((paramName, $"%{genre}%"));
                    genreIndex++;
                }
            }

            int formatIndex = 0;
            foreach (var format in criteria.MediaFormats)
            {
                if (!string.IsNullOrWhiteSpace(format))
                {
                    string paramName = $"@format{formatIndex}";
                    conditions.Add($"media_format ILIKE {paramName}");
                    parameters.Add((paramName, $"%{format}%"));
                    formatIndex++;
                }
            }

            if (!string.IsNullOrWhiteSpace(criteria.Director))
            {
                conditions.Add("director ILIKE @director");
                parameters.Add(("@director", $"%{criteria.Director}%"));
            }

            if (!string.IsNullOrWhiteSpace(criteria.Actors))
            {
                conditions.Add("actors ILIKE @actors");
                parameters.Add(("@actors", $"%{criteria.Actors}%"));
            }

            if (!string.IsNullOrWhiteSpace(criteria.AgeRating))
            {
                conditions.Add("age_rating = @ageRating");
                parameters.Add(("@ageRating", criteria.AgeRating));
            }

            if (conditions.Count > 0)
                sql += " AND " + string.Join(" AND ", conditions);

            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    foreach (var param in parameters)
                        cmd.Parameters.AddWithValue(param.name, param.value);

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
                                Duration = reader.IsDBNull(6) ? 0 : reader.GetInt32(6),
                                AgeRating = reader.IsDBNull(7) ? null : reader.GetString(7),
                                MediaFormat = reader.IsDBNull(8) ? null : reader.GetString(8),
                                Language = reader.IsDBNull(9) ? null : reader.GetString(9),
                                Description = reader.IsDBNull(10) ? null : reader.GetString(10),
                                PosterFileName = reader.IsDBNull(11) ? null : reader.GetString(11),
                                TotalCopies = reader.GetInt32(12),
                                AvailableCopies = reader.GetInt32(13),
                                RentalPrice = reader.IsDBNull(14) ? 0 : reader.GetDecimal(14),
                                IsDeleted = reader.GetBoolean(15)
                            });
                        }
                    }
                }
            }
            return movies;
        }
        // ==================== USER PROFILE UPDATE ====================

        public static bool UpdateUserProfile(int userId, string fullName, string email, string phone, string deliveryAddress)
        {
            string sql = @"UPDATE users SET full_name = @fullName, email = @email, phone = @phone, delivery_address = @deliveryAddress
                   WHERE id = @userId";
            using (var conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@fullName", (object)fullName ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@email", (object)email ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@phone", (object)phone ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@deliveryAddress", (object)deliveryAddress ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        // ==================== ORDERS (USER ORDERS) ====================

        public static List<OrderInfo> GetUserOrders(int userId, bool onlyActive = true)
        {
            var orders = new List<OrderInfo>();
            string sql = @"SELECT o.id, o.rent_date, o.due_date, o.return_date, o.status, o.total_amount,
                          STRING_AGG(m.title, ', ') AS movies_list
                   FROM orders o
                   LEFT JOIN order_items oi ON o.id = oi.order_id
                   LEFT JOIN movies m ON oi.movie_id = m.id
                   WHERE o.user_id = @userId";
            if (onlyActive)
                sql += " AND o.status IN ('active', 'overdue')";
            else
                sql += " AND o.status = 'returned'";
            sql += " GROUP BY o.id ORDER BY o.rent_date DESC";

            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orders.Add(new OrderInfo
                            {
                                Id = reader.GetInt32(0),
                                RentDate = reader.GetDateTime(1),
                                DueDate = reader.GetDateTime(2),
                                ReturnDate = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                                Status = reader.GetString(4),
                                TotalAmount = reader.GetDecimal(5),
                                MoviesList = reader.GetString(6)
                            });
                        }
                    }
                }
            }
            return orders;
        }

        public static List<OrderItemDetail> GetOrderDetails(int orderId)
        {
            var items = new List<OrderItemDetail>();
            string sql = @"SELECT m.title, oi.rental_price, oi.quantity, m.poster_filename
                   FROM order_items oi
                   JOIN movies m ON oi.movie_id = m.id
                   WHERE oi.order_id = @orderId";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@orderId", orderId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add(new OrderItemDetail
                            {
                                Title = reader.GetString(0),
                                RentalPrice = reader.GetDecimal(1),
                                Days = reader.GetInt32(2),
                                PosterFileName = reader.IsDBNull(3) ? null : reader.GetString(3)
                            });
                        }
                    }
                }
            }
            return items;
        }
        // ==================== ORDER DETAILS WITH DELIVERY INFO ====================

        public static OrderDeliveryInfo GetOrderDeliveryInfo(int orderId)
        {
            string sql = "SELECT customer_name, customer_phone, delivery_address, payment_method, total_amount FROM orders WHERE id = @orderId";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@orderId", orderId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new OrderDeliveryInfo
                            {
                                CustomerName = reader.IsDBNull(0) ? null : reader.GetString(0),
                                CustomerPhone = reader.IsDBNull(1) ? null : reader.GetString(1),
                                DeliveryAddress = reader.IsDBNull(2) ? null : reader.GetString(2),
                                PaymentMethod = reader.IsDBNull(3) ? null : reader.GetString(3),
                                TotalAmount = reader.GetDecimal(4)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public static List<OrderItemDetail> GetOrderItems(int orderId)
        {
            var items = new List<OrderItemDetail>();
            string sql = @"SELECT m.title, oi.rental_price, oi.quantity, m.poster_filename
                   FROM order_items oi
                   JOIN movies m ON oi.movie_id = m.id
                   WHERE oi.order_id = @orderId";
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@orderId", orderId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add(new OrderItemDetail
                            {
                                Title = reader.GetString(0),
                                RentalPrice = reader.GetDecimal(1),
                                Days = reader.GetInt32(2),
                                PosterFileName = reader.IsDBNull(3) ? null : reader.GetString(3)
                            });
                        }
                    }
                }
            }
            return items;
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
        public int Duration { get; set; }
        public string AgeRating { get; set; }
        public string MediaFormat { get; set; }
        public string Language { get; set; }
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
        public string Description { get; set; }
        public int OrderIndex { get; set; }
        public bool IsActive { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DeliveryAddress { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsBlocked { get; set; }
    }

    public class CartItem
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string PosterFileName { get; set; }
        public decimal RentalPrice { get; set; }
        public int Days { get; set; }
        public decimal TotalPrice => RentalPrice * Days;
    }
    public class OrderInfo
    {
        public int Id { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public string MoviesList { get; set; }
    }

    public class OrderItemDetail
    {
        public string Title { get; set; }
        public decimal RentalPrice { get; set; }
        public int Days { get; set; }
        public string PosterFileName { get; set; }
        public decimal TotalPrice => RentalPrice * Days;
    }
    public class OrderDeliveryInfo
    {
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string DeliveryAddress { get; set; }
        public string PaymentMethod { get; set; }
        public decimal TotalAmount { get; set; }
    }
}