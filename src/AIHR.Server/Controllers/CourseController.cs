using AIHR.Domain.Dtos;
using AIHR.Domain.Dtos.Course;
using AIHR.Server.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AIHR.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
    private readonly ApplicationDbContext _db;

    public CourseController(ApplicationDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        // NOTE: It's better to move mapping & queries to a repository inside "infrastructure layer" instead of here.
        var courses = await _db.Courses
            .Select(course => new CourseDto(course.Id, course.Name, $"{course.Duration.TotalHours} hours"))
            .ToListAsync(cancellationToken);

        return Ok(courses);
    }
}