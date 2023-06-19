namespace WebAPI.Repositoties
{
    public interface IGroupImageRepository
    {
        bool CreateGroupImage(GroupImageDTO groupImageDTO);
        bool DeleteGroupImage(string groupName);
        bool UpdateGroupImage(GroupImageDTO groupImageDTO);
        List<ImageDTO> GetAllImage();
    }
}
