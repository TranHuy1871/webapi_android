namespace WebAPI.Application.Queries.UserQueries
{
    public class GetUsersQuery : IRequest<List<User>>
    {
        public List<User> listUser { get; }
    }
}
