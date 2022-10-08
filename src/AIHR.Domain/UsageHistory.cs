namespace AIHR.Domain;

public sealed class UsageHistory
{
    // .ctor used by EF-Core
#pragma warning disable CS8618
    private UsageHistory()
#pragma warning restore CS8618
    {
    }

    public UsageHistory(Guid studentId, DateTimeOffset startDate, DateTimeOffset endDate,
        uint maxHoursToLearnPerDay, ICollection<Course> courses, bool succeed)
    {
        if (courses.Any() is false)
        {
            throw new ArgumentException("No course is selected to create a usage history.",
                nameof(courses));
        }
        
        StudentId = studentId;
        StartDate = startDate;
        EndDate = endDate;
        MaxHoursToLearnPerDay = maxHoursToLearnPerDay;
        UsageHistoryCourses = courses.Select(course => new UsageHistoryCourse(course, this)).ToList();
        Succeed = succeed;
    }
    
    public int Id { get; private set; }

    public DateTimeOffset StartDate { get; private set; }
    
    public DateTimeOffset EndDate { get; private set; }
    
    public uint MaxHoursToLearnPerDay { get; private set; }
    
    public bool Succeed { get; private set; }

    public Student Student { get; private set; } = default!;
    
    public Guid StudentId { get; private set; }
    
    public ICollection<UsageHistoryCourse> UsageHistoryCourses { get; private set; }
}