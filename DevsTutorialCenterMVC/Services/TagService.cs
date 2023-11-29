using DevsTutorialCenterMVC.Models.Components;
using DevsTutorialCenterMVC.Models;
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
            var address = "/api/tags/get-all-tag";
            var methodType = "GET";

            var result = await MakeRequest<ResponseObject<IEnumerable<TagViewModel>>, string>(address, methodType, "", "");
            if (result != null)
            {

                var mappedResult = result.Data.Select(x => new TagViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                });

                return mappedResult;

            }
            return Enumerable.Empty<TagViewModel>();
        }
    }
}
