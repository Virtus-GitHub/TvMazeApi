using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TvMazeApi.Interfaces;
using TvMazeApi.Models;

namespace TvMazeApi.Controllers
{
    /// <summary>
    /// GetShows Controller
    /// </summary>
    /// <param name="service"></param>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "ApiKeyPolicy")]
    public class ShowsController(IGetShowService service) : ControllerBase
    {
        private readonly IGetShowService _service = service;

        /// <summary>
        /// Get All Shows
        /// </summary>
        /// <returns>List all Shows</returns>
        [HttpGet]
        [Route("getShows")]
        public async Task<CustomResponse> GetAllShows() => await _service.GetAllShowsData();

        /// <summary>
        /// Get Show By Id
        /// </summary>
        /// <param name="showId"></param>
        /// <returns>Show filtered by id</returns>
        [HttpPost]
        [Route("getShowsById")]
        public async Task<CustomResponse> GetShowById([FromBody]GeneralRequest showId) => await _service.GetShowById(showId);
    }
}
