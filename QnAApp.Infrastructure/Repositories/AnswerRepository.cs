using QnAApp.Application.Interfaces;
using QnAApp.Domain.Entities;
using QnAApp.Infrastructure.Data;

namespace QnAApp.Infrastructure.Repositories;

public class AnswerRepository : IAnswerRepository
{
    private readonly AppDbContext _db;

    public AnswerRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task AddAsync(Answer a)
    {
        _db.Answers.Add(a);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var data = await _db.Answers.FindAsync(id);
        if (data != null)
        {
            _db.Answers.Remove(data);
            await _db.SaveChangesAsync();
        }
    }
}