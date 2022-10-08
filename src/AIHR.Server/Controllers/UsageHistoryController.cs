using AIHR.Domain.Dtos.Course;
using AIHR.Domain.Dtos.UsageHistory;
using AIHR.Server.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AIHR.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsageHistoryController : ControllerBase
{
    private readonly ApplicationDbContext _db;

    public UsageHistoryController(ApplicationDbContext db)
    {
        _db = db;
    }

    [HttpGet("{studentId:guid}")]
    public async Task<IActionResult> Get(Guid studentId, CancellationToken cancellationToken)
    {
        // NOTE: It's better to move queries to a repository inside "infrastructure layer" instead of here.
        var studentUsageHistories = await _db.UsageHistories
            .Where(usageHistory => usageHistory.StudentId == studentId)
            .Include(usageHistory => usageHistory.UsageHistoryCourses)
            .ThenInclude(usageHistoryCourses => usageHistoryCourses.Course)
            .Select(usageHistory => new UsageHistoryDto(
                usageHistory.Id,
                usageHistory.StartDate,
                usageHistory.EndDate,
                usageHistory.MaxHoursToLearnPerDay,
                usageHistory.Succeed,
                usageHistory.UsageHistoryCourses.Select(usageHistoryCourse => 
                    new CourseDto(
                        usageHistoryCourse.Course.Id,
                        usageHistoryCourse.Course.Name,
                        usageHistoryCourse.Course.Duration))
                ))
            .ToListAsync(cancellationToken);

        return Ok(studentUsageHistories);
    }
}