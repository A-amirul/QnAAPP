namespace QnAApp.Domain.Entities;

public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; } = "";

    public int AnswerId { get; set; }
    public string UserId { get; set; } = "";

    public Answer Answer { get; set; }
}