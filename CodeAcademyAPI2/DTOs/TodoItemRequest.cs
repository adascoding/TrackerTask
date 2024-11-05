namespace CodeAcademyAPI2.DTOs;

public class TodoItemRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime EndDate { get; set; }
    public string UserId { get; set; }
}
