using Newtonsoft.Json;
using TvMazeApi.Interfaces;
using TvMazeApi.Models;

namespace TvMazeApi.Repository
{
    /// <summary>
    /// Get Casting Repository
    /// </summary>
    public class GetCastingRepository : IGetCastingRepository
    {
        /// <summary>
        /// Get Castings from file
        /// </summary>
        /// <param name="showId"></param>
        /// <returns>Castings list</returns>
        /// <exception cref="Exception"></exception>
        public List<Casting>? GetCastings(int showId)
        {
            try
            {
                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                var finalPath = Path.Combine(basePath, "Casting");

                finalPath = Path.Combine(finalPath, $"show{showId}.csv");

                var castings = File.ReadAllText(finalPath);

                List<Casting>? castingList = JsonConvert.DeserializeObject<List<Casting>>(castings);

                return castingList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
