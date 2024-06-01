using BlazorAlexConsumer.Models;
using System.Net.Http.Json;

namespace BlazorAlexConsumer.Services
{
    public class EmployeService : IServices<Employee>
    {
        HttpClient _httpClient=null;//inject =="create" ??? register ??? ip
        public EmployeService(HttpClient _httpClient)
        {
            this._httpClient = _httpClient;
            //_httpClient = new HttpClient();
            //_httpClient.BaseAddress = new Uri("http://localhost:63289/");
        }


        public async Task<List<Employee>> GetAll()
        {
            //Call Endpoint fomr Web aPI 
            List<Employee>? Emplist =  await _httpClient
                .GetFromJsonAsync<List<Employee>>
                ("api/Employees");

            return Emplist;
        }
        public async Task Delete(int id)
        {
           await  _httpClient.DeleteAsync($"api/Employees/{id}");
        }

        public async Task<Employee> GetByID(int id)
        {
            Employee empobj=await _httpClient.GetFromJsonAsync<Employee>($"api/Employees/{id}");
            return empobj;
        }

        public async Task Insert(Employee item)
        {
           await _httpClient.PostAsJsonAsync<Employee>("api/Employees", item);
        }

        public async Task Update(int id,Employee item)
        {
            await _httpClient.PutAsJsonAsync<Employee>($"api/Employees/{id}", item);
        }
    }
}
