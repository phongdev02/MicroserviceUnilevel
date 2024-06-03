using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Models;
using UserService.Models.Dto;
using UserService.Service.IService;

namespace UserService.Controllers
{
    
    [Route("api/Area")]
    [ApiController]
    [Authorize]
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _khuvuc;
        private ResponseDto _responseDto;
        public AreaController(IAreaService khuvuc)
        {
            _khuvuc = khuvuc;
            _responseDto = new ResponseDto();
        }

        [HttpPost("AddAreaAsync")]
        public async Task<IActionResult> AddAreaAsync([FromBody] AreaDto model)
        {
            _responseDto = await _khuvuc.AddAreaAsync(model);

            if (_responseDto.IsSuccess == true)
            {
                return Ok(_responseDto);
            }
            else
            {
                return BadRequest(_responseDto.Message);
            }
        }

        [HttpDelete("DeleteAreaAsync/{code}")]
        public async Task<IActionResult> DeleteAreaAsync(string code)
        {
            _responseDto = await _khuvuc.DeleteAreaAsync(code);

            if (_responseDto.IsSuccess == true)
            {
                return Ok(_responseDto);
            }
            else
            {
                return BadRequest(_responseDto.Message);
            }
        }

        [HttpPut("EditAreaAsync")]
        public async Task<IActionResult> EditAreaAsync([FromBody] AreaDto model)
        {
            _responseDto = await _khuvuc.EditAreaAsync(model);

            if (_responseDto.IsSuccess == true)
            {
                return Ok(_responseDto);
            }
            else
            {
                return BadRequest(_responseDto.Message);
            }
        }

        [HttpGet("FindAreaAsync/{input}")]
        public async Task<IActionResult> FindAreaAsync(string input)
        {
            _responseDto = await _khuvuc.FindAreaAsync(input);

            if (_responseDto.IsSuccess == true)
            {
                return Ok(_responseDto);
            }
            else
            {
                return BadRequest(_responseDto.Message);
            }
        }

        [HttpGet("GetAreaAsync/{code}")]
        public async Task<IActionResult> GetAreaAsync(string code)
        {
            _responseDto = await _khuvuc.GetAreaAsync(code);

            if (_responseDto.IsSuccess == true)
            {
                return Ok(_responseDto);
            }
            else
            {
                return BadRequest(_responseDto.Message);
            }
        }

        [HttpGet("GetAreasAsync")]
        public async Task<IActionResult> GetAreasAsync()
        {
            _responseDto = await _khuvuc.GetAreasAsync();

            if (_responseDto.IsSuccess == true)
            {
                return Ok(_responseDto);
            }
            else
            {
                return BadRequest(_responseDto.Message);
            }
        }
    }
}
