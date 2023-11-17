using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Models.Components;

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
                       Designation = "java",
                       Image = "",
                       NumberOfArticles = 1,
                    },
                    CreatedOn = "",
                    Id = "234",
                    ImageUrl = "",
                    ReadTime = "4 mins",
                    Tag = new TagComponentViewModel{ Id = "", Name = "java"},
                    Text = "Text",
                    Title = "Title",
                },
                new()
                {
                    Author = new AuthorListItemViewModel
                    {
                       Name = "Author",
                       Designation = "java",
                       Image = "",
                       NumberOfArticles = 1,
                    },
                    CreatedOn = "",
                    Id = "234",
                    ImageUrl = "",
                    ReadTime = "4 mins",
                    Tag = new TagComponentViewModel{ Id = "", Name = "java"},
                    Text = "Text",
                    Title = "Title",
                },
                new()
                {
                    Author = new AuthorListItemViewModel
                    {
                       Name = "Author",
                       Designation = "java",
                       Image = "",
                       NumberOfArticles = 1,
                    },
                    CreatedOn = "",
                    Id = "234",
                    ImageUrl = "",
                    ReadTime = "4 mins",
                    Tag = new TagComponentViewModel{ Id = "", Name = "java"},
                    Text = "Text",
                    Title = "Title",
                }

            };

        }
    }
}
