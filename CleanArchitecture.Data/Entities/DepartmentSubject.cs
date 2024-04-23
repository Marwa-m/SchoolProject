using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Data.Entities
{
    public class DepartmentSubject
    {
        [Key]
        public int DID { get; set; }

        [Key]
        public int SubID { get; set; }

        [ForeignKey(nameof(Department.DID))]
        [InverseProperty(nameof(Department.DepartmentSubjects))]
        public virtual Department? Department { get; set; }

        [InverseProperty(nameof(Subject.DepartmentSubjects))]
        [ForeignKey(nameof(Subject.SubID))]
        public virtual Subject? Subject { get; set; }
    }
}