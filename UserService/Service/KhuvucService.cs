﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using UserService.Context;
using UserService.Models;
using UserService.Models.Dto;
using UserService.Service.IService;

namespace UserService.Service
{
    public class KhuvucService : IKhuvucService
    {
        private readonly AppDBContext _context;
        private ResponseDto _responseDto;
        private IMapper _mapper;
        private readonly KhuVuc _area;
        private readonly INPPService _nppService;
        public KhuvucService(AppDBContext appDBContext, IMapper mapper, INPPService nPPService)
        {
            _context = appDBContext;
            _responseDto = new ResponseDto();
            _mapper = mapper;
            _nppService = nPPService;
        }
        public async Task<ResponseDto> AddArea(KhuvucDto model)
        {
            try
            {
                var checkCode = checkExistAreaCode(model.KhuvucCode);
                var checkName = checkExistAreaName(model.TenKhuvuc);

                string message = "Area name or code already exists.";

                if (checkCode != null || checkName != null)
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = message,
                        Result = model
                    };

                model.Trangthai = true;
                model.KhuvucCode = model.KhuvucCode.Trim().ToUpper();

                var khuvuc = new KhuVuc()
                {
                    KhuvucCode = model.KhuvucCode,
                    TenKhuvuc = model.TenKhuvuc,
                    Trangthai = model.Trangthai
                };

                _context.khuVucs.Add(khuvuc);
                _context.SaveChanges();

                var check = await _nppService.createNPPTemplate(khuvuc.KhuvucCode);

                string messageC = "";

                if (check.IsSuccess == true) messageC = "";
                else messageC = check.Message;

                return _responseDto = new()
                {
                    IsSuccess = true,
                    Message = "Create new Area Success!" + messageC,
                    Result = model
                };
            }
            catch (Exception ex)
            {
                return _responseDto = new()
                {
                    IsSuccess = false,
                    Message = "Error : " + ex.ToString()
                };
                throw;
            }
        }

        public async Task<ResponseDto> DeleteArea(string KhuvucID)
        {
            try
            {
                KhuVuc Area = checkExistAreaCode(KhuvucID);

                if (Area == null)
                {
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = "Delete no success"
                    };
                }

                //check npp template
                var nppTemplate = await _nppService.getNPPTemplate(Area.KhuvucCode);
                var responselsNPP = await _nppService.getListNPP();


                if(responselsNPP != null && responselsNPP.IsSuccess == true && responselsNPP.Result != null)
                {
                    var lsNPP = (List<NhaPhanPhoiDto>)responselsNPP.Result;
                    var checkNPP = lsNPP.Any(npp => npp.tenNPP != null);

                    if(checkNPP == true)
                    {
                        return _responseDto = new()
                        {
                            IsSuccess = false,
                            Message = "Area with code "+ KhuvucID + " cannot remove because area has user."
                        };
                    }
                }

                if (nppTemplate == null)
                {
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = "delete area not success",
                    };
                }

                if ( nppTemplate.IsSuccess == false) {
                    AreaDeleteData(Area);

                    return _responseDto = new()
                    {
                        IsSuccess = true,
                        Result = _mapper.Map<KhuvucDto>(Area),
                        Message = "Succes, success delete"
                    };
                }
                else{
                    NhaPhanPhoiDto npp = new NhaPhanPhoiDto();
                    npp = (NhaPhanPhoiDto)nppTemplate.Result;

                    var resultDeleteNPP = await _nppService.deleteNPP(npp.nppID);

                    if(resultDeleteNPP.IsSuccess == true)
                    {
                        AreaDeleteData(Area);

                        return _responseDto = new()
                        {
                            IsSuccess = true,
                            Result = _mapper.Map<KhuvucDto>(Area),
                            Message = "Succes, success delete"
                        };
                    }
                }
                return _responseDto = new()
                {
                    IsSuccess = false,
                    Message = "Area with code " + KhuvucID + " cannot remove because area has user."
                };
            }
            catch (Exception ex)
            {
                return _responseDto = new()
                {
                    IsSuccess = false,
                    Message = "Error : " + ex.ToString()
                };
                throw;
            }
        }

        private void AreaDeleteData(KhuVuc model)
        {
            try
            {
                _context.khuVucs.Remove(model);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto> EditArea(KhuvucDto model)
        {
            try
            {
                // kiểm tra có đúng id không
                var Area = checkExistAreaCode(model.KhuvucCode);

                if (Area == null)
                {
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = "No Area or name is null"
                    };
                }
                // kiểm tra tên có tồn tại chưa
                var AreaName = checkExistAreaName(model.TenKhuvuc);

                if (AreaName != null)
                {
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = "Area name already exists."
                    };
                }

                // edit trong db
                Area.TenKhuvuc = model.TenKhuvuc;

                _context.khuVucs.Update(Area);
                _context.SaveChanges();

                return _responseDto = new()
                {
                    IsSuccess = true,
                    Message = "Update Success",
                    Result = _mapper.Map<KhuvucDto>(Area)
                };
            }
            catch (Exception ex)
            {
                return _responseDto = new()
                {
                    IsSuccess = false,
                    Message = "Error : " + ex.ToString()
                };
                throw;
            }
        }

        // tim area search qua ten va id cua area trong db
        public async Task<ResponseDto> FindArea(string inputSearch)
        {
            try
            {
                var lsNPP = await GetAreas();

                if (lsNPP.IsSuccess == false || lsNPP.Result == null)
                {
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = lsNPP.Message
                    };
                }

                var lsArea = (List<AreaViewDto>)lsNPP.Result;

                List<AreaViewDto> Areas = lsArea.Where(x => x.KhuvucCode.Trim().ToLower().Contains(inputSearch.Trim()) || x.TenKhuvuc.Trim().ToLower().Contains(inputSearch.Trim())).ToList();

                if (Areas.Count == 0)
                {
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = "No find result"
                    };
                }

                return _responseDto = new()
                {
                    Result = Areas,
                    Message = "find success"
                };
            }
            catch (Exception ex)
            {
                return _responseDto = new()
                {
                    IsSuccess = false,
                    Message = "Error : " + ex.ToString().Trim()
                };
                throw;
            }
        }

        public async Task<ResponseDto> GetArea(string KhuvucID)
        {
            try
            {
                var Area = checkExistAreaCode(KhuvucID);

                if (Area == null)
                {
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = "No Area, try again"
                    };
                }
                // so luong nha phan phoi trong khu vuc do
                int slNPP = 0;

                if (Area != null)
                    slNPP = _context.nhaPhanPhois.Where(x => x.KhuvucID.Trim().ToLower().Equals(Area.KhuvucCode.Trim().ToLower())).Count();

                //using mapper

                AreaViewDto AreaMapper = _mapper.Map<AreaViewDto>(Area);
                AreaMapper.slNhaPP = slNPP;

                return _responseDto = new()
                {
                    Result = AreaMapper,
                    Message = "find succes"
                };
            }
            catch (Exception ex)
            {
                return _responseDto = new()
                {
                    IsSuccess = false,
                    Message = "Error : " + ex.ToString().Trim()
                };
                throw;
            }
        }

        public async Task<ResponseDto> GetAreas()
        {
            try
            {
                var Area = await _context.khuVucs.ToListAsync();

                if (Area == null)
                {
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = "No Area,add and try again"
                    };
                }
                var lsNPP = await _context.nhaPhanPhois.ToListAsync();

                //đếm số lượng nhà phân phối có trong khu vực đó là bao nhiêu
                var lsAreaView = new List<AreaViewDto>();
                int numberNpp = 0;

                foreach (var item in Area)
                {
                    numberNpp = lsNPP.Where(x => x.KhuvucID.Trim().ToUpper().Equals(item.KhuvucCode.Trim().ToUpper())).Count();

                    AreaViewDto AreaMapper = _mapper.Map<AreaViewDto>(item);
                    AreaMapper.slNhaPP = numberNpp;

                    lsAreaView.Add(AreaMapper);
                    numberNpp = 0;
                }

                return _responseDto = new()
                {
                    Result = lsAreaView,
                    Message = "find succes"
                };
            }
            catch (Exception ex)
            {
                return _responseDto = new()
                {
                    IsSuccess = false,
                    Message = "Error : " + ex.ToString().Trim()
                };
                throw;
            }
        }

        private KhuVuc? checkExistAreaCode(string code)
        {

            var AreaCode = _context.khuVucs.FirstOrDefault(x => x.KhuvucCode.Trim().ToLower().Equals(code.Trim().ToLower()));

            return AreaCode;
        }

        private KhuVuc? checkExistAreaName(string name)
        {
            var AreaName = _context.khuVucs.FirstOrDefault(x => x.TenKhuvuc.Trim().ToLower().Equals(name.Trim().ToLower()));

            return AreaName;
        }
    }
}