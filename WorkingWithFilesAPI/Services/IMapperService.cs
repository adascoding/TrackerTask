using WorkingWithFilesAPI.DTOs;
using WorkingWithFilesAPI.Models;

namespace WorkingWithFilesAPI.Services
{
    public interface IMapperService
    {
        FileModel Map(FileRequestDto requestDto);
        FileResponseDto Map(FileModel fileModel);
    }
}
