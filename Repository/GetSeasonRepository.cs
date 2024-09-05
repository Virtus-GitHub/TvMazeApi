using Newtonsoft.Json;
using TvMazeApi.Interfaces;
using TvMazeApi.Models;

namespace TvMazeApi.Repository
{
    /// <summary>
    /// Get Season Repository
    /// </summary>
    public class GetSeasonRepository : IGetSeasonRepository
    {
        /// <summary>
        /// Get Seasons
        /// </summary>
        /// <param name="showId"></param>
        /// <returns>Season list</returns>
        /// <exception cref="Exception"></exception>
        public List<Season>? GetSeasons(int showId)
        {
            CustomResponse response = new CustomResponse();

            try
            {
                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                var finalPath = Path.Combine(basePath, "Seasons");

                finalPath = Path.Combine(finalPath, $"show{showId}.csv");

                var seasons = File.ReadAllText(finalPath);

                List<Season>? seasonsList = JsonConvert.DeserializeObject<List<Season>>(seasons);

                return seasonsList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
