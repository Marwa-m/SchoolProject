using CleanArchitecture.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Configurations
{
    public class DepartmentSubjectConfiguration : IEntityTypeConfiguration<DepartmentSubject>
    {
        public void Configure(EntityTypeBuilder<DepartmentSubject> builder)
        {
            builder.HasKey(x => new { x.SubID, x.DID });
            builder.HasOne(x => x.Department)
                   .WithMany(x => x.DepartmentSubjects)
                   .HasForeignKey(x => x.DID);
            builder.HasOne(x => x.Subject)
                .WithMany(x => x.DepartmentSubjects)
                .HasForeignKey(x => x.SubID);

        }

    }
}
