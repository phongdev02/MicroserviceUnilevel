using AutoMapper;
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
        public KhuvucService(AppDBContext appDBContext, IMapper mapper)
        {
            _context = appDBContext;
            _responseDto = new ResponseDto();
            _mapper = mapper;
        }
        public async Task<ResponseDto> AddArea(KhuVuc model)
        {
            try
            {
                var AreaCode = await _context.khuVucs.FirstOrDefaultAsync(x => compareString(x.KhuvucCode, model.KhuvucCode));
                var AreaName = await _context.khuVucs.FirstOrDefaultAsync(x => compareString(x.TenKhuvuc, model.TenKhuvuc));
                string message = "Area name or code already exists.";

                if (AreaCode != null || AreaName != null)
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = message,
                        Result = model
                    };

                model.Trangthai = true;
                model.KhuvucCode = model.KhuvucCode.ToUpper();

                _context.khuVucs.Add(model);
                _context.SaveChanges();

                return _responseDto = new()
                {
                    IsSuccess = true,
                    Message = "Create new Area Success!",
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
                var Area = await _context.khuVucs.FirstOrDefaultAsync(x => compareString(x.KhuvucCode, KhuvucID));
                if (Area == null)
                {
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = "No Area, try again"
                    };
                }

                _context.khuVucs.Remove(Area);
                _context.SaveChanges();

                return _responseDto = new()
                {
                    IsSuccess = true,
                    Message = "delete area success",
                    Result = Area
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

        public async Task<ResponseDto> EditArea(string KhuvucID, string NameArea = "")
        {
            try
            {
                // kiểm tra có đúng id không
                var Area = await _context.khuVucs.FirstOrDefaultAsync(x => compareString(x.KhuvucCode, KhuvucID));

                if (Area == null)
                {
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = "No Area or name is null"
                    };
                }
                // kiểm tra tên có tồn tại chưa
                var AreaName = await _context.khuVucs.FirstOrDefaultAsync(x => compareString(x.TenKhuvuc.Trim(), NameArea.Trim()));

                if (AreaName != null)
                {
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = "Area name already exists."
                    };
                }

                // edit trong db
                Area.TenKhuvuc = NameArea;

                _context.khuVucs.Update(Area);
                _context.SaveChanges();

                return _responseDto = new()
                {
                    IsSuccess = true,
                    Message = "Update Success",
                    Result = Area
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
                var check = await GetAreas();

                if (check.IsSuccess == false || check.Result == null)
                {
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = check.Message
                    };
                }

                var lsArea = (List<AreaViewDto>)check.Result;

                var Areas = lsArea.Where(x => x.KhuvucCode.Trim().Contains(inputSearch.Trim()) || x.TenKhuvuc.Trim().Contains(inputSearch.Trim()));

                if (Areas == null)
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
                var Area = await _context.khuVucs.FirstOrDefaultAsync(x => compareString(x.KhuvucCode, KhuvucID));

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
                    slNPP = _context.nhaPhanPhois.Where(x => compareString(x.KhuvucID, Area.KhuvucCode)).Count();

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
                    numberNpp = lsNPP.Where(x => compareString(x.KhuvucID.Trim().ToUpper(), item.KhuvucCode.Trim().ToUpper())).Count();

                    AreaViewDto AreaMapper = _mapper.Map<AreaViewDto>(Area);
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

        private bool compareString(string a, string b)
        {
            return string.Equals(a.Trim(), b.Trim(), StringComparison.OrdinalIgnoreCase);
        }
    }
}
