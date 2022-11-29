using PolicyProject.Dtos.Policydto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyProject.Models
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = null;

        public static implicit operator ServiceResponse<T>(ServiceResponse<ICollection<PolicyDto>> v)
        {
            throw new NotImplementedException();
        }
    }
}
