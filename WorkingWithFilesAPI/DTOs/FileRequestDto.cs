namespace WorkingWithFilesAPI.DTOs;

public class FileRequestDto
{
    public string FilePath { get; set; }
    public string? NewLine { get; set; }
    public int LineNumber { get; set; }
}