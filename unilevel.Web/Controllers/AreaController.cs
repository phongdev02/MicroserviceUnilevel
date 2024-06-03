using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using unilevel.Web.Models;
using unilevel.Web.Service.IAPI;

namespace unilevel.Web.Controllers
{
    [Route("api/Area")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IAreaApiService _areaApi;
        private ResponseDto _responseDto;
        public AreaController(IAreaApiService areaApi)
        {
            _areaApi = areaApi;
            _responseDto = new ResponseDto();
        }

        [HttpPost("AddAreaAsync")]
        public async Task<IActionResult> AddAreaAsync([FromBody] AreaDto model)
        {
            _responseDto = await _areaApi.AddAreaAsync(model);

            if (_responseDto.IsSuccess == true)
            {
                return Ok(_responseDto);
            }
            else
            {
                return BadRequest(_responseDto.Message);
            }
        }

        [HttpDelete("DeleteAreaAsync")]
        public async Task<IActionResult> DeleteAreaAsync(string code)
        {
            _responseDto = await _areaApi.DeleteAreaAsync(code);

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
            _responseDto = await _areaApi.EditAreaAsync(model);

            if (_responseDto.IsSuccess == true)
            {
                return Ok(_responseDto);
            }
            else
            {
                return BadRequest(_responseDto.Message);
            }
        }

        [HttpGet("FindAreaAsync")]
        public async Task<IActionResult> FindAreaAsync(string input)
        {
            _responseDto = await _areaApi.FindAreaAsync(input);

            if (_responseDto.IsSuccess == true)
            {
                return Ok(_responseDto);
            }
            else
            {
                return BadRequest(_responseDto.Message);
            }
        }

        [HttpGet("GetAreaAsync")]
        public async Task<IActionResult> GetAreaAsync(string code)
        {
            _responseDto = await _areaApi.GetAreaAsync(code);

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
            _responseDto = await _areaApi.GetAreasAsync();

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
