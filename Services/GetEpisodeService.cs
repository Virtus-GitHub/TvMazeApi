using Newtonsoft.Json;
using TvMazeApi.Interfaces;
using TvMazeApi.Models;

namespace TvMazeApi.Services
{
    /// <summary>
    /// Get Episode Service
    /// </summary>
    /// <param name="repository"></param>
    public class GetEpisodeService(IGetEpisodesRepository repository) : IGetEpisodeService
    {
        private readonly IGetEpisodesRepository _repository = repository;

        /// <summary>
        /// Get Episode By Date
        /// </summary>
        /// <param name="episode"></param>
        /// <returns>Episode</returns>
        public async Task<CustomResponse> GetEpisodesByDate(GeneralRequest episode)
        {
            CustomResponse response = new CustomResponse();

            if (episode.episodeDate == null)
            {
                response.response = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.NotFound, ReasonPhrase = "Episode date can´t be empty." };

                return await Task.FromResult(response);
            }

            try
            {
                List<Episode>? episodes = GetEpisodesByShow(episode).Result.data;

                if (episodes != null)
                {
                    List<Episode>? episodesList = episodes.Where(e => e.airdate == episode.episodeDate).ToList();
                    response.response = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.OK };
                    response.data = episodesList;   
                }
                else
                {
                    response.response = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.NotFound };
                }

                return await Task.FromResult(response);
            }
            catch (Exception ex)
            {
                response.response = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.InternalServerError, ReasonPhrase = ex.Message };

                return response;
            }            
        }

        /// <summary>
        /// Get Episode By Season And Episode number
        /// </summary>
        /// <param name="episode"></param>
        /// <returns>Episode</returns>
        public async Task<CustomResponse> GetEpisodeBySeasonAndEpisode(GeneralRequest episode)
        {
            CustomResponse response = new CustomResponse();

            if (episode.seasonId == null || episode.episodeId == null) {
                response.response = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.NotFound, ReasonPhrase = "Season and episode number can´t be empty." };

                return await Task.FromResult(response);
            }
                
            try
            {
                List<Episode>? episodes = GetEpisodesByShow(episode).Result.data;

                if (episodes != null)
                {
                    Episode? episodeSelected = episodes.Where(e => e.season == episode.seasonId && e.number == episode.episodeId).FirstOrDefault();

                    response.response = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.OK };
                    response.data = episodeSelected;
                }
                else
                {
                    response.response = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.NotFound };
                }

                return await Task.FromResult(response);
            }
            catch (Exception ex)
            {
                response.response = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.InternalServerError, ReasonPhrase = ex.Message };

                return response;
            }
        }

        /// <summary>
        /// Get Episodes by show id
        /// </summary>
        /// <param name="episode"></param>
        /// <returns>Episodes of selected show</returns>
        public async Task<CustomResponse> GetEpisodesByShow(GeneralRequest episode)
        {
            CustomResponse response = new CustomResponse();

            try
            {
                List<Episode>? episodesList = _repository.GetEpisodes(episode.showId);

                response.response = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.OK };
                response.data = episodesList;

                return await Task.FromResult(response);
            }
            catch (Exception ex)
            {
                response.response = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.InternalServerError, ReasonPhrase = ex.Message };

                return response;
            }
        }

        /// <summary>
        /// Get Episode list By Season
        /// </summary>
        /// <param name="episode"></param>
        /// <returns>Episodes list</returns>
        public async Task<CustomResponse> GetEpisodesBySeason(GeneralRequest episode)
        {
            CustomResponse response = new CustomResponse();

            try
            {
                List<Episode>? episodes = GetEpisodesByShow(episode).Result.data;

                if (episodes != null)
                {
                    List<Episode>? episodeList = episodes.Where(e => e.season == episode.seasonId).ToList();

                    response.response = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.OK };
                    response.data = episodeList;

                    return await Task.FromResult(response);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                response.response = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.InternalServerError, ReasonPhrase = ex.Message };

                return response;
            }
        }
    }
}
