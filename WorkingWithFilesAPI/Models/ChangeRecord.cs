using System.Globalization;
using WorkingWithFilesAPI.Enums;

namespace WorkingWithFilesAPI.Models
{
    public class ChangeRecord
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public ChangeType Type { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
