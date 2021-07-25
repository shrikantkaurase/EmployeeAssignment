using EmployeeTest.Models;
using EmployeeTest.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeTest.Controllers
{
    [ApiController]
    public class EmployeeInfoController : Controller
    {
        private readonly IEmployeeInfo _employeeInfo;

        public EmployeeInfoController(IEmployeeInfo EmployeeInfo)
        {
            _employeeInfo = EmployeeInfo;
        }
        [HttpGet]
        [Route("GetEmployeeInfo")]
        public IEnumerable<ViewModel> Get()
        {
            try
            {
                IEnumerable<ViewModel> viewModels = null;
                List<Companies> Companies = _employeeInfo.GetCompaniesAsync().Result;
                List<Employee> Employee = _employeeInfo.GetEmployeeAsync().Result;
                if (Companies.Count > 0 && Employee.Count > 0)
                {
                    viewModels = from e in Employee
                                 join c in Companies on e.companyId equals c.id
                                 select new ViewModel
                                 {
                                     employee = e.name,
                                     company = c.name
                                 };
                }
                return viewModels;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
