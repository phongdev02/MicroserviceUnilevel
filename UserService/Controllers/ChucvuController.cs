using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Context;
using UserService.Models.Dto;
using UserService.Service.IService;

namespace UserService.Controllers
{
    [Route("api/chuvu")]
    [ApiController]
    public class ChucvuController : ControllerBase
    {
        private readonly ResponseDto _responseDto;
        private readonly AppDBContext _context;
        private readonly IChucvuService _chucvuService;
        public ChucvuController(AppDBContext appDBContext, IChucvuService chucvuService)
        {
            _responseDto = new ResponseDto();
            _context = appDBContext;
            _chucvuService = chucvuService;
        }

        [HttpGet]
        public async Task<IActionResult> getAllChucvu()
        {
            var _responseDto = await _chucvuService.getAllChucvu();

            if (_responseDto != null && _responseDto.IsSuccess == true)
            {
                return Ok(_responseDto);
            }
            else
            {
                return BadRequest(_responseDto.Message);
            }
        }

        [HttpPost("createChucvu")]
        public async Task<IActionResult> CreateChucvuAsync([FromBody] ChucvuDto model)
        {
            try
            {
                var _responseDto = await _chucvuService.CreateChucvuAsync(model);
                if (_responseDto != null && _responseDto.IsSuccess == true)
                {
                    return Ok(_responseDto);
                }
                else
                {
                    return BadRequest(_responseDto.Message);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpPost("grantPermission/")]
        public async Task<IActionResult> grantPermission(int idChucvu, List<QuyenTruyCapDto> lsQuyentruycap)
        {
            try
            {
                var _responseDto = await _chucvuService.grantPermission(idChucvu, lsQuyentruycap);
                if (_responseDto != null && _responseDto.IsSuccess == true)
                {
                    return Ok(_responseDto);
                }
                else
                {
                    return BadRequest(_responseDto.Message);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpPost("grantAllPermission/{id:int}")]
        public async Task<IActionResult> grantAllPermission(int id)
        {
            try
            {
                var _responseDto = await _chucvuService.grantAllPermission(id);
                if (_responseDto != null && _responseDto.IsSuccess == true)
                {
                    return Ok(_responseDto);
                }
                else
                {
                    return BadRequest(_responseDto.Message);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
