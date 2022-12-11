using System;

namespace PolicyProject.Dtos.PolicyDetailDto
{
    public class PostPolicyDetailDto
    {
        public int PolicyDetailId { get; set; }

        public int PolicyId { get; set; }
        public double InitialDeposite { get; set; }

        public int UserId { get; set; }

        public DateTime StartDate { get; set; }

        public int Duration { get; set; }

        public int TermsPerYear { get; set; }
        public double TermsAmount { get; set; }
    }
}
