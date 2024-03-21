using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;
using TaiKhoan.Context;
using TaiKhoan.Models;
using TaiKhoan.Models.Dto;
using TaiKhoan.service.IService;

namespace TaiKhoan.service
{
    public class ChucvuService : IChucvuService
    {
        private ResponseDto _responseDto;
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;
        public ChucvuService(AppDBContext appDBContext, IMapper mapper) { 
            _responseDto = new ResponseDto();
            _context = appDBContext;
            _mapper = mapper;
        }

        public async Task<ResponseDto?> CreateChucvuAsync(ChucvuDto model)
        {
            try
            {
                var chucvu = await _context.chucVus.FirstOrDefaultAsync(cv => cv.TenCv.Contains(model.TenCv));

                if(chucvu != null)
                {
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = "The position already exists in the database. ",
                        Result = null
                    };
                }

                var result = _mapper.Map<ChucVu>(model);
                result.NgayTao = DateTime.Now;

                _context.chucVus.Add(result);
                _context.SaveChanges();

                return _responseDto = new()
                {
                    IsSuccess = true,
                    Message = "create chucvu success",
                    Result = result
                };
            }
            catch (Exception ex)
            {
                return _responseDto = new()
                {
                    IsSuccess = false,
                    Message = "Error: " + ex.ToString(),
                    Result = null
                };
            }
        }

        public async Task<ResponseDto?> grantPermission(int idChucvu, List<QuyenTruyCapDto> lsQuyentruycap)
        {
            try
            {
                //check position
                var chucvu = await _context.chucVus.FirstOrDefaultAsync(cv => cv.ChucvuId == idChucvu);

                if (chucvu == null) return _responseDto = new() {IsSuccess = false,  Message = "position do not exist" };
                //check roles

                var lsRole = await _context.quyenTruyCaps.ToListAsync();
                List<CapQuyen> lsRoleOfPosition = new List<CapQuyen>();
                foreach (var role in lsQuyentruycap)
                {
                    var check = lsRole.FirstOrDefault(lr => lr.QuyenTruycapId == role.QuyenTruycapId);
                    if (check == null)
                        return _responseDto = new() { IsSuccess = false, Message = "Role do not exist, please check and try again." };
                    lsRoleOfPosition.Add(new CapQuyen() { ChucvuId = idChucvu , QuyenTruycapId = role.QuyenTruycapId});
                }

                _context.capQuyens.AddRange(lsRoleOfPosition);
                _context.SaveChanges();

                return _responseDto = new()
                {
                    IsSuccess = true,
                    Message = "add role succes",
                    Result = lsQuyentruycap
                };
            }
            catch (Exception ex)
            {
                return _responseDto = new()
                {
                    IsSuccess = false,
                    Message = "Error: " + ex.ToString(),
                    Result = null
                };
            }
        }

        public async Task<ResponseDto?> grantAllPermission(int id)
        {
            try
            {
                //check position
                var chucvu = await _context.chucVus.FirstOrDefaultAsync(cv => cv.ChucvuId == id);

                if (chucvu == null) return _responseDto = new() { IsSuccess = false, Message = "position do not exist" };
                //check roles

                var lsRole = await _context.quyenTruyCaps.ToListAsync();
                List<CapQuyen> lsRoleOfPosition = new List<CapQuyen>();
                foreach (var role in lsRole)
                {
                    lsRoleOfPosition.Add(new CapQuyen() { ChucvuId = id, QuyenTruycapId = role.QuyenTruycapId });
                }

                _context.capQuyens.AddRange(lsRoleOfPosition);
                _context.SaveChanges();

                return _responseDto = new()
                {
                    IsSuccess = true,
                    Message = "add role succes",
                    Result = lsRole
                };
            }
            catch (Exception ex)
            {
                return _responseDto = new()
                {
                    IsSuccess = false,
                    Message = "Error: " + ex.ToString(),
                    Result = null
                };
            }
        }
    }
}
