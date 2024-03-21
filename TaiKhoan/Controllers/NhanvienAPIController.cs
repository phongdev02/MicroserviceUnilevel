using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Cryptography;
using TaiKhoan.Context;
using TaiKhoan.Models;
using TaiKhoan.Models.Dto;
using TaiKhoan.service;
using TaiKhoan.service.IService;

namespace TaiKhoan.Controllers
{
    [Route("api/NhanvienAPI")]
    [ApiController]
    //[Authorize]
    public class NhanvienAPIController : ControllerBase
    {
        private readonly AppDBContext _context;
        private ResponseDto _responseDto;
        private readonly IMapper _mapper;
        public readonly ITaikhoanService _taikhoanService;

        public NhanvienAPIController(AppDBContext context, IMapper mapper, ITaikhoanService taikhoanService)
        {
            _context = context;
            _taikhoanService = taikhoanService;
            this._responseDto = new ResponseDto();
            _mapper = mapper;
        }

        // GET: Nhanvien list
        [HttpGet]
        public async Task<IActionResult> GetListNV()
        {
            var models = await _taikhoanService.GetListNhanVat();
            if (models.IsSuccess == false)
            {
                return BadRequest(models.Message);
            }

            return Ok(models);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateNhanvien([FromBody] NhanvienDtoNoID nhanvienDto)
        {
            try
            {
                ResponseDto model = await _taikhoanService.CreateAccount(nhanvienDto);

                if (model.IsSuccess == true)
                {
                    return BadRequest(model.Message);
;               }

                return Ok(model);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return Ok(_responseDto);
        }

        
    }
}
