using Newtonsoft.Json;
using TvMazeApi.Interfaces;
using TvMazeApi.Models;

namespace TvMazeApi.Services
{
    /// <summary>
    /// Get Casting Service
    /// </summary>
    /// <param name="repository"></param>
    public class GetCastingService(IGetCastingRepository repository) : IGetCastingService
    {
        private readonly IGetCastingRepository _repository = repository;

        /// <summary>
        /// Get Castings by Show id
        /// </summary>
        /// <param name="casting"></param>
        /// <returns>Casting list</returns>
        public async Task<CustomResponse> GetCastings(GeneralRequest casting)
        {
            CustomResponse response = new CustomResponse();

            try
            {
                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                var finalPath = Path.Combine(basePath, "Casting");

                finalPath = Path.Combine(finalPath, $"show{casting.showId}.csv");

                var castings = File.ReadAllText(finalPath);

                List<Casting>? castingList = JsonConvert.DeserializeObject<List<Casting>>(castings);
                response.response = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.OK };
                response.data = castingList;

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
