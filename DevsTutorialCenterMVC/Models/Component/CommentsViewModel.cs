namespace DevsTutorialCenterMVC.Models.Component
{
    public class CommentsViewModel
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string UserId { get; set; }
        public string ArticleId { get; set; }
        public DateTime CreatedOn { get; set; }

        public IEnumerable<CommentsViewModel> Comments { get; set; }
    }
}
