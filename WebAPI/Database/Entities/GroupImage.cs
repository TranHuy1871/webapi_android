namespace WebAPI.Database.Entities
{
    public class GroupImage
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupDate { get; set; }
        public int UserId { get; set; }
        public int ImageId { get; set; }
        public User CreateBy { get; set; }
        public List<Image> Images { get; set; }
    }
}
