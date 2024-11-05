namespace WorkingWithFilesAPI.Models
{
    public class FileModel
    {
        public string FilePath { get; set; }
        public List<string> Lines { get; set; } = new List<string>();
        public string NewLine { get; set; }
        public int LineNumber { get; set; }
    }
}
