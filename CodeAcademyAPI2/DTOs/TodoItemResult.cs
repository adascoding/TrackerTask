namespace CodeAcademyAPI2.DTOs;

public class TodoItemResult
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime EndDate { get; set; }
    public string UserId { get; set; }
}
