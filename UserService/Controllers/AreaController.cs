using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Models;
using UserService.Models.Dto;
using UserService.Service.IService;

namespace UserService.Controllers
{
    [Route("api/Area")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _khuvuc;
        private ResponseDto _responseDto;
        public AreaController(IAreaService khuvuc)
        {
            _khuvuc = khuvuc;
            _responseDto = new ResponseDto();
        }

        //[HttpPost("AddArea")]
        //public async Task<IActionResult> AddArea([FromBody] AreaDto model)
        //{
        //    _responseDto = await _khuvuc.AddArea(model);

        //    if (_responseDto.IsSuccess == true)
        //    {
        //        return Ok(_responseDto);
        //    }
        //    else
        //    {
        //        return BadRequest(_responseDto.Message);
        //    }
        //}

        //[HttpDelete("DeleteArea")]
        //public async Task<IActionResult> DeleteArea(string code)
        //{
        //    _responseDto = await _khuvuc.DeleteArea(code);

        //    if (_responseDto.IsSuccess == true)
        //    {
        //        return Ok(_responseDto);
        //    }
        //    else
        //    {
        //        return BadRequest(_responseDto.Message);
        //    }
        //}

        //[HttpPut("EditArea")]
        //public async Task<IActionResult> EditArea([FromBody] AreaDto model)
        //{
        //    _responseDto = await _khuvuc.EditArea(model);

        //    if (_responseDto.IsSuccess == true)
        //    {
        //        return Ok(_responseDto);
        //    }
        //    else
        //    {
        //        return BadRequest(_responseDto.Message);
        //    }
        //}

        //[HttpGet("FindArea")]
        //public async Task<IActionResult> FindArea(string input)
        //{
        //    _responseDto = await _khuvuc.FindArea(input);

        //    if (_responseDto.IsSuccess == true)
        //    {
        //        return Ok(_responseDto);
        //    }
        //    else
        //    {
        //        return BadRequest(_responseDto.Message);
        //    }
        //}

        //[HttpGet("GetArea")]
        //public async Task<IActionResult> GetArea(string code)
        //{
        //    _responseDto = await _khuvuc.GetArea(code);

        //    if (_responseDto.IsSuccess == true)
        //    {
        //        return Ok(_responseDto);
        //    }
        //    else
        //    {
        //        return BadRequest(_responseDto.Message);
        //    }
        //}

        //[HttpGet("GetAreas")]
        //public async Task<IActionResult> GetAreas()
        //{
        //    _responseDto = await _khuvuc.GetAreas();

        //    if (_responseDto.IsSuccess == true)
        //    {
        //        return Ok(_responseDto);
        //    }
        //    else
        //    {
        //        return BadRequest(_responseDto.Message);
        //    }
        //}
    }
}
