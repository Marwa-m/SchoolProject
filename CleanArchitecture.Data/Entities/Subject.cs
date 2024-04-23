using CleanArchitecture.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Data.Entities
{
    public class Subject : GeneralLocalizableEntity
    {
        public Subject()
        {
            StudentSubjects = new HashSet<StudentSubject>();
            DepartmentSubjects = new HashSet<DepartmentSubject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubID { get; set; }
        public string? SubjectNameAr { get; set; }
        public string? SubjectNameEn { get; set; }
        public int Period { get; set; }

        //  [InverseProperty(nameof(StudentSubject.Subject))]
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
        [InverseProperty(nameof(DepartmentSubject.Subject))]
        public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }

        [InverseProperty(nameof(Ins_Subject.Subject))]
        public virtual ICollection<Ins_Subject> Ins_Subjects { get; set; }
    }
}
