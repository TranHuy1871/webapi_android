using MediatR;
using WebAPI.DTOs;
using WebAPI.Repositoties;

namespace WebAPI.Application.Commands.UserCommands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
    {
        private readonly IUserRepository _repository;

        public RegisterUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            //var fakeUsers = new UserDTO { UserName = "huytq", Password = "huytq" };
            //_repository.Register(fakeUsers);

            bool isRegistered = _repository.Register(request.User);

            return isRegistered;
        }
    }
}
