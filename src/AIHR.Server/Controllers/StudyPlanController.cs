using AIHR.Domain;
using AIHR.Domain.Dtos;
using AIHR.Domain.Dtos.StudyPlan;
using AIHR.Server.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AIHR.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudyPlanController : ControllerBase
{
    private readonly ApplicationDbContext _db;

    public StudyPlanController(ApplicationDbContext db)
    {
        _db = db;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateStudyPlanDto createStudyPlanDto, CancellationToken cancellationToken)
    {
        // NOTE: It's better to movie this logic to a service inside "application layer" instead of here.
        Student? student = await _db.Students
            .FirstOrDefaultAsync(student => student.Id == createStudyPlanDto.StudentId, cancellationToken);

        if (student is null)
        {
            return NotFound($"Student with id ({createStudyPlanDto.StudentId}) not found.");
        }

        // NOTE 1: This query is not so efficient because it uses "IN Clause" internally and "IN" queries are currently
        // not parameterized by EF-Core. It can replaced by this lib temporary: https://github.com/yv989c/BlazarTech.QueryableValues
        // NOTE 2: Validate all provided CourseIds are found or not?
        var courses = await _db.Courses
            .Where(course => createStudyPlanDto.CourseIds.Contains(course.Id))
            .ToListAsync(cancellationToken);

        var studyPlan = new StudyPlan(student, courses,
            createStudyPlanDto.StartDate, createStudyPlanDto.EndDate, createStudyPlanDto.MaxHoursToLearnPerDay);

        // NOTE: All the logic in this Action Method should split in Application/Infrastructure layers
        await _db.StudyPlans.AddAsync(studyPlan, cancellationToken);
        await _db.SaveChangesAsync(cancellationToken);
        
        return Ok(studyPlan);
    }

    [HttpDelete("{studyPlanId:int}")]
    public async Task<IActionResult> Delete(int studyPlanId, CancellationToken cancellationToken)
    {
        // NOTE: All the logic in this Action Method should split in Application/Infrastructure layers
        StudyPlan? studyPlan = await _db.StudyPlans
            .FirstOrDefaultAsync(studyPlan => studyPlan.Id == studyPlanId, cancellationToken);

        if (studyPlan is null)
        {
            return NotFound(studyPlanId);
        }
        
        _db.StudyPlans.Remove(studyPlan);
        await _db.SaveChangesAsync(cancellationToken);

        return Ok();
    }
}