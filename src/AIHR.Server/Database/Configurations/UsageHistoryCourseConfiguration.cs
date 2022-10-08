using AIHR.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIHR.Server.Database.Configurations;

public class UsageHistoryCourseConfiguration : IEntityTypeConfiguration<UsageHistoryCourse>
{
    public void Configure(EntityTypeBuilder<UsageHistoryCourse> builder)
    {
        builder.ToTable("UsageHistoryCourses");
        
        builder.HasKey(usageHistoryCourse => new { usageHistoryCourse.CourseId, usageHistoryCourse.UsageHistoryId });

        builder
            .HasOne(usageHistoryCourse => usageHistoryCourse.Course)
            .WithMany(course => course.UsageHistoryCourses)
            .HasForeignKey(usageHistoryCourse => usageHistoryCourse.CourseId);
        
        builder
            .HasOne(usageHistoryCourse => usageHistoryCourse.UsageHistory)
            .WithMany(usageHistory => usageHistory.UsageHistoryCourses)
            .HasForeignKey(usageHistoryCourse => usageHistoryCourse.UsageHistoryId);
    }
}