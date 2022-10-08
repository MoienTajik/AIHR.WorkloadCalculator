using AIHR.Domain.Dtos.Course;

namespace AIHR.Domain.Dtos.UsageHistory;

public record UsageHistoryDto(int Id, DateTimeOffset StartDate, DateTimeOffset EndDate, 
    uint MaxHoursToLearnPerDay, bool Succeed, IEnumerable<CourseDto> Courses);