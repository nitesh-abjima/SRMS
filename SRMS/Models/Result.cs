using Microsoft.Build.Framework;

namespace SRMS.Models
{
    public class Result
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int RollNo { get; set; }
        [Required]
        public decimal Maths { get; set; }
        [Required]
        public decimal English { get; set; }
        [Required]
        public decimal Science { get; set; }
        [Required]
        public decimal History { get; set; }
        [Required]
        public decimal Marks { get; set; }
        [Required]
        public decimal Percentage { get; set; }
        [Required]
        public string Decision { get; set; }
    }
}
