using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TvMazeApi.Interfaces;
using TvMazeApi.Models;

namespace TvMazeApi.Controllers
{
    /// <summary>
    /// Season Controller
    /// </summary>
    /// <param name="service"></param>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "ApiKeyPolicy")]
    public class SeasonController(IGetSeasonService service) : ControllerBase
    {
        private readonly IGetSeasonService _service = service;

        /// <summary>
        /// Get seasons by show id
        /// </summary>
        /// <param name="showId"></param>
        /// <returns>Seasons list</returns>
        [HttpPost]
        [Route("getSeasons")]
        public async Task<CustomResponse> GetSeasons([FromBody]GeneralRequest showId) => await _service.GetSeasonsByShow(showId);
    }
}
