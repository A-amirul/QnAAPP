using QnAApp.Application.Interfaces;
using QnAApp.Domain.Entities;
using QnAApp.Infrastructure.Data;

namespace QnAApp.Infrastructure.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly AppDbContext _db;

    public CommentRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task AddAsync(Comment c)
    {
        _db.Comments.Add(c);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var data = await _db.Comments.FindAsync(id);
        if (data != null)
        {
            _db.Comments.Remove(data);
            await _db.SaveChangesAsync();
        }
    }
}