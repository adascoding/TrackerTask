using WorkingWithFilesAPI.Models;

namespace WorkingWithFilesAPI.Services
{
    public class FileService : IFileService
    {
        public FileModel ReadAllLines(FileModel fileModel)
        {
            try
            {
                var lines = File.ReadAllLines(fileModel.FilePath).ToList();
                fileModel.Lines = lines;
                return fileModel;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading all lines: {ex.Message}");
            }
        }

        public FileModel WriteLine(FileModel fileModel)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fileModel.NewLine))
                    throw new ArgumentException("New line content must be provided.");

                File.AppendAllText(fileModel.FilePath, fileModel.NewLine + Environment.NewLine);
                return fileModel;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error writing line: {ex.Message}");
            }
        }

        public FileModel ReadLine(FileModel fileModel)
        {
            try
            {
                var lines = File.ReadLines(fileModel.FilePath).ToList();
                if (fileModel.LineNumber < 0 || fileModel.LineNumber >= lines.Count)
                    throw new ArgumentOutOfRangeException("Line number is out of range.");

                fileModel.Lines = new List<string> { lines[fileModel.LineNumber] };
                return fileModel;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading line: {ex.Message}");
            }
        }

        public FileModel ReplaceLine(FileModel fileModel)
        {
            try
            {
                var lines = File.ReadAllLines(fileModel.FilePath).ToList();
                if (fileModel.LineNumber < 0 || fileModel.LineNumber >= lines.Count)
                    throw new ArgumentOutOfRangeException("Line number is out of range.");

                if (string.IsNullOrWhiteSpace(fileModel.NewLine))
                    throw new ArgumentException("New line content must be provided.");

                lines[fileModel.LineNumber] = fileModel.NewLine;
                File.WriteAllLines(fileModel.FilePath, lines);
                fileModel.Lines = lines;
                return fileModel;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error replacing line: {ex.Message}");
            }
        }

        public FileModel RemoveLine(FileModel fileModel)
        {
            try
            {
                var lines = File.ReadAllLines(fileModel.FilePath).ToList();
                if (fileModel.LineNumber < 0 || fileModel.LineNumber >= lines.Count)
                    throw new ArgumentOutOfRangeException("Line number is out of range.");

                lines.RemoveAt(fileModel.LineNumber);
                File.WriteAllLines(fileModel.FilePath, lines);
                fileModel.Lines = lines;
                return fileModel;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error removing line: {ex.Message}");
            }
        }
    }
}
