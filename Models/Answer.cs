using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Answer
{
    public int Id { get; set; }

    [Required]
    public string Body { get; set; }

    public int QuestionId { get; set; }
    [ForeignKey("QuestionId")]
    public Question Question { get; set; }

    public string UserId { get; set; }
    [ForeignKey("UserId")]
    public ApplicationUser User { get; set; }

    public List<Comment> Comments { get; set; }
}