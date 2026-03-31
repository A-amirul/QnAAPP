using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Comment
{
    public int Id { get; set; }

    [Required]
    public string Body { get; set; }

    public string UserId { get; set; }
    [ForeignKey("UserId")]
    public ApplicationUser User { get; set; }

    public int? QuestionId { get; set; }
    [ForeignKey("QuestionId")]
    public Question Question { get; set; }

    public int? AnswerId { get; set; }
    [ForeignKey("AnswerId")]
    public Answer Answer { get; set; }
}