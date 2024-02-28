using Microsoft.AspNetCore.Mvc;
using unilevel.Web.Service;
using unilevel.Web.Service.IService;
using unilevel.Web.Models;
using TaiKhoan.Models.Dto;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace unilevel.Web.Controllers
{
    [Route("api/Nhanvien")]
    [ApiController]
    public class NhanvienController : ControllerBase
    {
        public readonly INhanvienService _nhanvienSv;


        public NhanvienController(INhanvienService nhanvienSv)
        {
            _nhanvienSv = nhanvienSv;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<NhanvienDto> lst = new();

            ResponseDto? response = await _nhanvienSv.GetNhanvienAsync();

            if (response != null && response.IsSuccess == true)
            {
                lst = JsonConvert.DeserializeObject<List<NhanvienDto>>(Convert.ToString(response.Result));
            }
            return Ok(lst);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetID(int id)
        {
            NhanvienDto lst = new();

            ResponseDto? response = await _nhanvienSv.GetNhanvienByIDAsync(id);

            if (response != null && response.IsSuccess == true)
            {
                lst = JsonConvert.DeserializeObject<NhanvienDto>(Convert.ToString(response.Result));
            }
            return Ok(lst);
        }
        [HttpPost]
        public async Task<IActionResult> PostID([FromBody] NhanvienDto nhanvienDto)
        {
            try
            {
                NhanvienDto lst = new();

                ResponseDto? response = await _nhanvienSv.CreateNhanvienAsync(nhanvienDto);

                if (response != null && response.IsSuccess == true)
                {
                    lst = JsonConvert.DeserializeObject<NhanvienDto>(Convert.ToString(response.Result));
                }


                return Ok(lst);
            }
            catch (Exception ex)
            {
                ResponseDto response = new ResponseDto()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
                return Ok(response);
            }
        }
    }
}
