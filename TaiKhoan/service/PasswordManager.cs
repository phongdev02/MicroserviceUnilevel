using BCrypt.Net;

namespace TaiKhoan.service
{
    public class PasswordManager
    {
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
    }
}
