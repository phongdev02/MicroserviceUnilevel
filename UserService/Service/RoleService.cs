using UserService.Context;
using UserService.Models.Dto;
using UserService.Service.IService;

namespace UserService.Service
{
    public class RoleService : IRoleService
    {
		private ResponseDto _responseDto;
		private AppDBContext _context;
		public RoleService(AppDBContext context) { 
			_responseDto = new ResponseDto();
			_context = context;
		}
        public async Task<ResponseDto?> GetListRole(int titleID)
        {
			try
			{
				//code logic
				//get lst title
				if(_context.Titles.Any(title => title.titleID == titleID))
				{
					var lsRoleTitle = 
							 from roleTitle in _context.RoleTitles
							 where roleTitle.titleID == titleID 
                                 select roleTitle;

                    var lsRole = from role in _context.Roles
                                 join roleTitle in lsRoleTitle on role.roleId equals roleTitle.roleId
                                 select role;

					return _responseDto = new()
					{
						Result = lsRole,
						Message = "Get success"
					};
                }

				return _responseDto = new()
				{
					IsSuccess = false,
					Message = "Get not success"
				};
			}
			catch (Exception ex)
			{
				return _responseDto = new() { Message = ex.Message, IsSuccess = false};
			}
        }

        public async Task<ResponseDto?> SetListRole(int titleID)
        {
            try
            {
                //code logic
                //get lst title
                if (_context.Titles.Any(title => title.titleID == titleID))
                {
                    var lsRoleTitle =
                             from roleTitle in _context.RoleTitles
                             where roleTitle.titleID == titleID
                             select roleTitle;

                    var lsRole = from role in _context.Roles
                                 join roleTitle in lsRoleTitle on role.roleId equals roleTitle.roleId
                                 select role;

                    return _responseDto = new()
                    {
                        Result = lsRole,
                        Message = "Get success"
                    };
                }

                return _responseDto = new()
                {
                    IsSuccess = false,
                    Message = "Get not success"
                };
            }
            catch (Exception ex)
            {
                return _responseDto = new() { Message = ex.Message, IsSuccess = false };
            }
        }
    }
}
