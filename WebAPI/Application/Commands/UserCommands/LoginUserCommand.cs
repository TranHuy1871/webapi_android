using MediatR;
using WebAPI.Database.Entities;
using WebAPI.DTOs;

namespace WebAPI.Application.Commands.UserCommands
{
    public class LoginUserCommand : IRequest<UserDTO>
    {
        public UserDTO User { get; set; }
    }
}
