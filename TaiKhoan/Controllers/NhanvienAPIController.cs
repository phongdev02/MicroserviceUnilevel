using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Cryptography;
using TaiKhoan.Context;
using TaiKhoan.Models;
using TaiKhoan.Models.Dto;

namespace TaiKhoan.Controllers
{
    [Route("api/NhanvienAPI")]
    [ApiController]
    public class NhanvienAPIController : ControllerBase
    {
        private readonly AppDBContext _context;
        private ResponseDto _responseDto;
        private IMapper _mapper;

        public NhanvienAPIController(AppDBContext context, IMapper mapper)
        {
            _context = context;
            this._responseDto = new ResponseDto();
            _mapper = mapper;
        }

        // GET: Nhanvien list
        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Nhanvien> nhanviens = _context.Nhanviens.ToList();
                _responseDto.Resurt = _mapper.Map<IEnumerable<NhanvienDto>>(nhanviens);
            }
            catch(Exception ex) { 
                _responseDto.Success = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }
        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto GetNhanvien(int id)
        {
            try
            {
                var nhanvien = _context.Nhanviens.FirstOrDefault(nv=>nv.NvId == id);
                _responseDto.Resurt = _mapper.Map<NhanvienDto>(nhanvien);
            }
            catch (Exception ex)
            {
                _responseDto.Success = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpGet]
        [Route("GetByGmail/{gmail}")]
        public ResponseDto GetByGmail(string gmail)
        {
            try
            {
                var nhanvien = _context.Nhanviens.FirstOrDefault(nv => nv.GmailNv.ToLower() == gmail.ToLower());
                _responseDto.Resurt = _mapper.Map<NhanvienDto>(nhanvien);
            }
            catch (Exception ex)
            {
                _responseDto.Success = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpPost]
        public ResponseDto CreateNhanvien([FromBody] NhanvienDtoNoID nhanvienDto)
        {
            try
            {
                // Tạo một đối tượng nhân viên mới từ dữ liệu nhận được
                var obj = _mapper.Map<Nhanvien>(nhanvienDto);

                var pass = GeneratePassword(12);
                
                var hasher = new PasswordHasher<string>();
                var hashedPassword = hasher.HashPassword(null, pass);

                obj.MatkhauNv = hashedPassword;

                // Thêm nhân viên mới vào cơ sở dữ liệu
                _context.Nhanviens.Add(obj);
                _context.SaveChanges();

                _responseDto.Resurt = _mapper.Map<NhanvienDto>(obj);

                return _responseDto;
            }
            catch (Exception ex)
            {
                _responseDto.Success = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        private static string GeneratePassword(int length)
        {
            // Tạo một mảng byte để lưu trữ các ký tự ngẫu nhiên
            byte[] buffer = new byte[length];

            // Sử dụng RandomNumberGenerator để tạo ra các byte ngẫu nhiên
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(buffer);
            }

            // Chuyển đổi các byte thành một chuỗi có thể đọc được bằng cách sử dụng bảng mã Base64
            return Convert.ToBase64String(buffer);
        }
    }
}
