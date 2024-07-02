using Ardalis.Result;
using Clean_Code_Services.Core.Entities.User;
using Clean_Code_Services.Features.Auth.Dto;
using Clean_Code_Services.Features.Auth.Query;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Clean_Code_Services.Features.Auth.QueryHandler
{
    public class UserQueryHandler(UserManager<AppUser> _userManager) : IRequestHandler<UserQuery, Result<UserDto>>
    {
        public async Task<Result<UserDto>> Handle(UserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            return Result.Success(new UserDto
            {
                Email = request.Email,
                Id = Guid.Parse(user.Id)
            });

        }
    }
}
