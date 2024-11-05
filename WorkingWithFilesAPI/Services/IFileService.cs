using WorkingWithFilesAPI.DTOs;
using WorkingWithFilesAPI.Models;

namespace WorkingWithFilesAPI.Services
{
    public interface IFileService
    {
        FileModel ReadAllLines(FileModel fileModel);
        FileModel WriteLine(FileModel fileModel);
        FileModel ReadLine(FileModel fileModel);
        FileModel ReplaceLine(FileModel fileModel);
        FileModel RemoveLine(FileModel fileModel);
    }
}
