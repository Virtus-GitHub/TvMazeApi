using TvMazeApi.Interfaces;
using TvMazeApi.Models;

namespace TvMazeApi.Services
{
    /// <summary>
    /// Get Show Service
    /// </summary>
    /// <param name="repository"></param>
    public class GetShowService(IGetShowRepository repository) : IGetShowService
    {
        private readonly IGetShowRepository _repository = repository;

        /// <summary>
        /// Get All shows in file/database
        /// </summary>
        /// <returns>List all Shows></returns>
        public async Task<CustomResponse> GetAllShowsData()
        {
            CustomResponse response = new CustomResponse();

            try
            {
                List<Show>? allShows = _repository.GetShows();

                response.response = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.OK };
                response.data = allShows;

                return await Task.FromResult(response);
            }
            catch (Exception ex)
            {
                response.response = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.InternalServerError, ReasonPhrase = ex.Message };

                return response;
            }
        }

        /// <summary>
        /// Get Show filtered by id
        /// </summary>
        /// <param name="showId"></param>
        /// <returns>Show selected by id</returns>
        public async Task<CustomResponse> GetShowById(GeneralRequest showId)
        {
            CustomResponse response = new CustomResponse();

            try
            {
                List<Show>? allShows = GetAllShowsData().Result.data;

                Show? showById = _repository.GetShow(showId.showId);

                response.response = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.OK };
                response.data = showById;

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
