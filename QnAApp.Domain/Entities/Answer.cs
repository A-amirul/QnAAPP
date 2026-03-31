namespace QnAApp.Domain.Entities;

public class Answer
{
    public int Id { get; set; }
    public string Content { get; set; } = "";

    public int QuestionId { get; set; }
    public string UserId { get; set; } = "";

    public Question Question { get; set; }
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}