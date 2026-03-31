using Microsoft.AspNetCore.Mvc;
using QnAApp.Application.Interfaces;
using QnAApp.Domain.Entities;

namespace QnAApp.API.Controllers;

public class AnswerController : Controller
{
    private readonly IAnswerRepository _repo;

    public AnswerController(IAnswerRepository repo)
    {
        _repo = repo;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Answer a)
    {
        await _repo.AddAsync(a);
        return RedirectToAction("Index", "Question");
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _repo.DeleteAsync(id);
        return RedirectToAction("Index", "Question");
    }
}