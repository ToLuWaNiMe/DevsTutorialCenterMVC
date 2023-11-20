using DevsTutorialCenterMVC.Services.Interfaces;

namespace DevsTutorialCenterMVC.Services
{
    public class StoryPageService : BaseService
    {
        public StoryPageService(HttpClient client, IConfiguration config) : base(client, config)
        {
        }


    }
}
