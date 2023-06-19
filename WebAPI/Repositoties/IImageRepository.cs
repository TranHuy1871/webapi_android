using WebAPI.DTOs;

namespace WebAPI.Repositoties
{
    public interface IImageRepository
    {
        bool AddImageToGroup(ImageDTO img);
        bool DeleteImageFromGroup(ImageDTO img);
        ImageDTO GetImageFromGroup(ImageDTO img);
    }
}
