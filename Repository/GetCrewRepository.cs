using Newtonsoft.Json;
using TvMazeApi.Interfaces;
using TvMazeApi.Models;

namespace TvMazeApi.Repository
{
    /// <summary>
    /// Get Crew Repository
    /// </summary>
    public class GetCrewRepository : IGetCrewRepository
    {
        /// <summary>
        /// Get Crews from file
        /// </summary>
        /// <param name="showId"></param>
        /// <returns>Crews list</returns>
        /// <exception cref="Exception"></exception>
        public List<Crew>? GetCrews(int showId)
        {
            try
            {
                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                var finalPath = Path.Combine(basePath, "Crew");

                finalPath = Path.Combine(finalPath, $"show{showId}.csv");

                var crews = File.ReadAllText(finalPath);

                List<Crew>? crewList = JsonConvert.DeserializeObject<List<Crew>>(crews);

                return crewList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
