using DevsTutorialCenterMVC.Models;
using DevsTutorialCenterMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DevsTutorialCenterMVC.Controllers;

[Route("articles")]
public class ArticlesController: Controller
{
    private readonly BlogPostService _blogPostService;
    private readonly TagService _tagService;
    private readonly AuthorService _authorService;

    public ArticlesController(BlogPostService blogPostService, TagService tagService, AuthorService authorService)
    {
        _blogPostService = blogPostService;
        _tagService = tagService;
        _authorService = authorService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingleArticle([FromRoute] string id)
    {
        var article = await _blogPostService.GetArticleById(id);

        var model = new SingleArticlePageVM
        {
            Article = article,
            Authors = (await _authorService.GetAllAuthorsAsync()).Take(3),
            Tags = await _tagService.AllTags(),
            MoreArticles = await _authorService.GetAuthorById(article.AuthorId)
        };
        
        return View(model);
    }
}