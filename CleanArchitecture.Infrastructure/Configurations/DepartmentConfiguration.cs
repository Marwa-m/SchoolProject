using CleanArchitecture.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.DID);
            builder.Property(x => x.DNameAr).HasMaxLength(200);
            builder.HasMany(x => x.Students)
                .WithOne(y => y.Department)
                .HasForeignKey(z => z.DID)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Instructor)
                .WithOne(x => x.DepartmentManager)
                .HasForeignKey<Department>(x => x.InsManager)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
