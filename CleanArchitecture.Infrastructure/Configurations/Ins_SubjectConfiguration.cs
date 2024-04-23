using CleanArchitecture.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Configurations
{
    public class Ins_SubjectConfiguration : IEntityTypeConfiguration<Ins_Subject>
    {
        public void Configure(EntityTypeBuilder<Ins_Subject> builder)
        {
            builder.HasKey(x => new { x.SubID, x.InsID });
            builder.HasOne(x => x.Instructor)
                   .WithMany(x => x.Ins_Subjects)
                   .HasForeignKey(x => x.InsID);
            builder.HasOne(x => x.Subject)
                .WithMany(x => x.Ins_Subjects)
                .HasForeignKey(x => x.SubID);

        }

    }
}
