using WorkingWithFilesAPI.Enums;

namespace WorkingWithFilesAPI.DTOs
{
    public class ChangeRecordDto
    {
        public string EntityName { get; set; }
        public ChangeType Type { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime ChangeTime { get; set; }
    }
}
