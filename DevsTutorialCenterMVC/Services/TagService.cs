
﻿using DevsTutorialCenterMVC.Models.Components;
using DevsTutorialCenterMVC.Models;

using DevsTutorialCenterMVC.Services.Interfaces;

namespace DevsTutorialCenterMVC.Services
{

    public class TagService : BaseService, ITagService
    {
        public TagService(HttpClient client, IHttpContextAccessor httpContextAccessor, IConfiguration config) : base(
       client, httpContextAccessor, config)
        {
        }

        public async Task<IEnumerable<GetAllTagsViewModel>> GetAllTagsAsync()
        {
            var address = "/api/tags/get-all-tag";
            var methodType = "GET";


            var result =
                await MakeRequest<ResponseObject<IEnumerable<GetAllTagsViewModel>>, string>(address, methodType, "", "");
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


    }


}
