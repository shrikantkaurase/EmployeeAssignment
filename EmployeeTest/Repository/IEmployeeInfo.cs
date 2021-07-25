using EmployeeTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTest.Repository
{
    public interface IEmployeeInfo
    {
        Task<List<Companies>> GetCompaniesAsync();
        Task<List<Employee>> GetEmployeeAsync();
    }
}
