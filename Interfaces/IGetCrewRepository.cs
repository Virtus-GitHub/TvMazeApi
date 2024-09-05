using TvMazeApi.Models;

namespace TvMazeApi.Interfaces
{
    /// <summary>
    /// Get Crew Repository interface
    /// </summary>
    public interface IGetCrewRepository
    {
        /// <summary>
        /// Get Crews
        /// </summary>
        /// <param name="showId"></param>
        /// <returns>Crew list</returns>
        List<Crew>? GetCrews(int showId);
    }
}
