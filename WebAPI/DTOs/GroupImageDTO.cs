
using WebAPI.Database.Entities;

namespace WebAPI.DTOs
{
    public class GroupImageDTO
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupDate { get; set; }
        public User CreateBy { get; set; }
    }
}
