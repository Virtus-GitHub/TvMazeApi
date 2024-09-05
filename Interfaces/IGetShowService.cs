using TvMazeApi.Models;

namespace TvMazeApi.Interfaces
{
    /// <summary>
    /// GetShow Service interface
    /// </summary>
    public interface IGetShowService
    {
        /// <summary>
        /// Get All shows in file/database
        /// </summary>
        /// <returns>List all Shows></returns>
        Task<CustomResponse> GetAllShowsData();
        /// <summary>
        /// Get Show filtered by id
        /// </summary>
        /// <param name="showId"></param>
        /// <returns>Show selected by id</returns>
        Task<CustomResponse> GetShowById(GeneralRequest showId);
    }
}
