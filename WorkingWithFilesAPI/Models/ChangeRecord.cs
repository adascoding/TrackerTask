using System.Globalization;
using WorkingWithFilesAPI.Enums;

namespace WorkingWithFilesAPI.Models
{
    public class ChangeRecord
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string EntityName { get; set; }
        public ChangeType Type { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime ChangeTime { get; set; }

    }
}
