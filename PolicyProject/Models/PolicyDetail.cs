using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PolicyProject.Models
{
    public class PolicyDetail
    {
        public int PolicyDetailId { get; set; }

        public int PolicyId { get; set; }
        public Policy Policy { get; set; }
        public double InitialDeposite { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }

        public int Duration { get; set; }

        public int TermsPerYear { get; set; }
        public double TermsAmount { get; set; }
        public string Status { get; set; } = "pending";
    }
}
