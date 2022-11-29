using PolicyProject.Models;
using System.Collections.Generic;

namespace PolicyProject.Dtos.PolicyTypedto
{
    public class PolicyTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Policy> Policies { get; set; }

    }
}
