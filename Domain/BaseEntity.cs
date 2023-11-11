using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BaseEntity
    {
        public DateTime CreatedOn { get; set; }
        public DateTime CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set;}
        public DateTime UpdatedBy { get; set;}

    }
}
