using GigApp.Models;
using GigApp.Models.Gigs;
using GigApp.Models.Users;
using GigApp.Views.UserAdd;
using Microsoft.EntityFrameworkCore;

namespace GigApp.Views;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    public async Task<Result> RegisterNewUser(UserAddRequest request)
    {
        try
        {
            var newUser = new User
            {
                Name = request.Username,
                Password = request.Password,
                Email = request.Email,
            };
            context.Users.Add(newUser);
            await context.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception e)
        {
            return Result.Failure(e.Message);
        }
    }

    public async Task<User> GetUserByEmail(string email)
    {
        return await context.Users.Where(x => x.Email == email).FirstAsync();
    }
}
