using MediatR;
using WebAPI.Database.Entities;
using WebAPI.DTOs;
using WebAPI.Repositoties;

namespace WebAPI.Application.Commands.UserCommands
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, UserDTO>
    {
        private readonly IUserRepository _repository;

        public LoginUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserDTO> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = _repository.Login(request.User);
            if (user != null)
            {
                var userDto = new UserDTO
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    Password = user.Password,
                };

                return userDto;
            }

            return null;
        }
    }
}
