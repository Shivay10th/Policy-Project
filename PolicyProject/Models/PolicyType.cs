using System.Collections.Generic;

namespace PolicyProject.Models
{
    public class PolicyType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Policy> Policies { get; set; }
    }
}
