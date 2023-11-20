﻿using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Models.Api;
using DevsTutorialCenterMVC.Services.Interfaces;
using DevsTutorialCenterMVC.Models.Components;

namespace DevsTutorialCenterMVC.Services;

public class BlogPostService : BaseService
{
    public BlogPostService(HttpClient client, IHttpContextAccessor httpContextAccessor, IConfiguration config) : base(client, httpContextAccessor, config)
    {
    }
        
    public async Task<IEnumerable<BlogPostVM>> GetAllArticles(FilterArticleDto? filterArticleDto = null)
    {
        var address = "/api/articles/get-all-article";
        const string methodType = "GET";

        if (filterArticleDto?.Page is not null)
            address = $"{address}?page={filterArticleDto.Page}";
            
        if (filterArticleDto?.Size is not null)
            address = $"{address}?size={filterArticleDto.Size}";
            
        if (!string.IsNullOrEmpty(filterArticleDto?.AuthorId))
            address = $"{address}?authorId={filterArticleDto.AuthorId}";

        if (!string.IsNullOrEmpty(filterArticleDto?.TagId))
            address = $"{address}?tagId={filterArticleDto.TagId}";
            
        if (filterArticleDto.IsRecentlyAdded.GetValueOrDefault())
            address = $"{address}?isRecentlyAdded={filterArticleDto.IsRecentlyAdded}";
                
        if (filterArticleDto.IsTopRead.GetValueOrDefault())
            address = $"{address}?isTopRead={filterArticleDto.IsTopRead}";

        var result = await MakeRequest<ResponseObject<IEnumerable<BlogPostVM>>, string>(address, methodType, "");
            
        if (result is null)
            return new List<BlogPostVM>();
            
        return result.Data;
    }

        public async Task<IEnumerable<BlogPostRecommendationItemVM>> GetRecommendedArticles()
        {
            var address = "/api/articles/get-all-articles?IsRecentlyAdded=true";
            var methodType = "GET";

            var result = await MakeRequest<ResponseObject<PaginatorResponseDto<IEnumerable<BlogPostRecommendationItemVM>>>, string>(address, methodType, "", "");

            if (result != null && result.Data.PageItems != null)
            {
                // Use null conditional operator to handle null checks more concisely
                var mappedResult = result.Data.PageItems.Select(x => new BlogPostRecommendationItemVM
                {
                    Id = x.Id,
                    Text = x.Text,
                    Title = x.Title,
                });

                return mappedResult;
            }

            // Use Enumerable.Empty<T>() for a more efficient empty collection
            return Enumerable.Empty<BlogPostRecommendationItemVM>();
        }

        public async Task<IEnumerable<GetAllTagsViewModel>> InterestingTopics()
        {
            var address = "/api/tags/get-all-tag";
            var methodType = "GET";

        var result = await MakeRequest<ResponseObject<IEnumerable<GetAllTagsViewModel>>, string>(address, methodType, "", "");
        if (result != null)
        {

            var mappedResult = result.Data.Select(x => new GetAllTagsViewModel
            {
                Id = x.Id,
                Name = x.Name,

            });

            return mappedResult;


        }
        return null;
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