using BAL.Interface;
using Common;
using Demo22Sep22.Model;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo22Sep22.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBAL _employeeBAL;

        public EmployeeController(IEmployeeBAL employeeBAL)
        {
            _employeeBAL = employeeBAL;
        }

        [Route(Routes.GetDepartment, Name = RouteName.GetDepartment)]
        [HttpGet]
        public IActionResult GetDepartment()
        {
            try
            {
                var employees = _employeeBAL.GetDepartment();
                if (employees.Count > 0)
                    return Ok(employees);
                return NoContent();
            }
            catch (Exception err)
            {
                return BadRequest();
            }
        }

        [Route(Routes.JobDetail, Name = RouteName.JobDetail)]
        [HttpGet]
        public IActionResult GetJobDetail(int id)
        {
            try
            {
                var jobDetail = _employeeBAL.GetJobDetail(id);
                if (jobDetail != null)
                    return Ok(jobDetail);
                return NoContent();
            }
            catch (Exception err)
            {
                return BadRequest();
            }
        }

        [Route(Routes.GetLocation, Name = RouteName.GetLocation)]
        [HttpGet]
        public IActionResult GetLocation()
        {
            try
            {
                var locations = _employeeBAL.GetLocation();
                if (locations.Count > 0)
                    return Ok(locations);
                return NoContent();
            }
            catch (Exception err)
            {
                return BadRequest();
            }
        }

        [Route(Routes.SaveDepartment, Name = RouteName.SaveDepartment)]
        [HttpPost]
        public async Task<IActionResult> SaveDepartment(DepartmentMdl departmentMdl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var departmentDetail = TransformDepartment(departmentMdl);
                    var res = _employeeBAL.SaveDepartment(departmentDetail);
                    if (res > 0)
                        return Ok(res);
                }
                return BadRequest();
            }
            catch (Exception err)
            {
                return BadRequest();
            }
        }
        [Route(Routes.SaveLocation, Name = RouteName.SaveLocation)]
        [HttpPost]
        public async Task<IActionResult> SaveLocation(LocationMdl locationMdl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var locationDetail = TransformLocation(locationMdl);
                    var res = _employeeBAL.SaveLocation(locationDetail);
                    if (res > 0)
                        return Ok(res);
                }
                return BadRequest();
            }
            catch (Exception err)
            {
                return BadRequest();
            }
        }

        [Route(Routes.UpdateDepartment, Name = RouteName.UpdateDepartment)]
        [HttpPost]
        public async Task<IActionResult> UpdateDepartment(int id, DepartmentMdl departmentMdl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var departmentDetail = TransformDepartment(departmentMdl);
                    var res = _employeeBAL.UpdateDepartment(id, departmentDetail);
                    if (res > 0)
                        return Ok(Messages.UpdateDepartmentSucc);
                }
                return BadRequest();
            }
            catch (Exception err)
            {
                return BadRequest();
            }
        }
        [Route(Routes.UpdateLocation, Name = RouteName.UpdateLocation)]
        [HttpPost]
        public async Task<IActionResult> UpdateLocation(int id, LocationMdl locationMdl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var locationDetail = TransformLocation(locationMdl);
                    var res = _employeeBAL.UpdateLocation(id, locationDetail);
                    if (res > 0)
                        return Ok(Messages.UpdateLocationtSucc);
                }
                return BadRequest();
            }
            catch (Exception err)
            {
                return BadRequest();
            }
        }

        [Route(Routes.SaveJob, Name = RouteName.SaveJob)]
        [HttpPost]
        public async Task<IActionResult> SaveJobDetail(JobDetailMdl jobDetailMdl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var jobsData = TransformJobDetaile(jobDetailMdl);
                    var res = _employeeBAL.SaveJobDetail(jobsData);
                    if (res > 0)
                        return Ok(Messages.SaveJobDetail);
                }
                return BadRequest();
            }
            catch (Exception err)
            {
                return BadRequest();
            }
        }
        [Route(Routes.UpdateJobDetail, Name = RouteName.UpdateJobDetail)]
        [HttpPost]
        public async Task<IActionResult> UpdateJobDetail(int id, JobDetailMdl jobDetailMdl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var jobsData = TransformJobDetaile(jobDetailMdl);
                    var res = _employeeBAL.UpdateJobDetail(id, jobsData);
                    if (res > 0)
                        return Ok(Messages.UpdateJobDetailSucc);
                }
                return BadRequest();
            }
            catch (Exception err)
            {
                return BadRequest();
            }
        }

        private Department TransformDepartment(DepartmentMdl departmentMdl)
        {
            return new Department()
            {
                Title = departmentMdl.Title
            };
        }
        private Location TransformLocation(LocationMdl locationMdl)
        {
            return new Location()
            {
                Title = locationMdl.Title,
                City = locationMdl.City,
                State = locationMdl.State,
                Country = locationMdl.Country,
                Zip = locationMdl.Zip,

            };
        }

        private JobDetail TransformJobDetaile(JobDetailMdl jobDetailMdl)
        {
            return new JobDetail()
            {
                Title = jobDetailMdl.Title,
                Description = jobDetailMdl.Description,
                LocationId = jobDetailMdl.locationId,
                DepartmentId = jobDetailMdl.DepartmentId,
                ClosingDate = jobDetailMdl.ClosingDate,

            };
        }


    }
}
