using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class JobDetail : JobDetailList
    {

        public int DepartmentId { get; set; }
        public int LocationId { get; set; }

    }
    public class JobDetailList : Base
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime ClosingDate { get; set; }
        public Department Department { get; set; }
        public Location Location { get; set; }
        public DateTime PostedDate { get; set; }
    }
}
