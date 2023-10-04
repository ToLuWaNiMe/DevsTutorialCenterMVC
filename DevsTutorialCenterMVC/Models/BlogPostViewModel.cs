namespace DevsTutorialCenterMVC.Models
{
    public class BlogPostViewModel
    {
      public   IEnumerable<GetAllArticlesViewModel> TrendingPostsViewModels { get; set; } = new List<GetAllArticlesViewModel>();
        public  IEnumerable<GetAllArticlesViewModel> GetAllArticlesViewModels { get; set; } = new List<GetAllArticlesViewModel>();
        public IEnumerable<GetAllArticlesViewModel> PopularViewModels { get; set; } = new List<GetAllArticlesViewModel>();
        public IEnumerable<GetAllTagsViewModel> InterestingTopicsViewModels { get; set; } = new List<GetAllTagsViewModel>();
        public PaginatorResponseViewModel<IEnumerable<GetAllAccountViewModel>> GetAllAuthors { get; set; }
    }
}
