using DevsTutorialCenterMVC.Models;
using System.Collections.Generic;

namespace DevsTutorialCenterMVC.Services
{
    public class BlogPostService : BaseService, IBlogPostService
    {
        public BlogPostService(HttpClient client, IConfiguration config) : base(client, config)
        {
        }

        public async Task<IEnumerable<GetAllArticlesViewModel>> LatestPosts()
        {
            var address = "/api/articles/get-all-articles?Page=1&Size=6";
            var methodType = "GET";

            var result = await MakeRequest<ResponseObject <PaginatorResponseViewModel< IEnumerable < GetAllArticlesViewModel>>>, string>(address, methodType, "", "");
            if (result != null && result.Data.PageItems != null)
            {

                var mappedResult = result.Data.PageItems.Select(x => new GetAllArticlesViewModel
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    ImageUrl = x.ImageUrl,
                    CreatedOn = x.CreatedOn,
                    Tag = x.Tag,
                    Text = x.Text,
                    Title = x.Title,
                    
                });

                return mappedResult;


            }
            return null;
        }

        public async Task<IEnumerable<GetAllArticlesViewModel>> Popular()
        {
            var address = "/api/articles/get-all-articles?Page=1&Size=2&IsRecommended=true";
            var methodType = "GET";

            var result = await MakeRequest<ResponseObject<PaginatorResponseViewModel<IEnumerable<GetAllArticlesViewModel>>>, string>(address, methodType, "", "");
            if (result != null)
            {

                var mappedResult = result.Data.PageItems.Select(x => new GetAllArticlesViewModel
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    ImageUrl = x.ImageUrl,
                    CreatedOn = x.CreatedOn,
                    Tag = x.Tag,
                    Text = x.Text,
                    Title = x.Title,

                });

                return mappedResult;


            }
            return null;
        }

        public async Task<IEnumerable<GetAllArticlesViewModel>> TrendingPosts()
        {
            var address = "/api/articles/get-all-articles?Page=1&Size=2&IsTrending=true";
            var methodType = "GET";

            var result = await MakeRequest<ResponseObject<PaginatorResponseViewModel<IEnumerable<GetAllArticlesViewModel>>>, string>(address, methodType, "", "");
            if (result != null)
            {

                var mappedResult = result.Data.PageItems.Select(x => new GetAllArticlesViewModel
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    ImageUrl = x.ImageUrl,
                    CreatedOn = x.CreatedOn,
                    Tag = x.Tag,
                    Text = x.Text,
                    Title = x.Title,

                });

                return mappedResult;


            }
            return null;
        }
    }
}
