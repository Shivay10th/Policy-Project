using PolicyProject.Dtos.User;
using PolicyProject.Models;
using System;

namespace PolicyProject.Dtos.PolicyDetailDto
{
    public class GetPolicyDetailDto
    {

        public int PolicyDetailId { get; set; }

        public int PolicyId { get; set; }
        public Policy Policy { get; set; }

        public int UserId { get; set; }
        public double InitialDeposite { get; set; }

        public GetUserDto User { get; set; }

        public DateTime StartDate { get; set; }

        public int Duration { get; set; }

        public int TermsPerYear { get; set; }
        public double TermsAmount { get; set; }
        public string Status { get; set; }
    }
}
