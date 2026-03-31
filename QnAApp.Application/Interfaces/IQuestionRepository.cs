using QnAApp.Domain.Entities;

namespace QnAApp.Application.Interfaces;

public interface IQuestionRepository
{
    Task<List<Question>> GetAllAsync();
    Task<Question?> GetByIdAsync(int id);
    Task AddAsync(Question q);
    Task UpdateAsync(Question q);
    Task DeleteAsync(int id);
}