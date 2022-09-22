using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DAL.Interface;
using DTO;

namespace DAL
{
    public class EmployeeDAL : IEmployeeDAL
    {
        private readonly IDataAccess _dataAccess;

        public EmployeeDAL(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public List<Department> GetDepartment()
        {
            List<Department> departmentList = new List<Department>();
            var reader = _dataAccess.GetDataReader(ProcedureName.stp_GetDepartment, CommandType.StoredProcedure);
            while (reader.Read())
            {
                Department department = new Department();
                department.Title = Convert.ToString(reader[DbColumnName.Title]);
                department.Id = Convert.ToInt32(reader[DbColumnName.Id]);
                departmentList.Add(department);
            }
            return departmentList;
        }

        public List<Location> GetLocation()
        {
            List<Location> locationList = new List<Location>();
            var reader = _dataAccess.GetDataReader(ProcedureName.stp_GetLocation, CommandType.StoredProcedure);
            while (reader.Read())
            {
                Location location = new Location();
                location.Title = Convert.ToString(reader[DbColumnName.Title]);
                location.Id = Convert.ToInt32(reader[DbColumnName.Id]);
                location.City = Convert.ToString(reader[DbColumnName.City]);
                location.Country = Convert.ToString(reader[DbColumnName.Country]);
                location.Zip = Convert.ToString(reader[DbColumnName.Zip]);
                location.State = Convert.ToString(reader[DbColumnName.State]);
                locationList.Add(location);
            }
            return locationList;
        }

        public int SaveDepartment(Department department)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
           {
                new SqlParameter(DBVariable.Title,department.Title),
           };
            var departmentId = _dataAccess.ExecuteScaler(ProcedureName.stp_SaveDepartment, CommandType.StoredProcedure, sqlParameters);
            return Convert.ToInt32(departmentId);
        }
        public int SaveLocation(Location location)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
           {
                new SqlParameter(DBVariable.Title,location.Title),
                 new SqlParameter(DBVariable.City,location.City),
                  new SqlParameter(DBVariable.State,location.State),
                   new SqlParameter(DBVariable.Country,location.Country),
                   new SqlParameter(DBVariable.Zip,location.Zip)
           };
            var locationId = _dataAccess.ExecuteScaler(ProcedureName.stp_SaveLocation, CommandType.StoredProcedure, sqlParameters);
            return Convert.ToInt32(locationId);
        }

        public int UpdateDepartment(int id, Department department)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
           {
                new SqlParameter(DBVariable.Title,department.Title),
                new SqlParameter(DBVariable.Id,id),
           };
            return _dataAccess.ExecuteDMLQuery(ProcedureName.stp_UpdateDepartment, CommandType.StoredProcedure, sqlParameters);
        }
        public int UpdateLocation(int id, Location location)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
           {
                new SqlParameter(DBVariable.Title,location.Title),
                new SqlParameter(DBVariable.City,location.City),
                new SqlParameter(DBVariable.State,location.State),
                new SqlParameter(DBVariable.Country,location.Country),
                new SqlParameter(DBVariable.Zip,location.Zip),
                new SqlParameter(DBVariable.Id,id),
           };
            return _dataAccess.ExecuteDMLQuery(ProcedureName.stp_UpdateLocation, CommandType.StoredProcedure, sqlParameters);
        }

        public int SaveJobDetail(JobDetail jobDetail)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
           {
                new SqlParameter(DBVariable.Title,jobDetail.Title),
                 new SqlParameter(DBVariable.Description,jobDetail.Description),
                  new SqlParameter(DBVariable.LocationId,jobDetail.LocationId),
                   new SqlParameter(DBVariable.DepartmentId,jobDetail.DepartmentId),
                   new SqlParameter(DBVariable.ClosingDate,jobDetail.ClosingDate)
           };
            return _dataAccess.ExecuteDMLQuery(ProcedureName.stp_SaveJobDetail, CommandType.StoredProcedure, sqlParameters);
        }
        public int UpdateJobDetail(int id, JobDetail jobDetail)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
           {
                new SqlParameter(DBVariable.Title,jobDetail.Title),
                 new SqlParameter(DBVariable.Description,jobDetail.Description),
                  new SqlParameter(DBVariable.LocationId,jobDetail.LocationId),
                   new SqlParameter(DBVariable.DepartmentId,jobDetail.DepartmentId),
                   new SqlParameter(DBVariable.ClosingDate,jobDetail.ClosingDate),
                new SqlParameter(DBVariable.Id,id),
           };
            return _dataAccess.ExecuteDMLQuery(ProcedureName.stp_UpdateJobDetail, CommandType.StoredProcedure, sqlParameters);
        }
        public JobDetailList GetJobDetail(int id)
        {
            JobDetailList jobDetail = new JobDetailList();
            ;
            SqlParameter[] sqlParameters = new SqlParameter[]
          {

                new SqlParameter(DBVariable.Id,id),
          };
            var reader = _dataAccess.GetDataReader(ProcedureName.stp_GetJobDetail, CommandType.StoredProcedure, sqlParameters);
            while (reader.Read())
            {
                jobDetail.Title = Convert.ToString(reader[DbColumnName.Title]);
                jobDetail.Code = Convert.ToString(reader[DbColumnName.Code]);
                jobDetail.Description = Convert.ToString(reader[DbColumnName.Description]);
                jobDetail.Id = Convert.ToInt32(reader[DbColumnName.Id]);


                jobDetail.ClosingDate = Convert.ToDateTime(reader[DbColumnName.ClosingDate]);
                jobDetail.PostedDate = Convert.ToDateTime(reader[DbColumnName.PostedDate]);
                jobDetail.Department = new Department()
                {
                    Id = Convert.ToInt32(reader[DbColumnName.DepartmentId]),
                    Title = Convert.ToString(reader[DbColumnName.DepartmentTitle])
                };
                jobDetail.Location = new Location()
                {
                    Id = Convert.ToInt32(reader[DbColumnName.LocationId]),
                    Title = Convert.ToString(reader[DbColumnName.LocationTitle]),
                    City = Convert.ToString(reader[DbColumnName.City]),
                    State = Convert.ToString(reader[DbColumnName.State]),
                    Country = Convert.ToString(reader[DbColumnName.Country]),
                    Zip = Convert.ToString(reader[DbColumnName.Zip])
                };
            }

            return jobDetail;
        }
    }
}
