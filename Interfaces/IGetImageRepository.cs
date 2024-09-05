using TvMazeApi.Models;

namespace TvMazeApi.Interfaces
{
    /// <summary>
    /// Get Image Repository interface
    /// </summary>
    public interface IGetImageRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="showId"></param>
        /// <returns>Image list</returns>
        List<ImageData>? GetImages(int showId);
    }
}
