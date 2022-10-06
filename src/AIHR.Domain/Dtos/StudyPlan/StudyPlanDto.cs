using AIHR.Domain.Dtos.Course;

namespace AIHR.Domain.Dtos.StudyPlan;

public sealed record StudyPlanDto(int Id, DateTimeOffset StartDate, DateTimeOffset EndDate, 
    uint TotalWeeksInSelectedDateRange, uint LearningHoursPerWeek, IEnumerable<CourseDto> Courses);