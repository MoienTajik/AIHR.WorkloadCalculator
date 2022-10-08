namespace AIHR.Domain;

public class UsageHistoryCourse
{
    // .ctor used by EF-Core
#pragma warning disable CS8618
    private UsageHistoryCourse()
#pragma warning restore CS8618
    {
    }

    public UsageHistoryCourse(Course course, UsageHistory usageHistory)
    {
        Course = course;
        CourseId = course.Id;
        
        UsageHistory = usageHistory;
        UsageHistoryId = usageHistory.Id;
    }

    public Course Course { get; set; }
    
    public Guid CourseId { get; set; }
    
    public UsageHistory UsageHistory { get; set; }
    
    public int UsageHistoryId { get; set; }
}