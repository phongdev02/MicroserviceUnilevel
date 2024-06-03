using unilevel.Web.Service.IService;
using unilevel.Web.Models;
using unilevel.Web.Utility;
using Microsoft.AspNetCore.Mvc;
using unilevel.Web.Service.IAPI;
using Azure;
using Newtonsoft.Json;
using System.Net.WebSockets;

namespace unilevel.Web.Service
{
    public class AccountService : IAccountService
    {
        private readonly IBaseService _baseService;
        private readonly IAccountAPIService _accountAPI;
        private ResponseDto _responseDto;
        public AccountService(IBaseService baseService, IAccountAPIService accountAPIService)
        {
            _baseService = baseService;
            _accountAPI = accountAPIService;
            _responseDto = new ResponseDto();
        }

        public async Task<ResponseDto?> AccountSearchAsync(string search)
        {
            try
            {
                var responsedto = await _accountAPI.AccountSearchAsync(search);
                
                return responsedto;
            }
            catch (Exception ex)
            {
                return _responseDto = new()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseDto?> CreateAccountAsync([FromBody] AccountDtoNoID model)
        {
            try
            {
                var responsedto = await _accountAPI.CreateAccountAsync(model);

                return responsedto;
            }
            catch (Exception ex)
            {
                return _responseDto = new()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseDto?> LogginAccountAsync([FromBody]LoginDto model)
        {
            try
            {
                var responsedto = await _accountAPI.LogginAccountAsync(model);


                return responsedto;
            }
            catch (Exception ex)
            {
                return _responseDto = new()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseDto?> ReadTokenAsync(string token)
        {
            try
            {
                var responsedto = await _accountAPI.ReadTokenAsync(token);

                return responsedto;
            }
            catch (Exception ex)
            {
                return _responseDto = new()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }
        }
    }
}
