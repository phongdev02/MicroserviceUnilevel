using BCrypt.Net;
using System.Security.Cryptography;

namespace TaiKhoan.service
{
    public class PasswordManager
    {
        public PasswordManager() { 
        }

        public string GenerateHashedPassword(string password)
        {
            // Generate salt (default cost is 10)
            string salt = BCrypt.Net.BCrypt.GenerateSalt();

            // Hash password with salt
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

            return hashedPassword;
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            // Verify the password
            bool passwordMatch = BCrypt.Net.BCrypt.Verify(password, hashedPassword);

            return passwordMatch;
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

    }
}
