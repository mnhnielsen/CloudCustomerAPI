namespace CloudCustomers.api.Services;
using Models;

public interface IUserService
{
    public Task<List<User>> GetAllUsers();
}
