using Microsoft.AspNetCore.Mvc;
using UserService.Models.Dto;
using UserService.Service;
using UserService.Service.IService;

namespace UserService.Controllers
{
    
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private ResponseDto _responseDto;
        private IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _responseDto = new ResponseDto();
            _accountService = accountService;
        }

        [HttpPut("StatusAccount/{int:id}")]
        public async Task<IActionResult> StatusAccount(int accid)
        {
            var responsedto = await _accountService.StatusAccountAsync(accid);

            if (responsedto == null || responsedto.IsSuccess == false)
            {
                return BadRequest(responsedto);
            }

            return Ok(responsedto);
        }

        [HttpPost("CreateAccount")]
        public async Task<IActionResult> CreateAccount([FromBody] AccountDtoNoID model)
        {
            var responsedto = await _accountService.CreateAccountAsync(model);

            if (responsedto == null || responsedto.IsSuccess == false)
            {
                return BadRequest(responsedto);
            }

            return Ok(responsedto);
        }

        [HttpPut("EditAccount")]
        public async Task<IActionResult> EditAccount([FromBody] AccountDtoNoID model)
        {
            var responsedto = await _accountService.EditAccountAsync(model);

            if (responsedto == null || responsedto.IsSuccess == false)
            {
                return BadRequest(responsedto);
            }

            return Ok(responsedto);
        }

        [HttpGet("AccountSearch/{search}")]
        public async Task<IActionResult> AccountSearch(String search)
        {
            var responsedto = await _accountService.AccountSearchAsync(search);

            if (responsedto == null || responsedto.IsSuccess == false)
            {
                return BadRequest(responsedto);
            }

            return Ok(responsedto);
        }

        [HttpGet("GetLsAccount")]
        public async Task<IActionResult> GetLsAccount()
        {
            var responsedto = await _accountService.GetLsAccountAsync();

            if (responsedto == null || responsedto.IsSuccess == false)
            {
                return BadRequest(responsedto);
            }

            return Ok(responsedto);
        }

        [HttpGet("GetAccount/{int:accid}")]
        public async Task<IActionResult> GetAccountAsync(int accid)
        {
            var responsedto = await _accountService.GetAccountAsync(accid);

            if (responsedto == null || responsedto.IsSuccess == false)
            {
                return BadRequest(responsedto);
            }

            return Ok(responsedto);
        }

        [HttpDelete("DeleteAccount/{int:accid}")]
        public async Task<IActionResult> DeleteAccount(int accid)
        {
            var responsedto = await _accountService.DeleteAccountAsync(accid);

            if (responsedto == null || responsedto.IsSuccess == false)
            {
                return BadRequest(responsedto);
            }

            return Ok(responsedto);
        }

    }
}
