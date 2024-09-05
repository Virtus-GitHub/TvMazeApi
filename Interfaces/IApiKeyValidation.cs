namespace TvMazeApi.Interfaces
{
    /// <summary>
    /// ApiKeyValidation interface
    /// </summary>
    public interface IApiKeyValidation
    {
        bool IsValidApiKey(string userApiKey);
    }
}
