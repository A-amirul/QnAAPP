using Microsoft.EntityFrameworkCore;
using QnAApp.Application.Interfaces;
using QnAApp.Domain.Entities;
using QnAApp.Infrastructure.Data;

namespace QnAApp.Infrastructure.Repositories;

public class QuestionRepository : QnAApp.Application.Interfaces.IQuestionRepository
{
    private readonly AppDbContext _db;

    public QuestionRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<Question>> GetAllAsync()
        => await _db.Questions.Include(x => x.Answers).ToListAsync();

    public async Task<Question?> GetByIdAsync(int id)
        => await _db.Questions.Include(x => x.Answers)
                              .FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(Question q)
    {
        _db.Questions.Add(q);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(Question q)
    {
        _db.Questions.Update(q);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var data = await _db.Questions.FindAsync(id);
        if (data != null)
        {
            _db.Questions.Remove(data);
            await _db.SaveChangesAsync();
        }
    }
}