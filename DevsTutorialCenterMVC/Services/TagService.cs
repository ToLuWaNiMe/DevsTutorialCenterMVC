using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Models.Components;
using DevsTutorialCenterMVC.Services.Interfaces;

namespace DevsTutorialCenterMVC.Services
{
    public class TagService : BaseService
    {
        public TagService(HttpClient client, IHttpContextAccessor httpContextAccessor, IConfiguration config) : base(client, httpContextAccessor, config)
        {
        }

        public async Task<IEnumerable<TagViewModel>> AllTags()
        {
            //var address = "/api/tags/get-all-tag";
            //var methodType = "GET";

            //var result = await MakeRequest<ResponseObject<IEnumerable<TagViewModel>>, string>(address, methodType, "", "");
            //if (result != null)
            //{

            //    var mappedResult = result.Data.Select(x => new TagViewModel
            //    {
            //        Id = x.Id,
            //        Name = x.Name,

            //    });

            //    return mappedResult;


            //}
            //return new List<TagViewModel>();

            return new List<TagViewModel>()
            {
                new()
                {
                    Id = "",
                    Name = "JAVA",
                },
                new()
                {
                    Id = "",
                    Name = "NODEJS",
                },
                new()
                {
                    Id = "",
                    Name = "DOTNET",
                },
                new()
                {
                    Id = "",
                    Name = "REACT",
                },
                new()
                {
                    Id = "",
                    Name = "PYTHON",
                },
                new()
                {
                    Id = "",
                    Name = "C#",
                },
                new()
                {
                    Id = "",
                    Name = "ANGULAR",
                },
                new()
                {
                    Id = "",
                    Name = "PHP",
                },
                new()
                {
                    Id = "",
                    Name = "DOTNET",
                },
                new()
                {
                    Id = "",
                    Name = "REACT",
                },
                new()
                {
                    Id = "",
                    Name = "PYTHON",
                },
                new()
                {
                    Id = "",
                    Name = "C#",
                },
                new()
                {
                    Id = "",
                    Name = "ANGULAR",
                },
                new()
                {
                    Id = "",
                    Name = "PHP",
                }
            };
        }
    }
}
