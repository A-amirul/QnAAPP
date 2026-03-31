using QnAApp.Domain.Entities;

namespace QnAApp.Application.Interfaces;

public interface IAnswerRepository
{
    Task AddAsync(Answer a);
    Task DeleteAsync(int id);
}