using TaiKhoan.Context;
using TaiKhoan.Models.Dto;
using TaiKhoan.service.IService;

namespace TaiKhoan.service
{
    public class TaikhoanService : ITaikhoanService
    {
        private readonly AppDBContext _dbContext;
        TaikhoanService(AppDBContext dBContext) { 
            _dbContext = dBContext;
        }

        public Task<NhanvienDto> CreateAccount()
        {
            throw new NotImplementedException();
        }

        public Task<NhanvienDto> EditAccount()
        {
            throw new NotImplementedException();
        }

        public Task<NhanvienDto> EditPass()
        {
            throw new NotImplementedException();
        }

        public Task<NhanvienDto> LogginAccount()
        {
            throw new NotImplementedException();
        }
    }
}
