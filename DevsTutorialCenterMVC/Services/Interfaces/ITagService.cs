using DevsTutorialCenterMVC.Models;

namespace DevsTutorialCenterMVC.Services.Interfaces
{
    public interface ITagService
    {
        Task<IEnumerable<GetAllTagsViewModel>> GetAllTagsAsync();
    }
}
