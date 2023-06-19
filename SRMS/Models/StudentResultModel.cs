using System.ComponentModel.DataAnnotations;

namespace SRMS.Models
{
    public class StudentResultModel
    {
        public string StudentName { get; set; }
        public int RollNo { get; set; }
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public string Class { get; set; }
        public decimal Maths { get; set; }
        public decimal English { get; set; }
        public decimal Science { get; set; }
        public decimal History { get; set; }
        public decimal Marks { get; set; }
        public decimal Percentage { get; set; }
        public string Decision { get; set; }
    }
}
