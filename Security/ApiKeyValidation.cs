using TvMazeApi.Interfaces;
using TvMazeApi.Models;

namespace TvMazeApi.Utils
{
    /// <summary>
    /// Api Key Validation
    /// </summary>
    /// <param name="_configuration"></param>
    public class ApiKeyValidation(IConfiguration _configuration) : IApiKeyValidation
    {
        private readonly IConfiguration configuration = _configuration;

        /// <summary>
        /// Checks if is a valid api key
        /// </summary>
        /// <param name="userApiKey"></param>
        /// <returns></returns>
        public bool IsValidApiKey(string userApiKey)
        {
            if (string.IsNullOrWhiteSpace(userApiKey))
                return false;

            string? apiKey = configuration.GetValue<string>(Constants.ApiKeyName);

            if (apiKey == null || apiKey != userApiKey)
                return false;

            return true;
        }
    }
}
