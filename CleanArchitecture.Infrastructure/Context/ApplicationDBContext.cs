using CleanArchitecture.Data.Entities;
using CleanArchitecture.Data.Entities.Identity;
using CleanArchitecture.Data.Entities.Views;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CleanArchitecture.Infrastructure.Data
{
    public class ApplicationDBContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {

        public ApplicationDBContext()
        {

        }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options
            ) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<DepartmentSubject> DepartmentSubjects { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Ins_Subject> Ins_Subjects { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

        #region Views
        public DbSet<ViewDepartment> ViewDepartment { get; set; }


        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //{
            //    foreach (var property in entityType.GetProperties())
            //    {
            //        var attributes = property.PropertyInfo.GetCustomAttributes(typeof(EncryptedAttribute), false);
            //        if (attributes.Any())
            //        {
            //            property.SetValueConverter(new EncryptedConverter());
            //        }
            //    }
            //}
        }

    }
}
