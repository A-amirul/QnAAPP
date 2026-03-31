using QnAApp.Domain.Entities;

namespace QnAApp.Application.Interfaces;

public interface ICommentRepository
{
    Task AddAsync(Comment c);
    Task DeleteAsync(int id);
    Task<Comment?> GetByIdAsync(int id);
    Task UpdateAsync(Comment c);
}