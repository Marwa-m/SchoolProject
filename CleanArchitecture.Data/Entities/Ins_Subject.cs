using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Data.Entities
{
    public class Ins_Subject
    {
        [Key]
        public int InsID { get; set; }
        [Key]
        public int SubID { get; set; }

        [ForeignKey(nameof(Instructor.InsID))]
        [InverseProperty(nameof(Instructor.Ins_Subjects))]
        public Instructor? Instructor { get; set; }

        [ForeignKey(nameof(Subject.SubID))]
        [InverseProperty(nameof(Subject.Ins_Subjects))]

        public Subject? Subject { get; set; }

    }
}
