using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyProject.Models
{
    [Table("Policy")]
    public class Policy
    {
        [Key]
        public int PolicyId { get; set; }
        public string PolicyName { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public string CompanyName { get; set; }
        public double InitialDeposite { get; set; }
        public string PolicyType { get; set; }
        public string UserType { get; set; }
        public int TermsPerYear { get; set; }
        public double TermsAmount { get; set; }
        public double Interest { get; set; }
    }
}
