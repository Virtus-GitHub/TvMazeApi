using TvMazeApi.Interfaces;
using TvMazeApi.Models;

namespace TvMazeApi.Services
{
    /// <summary>
    /// Get Season Service
    /// </summary>
    /// <param name="repository"></param>
    public class GetSeasonService(IGetSeasonRepository repository) : IGetSeasonService
    {
        private readonly IGetSeasonRepository _repository = repository;

        /// <summary>
        /// Get Seasons
        /// </summary>
        /// <param name="showId"></param>
        /// <returns>Seasons list</returns>
        public async Task<CustomResponse> GetSeasonsByShow(GeneralRequest showId)
        {
            CustomResponse response = new CustomResponse();

            try
            {
                List<Season>? seasonsList = _repository.GetSeasons(showId.showId);

                response.response = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.OK };
                response.data = seasonsList;

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
