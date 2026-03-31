using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;
    public List<Question> Questions { get; set; }

    public IndexModel(ApplicationDbContext context) => _context = context;

    public async Task OnGetAsync()
    {
        Questions = await _context.Questions
            .Include(q => q.User)
            .Include(q => q.Answers)
            .ToListAsync();
    }
}   