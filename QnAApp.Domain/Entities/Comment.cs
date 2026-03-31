namespace QnAApp.Domain.Entities;

public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; } = "";

    public int AnswerId { get; set; }
    public string UserId { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public Answer Answer { get; set; }
}