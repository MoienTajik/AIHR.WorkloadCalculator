using AIHR.Domain;
using AIHR.Domain.Dtos.Course;
using AIHR.Domain.Dtos.Student;
using AIHR.Domain.Dtos.StudyPlan;
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

        // NOTE: Use AutoMapper instead
        var studentDto = new StudentDto(
            Id: student.Id,
            Name: student.Name,
            StudyPlans: student.StudyPlans.Select(studyPlan => new StudyPlanDto(
                Id: studyPlan.Id,
                StartDate: studyPlan.StartDate,
                EndDate: studyPlan.EndDate,
                TotalWeeksInSelectedDateRange: studyPlan.TotalWeeksInSelectedDateRange,
                LearningHoursPerWeek: studyPlan.LearningHoursPerWeek,
                Courses: studyPlan.StudyPlanCourses
                    .Select(studyPlanCourse => new CourseDto(
                        Id: studyPlanCourse.CourseId,
                        Name: studyPlanCourse.Course.Name,
                        Duration: studyPlanCourse.Course.Duration)
                    ))));
        
        return Ok(studentDto);
    }
}