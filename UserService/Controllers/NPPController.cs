using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Models.Dto;
using UserService.Service.IService;

namespace UserService.Controllers
{
    [Route("api/NPP")]
    [ApiController]
    public class NPPController : ControllerBase
    {
        private readonly INPPService _npp;
        private ResponseDto _responseDto;
        public NPPController(INPPService iNPPService)
        {
            _npp = iNPPService;
            _responseDto = new ResponseDto();
        }
/*
        [HttpPost("createNPP")]
        public async Task<IActionResult> createNPP([FromBody] NhaPhanPhoiDto model)
        {
            _responseDto = await _npp.createNPP(model);

            if (_responseDto.IsSuccess == true)
            {
                return Ok(_responseDto);
            }
            else
            {
                return BadRequest(_responseDto.Message);
            }
        }

        [HttpPost("createNPPTemplate")]
        public async Task<IActionResult> createNPPTemplate(string code)
        {
            _responseDto = await _npp.createNPPTemplate(code);

            if (_responseDto.IsSuccess == true)
            {
                return Ok(_responseDto);
            }
            else
            {
                return BadRequest(_responseDto.Message);
            }
        }

        [HttpDelete("deleteNPP")]
        public async Task<IActionResult> deleteNPP(int id)
        {
            _responseDto = await _npp.deleteNPP(id);

            if (_responseDto.IsSuccess == true)
            {
                return Ok(_responseDto);
            }
            else
            {
                return BadRequest(_responseDto.Message);
            }
        }

        [HttpGet("findNPP")]
        public async Task<IActionResult> findNPP(int id)
        {
            _responseDto = await _npp.findNPP(id);

            if (_responseDto.IsSuccess == true)
            {
                return Ok(_responseDto);
            }
            else
            {
                return BadRequest(_responseDto.Message);
            }
        }

        [HttpGet("getListNPP")]
        public async Task<IActionResult> getListNPP()
        {
            _responseDto = await _npp.getListNPP();

            if (_responseDto.IsSuccess == true)
            {
                return Ok(_responseDto);
            }
            else
            {
                return BadRequest(_responseDto.Message);
            }
        }

        [HttpGet("getListNPPWithCodeArea")]
        public async Task<IActionResult> getListNPPWithCodeArea(string code)
        {
            _responseDto = await _npp.getListNPPWithCodeArea(code);

            if (_responseDto.IsSuccess == true)
            {
                return Ok(_responseDto);
            }
            else
            {
                return BadRequest(_responseDto.Message);
            }
        }

        [HttpGet("getNPPTemplate")]
        public async Task<IActionResult> getNPPTemplate(string code)
        {
            _responseDto = await _npp.getNPPTemplate(code);

            if (_responseDto.IsSuccess == true)
            {
                return Ok(_responseDto);
            }
            else
            {
                return BadRequest(_responseDto.Message);
            }
        }

        [HttpPut("updateNPP")]
        public async Task<IActionResult> updateNPP([FromBody] NhaPhanPhoiDto model)
        {
            _responseDto = await _npp.updateNPP(model);

            if (_responseDto.IsSuccess == true)
            {
                return Ok(_responseDto);
            }
            else
            {
                return BadRequest(_responseDto.Message);
            }
        }*/
    }
}
