using Newtonsoft.Json;
using TvMazeApi.Interfaces;
using TvMazeApi.Models;

namespace TvMazeApi.Repository
{
    /// <summary>
    /// Get Episodes Repository
    /// </summary>
    public class GetEpisodesRepository : IGetEpisodesRepository
    {
        /// <summary>
        /// Get Episodes from file
        /// </summary>
        /// <param name="showId"></param>
        /// <returns>Episodes list</returns>
        /// <exception cref="Exception"></exception>
        public List<Episode>? GetEpisodes(int showId)
        {
            try
            {
                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                var finalPath = Path.Combine(basePath, "Episodes");

                finalPath = Path.Combine(finalPath, $"show{showId}.csv");

                var episodes = File.ReadAllText(finalPath);

                List<Episode>? episodesList = JsonConvert.DeserializeObject<List<Episode>>(episodes);

                return episodesList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
