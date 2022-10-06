namespace AIHR.Domain;

public sealed class StudyPlan
{
    // .ctor used by EF-Core
#pragma warning disable CS8618
    private StudyPlan()
#pragma warning restore CS8618
    {
    }
    
    public StudyPlan(Student student, ICollection<Course> courses,
        DateTimeOffset startDate, DateTimeOffset endDate, uint? maxHoursToLearnPerDay = 6)
    {
        ArgumentNullException.ThrowIfNull(student);
        ArgumentNullException.ThrowIfNull(courses);

        if (courses.Any() is false)
        {
            throw new ArgumentException("No course is selected to create a study plan.", nameof(courses));
        }

        if (endDate <= startDate)
        {
            throw new ArgumentException("End date must be greater than Start date.", nameof(endDate));
        }

        StartDate = startDate;
        EndDate = endDate;
        MaxHoursToLearnPerDay = maxHoursToLearnPerDay ?? 6;

        Student = student;
        StudentId = student.Id;
        StudyPlanCourses = courses.Select(course => new StudyPlanCourse(course, this)).ToList();

        if (CanCompleteCoursesInSelectedDateRange is false)
        {
            throw new ArgumentOutOfRangeException(nameof(maxHoursToLearnPerDay),
                $"You cannot finish {TakenCoursesTotalHours} hours courses in {TotalDaysInSelectedDateRange} days by learning {MaxHoursToLearnPerDay} hours a day!");
        }
    }

    public int Id { get; private set; }

    public DateTimeOffset StartDate { get; private set; }

    public DateTimeOffset EndDate { get; private set; }

    public uint MaxHoursToLearnPerDay { get; private set; }

    public Guid StudentId { get; private set; }

    public Student Student { get; private set; }

    public ICollection<StudyPlanCourse> StudyPlanCourses { get; private set; } = new List<StudyPlanCourse>();

    public uint TakenCoursesTotalHours => (uint)StudyPlanCourses.Sum(studyPlanCourse => studyPlanCourse.Course.Duration.TotalHours) == 0
        ? 1
        : (uint)StudyPlanCourses.Sum(studyPlanCourse => studyPlanCourse.Course.Duration.TotalHours);
    
    public uint TotalDaysInSelectedDateRange => (uint)(EndDate - StartDate).TotalDays;

    public uint TotalWeeksInSelectedDateRange
    {
        get => TotalDaysInSelectedDateRange / 7 == 0
            ? 1
            : (uint)Math.Ceiling((double)TotalDaysInSelectedDateRange / 7);
        private set { } // Used by EF-Core
    }

    public uint TotalAvailableHoursToLearnInSelectedDateRange => TotalDaysInSelectedDateRange * MaxHoursToLearnPerDay;

    public bool CanCompleteCoursesInSelectedDateRange => TotalAvailableHoursToLearnInSelectedDateRange >= TakenCoursesTotalHours;

    public uint LearningHoursPerWeek
    {
        get => (uint)Math.Ceiling((double)TakenCoursesTotalHours / TotalWeeksInSelectedDateRange);
        private set { } // Used by EF-Core
    }
}