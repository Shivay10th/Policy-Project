﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Column(TypeName = "Date")]
        public DateTime DOB { get; set; }
        [Required]
        public string ContactNo { get; set; }
        [Required]
        [StringLength(450)]

        public string Email { get; set; }

        public double Salary { get; set; }
        [StringLength(10)]
        public string Pan { get; set; }
        [Column(TypeName = "char(1)")]
        public string EmployerType { get; set; }
        public string EmployerName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        [Required]
        public string Role { get; set; }
    }
}