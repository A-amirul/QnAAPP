using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public Question Question { get; set; }
    public string CurrentUserId { get; set; }

    [BindProperty]
    public Answer NewAnswer { get; set; }

    [BindProperty]
    public Comment NewComment { get; set; }

    public DetailsModel(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Question = await _context.Questions
            .Include(q => q.User)
            .Include(q => q.Answers).ThenInclude(a => a.User)
            .Include(q => q.Comments).ThenInclude(c => c.User)
            .FirstOrDefaultAsync(q => q.Id == id);

        if (Question == null) return NotFound();
        CurrentUserId = _userManager.GetUserId(User);
        return Page();
    }

    public async Task<IActionResult> OnPostAnswerAsync(int id)
    {
        if (!ModelState.IsValid) return await OnGetAsync(id);
        var user = await _userManager.GetUserAsync(User);
        NewAnswer.UserId = user.Id;
        NewAnswer.QuestionId = id;
        _context.Answers.Add(NewAnswer);
        await _context.SaveChangesAsync();
        return RedirectToPage(new { id });
    }

    public async Task<IActionResult> OnPostCommentAsync(int id)
    {
        if (!ModelState.IsValid) return await OnGetAsync(id);
        var user = await _userManager.GetUserAsync(User);
        NewComment.UserId = user.Id;
        NewComment.QuestionId = id;
        _context.Comments.Add(NewComment);
        await _context.SaveChangesAsync();
        return RedirectToPage(new { id });
    }

    public async Task<IActionResult> OnPostAcceptAsync(int id, int answerId)
    {
        var question = await _context.Questions.FindAsync(id);
        var userId = _userManager.GetUserId(User);
        if (question.UserId != userId) return Forbid();
        question.AcceptedAnswerId = answerId;
        await _context.SaveChangesAsync();
        return RedirectToPage(new { id });
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        var question = await _context.Questions.FindAsync(id);
        var userId = _userManager.GetUserId(User);
        if (question.UserId != userId) return Forbid();
        _context.Questions.Remove(question);
        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}