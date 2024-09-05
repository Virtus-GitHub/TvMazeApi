using TvMazeApi.Models;

namespace TvMazeApi.Interfaces
{
    /// <summary>
    /// Get Season Repository interface
    /// </summary>
    public interface IGetSeasonRepository
    {
        /// <summary>
        /// Get Seasons
        /// </summary>
        /// <param name="showId"></param>
        /// <returns>Season list</returns>
        List<Season>? GetSeasons(int showId);
    }
}
