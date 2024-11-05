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
            var lines = _fileService.ReadAllLines(new FileModel { FilePath = LogFilePath }).Lines;
            for (int i = lines.Count - 1; i >= 0; i--)
            {
                _fileService.RemoveLine(new FileModel { FilePath = LogFilePath, LineNumber = i });
            }
        }

        public void DeleteChange(Guid id)
        {
            var fileModel = new FileModel { FilePath = LogFilePath };
            var lines = _fileService.ReadAllLines(fileModel).Lines;

            var updatedLines = lines.Where(line =>
            {
                var parts = line.Split(", ");
                return parts.Length > 0 && Guid.Parse(parts[0]) != id;
            }).ToList();

            ClearChanges();
            foreach (var line in updatedLines)
            {
                _fileService.WriteLine(new FileModel { FilePath = LogFilePath, NewLine = line });
            }
        }


        public ChangeRecord GetChange(Guid id)
        {
            var fileModel = new FileModel { FilePath = LogFilePath };
            var lines = _fileService.ReadAllLines(fileModel).Lines;

            foreach (var line in lines)
            {
                var parts = line.Split(", ");
                if (parts.Length >= 6)
                {
                    var changeRecord = new ChangeRecord
                    {
                        Id = Guid.Parse(parts[0]),
                        EntityName = parts[1],
                        Type = (ChangeType)Enum.Parse(typeof(ChangeType), parts[2]),
                        OldValue = parts[3],
                        NewValue = parts[4],
                        ChangeTime = DateTime.Parse(parts[5])
                    };

                    if (changeRecord.Id == id)
                    {
                        return changeRecord;
                    }
                }
            }

            return null;
        }

        public List<ChangeRecord> GetChanges(ChangeType type)
        {
            var fileModel = new FileModel { FilePath = LogFilePath };
            var lines = _fileService.ReadAllLines(fileModel).Lines;

            var changeRecords = new List<ChangeRecord>();

            foreach (var line in lines)
            {
                var parts = line.Split(", ");
                if (parts.Length >= 6)
                {
                    var changeRecord = new ChangeRecord
                    {
                        Id = Guid.Parse(parts[0]),
                        EntityName = parts[1],
                        Type = (ChangeType)Enum.Parse(typeof(ChangeType), parts[2]),
                        OldValue = parts[3],
                        NewValue = parts[4],
                        ChangeTime = DateTime.Parse(parts[5])
                    };

                    if (changeRecord.Type == type)
                    {
                        changeRecords.Add(changeRecord);
                    }
                }
            }

            return changeRecords;
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
            var fileModel = new FileModel { FilePath = LogFilePath };
            var lines = _fileService.ReadAllLines(fileModel).Lines;

            int indexToUpdate = -1;
            for (int i = 0; i < lines.Count; i++)
            {
                var parts = lines[i].Split(", ");
                if (parts.Length >= 6 && Guid.Parse(parts[0]) == change.Id)
                {
                    indexToUpdate = i;
                    break;
                }
            }

            if (indexToUpdate != -1)
            {
                var parts = lines[indexToUpdate].Split(", ");
                parts[3] = change.OldValue; 
                parts[4] = change.NewValue; 

                var updatedLogEntry = string.Join(", ", parts);

                lines[indexToUpdate] = updatedLogEntry;

                ClearChanges();
                foreach (var line in lines)
                {
                    _fileService.WriteLine(new FileModel { FilePath = LogFilePath, NewLine = line });
                }
            }
            else
            {
                throw new ArgumentException("Change record not found for the provided ID.");
            }
        }

    }
}
