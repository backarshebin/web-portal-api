using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using portal_domain;
namespace my_services
{
    public interface IUserService
    {
        Task<ApiDataResponse<User>> GeUsersAsync(string searchTerm, bool searchAll = false, int offset = 0, int limit = 50);
        Task<User> UpdateUserAsync(int id, User user);
        Task<bool> DeleteUserAsync(int id);
        Task<User> CreeateUserAsync(User user);
        
    }
}

