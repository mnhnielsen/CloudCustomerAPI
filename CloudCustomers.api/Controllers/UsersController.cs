using Microsoft.AspNetCore.Mvc;
using CloudCustomers.api.Services;

namespace CloudCustomers.api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userservice)
    {
        _userService = userservice;
    }


    [HttpGet(Name = "GetUsers")]
    public async Task<IActionResult> Get()
    {
        var users = await _userService.GetAllUsers();

        if(users.Any())
            return Ok(users);

        return NotFound();
    }
}
