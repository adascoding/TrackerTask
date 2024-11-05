using Microsoft.AspNetCore.Mvc;
using WorkingWithFilesAPI.DTOs;
using WorkingWithFilesAPI.Models;
using WorkingWithFilesAPI.Services;

namespace WorkingWithFilesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IMapperService _mapperService;

        public FilesController(IFileService fileService, IMapperService mapperService)
        {
            _fileService = fileService;
            _mapperService = mapperService;
        }

        [HttpGet]
        public IActionResult ReadAllLines([FromQuery] FileRequestDto request)
        {
            var fileModel = _mapperService.Map(request);
            var result = _fileService.ReadAllLines(fileModel);
            return Ok(_mapperService.Map(result));
        }

        [HttpGet("GetByLineNumber")]
        public IActionResult ReadLine([FromQuery] FileRequestDto request)
        {
            var fileModel = _mapperService.Map(request);
            var result = _fileService.ReadLine(fileModel);
            return Ok(_mapperService.Map(result));
        }

        [HttpPost]
        public IActionResult WriteLine([FromBody] FileRequestDto request)
        {
            var fileModel = _mapperService.Map(request);
            var result = _fileService.WriteLine(fileModel);
            return Created();
        }

        [HttpPut]
        public IActionResult ReplaceLine([FromBody] FileRequestDto request)
        {
            var fileModel = _mapperService.Map(request);
            var result = _fileService.ReplaceLine(fileModel);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult RemoveLine([FromBody] FileRequestDto request)
        {
            var fileModel = _mapperService.Map(request);
            var result = _fileService.RemoveLine(fileModel);
            return NoContent();
        }
    }
}
