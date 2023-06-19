namespace WebAPI.Application.Queries.UserQueries
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<User>>
    {
        private readonly IUserRepository _repository;

        public GetUsersQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<User>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var listUser = _repository.GetUsers();
            return listUser;
        }
    }
}
