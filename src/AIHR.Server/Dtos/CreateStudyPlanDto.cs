namespace AIHR.Server.Dtos;

public record CreateStudyPlanDto(Guid StudentId, IEnumerable<Guid> CourseIds, 
    DateTimeOffset StartDate, DateTimeOffset EndDate, uint? MaxHoursToLearnPerDay);