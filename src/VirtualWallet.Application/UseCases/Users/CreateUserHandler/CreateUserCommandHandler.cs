using MediatR;
using VirtualWallet.Domain.Entities;
using VirtualWallet.Domain.Enums.User;
using VirtualWallet.Infrastructure.Repository.Users;

namespace VirtualWallet.Application.UseCases.Users.CreateUserHandler;

public class CreateUserCommandHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
     private readonly IUserRepository _userRepository;

     public CreateUserCommandHandler(IUserRepository userRepository)
     {
         _userRepository = userRepository;
     }

     public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
     {
//         var user = new User
//         {
//             Pinfl = request.Pinfl,
//             Tin = request.Tin,
//             LastName = request.LastName,
//             FirstName = request.FirstName,
//             MiddleName = request.MiddleName,
//             UserType = request.UserType,
//             ExternalId = request.ExternalId,
//         };
//         await _userRepository.CreateUserAsync(user, cancellationToken);
        return new CreateUserResponse
        {
            // Id = user.Id,
            Id = null,
        };
    }
}