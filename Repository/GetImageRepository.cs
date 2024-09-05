using Newtonsoft.Json;
using TvMazeApi.Interfaces;
using TvMazeApi.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TvMazeApi.Repository
{
    /// <summary>
    /// Get Image Repository
    /// </summary>
    public class GetImageRepository : IGetImageRepository
    {
        /// <summary>
        /// Get Images from file
        /// </summary>
        /// <param name="showId"></param>
        /// <returns>Images list</returns>
        /// <exception cref="Exception"></exception>
        public List<ImageData>? GetImages(int showId)
        {
            try
            {
                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                var finalPath = Path.Combine(basePath, "Images");

                finalPath = Path.Combine(finalPath, $"show{showId}.csv");

                var images = File.ReadAllText(finalPath);

                List<ImageData>? imagesList = JsonConvert.DeserializeObject<List<ImageData>>(images);

                return imagesList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
