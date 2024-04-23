using CleanArchitecture.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Data.Entities
{
    public class Student : GeneralLocalizableEntity
    {
        public Student()
        {
            StudentSubjects = new HashSet<StudentSubject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentID { get; set; }

        [StringLength(100)]
        public string? NameAr { get; set; }
        [StringLength(100)]
        public string? NameEn { get; set; }

        [StringLength(500)]
        public string? Address { get; set; }

        [StringLength(12)]
        public string? Phone { get; set; }


        public int? DID { get; set; }

        [ForeignKey("DID")]
        [InverseProperty("Students")]
        public virtual Department? Department { get; set; }

        // [InverseProperty(nameof(StudentSubject.Subject))]
        public ICollection<StudentSubject> StudentSubjects { get; set; }

    }
}
