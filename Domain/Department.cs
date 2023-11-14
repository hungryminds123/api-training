using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Department : BaseEntity
    {
        public int DepartmentId { get; set; }

        public string? DepartmentName { get; set; }
    }
}
