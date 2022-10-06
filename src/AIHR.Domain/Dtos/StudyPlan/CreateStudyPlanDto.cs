namespace AIHR.Domain.Dtos.StudyPlan;

public record CreateStudyPlanDto(Guid StudentId, IEnumerable<Guid> CourseIds, 
    DateTimeOffset StartDate, DateTimeOffset EndDate, uint? MaxHoursToLearnPerDay);