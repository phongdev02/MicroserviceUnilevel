using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml.Style.XmlAccess;
using UserService.Context;
using UserService.Models;
using UserService.Models.Dto;
using UserService.Service.IService;

namespace UserService.Service
{
    public class TitleService : ITitleService
    {
        private IMapper _mapper;
        private AppDBContext _context;

        public TitleService(IMapper mapper, AppDBContext context) { 
            _mapper = mapper;
            _context = context;
        }

        public async Task<ResponseDto?> CreateTitle([FromBody]TitleDto model)
        {
            try
            {
                Title title = _mapper.Map<Title>(model);

                if(_context.Titles.Any(item=> item.titleName.ToLower().Trim().Equals(title.titleName.ToLower().Trim())))
                    return new ResponseDto()
                    {
                        IsSuccess = false,
                        Message = "title available",
                    };
                _context.Titles.Add(title);
                _context.SaveChanges();

                return new ResponseDto()
                {
                    IsSuccess = true,
                    Message = "",
                    Result = _mapper.Map<TitleDto>(title)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto()
                {
                    IsSuccess = true,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseDto?> EditTitle([FromBody]TitleDto model)
        {
            try
            {
                Title title = _mapper.Map<Title>(model);

                var item = _context.Titles.FirstOrDefault(item=> item.titleID == model.titleID);

                if (_context.Titles.Any(item =>item.titleName.ToLower().Trim().Equals(title.titleName.ToLower().Trim())))
                    return new ResponseDto()
                    {
                        IsSuccess = false,
                        Message = "title name available",
                    };

                item.titleName = title.titleName;

                _context.Titles.Update(item);
                _context.SaveChanges();

                return new ResponseDto()
                {
                    IsSuccess = true,
                    Message = "",
                    Result = _mapper.Map<TitleDto>(title)
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto()
                {
                    IsSuccess = true,
                    Message = ex.Message,
                };
            }
        }

        public async Task<ResponseDto?> DeleteTitle(int titleID)
        {
            try
            {
                if(!_context.Accounts.Any(item=> item.titleID == titleID))
                {

                    var title = _context.Titles.FirstOrDefault(item => item.titleID == titleID);

                    if (title == null) return new ResponseDto() { IsSuccess = false, Message = "not available" };

                    _context.Titles.Remove(title);
                    _context.SaveChanges();
                }

                return new ResponseDto() { IsSuccess = false, Message = "not delete" };
            }
            catch (Exception ex)
            {
                return new ResponseDto() { IsSuccess = false, Message = ex.Message };
            }
        }
    }
}
