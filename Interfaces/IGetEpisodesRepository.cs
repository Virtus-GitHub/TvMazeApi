using TvMazeApi.Models;

namespace TvMazeApi.Interfaces
{
    /// <summary>
    /// Get Episodes Repository interface
    /// </summary>
    public interface IGetEpisodesRepository
    {
        /// <summary>
        /// Get Episodes
        /// </summary>
        /// <param name="showId"></param>
        /// <returns>Episodes list</returns>
        List<Episode>? GetEpisodes(int showId);
    }
}
