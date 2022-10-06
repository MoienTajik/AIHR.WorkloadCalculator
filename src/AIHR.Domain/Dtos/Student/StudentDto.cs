using AIHR.Domain.Dtos.StudyPlan;

namespace AIHR.Domain.Dtos.Student;

public sealed record StudentDto(Guid Id, string Name, IEnumerable<StudyPlanDto> StudyPlans);