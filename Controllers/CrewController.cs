using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TvMazeApi.Interfaces;
using TvMazeApi.Models;

namespace TvMazeApi.Controllers
{
    /// <summary>
    /// Crew Controller
    /// </summary>
    /// <param name="service"></param>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "ApiKeyPolicy")]
    public class CrewController(IGetCrewService service) : ControllerBase
    {
        private readonly IGetCrewService _service = service;

        /// <summary>
        /// Get crews by show id
        /// </summary>
        /// <param name="crew"></param>
        /// <returns>Crews list</returns>
        [HttpPost]
        [Route("crewByShow")]
        public async Task<CustomResponse> GetCrews([FromBody]GeneralRequest crew) => await _service.GetCrewsByShow(crew);
    }
}
