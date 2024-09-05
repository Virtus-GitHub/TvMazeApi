using TvMazeApi.Models;

namespace TvMazeApi.Interfaces
{
    /// <summary>
    /// Get Images Service interface
    /// </summary>
    public interface IGetImagesService
    {
        /// <summary>
        /// Get Images by Show
        /// </summary>
        /// <param name="image"></param>
        /// <returns>Image of Show</returns>
        Task<CustomResponse> GetImagesByShow(GeneralRequest image);
    }
}
