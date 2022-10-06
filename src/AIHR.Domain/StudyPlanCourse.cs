namespace AIHR.Domain;

public class StudyPlanCourse
{
    // .ctor used by EF-Core
#pragma warning disable CS8618
    private StudyPlanCourse()
#pragma warning restore CS8618
    {
    }

    public StudyPlanCourse(Course course, StudyPlan studyPlan)
    {
        Course = course;
        CourseId = course.Id;
        
        StudyPlan = studyPlan;
        StudyPlanId = studyPlan.Id;
    }

    public Course Course { get; set; }
    
    public Guid CourseId { get; set; }
    
    public StudyPlan StudyPlan { get; set; }
    
    public int StudyPlanId { get; set; }
}