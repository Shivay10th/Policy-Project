using PolicyProject.Models;
using System;

namespace PolicyProject.Dtos.Policydto
{
    public class PolicyDto
    {
        public int PolicyId { get; set; }
        public string PolicyName { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
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
