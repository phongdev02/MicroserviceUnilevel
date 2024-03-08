using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using unilevel.Web.Service.IService;
using unilevel.Web.Utility;

namespace unilevel.Web.Service
{
    public class TokenProvider : ITokenProvider
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public TokenProvider(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string? getToken()
        {
            string? token = null;

            bool? hasToken = _contextAccessor.HttpContext?.Request.Cookies?.TryGetValue(SD.TokenCookie, out token);

            return hasToken is true ? token : null;
        }

        public void clearToken()
        {
            _contextAccessor.HttpContext?.Response.Cookies.Delete(SD.TokenCookie);
        }

        public void setToken(string token)
        {
            _contextAccessor.HttpContext?.Response.Cookies.Append(SD.TokenCookie, token);

        }
    }
}
