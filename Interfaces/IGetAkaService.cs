using TvMazeApi.Models;

namespace TvMazeApi.Interfaces
{
    /// <summary>
    /// Get Aka Service interface
    /// </summary>
    public interface IGetAkaService
    {
        /// <summary>
        /// Get Aka by Show id
        /// </summary>
        /// <param name="aka"></param>
        /// <returns>Aka list</returns>
        Task<CustomResponse> GetAkaByShow(GeneralRequest aka);
    }
}
