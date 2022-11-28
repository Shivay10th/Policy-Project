using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PolicyProject.Models
{
    [Table("Policy")]
    public class Policy
    {
        [Key]
        public int PolicyId { get; set; }
        public string PolicyName { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public double InitialDeposite { get; set; }
        public string UserType { get; set; }
        public int TermsPerYear { get; set; }
        public double TermsAmount { get; set; }
        public double Interest { get; set; }

        public int PolicyTypeId { get; set; }
        public PolicyType PolicyType { get; set; }
    }
}
