using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyProject.Dtos.User
{
    public class UserRegisterDto
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }

        public double Salary { get; set; }
        public string Pan { get; set; }
        public string EmployerType { get; set; }
        public string EmployerName { get; set; }
public string Password { get; set; }
    }
}
