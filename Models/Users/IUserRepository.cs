using GigApp.Views.UserAdd;

namespace GigApp.Models.Users;

public interface IUserRepository
{
    Task<Result> RegisterNewUser(UserAddRequest request);
}