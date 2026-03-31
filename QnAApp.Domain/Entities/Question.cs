namespace QnAApp.Domain.Entities;

public class Question
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string UserId { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public ICollection<Answer> Answers { get; set; } = new List<Answer>();
}