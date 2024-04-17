using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using unilevel.Web.Models;
using unilevel.Web.Service.IService;

namespace unilevel.Web.Controllers
{
    [Route("api/Area")]
    [ApiController]
    public class AreaController : ControllerBase
    {

        private readonly IAreaService _areaService;
        private ResponseDto _responseDto;
        public AreaController(IAreaService khuvuc)
        {
            _areaService = khuvuc;
            _responseDto = new ResponseDto();
        }

        [HttpPost("AddArea")]
        public async Task<IActionResult> AddArea([FromBody] KhuvucDto model)
        {
            _responseDto = await _areaService.AddArea(model);

            if (_responseDto.IsSuccess == true)
            {
                return Ok(_responseDto);
            }
            else
            {
                return BadRequest(_responseDto.Message);
            }
        }

        [HttpDelete("DeleteArea")]
        public async Task<IActionResult> DeleteArea(string code)
        {
            _responseDto = await _areaService.DeleteArea(code);

            if (_responseDto.IsSuccess == true)
            {
                return Ok(_responseDto);
            }
            else
            {
                return BadRequest(_responseDto.Message);
            }
        }

        [HttpPut("EditArea")]
        public async Task<IActionResult> EditArea([FromBody] KhuvucDto model)
        {
            _responseDto = await _areaService.EditArea(model);

            if (_responseDto.IsSuccess == true)
            {
                return Ok(_responseDto);
            }
            else
            {
                return BadRequest(_responseDto.Message);
            }
        }

        [HttpGet("FindArea")]
        public async Task<IActionResult> FindArea(string input)
        {
            _responseDto = await _areaService.FindArea(input);

            if (_responseDto.IsSuccess == true)
            {
                return Ok(_responseDto);
            }
            else
            {
                return BadRequest(_responseDto.Message);
            }
        }

        [HttpGet("GetArea")]
        public async Task<IActionResult> GetArea(string code)
        {
            _responseDto = await _areaService.GetArea(code);

            if (_responseDto.IsSuccess == true)
            {
                return Ok(_responseDto);
            }
            else
            {
                return BadRequest(_responseDto.Message);
            }
        }

        [HttpGet("GetAreas")]
        public async Task<IActionResult> GetAreas()
        {
            _responseDto = await _areaService.GetAreas();

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
