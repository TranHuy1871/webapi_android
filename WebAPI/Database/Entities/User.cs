namespace WebAPI.Database.Entities
{
    public class User
    {
        public int    UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<GroupImage> GroupImage { get; set; }   
    }
}
