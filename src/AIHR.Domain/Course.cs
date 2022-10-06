namespace AIHR.Domain;

public sealed class Course
{
    // .ctor used by EF-Core
#pragma warning disable CS8618
    private Course()
#pragma warning restore CS8618
    {
    }
    
    public Course(string name, TimeSpan duration)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        if (duration == default)
        {
            throw new ArgumentException("Duration could not be empty.", nameof(duration));
        }

        Id = Guid.NewGuid();
        Name = name;
        Duration = duration;
    }
    
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public TimeSpan Duration { get; private set; }

    public ICollection<StudyPlanCourse> StudyPlanCourses { get; private set; } = default!;
}