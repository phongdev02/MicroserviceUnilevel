using BCrypt.Net;
using System.Security.Cryptography;

namespace UserService.Service.SetFunc
{
    public class PasswordManager
    {
        public PasswordManager()
        {
        }

        public string GenerateHashedPassword(string password)
        {
            // Generate salt (default cost is 10)
            string salt = BCrypt.Net.BCrypt.GenerateSalt();

            // Hash password with salt
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

            return hashedPassword;
        }

        public string GeneratePassword(int length)
        {
            // Tạo một mảng byte để lưu trữ các ký tự ngẫu nhiên
            byte[] buffer = new byte[length];

            // Sử dụng RandomNumberGenerator để tạo ra các byte ngẫu nhiên
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(buffer);
            }

            // Chuyển đổi các byte thành một chuỗi có thể đọc được bằng cách sử dụng bảng mã Base64
            return Convert.ToBase64String(buffer);
        }
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(password.Trim(), hashedPassword.Trim());
            }
            catch (SaltParseException ex)
            {
                // Log lỗi chi tiết và thông báo người dùng
                Console.WriteLine("Invalid salt version: " + ex.Message);
                return false;
            }
        }


    }
}
