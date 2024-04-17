namespace unilevel.Web.Utility
{
    public class SD
    {
        public static string UserApiBase { get; set; }
        public static string AuthAPIBase { get; set; }
        public static string TokenCookie { get; set; } = "JwtToken";
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }

    }
}
