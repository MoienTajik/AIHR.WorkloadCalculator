namespace AIHR.Domain;

public sealed class Student
{
    // .ctor used by EF-Core
#pragma warning disable CS8618
    private Student()
#pragma warning restore CS8618
    {
    }
    
    public Student(Guid id, string name)
    {
        if (id == default)
        {
            throw new ArgumentException("Student id could not be empty.", nameof(id));
        }
        
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        Id = id;
        Name = name;
    }
    
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public ICollection<StudyPlan> StudyPlans { get; set; } = new List<StudyPlan>();
}