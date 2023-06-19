using System.ComponentModel.DataAnnotations;

namespace SRMS.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; } = null!;
        public int RollNo { get; set; }
        public string Gender { get; set; } = null!;
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public string Class { get; set; } = null!;
    }
}
