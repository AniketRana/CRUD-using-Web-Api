using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CRUD_WebApi.Models
{
    public class EmployeeClient
    {
        private string Base_URL = "http://localhost:30110/api/";

        public IEnumerable<Employee> FindAll()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respon = client.GetAsync("employee").Result;
                if (respon.IsSuccessStatusCode)
                {
                    return respon.Content.ReadAsAsync<IEnumerable<Employee>>().Result;
                }
                else
                {
                    return null;
                }
            }
            catch 
            {
                return null;
            }
        }

        public Employee Find(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respon = client.GetAsync("employee/"+ id).Result;
                if (respon.IsSuccessStatusCode)
                {
                    return respon.Content.ReadAsAsync<Employee>().Result;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public bool create(Employee employee)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respon = client.PostAsJsonAsync("employee", employee).Result;
                return respon.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(Employee employee)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respon = client.PutAsJsonAsync("employee/" + employee.EmpID,employee).Result;
                return respon.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id) 
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage respon = client.DeleteAsync("employee/"+id).Result;
                return respon.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}