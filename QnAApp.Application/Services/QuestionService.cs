using QnAApp.Application.Interfaces;
using QnAApp.Domain.Entities;

namespace QnAApp.Application.Services;

public class QuestionService
{
    private readonly IQuestionRepository _repo;

    public QuestionService(IQuestionRepository repo)
    {
        _repo = repo;
    }

    public Task<List<Question>> GetAll() => _repo.GetAllAsync();
    public Task<Question?> Get(int id) => _repo.GetByIdAsync(id);
    public Task Create(Question q) => _repo.AddAsync(q);
    public async Task Update(Question q)
    {
        q.UpdatedAt = DateTime.Now;
        await _repo.UpdateAsync(q);
    }
    public Task Delete(int id) => _repo.DeleteAsync(id);
}