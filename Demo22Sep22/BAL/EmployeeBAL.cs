using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Interface;
using DAL.Interface;
using DTO;

namespace BAL
{
    public class EmployeeBAL : IEmployeeBAL
    {
        private readonly IEmployeeDAL _employeeDAL;

        public EmployeeBAL(IEmployeeDAL employeeDAL)
        {
            _employeeDAL = employeeDAL;
        }
        public List<Department> GetDepartment()
        {
            return _employeeDAL.GetDepartment();
        }

        public List<Location> GetLocation()
        {
            return _employeeDAL.GetLocation();
        }

        public int SaveDepartment(Department department)
        {
            return _employeeDAL.SaveDepartment(department);
        }

        public int SaveJobDetail(JobDetail jobDetail)
        {
            return _employeeDAL.SaveJobDetail(jobDetail);
        }

        public int SaveLocation(Location location)
        {
            return _employeeDAL.SaveLocation(location);
        }

        public int UpdateDepartment(int id, Department department)
        {
            return _employeeDAL.UpdateDepartment(id, department);
        }
        public int UpdateLocation(int id, Location location)
        {
            return _employeeDAL.UpdateLocation(id, location);
        }
        public int UpdateJobDetail(int id, JobDetail jobDetail)
        {
            return _employeeDAL.UpdateJobDetail(id, jobDetail);
        }

        public JobDetailList GetJobDetail(int id)
        {
            return _employeeDAL.GetJobDetail(id);
        }
    }
}
