using UserService.Models.Dto;
using UserService.Service.IService;

namespace UserService.Service
{
    public class ViengThamService : IViengThamService
    {
        public async Task<ResponseDto?> CreateViengTham(ViengThamDto viengTham)
        {
            try
            {
                return new ResponseDto()
                {
                    IsSuccess = false,
                    Message = "Error: ",
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto()
                {
                    IsSuccess = false,
                    Message = "Error: "+ex.Message.ToString().Trim(),
                };
            }
        }

        public async Task<ResponseDto?> DeleteViengTham(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto?> getLsViengTham()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto?> getViengTham(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto?> UpdateViengTham(ViengThamDto viengTham)
        {
            throw new NotImplementedException();
        }
    }
}
