using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TvMazeApi.Interfaces;
using TvMazeApi.Models;

namespace TvMazeApi.Controllers
{
    /// <summary>
    /// Aka Controller
    /// </summary>
    /// <param name="service"></param>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "ApiKeyPolicy")]
    public class AkaController(IGetAkaService service) : ControllerBase
    {
        private readonly IGetAkaService _service = service;

        /// <summary>
        /// Get Aka by Show
        /// </summary>
        /// <param name="aka"></param>
        /// <returns>Aka list</returns>
        [HttpPost]
        [Route("akaByShowId")]
        public async Task<CustomResponse> GetAkaByShow(GeneralRequest aka) => await _service.GetAkaByShow(aka);
    }
}
