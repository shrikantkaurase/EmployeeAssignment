using EmployeeTest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeTest.Repository
{
    public class EmpolyeeInfo : IEmployeeInfo
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EmpolyeeInfo(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<Companies>> GetCompaniesAsync()
        {
            List<Companies> _companyDetails = new List<Companies>();
            HttpClient _httpClient = _httpClientFactory.CreateClient("ctaima");
            if (_httpClient != null)
            {
                HttpResponseMessage _httpResponseMessage = await _httpClient.GetAsync("api/companies");

                if (_httpResponseMessage.IsSuccessStatusCode)
                {
                    string _companyResponse = _httpResponseMessage.Content.ReadAsStringAsync().Result;
                    _companyDetails = JsonConvert.DeserializeObject<List<Companies>>(_companyResponse);
                }
            }
            return _companyDetails;
        }

        public async Task<List<Employee>> GetEmployeeAsync()
        {
            List<Employee> _empDetails = new List<Employee>();
            HttpClient _httpClient = _httpClientFactory.CreateClient("ctaima");
            if (_httpClient != null)
            {
                HttpResponseMessage _httpResponseMessage = await _httpClient.GetAsync("api/employees");
                if (_httpResponseMessage.IsSuccessStatusCode)
                {
                    string _empResponse = _httpResponseMessage.Content.ReadAsStringAsync().Result;
                    _empDetails = JsonConvert.DeserializeObject<List<Employee>>(_empResponse);
                }
            }
            return _empDetails;
        }
    }
}
