using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TvMazeApi.Interfaces;
using TvMazeApi.Models;

namespace TvMazeApi.Controllers
{
    /// <summary>
    /// Get Episodes Controller
    /// </summary>
    /// <param name="service"></param>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "ApiKeyPolicy")]
    public class EpisodesController(IGetEpisodeService service) : ControllerBase
    {
        private readonly IGetEpisodeService _service = service;

        /// <summary>
        /// Get Episodes by Show id
        /// </summary>
        /// <param name="episode"></param>
        /// <returns>Episodes List</returns>
        [HttpPost]
        [Route("showEpisodes")]
        public async Task<CustomResponse> GetEpisodesByShowId([FromBody]GeneralRequest episode) => await _service.GetEpisodesByShow(episode);

        /// <summary>
        /// Get Episode By Season And Episode Id
        /// </summary>
        /// <param name="episode"></param>
        /// <returns>Episode</returns>
        [HttpPost]
        [Route("episodeBySeasonAndEpisodeId")]
        public async Task<CustomResponse> GetEpisodeBySeasonAndId([FromBody]GeneralRequest episode) => await _service.GetEpisodeBySeasonAndEpisode(episode);

        /// <summary>
        /// Get Espisode By Date
        /// </summary>
        /// <param name="episode"></param>
        /// <returns>Episode</returns>
        [HttpPost]
        [Route("episodesByDate")]
        public async Task<CustomResponse> GetEspisodesByDate([FromBody]GeneralRequest episode) => await _service.GetEpisodesByDate(episode);

        /// <summary>
        /// Get Episodes list By Season
        /// </summary>
        /// <param name="episode"></param>
        /// <returns>Episodes list</returns>
        [HttpPost]
        [Route("episodesBySeason")]
        public async Task<CustomResponse> GetEpisodesBySeason([FromBody]GeneralRequest episode) => await _service.GetEpisodesBySeason(episode);
    }
}
