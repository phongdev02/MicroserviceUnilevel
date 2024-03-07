using AutoMapper;
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
                _responseDto.Result = _mapper.Map<IEnumerable<NhanvienDto>>(nhanviens);
            }
            catch(Exception ex) { 
                _responseDto.IsSuccess = false;
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
                _responseDto.Result = _mapper.Map<NhanvienDto>(nhanvien);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpGet]
        [Route("GetByGmail/{gmail}")]
        public ResponseDto LoginAccount(string gmail, string pass)
        {
            try
            {
                var nhanvien = _context.Nhanviens.FirstOrDefault(nv => nv.GmailNv.ToLower() == gmail.ToLower());
                _responseDto.Result = _mapper.Map<NhanvienDto>(nhanvien);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
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


                // Thêm nhân viên mới vào cơ sở dữ liệu
                _context.Nhanviens.Add(obj);
                _context.SaveChanges();

                _responseDto.Result = _mapper.Map<NhanvienDto>(obj);

                return _responseDto;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpPut]
        public ResponseDto PutNhanvien([FromBody] NhanvienDto nhanvienDto)
        {
            try
            {
                // Tạo một đối tượng nhân viên mới từ dữ liệu nhận được
                var obj = _mapper.Map<Nhanvien>(nhanvienDto);

                // Thêm nhân viên mới vào cơ sở dữ liệu
                _context.Nhanviens.Update(obj);
                _context.SaveChanges();

                _responseDto.Result = _mapper.Map<NhanvienDto>(obj);

                return _responseDto;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public ResponseDto DeleteNhanvien(int id) 
        {
            try
            {
                var obj = _context.Nhanviens.FirstOrDefault(nv => nv.NvId == id);

                // Thêm nhân viên mới vào cơ sở dữ liệu
                _context.Nhanviens.Remove(obj);
                _context.SaveChanges();

                _responseDto.Result = _mapper.Map<NhanvienDto>(obj);

                return _responseDto;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }
        
    }
}
