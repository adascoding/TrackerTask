using System.ComponentModel.DataAnnotations;

namespace WorkingWithFilesAPI.DTOs;

public class FileRequestDto
{
    public string FilePath { get; set; }
    public string? NewLine { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "Line number must be non-negative.")]
    public int LineNumber { get; set; }
}