using Microsoft.AspNetCore.Mvc;
using QnAApp.Application.Interfaces;
using QnAApp.Domain.Entities;

public class CommentController : Controller
{
    private readonly ICommentRepository _repo;

    public CommentController(ICommentRepository repo)
    {
        _repo = repo;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Comment c)
    {
        c.CreatedAt = DateTime.Now;
        await _repo.AddAsync(c);
        return RedirectToAction("Index", "Question");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var data = await _repo.GetByIdAsync(id);
        return View(data);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Comment c)
    {
        await _repo.UpdateAsync(c);
        return RedirectToAction("Index", "Question");
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _repo.DeleteAsync(id);
        return RedirectToAction("Index", "Question");
    }
}