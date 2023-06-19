namespace WebAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _context;

        public UserRepository(MyDbContext context)
        {
            _context = context;
        }

        public List<User> GetUsers()
        {
            var listUser = _context.Users.ToList();
            return listUser;
        }

        public User Login(UserDTO us)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == us.Username && u.Password == us.Password);
            return user;
        }

        public bool Register(UserDTO us)
        {
            bool userExists = _context.Users.Any(u => u.Username == us.Username);

            if (userExists)
                return false;

            User user = new User
            {
                Username = us.Username,
                Password = us.Password
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return true;
        }
    }
}
