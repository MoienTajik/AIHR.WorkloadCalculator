using AIHR.Domain;

namespace AHR.Client.ViewModels;

public record CourseIndexViewModel(List<CourseIndexViewModel.Course> Courses, List<Student> Students)
{
     public Guid SelectedStudentId { get; set; }

     public DateTime StartDate { get; set; }

     public DateTime EndDate { get; set; }

     public int AvailableHoursPerDay { get; set; }
     
     public record Course(Guid Id, string Name, string Duration, bool Selected);
}