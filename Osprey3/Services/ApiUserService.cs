using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Osprey3.Models;
using System.Diagnostics;

namespace Osprey3.Services
{
    public class ApiUserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public ApiUserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync("Users");
                return JsonConvert.DeserializeObject<IEnumerable<User>>(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching users: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> CheckUserExistsAsync(string email, string password)
        {
            try
            {
                var request = new { Email = email, Password = password };
                var requestJson = JsonConvert.SerializeObject(request);
                var content = new StringContent(requestJson, System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("Users/CheckUser", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<bool>(responseContent);
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Failed to check user: {errorMessage}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error checking user: {ex.Message}");
                throw;
            }
        }

        public async Task<User> GetUserAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetStringAsync($"Users/{id}");
                return JsonConvert.DeserializeObject<User>(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching user with ID {id}: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> RegisterUserAsync(User user)
        {
            try
            {
                var userJson = JsonConvert.SerializeObject(user);
                var content = new StringContent(userJson, System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("Users", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    return false;
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException($"Registration failed: {errorMessage}");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Network Error: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error registering user: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateUserAsync(User user)
        {
            try
            {
                var userJson = JsonConvert.SerializeObject(user);
                var content = new StringContent(userJson, System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"Users/{user.Id}", content);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating user with ID {user.Id}: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"Users/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting user with ID {id}: {ex.Message}");
                throw;
            }
        }

        public async Task SaveUserAsync(User user)
        {
            if (user.Id == 0)
            {
                await RegisterUserAsync(user);
            }
            else
            {
                await UpdateUserAsync(user);
            }
        }
    }
}