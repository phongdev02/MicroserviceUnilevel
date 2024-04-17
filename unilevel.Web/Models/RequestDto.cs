using Microsoft.AspNetCore.Mvc;
using static unilevel.Web.Utility.SD;

namespace unilevel.Web.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AcceptToken { get; set; }
    }
}
