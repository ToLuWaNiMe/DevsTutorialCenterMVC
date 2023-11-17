using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Models.Components;
using DevsTutorialCenterMVC.Services.Interfaces;

namespace DevsTutorialCenterMVC.Services
{
    public class DashboardService : BaseService
    {
        public DashboardService(HttpClient client, IConfiguration config) : base(client, config)
        {
        }

        public async Task<IEnumerable<BlogPostListItemVM>> ReadArticles()
        {
            //var address = "/api/users/get-read-articles-by-user";
            //var methodType = "GET";

            //var result = await MakeRequest<ResponseObject<PaginatorResponseViewModel<IEnumerable<BlogPostListItemVM>>>, string>(address, methodType, "", "");
            //if(result != null && result.Data.PageItems != null )
            //{
            //    var mappedResult = result.Data.PageItems.Select(x => new BlogPostListItemVM
            //    {
            //        Author = x.Author,
            //        Id = x.Id,
            //        CreatedOn = x.CreatedOn,
            //        ImageUrl = x.ImageUrl,
            //        ReadTime = x.ReadTime,
            //        Tag = x.Tag,
            //        Text = x.Text,
            //        Title = x.Title,
            //    });

            //    return mappedResult;
            //}
            //return null;

            return new List<BlogPostListItemVM>
            {
                new()
                {
                    Author = new AuthorListItemViewModel
                    {
                       Name = "Author",
                       Designation = "UIUX Designer",
                       Image = "",
                       NumberOfArticles = 1,
                    },
                    CreatedOn = "Jun 12,2023",
                    Id = "234",
                    ImageUrl = "",
                    ReadTime = "4 mins",
                    Tag = new TagViewModel{ Id = "", Name = "java"},
                    Text = "Forem ipsum dolor sit amet, .",
                    Title = "Exploring the ",
                },                
                new()
                {
                    Author = new AuthorListItemViewModel
                    {
                       Name = "Author",
                       Designation = "UIUX Designer",
                       Image = "",
                       NumberOfArticles = 1,
                    },
                    CreatedOn = "Jun 12,2023",
                    Id = "234",
                    ImageUrl = "",
                    ReadTime = "4 mins",
                    Tag = new TagViewModel{ Id = "", Name = "java"},
                    Text = "Forem ipsum dolor sit amet, consectetur adipiscing elit. Nunc vulputate libero et velit interdum, ac aliquet odio mattis.",
                    Title = "Exploring the Evolution of Java: From Past to Present",
                },
                new()
                {
                    Author = new AuthorListItemViewModel
                    {
                       Name = "Author",
                       Designation = "UIUX Designer",
                       Image = "",
                       NumberOfArticles = 1,
                    },
                    CreatedOn = "Jun 12,2023",
                    Id = "234",
                    ImageUrl = "",
                    ReadTime = "4 mins",
                    Tag = new TagViewModel{ Id = "", Name = "java"},
                    Text = "Forem ipsum dolor sit amet, consectetur adipiscing elit. Nunc vulputate libero et velit interdum, ac aliquet odio mattis.",
                    Title = "Exploring the Evolution of Java: From Past to Present",
                }

            };

        }

        public async Task<IEnumerable<AuthorListItemViewModel>> AllAuthors()
        {
            return new List<AuthorListItemViewModel>
            {
                new()
                {
                    Name = "Ayomide Akin",
                    Designation = "UIUX Designer",
                    Image = "https://via.placeholder.com/280x204",
                    NumberOfArticles = 50,
                },
                new()
                {
                    Name = "Ayomide Akin",
                    Designation = "UIUX Designer",
                    Image = "https://via.placeholder.com/280x204",
                    NumberOfArticles = 50,
                },
                new()
                {
                    Name = "Ayomide Akin",
                    Designation = "UIUX Designer",
                    Image = "https://via.placeholder.com/280x204",
                    NumberOfArticles = 50,
                },

            };
        }
    }
}
