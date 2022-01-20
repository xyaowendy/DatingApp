using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }
    
    // add end point
    // IEnumerable : Exposes an enumerator, which supports a simple iteration over a non-generic collection.
    // https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerable?view=net-6.0
    
    [HttpGet]
    // make code asynchronous
    // 1. specify keyword async
    // 2. tell the method -> wrap code in a task
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }
    
    // eg. api/uses/3
    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        return await _context.Users.FindAsync(id);
    }
}