using Newtonsoft.Json;
using TvMazeApi.Interfaces;
using TvMazeApi.Models;

namespace TvMazeApi.Repository
{
    /// <summary>
    /// Get Show Repository
    /// </summary>
    public class GetShowRepository : IGetShowRepository
    {
        /// <summary>
        /// GetShow
        /// </summary>
        /// <param name="showId"></param>
        /// <returns>show</returns>
        /// <exception cref="Exception"></exception>
        public Show? GetShow(int showId)
        {
            try
            {
                List<Show>? allShows = GetShows();

                Show? showById = allShows?.Where(s => s.id == showId).FirstOrDefault();

                return showById;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get Shows from file
        /// </summary>
        /// <returns>show list</returns>
        /// <exception cref="Exception"></exception>
        public List<Show>? GetShows()
        {
            try
            {
                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                var finalPath = Path.Combine(basePath, "shows.csv");

                var showsFromFile = File.ReadAllText(finalPath);

                List<Show>? allShows = JsonConvert.DeserializeObject<List<Show>>(showsFromFile);

                return allShows;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
