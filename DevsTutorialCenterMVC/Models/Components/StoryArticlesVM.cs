namespace DevsTutorialCenterMVC.Models.Components
{
    public class StoryArticlesVM
    {
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public TagViewModel Tag { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string PublishedOn { get; set; }
        public string CreatedOn { get; set; }
        public string SubmittedOn { get; set; }
        public int NoOfLikes { get; set; }
        public int NoOfComments { get; set; }
    }
}
