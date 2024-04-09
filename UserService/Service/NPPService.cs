using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserService.Context;
using UserService.Models;
using UserService.Models.Dto;
using UserService.Service.IService;

namespace UserService.Service
{
    public class NPPService : INPPService
    {
        private readonly AppDBContext _context;
        private ResponseDto _responseDto;
        private readonly IMapper _mapper;
        public NPPService(AppDBContext appDBContext, IMapper mapper)
        {
            _context = appDBContext;
            _responseDto = new ResponseDto();
            _mapper = mapper;
        }

        public async Task<ResponseDto?> createNPP(NhaPhanPhoiDto model)
        {
            try
            {
                if(model == null || model.tenNPP == null || model.email == null || model.Diachi == null || model.KhuvucID == null)
                {
                    return new ResponseDto()
                    {
                        IsSuccess = false,
                        Message = "NPP is not null"
                    };
                }

                var nppDto = new NhaPhanPhoiDto()
                {
                    tenNPP = model.tenNPP,
                    email = model.email,
                    Diachi = model.Diachi,
                    SDT = model.SDT,
                    trangthai = model.trangthai,
                    KhuvucID = model.KhuvucID.ToUpper().Trim()
                };

                var NPP = _mapper.Map<NhaPhanPhoi>(nppDto);

                if (NPP.tenNPP == null || NPP.Diachi == null || NPP.email == null)
                {
                    return new ResponseDto()
                    {
                        IsSuccess = false,
                        Message = "Value in NPP is not null"
                    };
                }

                _context.nhaPhanPhois.Add(NPP);
                _context.SaveChanges();

                var getNPP = _mapper.Map<NhaPhanPhoiDto>(NPP);

                return _responseDto = new()
                {
                    Result = getNPP,
                    Message = "create Succes NPP"
                };
                
            }
            catch (Exception ex)
            {
                return _responseDto = new()
                {
                    IsSuccess= false,
                    Message = "Error: "+ex.Message
                };
            }
        }

        public async Task<ResponseDto?> createNPPTemplate(string code)
        {
            try
            {
                var model = new NhaPhanPhoiDto();
                model.KhuvucID = code.ToUpper().Trim();

                var NPP = _mapper.Map<NhaPhanPhoi>(model);

                var lsNPPTemplate = _context.nhaPhanPhois.Where(npp => compareString(npp.KhuvucID, code) && npp.tenNPP == null).ToList();
                if (lsNPPTemplate.Count == 0)
                {
                    _context.nhaPhanPhois.Add(NPP);
                    _context.SaveChanges();

                    return _responseDto = new()
                    {
                        Result = model,
                        Message = "create Succes NPP"
                    };
                }
                else
                {
                    return _responseDto = new() 
                    {
                        IsSuccess = false,
                        Message = "have many one NPP template on Database, please check data on Database and try again" + lsNPPTemplate[0].KhuvucID
                    };
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResponseDto?> deleteNPP(int id)
        {
            try
            {
                var model = await _context.nhaPhanPhois.FirstOrDefaultAsync(npp=> npp.nppID == id);

                if( model == null)
                {
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = "not find NPP"
                    };
                }

                var lsNhanvien = _context.Nhanviens.Where(Nhanvien => Nhanvien.nppID == id).ToList();

                var countLsNhanvien = lsNhanvien.Count();

                if(countLsNhanvien == 0)
                {
                    _context.nhaPhanPhois.Remove(model);
                    await _context.SaveChangesAsync();
                    return _responseDto = new()
                    {
                        Result = model,
                        Message = "Success. Delete success"
                    };
                }
                else
                {
                    return _responseDto = new()
                    {
                        Result = model,
                        IsSuccess = false,
                        Message = "Fail Delete success"
                    };
                }
            }
            catch (Exception ex)
            {
                return _responseDto = new()
                {
                    IsSuccess = false,
                    Message = "Error: " + ex.Message
                };
            }
        }

        public async Task<ResponseDto?> findNPP(int id)
        {
            try
            {
                var response = await getListNPP();

                if(response == null || response.Result == null)
                {
                    return _responseDto = new()
                    {
                        Result = null,
                        IsSuccess = false,
                        Message = "not find"
                    };
                }

                if(response.IsSuccess == false)
                {
                    return _responseDto = new()
                    {
                        Result = null,
                        IsSuccess = false,
                        Message = "not find"
                    };
                }
                else
                {

                    var npp = (List<NhaPhanPhoiDto>)response.Result;

                    if (response.Result == null)
                    {
                        return _responseDto = new()
                        {
                            Result = null,
                            IsSuccess = false,
                            Message = "not find"
                        };
                    }
                    else
                    {
                        return _responseDto = new()
                        {
                            Result = response.Result,
                            Message = "Success, success find"
                        };
                    }
                }

                
            }
            catch (Exception ex)
            {
                return _responseDto = new()
                {
                    IsSuccess = false,
                    Message = "Error: " + ex.Message
                };
            }
        }

        public async Task<ResponseDto?> getListNPP()
        {
            try
            {
                var lsNPPTemplate = _context.nhaPhanPhois.ToList();

                if (lsNPPTemplate.Count == 0)
                {
                    return _responseDto = new()
                    {
                        Result = null,
                        IsSuccess = false,
                        Message = "not find "
                    };
                }
                else
                {
                    return _responseDto = new()
                    {
                        Result = _mapper.Map<List<NhaPhanPhoiDto>>(lsNPPTemplate),
                        Message = "Success, success find"
                    };
                }
            }
            catch (Exception ex)
            {
                return _responseDto = new()
                {
                    IsSuccess = false,
                    Message = "Error: " + ex.Message
                };
            }
        }

        public async Task<ResponseDto?> getListNPPWithCodeArea(string code)
        {
            try
            {
                var lsNPPTemplate = _context.nhaPhanPhois.Where(npp => npp.tenNPP != null).ToList();

                if (lsNPPTemplate.Count == 0)
                {
                    return _responseDto = new()
                    {
                        Result = null,
                        IsSuccess = false,
                        Message = "not find"
                    };
                }
                else
                {
                    return _responseDto = new()
                    {
                        Result = _mapper.Map<List<NhaPhanPhoiDto>>(lsNPPTemplate),
                        Message = "Success, success find"
                    };
                }
            }
            catch (Exception ex)
            {
                return _responseDto = new()
                {
                    IsSuccess = false,
                    Message = "Error: " + ex.Message
                };
            }

        }
        public async Task<ResponseDto?> getNPPTemplate(string code)
        {
            try
            {
                var lsNPPTemplate = _context.nhaPhanPhois.Where(npp => npp.tenNPP == null).ToList();
                var template = lsNPPTemplate.FirstOrDefault(npp=> compareString(npp.KhuvucID, code));

                if (template == null)
                {


                    return _responseDto = new()
                    {
                        Result = null,
                        IsSuccess = false,
                        Message = "not find NPP Template"
                    };
                }
                else
                {
                    return _responseDto = new()
                    {
                        Result = _mapper.Map<NhaPhanPhoiDto>(template),
                        Message = "Success, success find"
                    };
                }
            }
            catch (Exception ex)
            {
                return _responseDto = new()
                {
                    IsSuccess = false,
                    Message = "Error: " + ex.Message
                };
            }

        }

        public async Task<ResponseDto?> updateNPP(NhaPhanPhoiDto model)
        {
            try
            {
                var lsNPP = _context.nhaPhanPhois.Where(npp => npp.tenNPP != null).ToList();

                var valueUpdate = lsNPP.FirstOrDefault(npp=>npp.nppID == model.nppID);

                if (valueUpdate != null && model.tenNPP != null && model.email != null)
                {
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = "No find in DB"
                    };
                }

                valueUpdate = _mapper.Map<NhaPhanPhoi>(model);

                _context.nhaPhanPhois.Update(valueUpdate);
                _context.SaveChanges();

                return _responseDto = new()
                {
                    Result = valueUpdate,
                    Message = "Success. Update success"
                };
            }
            catch (Exception ex) 
            {
                return _responseDto = new()
                {
                    IsSuccess = false,
                    Message = "Error: " + ex.Message
                };
            }
        }

        private bool compareString(string a, string b)
        {
            return a.Trim().ToUpper().Contains(b.Trim().ToUpper());
        }
    }
}
