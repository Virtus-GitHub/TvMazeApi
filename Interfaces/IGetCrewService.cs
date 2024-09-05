using TvMazeApi.Models;

namespace TvMazeApi.Interfaces
{
    /// <summary>
    /// Get Crew Service interface
    /// </summary>
    public interface IGetCrewService
    {
        /// <summary>
        /// Get Crews By show id
        /// </summary>
        /// <param name="crew"></param>
        /// <returns>Crew list</returns>
        Task<CustomResponse> GetCrewsByShow(GeneralRequest crew);
    }
}
