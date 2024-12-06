using GigApp.Models;
using GigApp.Models.Users;
using MediatR;

namespace GigApp.Views.UserAdd;

public class UserAddHandler(IUserRepository userRepository) : IRequestHandler<UserAddRequest, Result>
{
    public async Task<Result> Handle(UserAddRequest request, CancellationToken cancellationToken)
    {
        var response = await userRepository.RegisterNewUser(request);
        return response;
    }
}