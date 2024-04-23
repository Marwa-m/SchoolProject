using CleanArchitecture.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Data.Entities
{
    public class Department : GeneralLocalizableEntity
    {
        public Department()
        {
            Students = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmentSubject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DID { get; set; }

        [StringLength(100)]
        public string? DNameAr { get; set; }
        [StringLength(100)]
        public string? DNameEn { get; set; }

        public int? InsManager { get; set; }

        [InverseProperty(nameof(Student.Department))]
        public virtual ICollection<Student> Students { get; set; }

        [InverseProperty(nameof(DepartmentSubject.Department))]
        public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }

        [InverseProperty(nameof(Instructor.Department))]
        public virtual ICollection<Instructor> Instructors { get; set; }

        [ForeignKey(nameof(Department.InsManager))]
        [InverseProperty(nameof(Instructor.DepartmentManager))]
        public virtual Instructor? Instructor { get; set; }

    }
}