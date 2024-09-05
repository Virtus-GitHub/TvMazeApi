using Newtonsoft.Json;
using TvMazeApi.Interfaces;
using TvMazeApi.Models;

namespace TvMazeApi.Services
{
    /// <summary>
    /// Get Aka Service
    /// </summary>
    public class GetAkaService(IGetAkaRepository repository) : IGetAkaService
    {
        private readonly IGetAkaRepository _repository = repository;

        /// <summary>
        /// Get Aka by Show id
        /// </summary>
        /// <param name="aka"></param>
        /// <returns>Aka list</returns>
        public async Task<CustomResponse> GetAkaByShow(GeneralRequest aka)
        {
            CustomResponse response = new CustomResponse();

            try
            {
                List<Aka>? akasList = _repository.GetAkas(aka.showId);
                response.response = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.OK };
                response.data = akasList;

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
