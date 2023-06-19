namespace WebAPI.Database.Entities
{
    public class Image
    {
        public int ImageId { get; set; }
        public string FileImage { get; set; }
        public string ImageDate { get; set; }
        public int GroupId { get; set; }
        public GroupImage GroupImage { get; set; }
    }
}
