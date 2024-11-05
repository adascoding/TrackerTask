using WorkingWithFilesAPI.Enums;
using WorkingWithFilesAPI.Models;

namespace WorkingWithFilesAPI.Services
{
    public interface IDbChangeTracker
    {
        void TrackChange(ChangeRecord change);
        ChangeRecord GetChange(Guid id);
        List<ChangeRecord> GetChanges(ChangeType type);
        void ClearChanges();
        void DeleteChange(Guid id);
        List<ChangeRecord> GetChanges();
        List<ChangeRecord> GetChanges(DateTime from, DateTime to);
        void UpdateChange(ChangeRecord change);
    }
}
