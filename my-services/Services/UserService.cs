using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using portal_dal;
using portal_domain;
using portal_domain.Repository;

namespace my_services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryAsync<User> userRepository;

        private readonly UnitOfWork unitOfWork;
        public UserService(UnitOfWork unitOfWork,
           IRepositoryAsync<User> userRepository
          )
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;

        }



        public async Task<ApiDataResponse<User>> GeUsersAsync(string searchTerm, bool searchAll = false, int offset = 0, int limit = 50)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                searchTerm = string.Empty;
            }
            var query = userRepository.Entities.Where(d => d.FirstName.ToLower().Contains(searchTerm.ToLower()));
            if (!searchAll)
            {
                query = query.Where(c => c.Status == true);

            }
            var data = await query.Skip(offset).Take(limit).AsNoTracking().ToListAsync();
            var total = await query.CountAsync();
            return new ApiDataResponse<User>()
            {
                Data = data,
                Total = total,
                Limit = limit,
                Offset = offset
            };
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var currentUser = await userRepository.GetByIdAsync(id);
            if (currentUser == null)
            {
                throw new Exception("Not found");
            }
            currentUser.Status = false;
            await unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<User> UpdateUserAsync(int id, User user)
        {
            var currentUser = await userRepository.GetByIdAsync(id);
            if (currentUser == null)
            {
                throw new Exception("Not found");
            }
            currentUser.FirstName = user.FirstName;
            currentUser.LastName = user.LastName;
            currentUser.Email = user.Email;
            currentUser.Status = user.Status;
            currentUser.Gender = user.Gender;
            await unitOfWork.SaveChangesAsync();
            return currentUser;

        }

        public async Task<User> CreeateUserAsync(User user)
        {
            user.Status = true;
            var newUser = await userRepository.AddAsync(user);
            await unitOfWork.SaveChangesAsync();
            return newUser;
        }
    }
}
