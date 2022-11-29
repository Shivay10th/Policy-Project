﻿using System;

namespace PolicyProject.Dtos.User
{
    public class UserUpdateDto
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }

        public double Salary { get; set; }
        public string EmployerType { get; set; }
        public string EmployerName { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
    }
}
