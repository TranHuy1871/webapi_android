namespace WebAPI.Repositoties
{
    public interface IUserRepository
    {
        bool Register(UserDTO user);
        User Login(UserDTO user);
        List<User> GetUsers();

    }
}
