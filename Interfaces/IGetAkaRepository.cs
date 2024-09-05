using TvMazeApi.Models;

namespace TvMazeApi.Interfaces
{
    /// <summary>
    /// Get Aka Repository interface
    /// </summary>
    public interface IGetAkaRepository
    {
        /// <summary>
        /// Get Akas
        /// </summary>
        /// <param name="showId"></param>
        /// <returns>Akas list</returns>
        List<Aka>? GetAkas(int showId);
    }
}
