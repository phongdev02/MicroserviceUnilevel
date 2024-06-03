using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using unilevel.Web.Models;
using unilevel.Web.Service.IAPI;
using unilevel.Web.Service.IService;
using unilevel.Web.Utility;

namespace unilevel.Web.Service.API
{
    public class AccountAPIService : IAccountAPIService
    {
        private readonly IBaseService _baseService;
        private readonly ITokenProvider _tokenProvider;
        private readonly IUrlHelper _urlHelper;
        public AccountAPIService(IBaseService baseService, ITokenProvider tokenProvider, IUrlHelper urlHelper)
        {
            _baseService = baseService;
            _tokenProvider = tokenProvider;
            _urlHelper = urlHelper;
        }

        public async Task<ResponseDto?> AccountSearchAsync(string search)
        {
            var responseDto = await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.UserApiBase + "/api/Account/AccountSearchAsync/" + search
            }, withBearer: false);

            if (responseDto != null && responseDto.IsSuccess == true) {
                var result = JsonConvert.DeserializeObject<List<AccountDto>>(Convert.ToString(responseDto.Result));
                responseDto.Result = result;
            }

            return responseDto;
        }

        public async Task<ResponseDto?> CreateAccountAsync([FromBody] AccountDtoNoID model)
        {
            var responseDto = await _baseService.SenAsync(new RequestDto() 
            { 
                ApiType = SD.ApiType.POST, 
                Data = model, 
                Url = SD.UserApiBase + "/api/Account/CreateAccountAsync"
            }, withBearer: false);

            if (responseDto != null && responseDto.IsSuccess == true)
            {
                var result = JsonConvert.DeserializeObject<AccountDto>(Convert.ToString(responseDto.Result));
                responseDto.Result = result;
            }

            return responseDto;
        }

        public async Task<ResponseDto?> LogginAccountAsync([FromBody]LoginDto model)
        {
            var responseDto = await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = model,
                Url = SD.UserApiBase + "/api/Account/LogginAccountAsync"
            }, withBearer: false);

            if(responseDto != null && responseDto.IsSuccess == true)
            {
                //_tokenProvider.setToken(Convert.ToString(responseDto.Result));
            }

            return responseDto;
        }

        public async Task<ResponseDto?> ReadTokenAsync(string token)
        {
            var responseDto = await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.UserApiBase + "/api/Account/ReadTokenAsync/" + token
            }, withBearer: false);

            if (responseDto != null && responseDto.IsSuccess == true)
            {
                var result = JsonConvert.DeserializeObject<AccountDto>(Convert.ToString(responseDto.Result));
                responseDto.Result = result;
            }

            return responseDto;
        }

        public async Task<ResponseDto?> SendEmailAsync([FromBody]MailContextDto mailContextDto, HttpRequest request)
        {
            string confirmationLink = "";


            //test get link host
            var baseUrl = $"{request.Scheme}://{request.Host}";

            var actionUrl = _urlHelper.Action("SetCookie", "Account", new { token = mailContextDto.token });


            mailContextDto.confirmationLink = baseUrl + "/api/Account/SetCookie/" + mailContextDto.token;

            var responseDto = await _baseService.SenAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = mailContextDto,
                Url = SD.UserApiBase + "/api/Account/SendEmailAsync/"
            }, withBearer: false);

            if (responseDto != null && responseDto.IsSuccess == true)
            {
                var result = JsonConvert.DeserializeObject<AccountDto>(Convert.ToString(responseDto.Result));
                responseDto.Result = result;
            }

            return responseDto;
        }
    }
}
