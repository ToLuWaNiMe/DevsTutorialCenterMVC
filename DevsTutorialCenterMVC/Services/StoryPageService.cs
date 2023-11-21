using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Models.Components;
using DevsTutorialCenterMVC.Services.Interfaces;

namespace DevsTutorialCenterMVC.Services
{
    public class StoryPageService : BaseService
    {
        public StoryPageService(HttpClient client, IHttpContextAccessor httpContextAccessor, IConfiguration config) : base(client, httpContextAccessor, config)
        {
        }


        public async Task<IEnumerable<StoryArticlesVM>> PendingArticlesAsync()
        {

            return new List<StoryArticlesVM>()
            {
                new()
                {
                    SubmittedOn = "21, Jun 2023",
                    Id = "",
                    ImageUrl = "",
                    Tag = new TagViewModel{ Name = "JAVA", Id ="", },
                    Text = "jbsjvjdvdn vnndin vnnnoso mvbu sbb n djd ihllgvvsf c. nkncjb ns.",
                    Title = "THE SOLUTION FOR AFRICA",
                    
                },

                new()
                {
                    SubmittedOn = "21, Jun 2023",
                    Id = "",
                    ImageUrl = "",
                    Tag = new TagViewModel{ Name = "JAVA", Id ="", },
                    Text = "jbsjvjdvdn vnndin vnnnoso mvbu sbb n djd ihllgvvsf c. nkncjb ns.",
                    Title = "THE SOLUTION FOR AFRICA",
                },

                new()
                {
                    SubmittedOn = "21, Jun 2023",
                    Id = "",
                    ImageUrl = "",
                    Tag = new TagViewModel{ Name = "JAVA", Id ="", },
                    Text = "jbsjvjdvdn vnndin vnnnoso mvbu sbb n djd ihllgvvsf c. nkncjb ns.",
                    Title = "THE SOLUTION FOR AFRICA",
                },
            };
        }

    }
}
