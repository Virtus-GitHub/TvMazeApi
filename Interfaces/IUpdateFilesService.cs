using TvMazeApi.Models;

namespace TvMazeApi.Interfaces
{
    /// <summary>
    /// UpdateShowsFileService interface
    /// </summary>
    public interface IUpdateFilesService
    {
        /// <summary>
        /// Update the files selected
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="name"></param>
        /// <returns>Information of result</returns>
        Task<CustomResponse> UpdateFile(string folder, string name);
        /// <summary>
        /// Update Shows file
        /// </summary>
        /// <returns>Code Response and Data with information</returns>
        Task<CustomResponse> UpdateShowsFile(int page);
    }
}
