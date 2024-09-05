namespace TvMazeApi.Models
{
    /// <summary>
    /// Response customized
    /// </summary>
    public class CustomResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public HttpResponseMessage response { get; set; }
        public dynamic? data { get; set; }
    }
}
