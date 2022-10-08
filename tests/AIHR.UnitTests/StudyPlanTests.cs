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
        var student = new Student(Guid.Parse("ab3ed2ad-ff11-42dd-88c6-ce1ca99ebb11"), "Moien");
        var courses = new List<Course>
        {
            new(Guid.Parse("925A6B16-F1D9-459C-9500-5873F8B0B445"), "Blockchain and HR", TimeSpan.FromHours(8)),
            new(Guid.Parse("0E2AC2B9-813D-4D54-B79F-084C30924FFA"), "Digital HR", TimeSpan.FromHours(40))
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
        var student = new Student(Guid.Parse("ab3ed2ad-ff11-42dd-88c6-ce1ca99ebb11"), "Moien");
        var courses = new List<Course>
        {
            new(Guid.Parse("97DCC28D-4A7C-48A2-99C6-361747536033"), "Compensation & Benefits", TimeSpan.FromHours(32))
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