using WorkingWithFilesAPI.Enums;

namespace WorkingWithFilesAPI.DTOs
{
    public class ChangeRecordDto
    {
        public ChangeType Type { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
