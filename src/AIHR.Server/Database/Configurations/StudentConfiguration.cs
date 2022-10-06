using AIHR.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIHR.Server.Database.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");
        
        builder.HasKey(student => student.Id);
        builder.HasIndex(student => student.Name);

        builder
            .Property(student => student.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder
            .HasMany(student => student.StudyPlans)
            .WithOne(studyPlan => studyPlan.Student)
            .HasForeignKey(studyPlan => studyPlan.StudentId);
    }
}