using AutoMapper;
using FileRetention.Context;
using FileRetention.Models;
using FileRetention.Models.Dto;
using FileRetention.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;

namespace FileRetention.Controllers
{
    [Route("api/Retention")]
    [ApiController]
    public class RetentionController : ControllerBase
    {
        private readonly AppDBContext _db;
        private ResponseDto _responseDto;
        private IFileRetenService _fileRetenService;
        private readonly IMapper _mapper;

        public RetentionController(AppDBContext appDBContext, IFileRetenService fileRetenService, IMapper mapping)
        {
            _db = appDBContext;
            _responseDto = new ResponseDto();
            _fileRetenService = fileRetenService;
            _mapper = mapping;
        }
        [HttpGet]
        public async Task<IActionResult> GetListFile()
        {
            try
            {
                var _responseDto = await _fileRetenService.GetFileAsync();
                if (_responseDto.IsSuccess == true)
                {
                    var lsTep = (List<Tep>)_responseDto.Result;

                    var displayLsTep = lsTep.Select(item => new
                    {
                        item.TepId,
                        item.TenTep,
                        item.KieuTep,
                        item.NgayTao
                    });

                    _responseDto.Result = displayLsTep;
                    _responseDto.IsSuccess = true;
                    _responseDto.Message = "List Tep on DB";


                    return Ok(_responseDto);
                }
                else
                {
                    _responseDto.IsSuccess = false;
                    _responseDto.Message = "Lỗi file";
                    return BadRequest(_responseDto);
                }
                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddFile(string file)
        {
            var absolute = Path.GetFullPath(file.ToString().Trim());

            if (absolute == file)
            {
                _responseDto = await _fileRetenService.AddFileAsync(absolute);
            }
            else
            {
                return BadRequest(file);
            }

            try
            {
                if (_responseDto.IsSuccess == true)
                {
                    Tep itemTep = (Tep)_responseDto.Result;

                    var obj2 = _mapper.Map<TepDto>(itemTep);

                    _responseDto.Result = obj2;
                    _responseDto.IsSuccess = true;
                    _responseDto.Message = "List Tep on DB";


                    return Ok(_responseDto);
                }
                else
                {
                    return BadRequest(_responseDto.Message);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }

            return Ok(_responseDto);
        }
    }
}
