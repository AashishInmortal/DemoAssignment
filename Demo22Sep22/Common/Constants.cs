using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Constants
    {
    }
    public class ProcedureName
    {
        public const string stp_GetDepartment = "stp_GetDepartment";
        public const string stp_GetLocation = "stp_GetLocation";
        public const string stp_SaveDepartment = "stp_SaveDepartment";
        public const string stp_SaveLocation = "stp_SaveLocation";
        public const string stp_UpdateDepartment = "stp_UpdateDepartment";
        public const string stp_UpdateLocation = "stp_UpdateLocation";
        public const string stp_SaveJobDetail = "stp_SaveJobDetail";
        public const string stp_UpdateJobDetail = "stp_UpdateJobDetail";
        public const string stp_GetJobDetail = "stp_GetJobDetail";
    }
    public class DbColumnName
    {
        public const string Title = "Title";
        public const string Id = "Id";
        public const string City = "City";
        public const string State = "State";
        public const string Country = "Country";
        public const string Zip = "Zip";
        public const string Description = "Description";
        public const string ClosingDate = "ClosingDate";
        public const string LocationId = "LocationId";
        public const string DepartmentId = "DepartmentId";
        public const string Code = "Code";
        public const string PostedDate = "PostedDate";
        public const string DepartmentTitle = "DepartmentTitle";
        public const string LocationTitle = "LocationTitle";
    }


    public class DBVariable
    {
        public const string Title = "@Title";
        public const string City = "@City";
        public const string State = "@State";
        public const string Country = "@Country";
        public const string Zip = "@Zip";
        public const string Id = "@Id";

        public const string Description = "@Description";
        public const string ClosingDate = "@ClosingDate";
        public const string LocationId = "@LocationId";
        public const string DepartmentId = "@DepartmentId";
    }



    public class Messages
    {
        public const string UpdateDepartmentSucc = "Department updated successfully.";
        public const string UpdateLocationtSucc = "Location updated successfully.";
        public const string SaveJobDetail = "Job Saved Successfully.";
        public const string UpdateJobDetailSucc = "JobDetail Updated Successfully.";
    }
    public class Routes
    {
        public const string GetDepartment = "api/departments";
        public const string GetLocation = "api/locations";
        public const string SaveDepartment = "api/save-department";
        public const string SaveLocation = "api/save-location";
        public const string UpdateDepartment = "api/update-department/{id}";
        public const string UpdateLocation = "api/update-location/{id}";
        public const string SaveJob = "api/save-job";
        public const string UpdateJobDetail = "api/update-JobDetail/{id}";
        public const string JobDetail = "api/JobDetail";
    }
    public class RouteName
    {
        public const string GetDepartment = "GetDepartment";
        public const string GetLocation = "GetLocation";
        public const string SaveDepartment = "SaveDepartment";
        public const string SaveLocation = "SaveLocation";
        public const string UpdateDepartment = "UpdateDepartment";
        public const string UpdateLocation = "UpdateLocation";
        public const string SaveJob = "SaveJob";
        public const string UpdateJobDetail = "UpdateJobDetail";
        public const string JobDetail = "JobDetail";
    }

}
