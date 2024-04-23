using CleanArchitecture.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Data.Entities
{
    public class Instructor : GeneralLocalizableEntity
    {
        public Instructor()
        {
            Instructors = new HashSet<Instructor>();
            Ins_Subjects = new HashSet<Ins_Subject>();
        }
        [Key]
        public int InsID { get; set; }

        public string? NameAr { get; set; }

        public string? NameEn { get; set; }

        public string? Position { get; set; }

        public string? Address { get; set; }

        public int? SupervisorID { get; set; }
        public double? Salary { get; set; }

        public int DID { get; set; }

        [ForeignKey(nameof(Department.DID))]
        [InverseProperty(nameof(Department.Instructors))]
        public Department? Department { get; set; }

        [InverseProperty(nameof(Department.Instructor))]
        public Department? DepartmentManager { get; set; }

        [ForeignKey(nameof(SupervisorID))]
        [InverseProperty(nameof(Instructors))]
        public Instructor? Supervisor { get; set; }

        [InverseProperty(nameof(Supervisor))]
        public virtual ICollection<Instructor> Instructors { get; set; }

        [InverseProperty(nameof(Ins_Subject.Instructor))]
        public virtual ICollection<Ins_Subject> Ins_Subjects { get; set; }
    }
}
