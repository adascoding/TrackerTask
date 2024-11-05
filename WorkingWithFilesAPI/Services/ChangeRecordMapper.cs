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
                Type = dto.Type,
                Description = dto.Description,
                CreatedAt = dto.CreatedAt
            };
        }

        public ChangeRecordDto MapToDto(ChangeRecord model)
        {
            return new ChangeRecordDto
            {
                Type = model.Type,
                Description = model.Description,
                CreatedAt = model.CreatedAt
            };
        }
        public void UpdateModelFromDto(ChangeRecordDto dto, ChangeRecord model)
        {
            model.Type = dto.Type;
            model.Description = dto.Description;
            model.CreatedAt = dto.CreatedAt;
        }
    }
}
