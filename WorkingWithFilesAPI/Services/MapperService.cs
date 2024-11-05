using WorkingWithFilesAPI.DTOs;
using WorkingWithFilesAPI.Models;

namespace WorkingWithFilesAPI.Services;

public class MapperService : IMapperService
{
    public FileModel Map(FileRequestDto requestDto)
    {
        return new FileModel
        {
            FilePath = requestDto.FilePath,
            LineNumber = requestDto.LineNumber,
            NewLine = requestDto.NewLine
        };
    }

    public FileResponseDto Map(FileModel fileModel)
    {
        return new FileResponseDto
        {
            Lines = fileModel.Lines
        };
    }
}
