using Microsoft.AspNetCore.Mvc;
using TvMazeApi.Interfaces;
using TvMazeApi.Models;

namespace TvMazeApi.Controllers
{
    /// <summary>
    /// UpdateShowsFile Controller
    /// </summary>
    /// <param name="service"></param>
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateFilesController(IUpdateFilesService service) : ControllerBase
    {
        private readonly IUpdateFilesService _service = service;
        /// <summary>
        /// Update the file with shows of the page selected
        /// </summary>
        /// <returns>Code Response and Data with information</returns>
        [HttpPost]
        [Route("updateShows/{page}")]
        public async Task<CustomResponse> UpdateShows(int page = 0) => await _service.UpdateShowsFile(page);

        /// <summary>
        /// Update the files with episodes data
        /// </summary>
        /// <returns>Code Response and Data with information</returns>
        [HttpPost]
        [Route("updateEpisodes")]
        public async Task<CustomResponse> UpdateEpisodes() => await _service.UpdateFile(FileType.episodesFolder, FileType.episodesName);

        /// <summary>
        /// Update the files with seasons data
        /// </summary>
        /// <returns>Code Response and Data with information</returns>
        [HttpPost]
        [Route("updateSeasons")]
        public async Task<CustomResponse> UpdateSeasons() => await _service.UpdateFile(FileType.seasonsFolder, FileType.seasonsName);

        /// <summary>
        /// Update the files with Casting data
        /// </summary>
        /// <returns>Code Response and Data with information</returns>
        [HttpPost]
        [Route("updateCasting")]
        public async Task<CustomResponse> UpdateCasting() => await _service.UpdateFile(FileType.castingFolder, FileType.castingName);

        /// <summary>
        /// Update the files with Crew data
        /// </summary>
        /// <returns>Code Response and Data with information</returns>
        [HttpPost]
        [Route("updateCrew")]
        public async Task<CustomResponse> UpdateCrew() => await _service.UpdateFile(FileType.crewFolder, FileType.crewName);

        /// <summary>
        /// Update the files with Aka data
        /// </summary>
        /// <returns>Code Response and Data with information</returns>
        [HttpPost]
        [Route("updateAka")]
        public async Task<CustomResponse> UpdateAka() => await _service.UpdateFile(FileType.akaFolder, FileType.akaName);
        /// <summary>
        /// Update the files with Images data
        /// </summary>
        /// <returns>Code Response and Data with information</returns>
        [HttpPost]
        [Route("updateImages")]
        public async Task<CustomResponse> UpdateImages() => await _service.UpdateFile(FileType.imagesFolder, FileType.imagesName);
    }
}
