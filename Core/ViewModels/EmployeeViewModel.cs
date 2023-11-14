using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class EmployeeViewModel
    {

        public int Id { get; set; } 

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Gender { get; set; }

        public string FullName
        {
            get
            {
                return FirstName +  " " + LastName; 
            }
        }
    }
}
