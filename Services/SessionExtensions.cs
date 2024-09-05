namespace TvMazeApi.Services
{
    /// <summary>
    /// Gets and sets the page of shows selected
    /// </summary>
    public static class SessionExtensions
    {
        public static void SetPage(this ISession session, string key, int value)
        {
            session.SetInt32(key, value);
        }

        public static int? GetPage<T>(this ISession session, string key)
        {
            var value = session.GetInt32(key);

            return value;
        }
    }
}
