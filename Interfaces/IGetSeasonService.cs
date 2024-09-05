using TvMazeApi.Models;

namespace TvMazeApi.Interfaces
{
    /// <summary>
    /// Get Season Service interface
    /// </summary>
    public interface IGetSeasonService
    {
        /// <summary>
        /// Get Season list by Show id
        /// </summary>
        /// <param name="showId"></param>
        /// <returns>Season list</returns>
        Task<CustomResponse> GetSeasonsByShow(GeneralRequest showId);
    }
}
