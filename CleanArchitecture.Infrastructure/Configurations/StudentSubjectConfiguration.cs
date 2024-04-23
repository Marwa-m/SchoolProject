using CleanArchitecture.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Configurations
{
    public class StudentSubjectConfiguration : IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
            builder.HasKey(x => new { x.SubID, x.StudID });
            builder.HasOne(x => x.Student)
                   .WithMany(x => x.StudentSubjects)
                   .HasForeignKey(x => x.StudID);
            builder.HasOne(x => x.Subject)
                .WithMany(x => x.StudentSubjects)
                .HasForeignKey(x => x.SubID);
        }
    }
}
