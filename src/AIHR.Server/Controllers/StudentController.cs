using AIHR.Domain;
using AIHR.Server.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AIHR.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly ApplicationDbContext _db;

    public StudentController(ApplicationDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        // NOTE: It's better to movie queries to a repository inside "infrastructure layer" instead of here.
        var students = await _db.Students
            .Select(student => new
            {
                student.Id,
                student.Name
            })
            .ToListAsync(cancellationToken);

        return Ok(students);
    }

    [HttpGet("{studentId:guid}")]
    public async Task<IActionResult> Get(Guid studentId, CancellationToken cancellationToken)
    {
        // NOTE: It's better to movie queries to a repository inside "infrastructure layer" instead of here.
        Student? student = await _db.Students
            .Include(student => student.StudyPlans)
            .ThenInclude(studyPlan => studyPlan.StudyPlanCourses)
            .ThenInclude(studyPlanCourse => studyPlanCourse.Course)
            .FirstOrDefaultAsync(student => student.Id == studentId, cancellationToken);

        if (student is null)
        {
            return NotFound(studentId);
        }

        return Ok(student);
    }
}