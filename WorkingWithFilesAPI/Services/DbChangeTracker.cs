using WorkingWithFilesAPI.Enums;
using WorkingWithFilesAPI.Models;

namespace WorkingWithFilesAPI.Services
{
    public class DbChangeTracker : IDbChangeTracker
    {
        private readonly List<ChangeRecord> _changes = new List<ChangeRecord>();

        public void TrackChange(ChangeRecord change)
        {
            _changes.Add(change);
        }

        public ChangeRecord GetChange(Guid id)
        {
            return _changes.FirstOrDefault(c => c.Id == id);
        }

        public List<ChangeRecord> GetChanges(ChangeType type)
        {
            return _changes.Where(c => c.Type == type).ToList();
        }
        public List<ChangeRecord> GetChanges()
        {
            return _changes.ToList();
        }
        public List<ChangeRecord> GetChanges(DateTime from, DateTime to)
        {
            return _changes
                .Where(d => d.ChangeTime >= from && d.ChangeTime <= to)
                .ToList();
        }
        public void ClearChanges()
        {
            _changes.Clear();
        }
        public void DeleteChange(Guid id)
        {
            var change = _changes.FirstOrDefault(c => c.Id == id);
            if (change != null)
            {
                _changes.Remove(change);
            }
        }
        public void UpdateChange(ChangeRecord change)
        {
            var index = _changes.FindIndex(c => c.Id == change.Id);
            if (index != -1)
            {
                _changes[index] = change;
            }
        }


    }
}
