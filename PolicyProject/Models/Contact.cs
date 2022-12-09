using System.ComponentModel.DataAnnotations;

namespace PolicyProject.Models
{
    public class Contact
    {
        public int ContactId { get; set; }

        [Required]
        [StringLength(20)]

        public string Email { get; set; }
        [Required]
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        public int? PolicyId { get; set; }
        public Policy Policy { get; set; }
        public string Message { get; set; }
    }
}
