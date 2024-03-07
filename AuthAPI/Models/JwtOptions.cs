namespace AuthAPI.Models
{
    public class JwtOptions
    {
        public string Secret { get; set; } = string.Empty;
        public string Issuer { set; get; } = string.Empty;
        public string Audience {  set; get; } = string.Empty;
    }
}
