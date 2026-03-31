using QnAApp.Domain.Entities;

namespace QnAApp.Application.Interfaces;

public interface IAnswerRepository
{
    Task<Answer?> GetByIdAsync(int id);
    Task UpdateAsync(Answer a);
    Task AddAsync(Answer a);
    Task DeleteAsync(int id);
}