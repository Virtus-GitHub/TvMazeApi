using TvMazeApi.Models;

namespace TvMazeApi.Interfaces
{
    /// <summary>
    /// Get Episode Service interface
    /// </summary>
    public interface IGetEpisodeService
    {
        /// <summary>
        /// Get Episodes by show id
        /// </summary>
        /// <param name="episode"></param>
        /// <returns>Episodes of selected show</returns>
        Task<CustomResponse> GetEpisodesByShow(GeneralRequest episode);
        /// <summary>
        /// Get Episode By Season And Episode number
        /// </summary>
        /// <param name="episode"></param>
        /// <returns>Episode</returns>
        Task<CustomResponse> GetEpisodeBySeasonAndEpisode(GeneralRequest episode);
        /// <summary>
        /// Get Episode By Date
        /// </summary>
        /// <param name="episode"></param>
        /// <returns>Episode</returns>
        Task<CustomResponse> GetEpisodesByDate(GeneralRequest episode);
        /// <summary>
        /// Get Episode list By Season
        /// </summary>
        /// <param name="episode"></param>
        /// <returns>Episodes list</returns>
        Task<CustomResponse> GetEpisodesBySeason(GeneralRequest episode);
    }
}
