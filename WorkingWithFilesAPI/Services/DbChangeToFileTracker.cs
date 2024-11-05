using WorkingWithFilesAPI.Enums;
using WorkingWithFilesAPI.Models;

namespace WorkingWithFilesAPI.Services
{
    public class DbChangeToFileTracker : IDbChangeTracker
    {
        private readonly IFileService _fileService;
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
            throw new NotImplementedException();
        }

        public List<ChangeRecord> GetChanges(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public void TrackChange(ChangeRecord change)
        {
            throw new NotImplementedException();
        }

        public void UpdateChange(ChangeRecord change)
        {
            throw new NotImplementedException();
        }
    }
}
