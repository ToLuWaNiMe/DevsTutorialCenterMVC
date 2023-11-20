using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Models.Components;
using DevsTutorialCenterMVC.Services.Interfaces;

namespace DevsTutorialCenterMVC.Services
{
    public class StoryPageService : BaseService
    {
        public StoryPageService(HttpClient client, IConfiguration config) : base(client, config)
        {
        }


        public async Task<IEnumerable<StoryArticlesVM>> PendingArticlesAsync()
        {
            //var address = "/api/articles/pending-articles";
            //var methodType = "GET";

            //var result = await MakeRequest<ResponseObject<PaginatorResponseViewModel<IEnumerable<StoryArticlesVM>>>, string>(address, methodType, "", "");
            //if (result != null)
            //{

            //    var mappedResult = result.Data.PageItems.Select(x => new StoryArticlesVM
            //    {
            //        Id = x.Id,
            //        ImageUrl = x.ImageUrl,
            //        CreatedOn = x.CreatedOn,
            //        Tag = x.Tag,
            //        Text = x.Text,
            //        Title = x.Title,
            //        SubmittedOn = x.SubmittedOn,

            //    });

            //    return mappedResult;


            //}
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
