using Microsoft.AspNetCore.Mvc;
using QnAApp.Application.Services;
using QnAApp.Domain.Entities;

namespace QnAApp.API.Controllers;

public class QuestionController : Controller
{
    private readonly QuestionService _service;

    public QuestionController(QuestionService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
        => View(await _service.GetAll());

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Question q)
    {
        await _service.Create(q);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
        => View(await _service.Get(id));

    [HttpPost]
    public async Task<IActionResult> Edit(Question q)
    {
        await _service.Update(q);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}