namespace WebAPI.Repositoties
{
    public class GroupImageRepository : IGroupImageRepository
    {
        private readonly MyDbContext _context;

        public GroupImageRepository(MyDbContext context)
        {
            _context = context;
        }

        public bool CreateGroupImage(GroupImageDTO groupImageDTO)
        {
            bool groupExists = _context.GroupImages.Any(u => u.GroupName == groupImageDTO.GroupName);

            if (groupExists)
                return false;

            GroupImage groupImg = new GroupImage
            {
                GroupName = groupImageDTO.GroupName,
                GroupDate = DateTime.Now.ToString(),
            };

            _context.GroupImages.Add(groupImg);
            _context.SaveChanges();

            return true;
        }

        public bool DeleteGroupImage(string groupName)
        {
            var groupImg = _context.GroupImages.FirstOrDefault(u => u.GroupName == groupName);

            if (groupImg == null)
                return false;

            _context.GroupImages.Remove(groupImg);
            _context.SaveChanges();

            return true;
        }

        public List<ImageDTO> GetAllImage()
        {
            var imageList = _context.Images.ToList();
            var imageDTOList = imageList.Select(image => new ImageDTO
            {
                ImageId = image.ImageId,
                FileImage = image.FileImage
            }).ToList();

            return imageDTOList;
        }

        public bool UpdateGroupImage(GroupImageDTO groupImageDTO)
        {
            var groupImg = _context.GroupImages.FirstOrDefault(u => u.GroupName == groupImageDTO.GroupName);

            if (groupImg == null)
                return false;

            groupImg.GroupName = groupImageDTO.GroupName;
            _context.SaveChanges();

            return true;
        }
    }
}
