using Newtonsoft.Json;
using TvMazeApi.Interfaces;
using TvMazeApi.Models;

namespace TvMazeApi.Services
{
    /// <summary>
    /// Get Crew Service
    /// </summary>
    /// <param name="repository"></param>
    public class GetCrewService(IGetCrewRepository repository) : IGetCrewService
    {
        private readonly IGetCrewRepository _repository = repository;
        /// <summary>
        /// Get Crews By show id
        /// </summary>
        /// <param name="crew"></param>
        /// <returns>Crew list</returns>
        public async Task<CustomResponse> GetCrewsByShow(GeneralRequest crew)
        {
            CustomResponse response = new CustomResponse();

            try
            {
                List<Crew>? crewList = _repository.GetCrews(crew.showId);
                response.response = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.OK };
                response.data = crewList;

                return await Task.FromResult(response);
            }
            catch (Exception ex)
            {
                response.response = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.InternalServerError, ReasonPhrase = ex.Message };

                return response;
            }
        }
    }
}
