namespace DevsTutorialCenterMVC.Models
{
    public class GetAllTagsDto
    {
        public GetAllTagsDto()
        {
            TagId = new List<GetAllTagsViewModel>();
        }

        public IEnumerable<GetAllTagsViewModel> TagId { get; set; }
    }
}
