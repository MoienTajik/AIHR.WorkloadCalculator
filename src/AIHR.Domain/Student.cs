namespace AIHR.Domain;

public sealed class Student
{
    // .ctor used by EF-Core
#pragma warning disable CS8618
    private Student()
#pragma warning restore CS8618
    {
    }
    
    public Student(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }
        
        Id = Guid.NewGuid();
        Name = name;
    }
    
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public ICollection<StudyPlan> StudyPlans { get; private set; } = default!;
}