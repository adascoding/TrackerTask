using WorkingWithFilesAPI.DTOs;
using WorkingWithFilesAPI.Models;

namespace WorkingWithFilesAPI.Services
{
    public class ChangeRecordMapper : IChangeRecordMapper
    {
        public ChangeRecord MapToModel(ChangeRecordDto dto)
        {
            return new ChangeRecord
            {
                EntityName = dto.EntityName,
                Type = dto.Type,
                OldValue = dto.OldValue,
                NewValue = dto.NewValue,
                ChangeTime = dto.ChangeTime
            };
        }

        public ChangeRecordDto MapToDto(ChangeRecord model)
        {
            return new ChangeRecordDto
            {
                EntityName = model.EntityName,
                Type = model.Type,
                OldValue = model.OldValue,
                NewValue = model.NewValue,
                ChangeTime = model.ChangeTime
            };
        }
        public void Project(ChangeRecordDto dto, ChangeRecord model)
        {
            model.EntityName = dto.EntityName;
            model.Type = dto.Type;
            model.OldValue = dto.OldValue;
            model.NewValue = dto.NewValue;
            model.ChangeTime = dto.ChangeTime;
        }
    }
}
