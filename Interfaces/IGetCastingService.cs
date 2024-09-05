using TvMazeApi.Models;

namespace TvMazeApi.Interfaces
{
    /// <summary>
    /// Get Casting Service interface
    /// </summary>
    public interface IGetCastingService
    {
        /// <summary>
        /// Get Castings by Show id
        /// </summary>
        /// <param name="casting"></param>
        /// <returns>Casting list</returns>
        Task<CustomResponse> GetCastings(GeneralRequest casting);
    }
}
