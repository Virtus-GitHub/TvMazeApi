using TvMazeApi.Models;

namespace TvMazeApi.Interfaces
{
    /// <summary>
    /// Get Show Repository interface
    /// </summary>
    public interface IGetShowRepository
    {
        /// <summary>
        /// Get Shows from file
        /// </summary>
        /// <returns>show list</returns>
        List<Show>? GetShows();
        /// <summary>
        /// Get Show
        /// </summary>
        /// <param name="showId"></param>
        /// <returns>show</returns>
        Show? GetShow(int showId);
    }
}
