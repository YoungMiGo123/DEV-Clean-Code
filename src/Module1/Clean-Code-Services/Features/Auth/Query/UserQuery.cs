using Ardalis.Result;
using Clean_Code_Services.Features.Auth.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean_Code_Services.Features.Auth.Query
{
    public class UserQuery : IRequest<Result<UserDto>>
    {
        [FromQuery]
        public string Email { get; set; }
    }
}
