using BlazorAlexConsumer.Models;
using System.Net.Http.Json;

namespace BlazorAlexConsumer.Services
{
    public class DepartmentServices : IServices<Department>
    {
        HttpClient _httpClient=null;
        public DepartmentServices(HttpClient httpclient)
        {
          _httpClient = httpclient;
        }
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Department>> GetAll()
        {
             return await _httpClient.GetFromJsonAsync<List<Department>>("api/Department");
        }

        public Task<Department> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Department item)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, Department item)
        {
            throw new NotImplementedException();
        }
    }
}
