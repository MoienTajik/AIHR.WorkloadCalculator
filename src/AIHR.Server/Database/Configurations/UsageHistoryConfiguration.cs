using AIHR.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AIHR.Server.Database.Configurations;

public class UsageHistoryConfiguration : IEntityTypeConfiguration<UsageHistory>
{
    public void Configure(EntityTypeBuilder<UsageHistory> builder)
    {
        builder.ToTable("UsageHistories");
        
        builder.HasKey(usageHistory => usageHistory.Id);
        
        builder
            .HasOne(usageHistory => usageHistory.Student)
            .WithMany(student => student.UsageHistories)
            .HasForeignKey(usageHistory => usageHistory.StudentId);
    }
}