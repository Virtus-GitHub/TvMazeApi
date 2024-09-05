using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TvMazeApi.Interfaces;
using TvMazeApi.Models;

namespace TvMazeApi.Controllers
{
    /// <summary>
    /// Images Controller
    /// </summary>
    /// <param name="service"></param>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "ApiKeyPolicy")]
    public class ImagesController(IGetImagesService service) : ControllerBase
    {
        private readonly IGetImagesService _service = service;

        /// <summary>
        /// Get Images by show
        /// </summary>
        /// <param name="image"></param>
        /// <returns>Images data list</returns>
        [HttpPost]
        [Route("imagesByShow")]
        public async Task<CustomResponse> GetImages([FromBody]GeneralRequest image) => await _service.GetImagesByShow(image);
    }
}
