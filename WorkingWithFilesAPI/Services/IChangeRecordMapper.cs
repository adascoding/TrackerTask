using WorkingWithFilesAPI.DTOs;
using WorkingWithFilesAPI.Models;

namespace WorkingWithFilesAPI.Services
{
    public interface IChangeRecordMapper
    {
        ChangeRecord MapToModel(ChangeRecordDto dto);
        ChangeRecordDto MapToDto(ChangeRecord model);
        void UpdateModelFromDto(ChangeRecordDto dto, ChangeRecord model);
    }
}
