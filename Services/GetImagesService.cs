using Newtonsoft.Json;
using TvMazeApi.Interfaces;
using TvMazeApi.Models;

namespace TvMazeApi.Services
{
    /// <summary>
    /// Get Images Service
    /// </summary>
    /// <param name="repository"></param>
    public class GetImagesService(IGetImageRepository repository) : IGetImagesService
    {
        private readonly IGetImageRepository _repository = repository;

        /// <summary>
        /// Get Images by Show
        /// </summary>
        /// <param name="image"></param>
        /// <returns>Image of Show</returns>
        public async Task<CustomResponse> GetImagesByShow(GeneralRequest image)
        {
            CustomResponse response = new CustomResponse();

            try
            {
                List<ImageData>? imagesList = _repository.GetImages(image.showId);

                response.response = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.OK };
                response.data = imagesList;

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
