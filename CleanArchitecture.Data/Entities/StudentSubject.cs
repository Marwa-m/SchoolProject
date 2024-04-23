using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Data.Entities
{
    public class StudentSubject
    {
        [Key]
        public int StudID { get; set; }

        [Key]
        public int SubID { get; set; }

        public double? Grade { get; set; }
        // [InverseProperty(nameof(Student.StudentSubjects))]
        [ForeignKey(nameof(Student.StudentID))]
        public virtual Student? Student { get; set; }

        // [InverseProperty(nameof(Subject.DepartmentSubjects))]
        [ForeignKey(nameof(Subject.SubID))]
        public virtual Subject? Subject { get; set; }
    }
}
