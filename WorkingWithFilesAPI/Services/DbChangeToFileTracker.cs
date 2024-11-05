using System.Globalization;
using WorkingWithFilesAPI.Enums;
using WorkingWithFilesAPI.Models;

namespace WorkingWithFilesAPI.Services
{
    public class DbChangeToFileTracker : IDbChangeTracker
    {
        private readonly IFileService _fileService;
        private const string LogFilePath = "change_logs.txt";
        public DbChangeToFileTracker(IFileService fileService)
        {
            _fileService = fileService;
        }
        public void ClearChanges()
        {
            throw new NotImplementedException();
        }

        public void DeleteChange(Guid id)
        {
            throw new NotImplementedException();
        }

        public ChangeRecord GetChange(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<ChangeRecord> GetChanges(ChangeType type)
        {
            throw new NotImplementedException();
        }

        public List<ChangeRecord> GetChanges()
        {
            var lines = _fileService.ReadAllLines(new FileModel { FilePath = LogFilePath }).Lines;
            var changeRecords = new List<ChangeRecord>();

            foreach (var line in lines)
            {
                var parts = line.Split(", ");
                var changeRecord = new ChangeRecord
                {
                    Id = Guid.Parse(parts[0]),
                    EntityName = parts[1],
                    Type = (ChangeType)Enum.Parse(typeof(ChangeType), parts[2]),
                    OldValue = parts[3],
                    NewValue = parts[4],
                    ChangeTime = DateTime.Parse(parts[5])
                };

                changeRecords.Add(changeRecord);
            }

            return changeRecords;
        }

        public List<ChangeRecord> GetChanges(DateTime from, DateTime to)
        {
            var lines = _fileService.ReadAllLines(new FileModel { FilePath = LogFilePath }).Lines;
            var changeRecords = new List<ChangeRecord>();

            foreach (var line in lines)
            {
                var parts = line.Split(", ");
                var changeRecord = new ChangeRecord
                {
                    Id = Guid.Parse(parts[0]),
                    EntityName = parts[1],
                    Type = (ChangeType)Enum.Parse(typeof(ChangeType), parts[2]),
                    OldValue = parts[3],
                    NewValue = parts[4],
                    ChangeTime = DateTime.Parse(parts[5])
                };

                changeRecords.Add(changeRecord);
            }

            return changeRecords.Where(d => d.ChangeTime >= from && d.ChangeTime <= to).ToList();
        }

        public void TrackChange(ChangeRecord change)
        {
            var logEntry = $"{change.Id}, {change.EntityName}, {change.Type}, {change.OldValue}, {change.NewValue}, {change.ChangeTime}";
            _fileService.WriteLine(new FileModel { FilePath = LogFilePath, NewLine = logEntry });
        }

        public void UpdateChange(ChangeRecord change)
        {
            throw new NotImplementedException();
        }
    }
}
