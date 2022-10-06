using AIHR.Domain;
using FluentAssertions;
using Xunit;

namespace AIHR.UnitTests;

public sealed class StudyPlanTests
{
    [Fact]
    public void CreateStudyPlan_WithValidParameters_CreatesSuccessfully()
    {
        // Arrange
        var student = new Student("Moien");
        var courses = new List<Course>
        {
            new("Blockchain and HR", TimeSpan.FromHours(8)),
            new("Digital HR", TimeSpan.FromHours(40))
        };

        // Act
        DateTimeOffset today = DateTimeOffset.Now;
        DateTimeOffset startDate = today.AddDays(2);
        DateTimeOffset endDate = today.AddDays(15);
        var studyPlan = new StudyPlan(student, courses, startDate, endDate, 4);
        
        // Assert
        studyPlan.TakenCoursesTotalHours.Should().Be(48);
        studyPlan.TotalDaysInSelectedDateRange.Should().Be(13);
        studyPlan.TotalAvailableHoursToLearnInSelectedDateRange.Should().Be(52);
        studyPlan.CanCompleteCoursesInSelectedDateRange.Should().BeTrue();
        studyPlan.LearningHoursPerWeek.Should().Be(24);
    }
    
    [Fact]
    public void CreateStudyPlan_WithValidParameters_CreatesSuccessfully2()
    {
        // Arrange
        var student = new Student("Moien");
        var courses = new List<Course>
        {
            new("Compensation & Benefits", TimeSpan.FromHours(32))
        };

        // Act
        DateTimeOffset today = DateTimeOffset.Now;
        DateTimeOffset startDate = today.AddDays(1);
        DateTimeOffset endDate = today.AddDays(9);
        var studyPlan = new StudyPlan(student, courses, startDate, endDate, 4);
        
        // Assert
        studyPlan.TakenCoursesTotalHours.Should().Be(32);
        studyPlan.TotalDaysInSelectedDateRange.Should().Be(8);
        studyPlan.TotalAvailableHoursToLearnInSelectedDateRange.Should().Be(32);
        studyPlan.CanCompleteCoursesInSelectedDateRange.Should().BeTrue();
        
        // **NOTE**: This calculation may not be correct, as we just need 4 hours from the second week, not 16 hours.
        studyPlan.LearningHoursPerWeek.Should().Be(16);
    }
}