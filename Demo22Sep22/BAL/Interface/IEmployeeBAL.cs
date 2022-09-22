using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BAL.Interface
{
    public interface IEmployeeBAL
    {
        List<Department> GetDepartment();
        List<Location> GetLocation();
        JobDetailList GetJobDetail(int id);
        int SaveDepartment(Department department);
        int SaveLocation(Location location);
        int UpdateDepartment(int id, Department department);
        int UpdateLocation(int id, Location location);
        int SaveJobDetail(JobDetail jobDetail);
        int UpdateJobDetail(int id, JobDetail jobDetail);
    }
}
