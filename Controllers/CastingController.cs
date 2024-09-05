using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TvMazeApi.Interfaces;
using TvMazeApi.Models;

namespace TvMazeApi.Controllers
{
    /// <summary>
    /// Casting Controller
    /// </summary>
    /// <param name="service"></param>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "ApiKeyPolicy")]
    public class CastingController(IGetCastingService service) : ControllerBase
    {
        private readonly IGetCastingService _service = service;

        /// <summary>
        /// Get Castings by show id
        /// </summary>
        /// <param name="casting"></param>
        /// <returns>Casting list</returns>
        [HttpPost]
        [Route("castingByShow")]
        public async Task<CustomResponse> GetCastings([FromBody]GeneralRequest casting) => await _service.GetCastings(casting);
    }
}
