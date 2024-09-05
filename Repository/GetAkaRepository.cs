using Newtonsoft.Json;
using TvMazeApi.Interfaces;
using TvMazeApi.Models;

namespace TvMazeApi.Repository
{
    /// <summary>
    /// Get Aka Repository
    /// </summary>
    public class GetAkaRepository : IGetAkaRepository
    {
        /// <summary>
        /// Get Akas from file
        /// </summary>
        /// <param name="showId"></param>
        /// <returns>Akas list</returns>
        /// <exception cref="Exception"></exception>
        public List<Aka>? GetAkas(int showId)
        {
            try
            {
                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                var finalPath = Path.Combine(basePath, "Aka");

                finalPath = Path.Combine(finalPath, $"show{showId}.csv");

                var akas = File.ReadAllText(finalPath);

                List<Aka>? akasList = JsonConvert.DeserializeObject<List<Aka>>(akas);

                return akasList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
