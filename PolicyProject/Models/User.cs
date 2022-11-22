using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyProject.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        [Required]
        public string ContactNo { get; set; }
        [Required]
        [StringLength(450)]

        public string Email { get; set; }

        public double Salary { get; set; }
        public string Pan { get; set; }
        public string EmployerType { get; set; }
        public string EmployerName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
