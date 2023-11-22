namespace DevsTutorialCenterMVC.Models.Api
{
    public class CreateArticleDto
    {

        public string Title { get; set; }
        public string Text { get; set; }

        public string TagId { get; set; }

        public string ImageUrl { get; set; }
        public string PublicId { get; set; }

    }
}
