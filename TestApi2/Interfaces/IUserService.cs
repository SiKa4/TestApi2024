using Microsoft.AspNetCore.Mvc;
using TestApi2.Requests;

namespace TestApi2.Interfaces
{
    public interface IUserService
    {
        Task<IActionResult> GetAllUsersAsync();
        Task<IActionResult> CreateNewUserAndLoginAsync(CreateNewUserAndLogin newUser);
    }
}
