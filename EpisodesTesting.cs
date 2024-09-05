using TvMazeApi.Controllers;
using TvMazeApi.Interfaces;
using TvMazeApi.Models;
using TvMazeApi.Services;

namespace TvMazeTest
{
    public class EpisodesTesting
    {
        private readonly EpisodesController controller;
        private readonly IGetEpisodeService service;

        public EpisodesTesting()
        {
            service = new GetEpisodeService();
            controller = new EpisodesController(service);
        }

        [Fact]
        public void GetEpisodesByShowIdTesting()
        {
            int id = 1;
            var result = controller.GetEpisodesByShowId(id);

            try
            {
                Assert.IsType<List<Episode>?>(result?.Result.data);
            }
            catch (Exception)
            {
                Assert.IsType<HttpResponseMessage>(result?.Result.response);
            }
        }

        [Fact]
        public void GetEpisodeBySeasonAndIdTesting()
        {
            int idshow = 1;
            int seasonId = 1;
            int idEpsisode = 1;

            var result = controller.GetEpisodeBySeasonAndId(idshow, seasonId, idEpsisode);

            try
            {
                Assert.IsType<Episode?>(result?.Result.data);
            }
            catch (Exception)
            {
                Assert.IsType<HttpResponseMessage>(result?.Result.response);
            }
        }

        [Fact]
        public void GetEspisodesByDateTesting()
        {
            int showId = 1;
            DateTime date = DateTime.Now;

            var result = controller.GetEspisodesByDate(showId, date);

            try
            {
                Assert.IsType<List<Episode>?> (result?.Result.data);
            }
            catch (Exception)
            {
                Assert.IsType<HttpResponseMessage>(result?.Result.response);
            }
        }

        [Fact]
        public void GetEpisodesBySeasonTesting()
        {
            int showId = 1;
            int season = 1;

            var result = controller.GetEpisodesBySeason(showId, season);

            try
            {
                Assert.IsType<List<Episode>?>(result?.Result.data);
            }
            catch (Exception)
            {
                Assert.IsType<HttpResponseMessage>(result?.Result.response);
            }
        }
    }
}
