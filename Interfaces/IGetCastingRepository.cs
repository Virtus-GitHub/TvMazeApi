using TvMazeApi.Models;

namespace TvMazeApi.Interfaces
{
    /// <summary>
    /// Get Casting Repository interface
    /// </summary>
    public interface IGetCastingRepository
    {
        /// <summary>
        /// Get Castings
        /// </summary>
        /// <param name="showId"></param>
        /// <returns>Castings list</returns>
        List<Casting>? GetCastings(int showId);
    }
}
