using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using UserService.Context;
using UserService.Models;
using UserService.Models.Dto;
using UserService.Service.IService;

namespace UserService.Service
{
    public class AreaService : IAreaService
    {
        private readonly AppDBContext _context;
        private ResponseDto _responseDto;
        private IMapper _mapper;
        private readonly Area _area;
        private readonly INPPService _nppService;
        public AreaService(AppDBContext appDBContext, IMapper mapper, INPPService nPPService)
        {
            _context = appDBContext;
            _responseDto = new ResponseDto();
            _mapper = mapper;
            _nppService = nPPService;
        }
        public async Task<ResponseDto> AddAreaAsync(AreaDto model)
        {
            try
            {
                var checkCode =await checkExistAreaCode(model.areaCode);
                var checkName =await checkExistAreaName(model.areaName);

                string message = "Area name or code already exists.";

                if (checkCode != null || checkName != null)
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = message,
                        Result = model
                    };

                model.status = true;
                model.areaCode = model.areaCode.Trim().ToUpper();

                var khuvuc = new Area()
                {
                    areaCode = model.areaCode,
                    areaName = model.areaName,
                    status = model.status
                };

                await _context.Areas.AddAsync(khuvuc);
                await _context.SaveChangesAsync();

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

        public async Task<ResponseDto> DeleteAreaAsync(string KhuvucID)
        {
            try
            {
                Area? Area = await checkExistAreaCode(KhuvucID);

                if (Area == null)
                {
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = "Area no available"
                    };
                }
                //kiem tra co nguoi trong area nay khong
                int numberAccoutOnArea = 0;

                if (!_context.Accounts.IsNullOrEmpty())
                {
                    numberAccoutOnArea = (from account in _context.Accounts
                                          where !account.areaCode.IsNullOrEmpty() && account.areaCode.Trim().ToUpper().Equals(Area.areaCode.ToUpper())
                                          select account).Count();
                }
                //kiem tra so luong npp trong khu vuc nay
                int numberDistributorOnArea = 0;

                if (!_context.Accounts.IsNullOrEmpty())
                {
                    numberDistributorOnArea = (from Distributor in _context.Distributors where Distributor.areacode.Trim().ToLower().Equals(Area.areaCode.ToLower()) select Distributor).Count();
                }

                if (numberAccoutOnArea != 0 || numberDistributorOnArea != 0)
                {
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = "No success"
                    };
                }
                _context.Areas.Remove(Area);
                await _context.SaveChangesAsync();

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

        public async Task<ResponseDto> EditAreaAsync(AreaDto model)
        {
            try
            {
                // kiểm tra có đúng id không
                var Area = await checkExistAreaCode(model.areaCode);

                if (Area == null)
                {
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = "Area not available"
                    };
                }

                // kiểm tra tên có tồn tại chưa
                var AreaName = await checkExistAreaName(model.areaName);

                if (AreaName != null)
                {
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = "Area name already exists."
                    };
                }

                // edit trong db
                Area.areaName = model.areaName;

                _context.Areas.Update(Area);
                await _context.SaveChangesAsync();

                return _responseDto = new()
                {
                    IsSuccess = true,
                    Message = "Update Success",
                    Result = _mapper.Map<AreaDto>(Area)
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

        //tim area search qua ten va id cua area trong db
        public async Task<ResponseDto> FindAreaAsync(string inputSearch)
        {
            try
            {
                var response = await GetAreasAsync();

                if(response == null || response.IsSuccess == false || response.Result == null)
                {
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = response.Message
                    };
                }
                else
                {
                    var listArea = from area in (List<AreaViewDto>)response.Result
                                   where area.areaName.Trim().ToLower().Contains(inputSearch.Trim().ToLower()) ||
                                   area.areaCode.Trim().ToLower().Contains(inputSearch.Trim().ToLower())
                                   select area;

                    return _responseDto = new()
                    {
                        Result = listArea,
                        Message = "Find success"
                    };

                }
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



        public async Task<ResponseDto> GetAreasAsync()
        {
            try
            {
                var Areas = _context.Areas;

                if (Areas == null)
                {
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = "No Area,add and try again"
                    };
                }

                var groupDisWithArea = _context.Distributors.GroupBy(item => item.areacode);

                List<AreaViewDto> areaViews = new List<AreaViewDto>();
                var lsArea = _context.Areas;

                AreaViewDto areaCheck = new AreaViewDto();
                AreaViewDto areaView = new AreaViewDto();

                //Nhóm NPP theo area rồi đếm list trong nó
                areaViews = _mapper.Map<List<AreaViewDto>>(Areas.ToList());

                foreach (var area in groupDisWithArea)
                {
                    areaCheck = areaViews.FirstOrDefault(item => item.areaCode.Trim().ToLower().Equals(area.Key.Trim().ToLower()))!;
                    if (areaCheck != null)
                    {
                        areaCheck.number = area.Count();
                    }
                }

                return _responseDto = new()
                {
                    Result = areaViews,
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
        public async Task<ResponseDto> GetAreaAsync(string areacode)
        {
            try
            {
                var model = await _context.Areas.FirstOrDefaultAsync(item => item.areaCode.Trim().ToLower().Equals(areacode.Trim().ToLower()));

                if (model != null) {
                    return _responseDto = new()
                    {
                        Result = model,
                        Message = "succes"
                    };
                }
                else
                {
                    return _responseDto = new()
                    {
                        IsSuccess = false,
                        Message = "Area unavailable"
                    };
                }
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
        private async Task<Area?> checkExistAreaCode(string code)
        {

            var AreaCode = await _context.Areas.FirstOrDefaultAsync(x => x.areaCode.Trim().ToLower().Equals(code.Trim().ToLower()));

            return AreaCode;
        }

        private async Task<Area?> checkExistAreaName(string name)
        {
            var AreaName = await _context.Areas.FirstOrDefaultAsync(x => x.areaName.Trim().ToLower().Equals(name.Trim().ToLower()));

            return AreaName;
        }


    }
}
