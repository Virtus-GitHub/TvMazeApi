using TvMazeApi.Controllers;
using TvMazeApi.Interfaces;
using TvMazeApi.Models;
using TvMazeApi.Services;

namespace TvMazeTest
{
    public class ShowsTesting
    {
        private readonly ShowsController controller;
        private readonly IGetShowService service;

        public ShowsTesting()
        {
            service = new GetShowService();
            controller = new ShowsController(service);
        }

        [Fact]
        public void GetAllShowsTesting()
        {
            var result = controller.GetAllShows();

            try
            {
                Assert.IsType<List<Show>?>(result?.Result.data);
            }
            catch (Exception)
            {
                Assert.IsType<HttpResponseMessage>(result?.Result.response);
            }          
        }

        [Fact]
        public void GetShowByIdTesting()
        {
            int id = 1;
            var result = controller.GetShowById(id);

            try
            {
                Assert.IsType<Show?>(result?.Result.data);
            }
            catch (Exception)
            {
                Assert.IsType<HttpResponseMessage>(result?.Result.response);
            }
        }
    }
}