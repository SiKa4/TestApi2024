using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApi2.DataBaseContext;
using TestApi2.Interfaces;
using TestApi2.Model;
using TestApi2.Requests;

namespace TestApi2.Service
{
    public class UserService : IUserService
    {
        private readonly TestApiDB _context;

        public UserService(TestApiDB context)
        {
            _context = context;
        }

        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _context.Logins
                                      .Where(a => a.id_Login == 1)
                                      .Include(a => a.Users)
                                      .ToListAsync();

            return new OkObjectResult(new
            {
                users = users,
                status = true
            });
        }

        public async Task<IActionResult> CreateNewUserAndLoginAsync(CreateNewUserAndLogin newUser)
        {
            var user = new Users()
            {
                Name = newUser.Name,
                Description = newUser.Description,
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            var login = new Logins()
            {
                User_id = user.id_User,
                Login = newUser.Login,
                Password = newUser.Password,
            };

            await _context.Logins.AddAsync(login);
            await _context.SaveChangesAsync();

            return new OkResult();
        }
    }
}
