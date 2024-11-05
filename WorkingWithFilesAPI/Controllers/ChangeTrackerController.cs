using Microsoft.AspNetCore.Mvc;
using WorkingWithFilesAPI.DTOs;
using WorkingWithFilesAPI.Enums;
using WorkingWithFilesAPI.Services;

namespace WorkingWithFilesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangeTrackerController : ControllerBase
    {
        private readonly IDbChangeTracker _dbChangeTracker;
        private readonly IChangeRecordMapper _changeRecordMapper;

        public ChangeTrackerController(IDbChangeTracker dbChangeTracker, IChangeRecordMapper changeRecordMapper)
        {
            _dbChangeTracker = dbChangeTracker;
            _changeRecordMapper = changeRecordMapper;
        }

        [HttpGet]
        public IActionResult GetAllChanges()
        {
            var changes = _dbChangeTracker.GetChanges();
            var changeDtos = changes.Select(c => _changeRecordMapper.MapToDto(c)).ToList();
            return Ok(changeDtos);
        }

        [HttpGet("GetByType/{changeType}")]
        public IActionResult GetChangesByType(ChangeType changeType)
        {
            var changes = _dbChangeTracker.GetChanges(changeType);
            var changeDtos = changes.Select(c => _changeRecordMapper.MapToDto(c)).ToList();
            return Ok(changeDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetChangeById(Guid id)
        {
            var change = _dbChangeTracker.GetChange(id);
            if (change == null)
                return NotFound();

            var changeDto = _changeRecordMapper.MapToDto(change);
            return Ok(changeDto);
        }

        [HttpGet("GetByDate")]
        public IActionResult GetChangesByDateRange([FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            var changes = _dbChangeTracker.GetChanges(from, to);
            var changeDtos = changes.Select(c => _changeRecordMapper.MapToDto(c)).ToList();
            return Ok(changeDtos);
        }

        [HttpPost]
        public IActionResult AddChange([FromBody] ChangeRecordDto changeDto)
        {
            var changeRecord = _changeRecordMapper.MapToModel(changeDto);
            _dbChangeTracker.TrackChange(changeRecord);
            return CreatedAtAction(nameof(GetChangeById), new { id = changeRecord.Id }, changeDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateChange(Guid id, [FromBody] ChangeRecordDto changeDto)
        {
            var changeRecord = _dbChangeTracker.GetChange(id);
            if (changeRecord == null)
                return NotFound();

            _changeRecordMapper.UpdateModelFromDto(changeDto, changeRecord);
            _dbChangeTracker.UpdateChange(changeRecord);

            return NoContent();
        }

        [HttpDelete]
        public IActionResult ClearChanges()
        {
            _dbChangeTracker.ClearChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteChange(Guid id)
        {
            var change = _dbChangeTracker.GetChange(id);
            if (change == null)
                return NotFound();

            _dbChangeTracker.DeleteChange(id);
            return NoContent();
        }
    }
}
