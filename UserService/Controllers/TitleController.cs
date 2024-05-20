using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Models.Dto;
using UserService.Service.IService;

namespace UserService.Controllers
{
    [Route("api/Title")]
    [ApiController]
    public class TitleController : ControllerBase
    {
        private ITitleService _titleService;
        private ResponseDto _responseDto;
        public TitleController(ITitleService titleService) {
            _titleService = titleService;
            _responseDto = new ResponseDto();
        }

        [HttpPost]
        public async Task<ResponseDto?> CreateTitle([FromBody] TitleDto model)
        {
            try
            {
                var _responseDto = await _titleService.CreateTitle(model);

                return _responseDto;
            }
            catch (Exception ex)
            {

                return _responseDto = new() { Message = ex.Message, IsSuccess = false};
            }
        }

        [HttpPut] 
        public async Task<ResponseDto?> EditTitle([FromBody] TitleDto model)
        {
            try
            {
                var _responseDto = await _titleService.EditTitle(model);

                return _responseDto;
            }
            catch (Exception ex)
            {

                return _responseDto = new() { Message = ex.Message, IsSuccess = false };
            }
        }

        [HttpDelete]
        public async Task<ResponseDto?> DeleteTitle(int titleID)
        {
            try
            {
                var _responseDto = await _titleService.DeleteTitle(titleID);

                return _responseDto;
            }
            catch (Exception ex)
            {

                return _responseDto = new() { Message = ex.Message, IsSuccess = false };
            }
        }
    }
}
