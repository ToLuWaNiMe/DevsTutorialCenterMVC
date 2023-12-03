using DevsTutorialCenterMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevsTutorialCenterMVC.Controllers;

[Route("editor")]
public class EditorController : Controller
{
    private readonly EditorService _editorService;

    public EditorController(EditorService editorService)
    {
        _editorService = editorService;
    }
    
    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        var model = await _editorService.GetPendingArticles();
        return View(model);
    }
    
    [HttpPost("approve/{articleId}")]
    public async Task<IActionResult> ApproveArticle(string articleId)
    {
        var isSuccessful = await _editorService.ApproveArticle(articleId);
        if (!isSuccessful) return BadRequest();
        return RedirectToAction("Index");
    }
    
    [HttpPost("reject/{articleId}")]
    public async Task<IActionResult> RejectArticle(string articleId)
    {
        var isSuccessful = await _editorService.RejectArticle(articleId);
        if (!isSuccessful) return BadRequest();
        return RedirectToAction("Index");
    }
}