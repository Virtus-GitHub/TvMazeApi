using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using TvMazeApi.Interfaces;
using TvMazeApi.Models;

namespace TvMazeApi.Services
{
    /// <summary>
    /// UpdateShowsFile Service
    /// </summary>
    /// <param name="context"></param>
    public class UpdateFilesService(IHttpContextAccessor context) : IUpdateFilesService
    {
        private readonly IHttpContextAccessor _context = context;

        /// <summary>
        /// Update the files selected
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="name"></param>
        /// <returns>Information of result</returns>
        public async Task<CustomResponse> UpdateFile(string folder, string name)
        {
            try
            {
                int page = _context.HttpContext.Session.GetPage<int>("Page") ?? 0;

                var client = new HttpClient();
                var basePath = AppDomain.CurrentDomain.BaseDirectory;

                List<Show>? content = new List<Show>();

                content = await GetShowsCountFromUrl(page);
                int numberShows = content.Count;

                if (numberShows == 0)
                {
                    var showsPath = Path.Combine(basePath, "shows.csv");

                    if (File.Exists(showsPath)) {
                        content = GetShowsCountFromFile(showsPath);
                        numberShows = content.Count;
                    }
                }

                if (numberShows > 0)
                {
                    List<int?> idx = content.Distinct().Select(s => s.id).ToList();

                    var dataPath = Path.Combine(basePath, folder);

                    if (Directory.Exists(dataPath))
                    {
                        var dir = new DirectoryInfo(dataPath);
                        dir.Delete(true);
                    }

                    Directory.CreateDirectory(dataPath);

                    for (int i = 0; i < idx.Count; i++)
                    {
                        var finalPath = Path.Combine(dataPath, $"show{idx[i]}.csv");

                        try
                        {
                            var data = await client.GetStringAsync($"https://api.tvmaze.com/shows/{idx[i]}/{name}");

                            File.WriteAllText(finalPath, data);
                        }
                        catch
                        {
                        }
                    }
                }
                else
                {
                    return new CustomResponse() { response = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.NotFound }, data = $"There is no {name} files created" };
                }

                return new CustomResponse() { response = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.OK }, data = $"Files of {name} have been created" };
            }
            catch (Exception ex)
            {
                return new CustomResponse() { response = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.InternalServerError }, data = ex.Message };
            }
        }

        /// <summary>
        /// Method where the file shows.csv is updated or created, if page is not selected will use page 0
        /// </summary>
        /// <param name="page"></param>
        /// <returns>Message with response information</returns>
        public async Task<CustomResponse> UpdateShowsFile(int page)
        {
            try
            {
                _context.HttpContext.Session.SetPage("Page", page);

                var client = new HttpClient();

                var content = await client.GetStringAsync($"https://api.tvmaze.com/shows?page={page}");

                var basePath = AppDomain.CurrentDomain.BaseDirectory;
                var finalPath = Path.Combine(basePath, "shows.csv");

                List<Show>? allShows = new List<Show>();

                if (content != null)
                {
                    if (File.Exists(finalPath))
                        File.Delete(finalPath);

                    File.WriteAllText(finalPath, content);
                }

                if (File.Exists(finalPath))
                {
                    var showsFromFile = File.ReadAllText(finalPath);

                    allShows = JsonConvert.DeserializeObject<List<Show>>(showsFromFile);
                }

                return new CustomResponse() { response = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.OK }, data = "Shows file had been created/updated" };
            }
            catch (Exception ex)
            {
                return new CustomResponse() { response = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.InternalServerError }, data = ex.Message };
            }
        }

        private async Task<List<Show>?> GetShowsCountFromUrl(int page)
        {
            var client = new HttpClient();
            var basePath = AppDomain.CurrentDomain.BaseDirectory;

            try
            {
                return await client.GetFromJsonAsync<List<Show>>($"https://api.tvmaze.com/shows?page={page}");
            }
            catch (Exception)
            {
                return null;
            }
        }

        private List<Show>? GetShowsCountFromFile(string showsPath)
        {
            try
            {
                var showsFromFile = File.ReadAllText(showsPath);

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