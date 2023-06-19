using MediatR;
using WebAPI.DTOs;

namespace WebAPI.Application.Commands.UserCommands
{
    public class RegisterUserCommand : IRequest<bool>
    {
        public UserDTO User { get; set; }
    }
}
