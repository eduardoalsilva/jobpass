// REST controller for managing users
// Implements basic CRUD operations
// Endpoints:
// POST   /api/users
// GET    /api/users
// GET    /api/users/{id}
// PUT    /api/users/{id}
// DELETE /api/users/{id}
// Keep logic simple, no DTOs for now (MVP)
using JobPass.Api.Data;
using JobPass.Api.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobPass.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly JobPassDbContext _context;
    public UsersController(JobPassDbContext context)
    {
        _context = context;
    }
    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserById(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return user;
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, User updatedUser)
    {
        if (id != updatedUser.Id)
        {
            return BadRequest();
        }
        _context.Entry(updatedUser).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UserExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {       
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return NoContent();
    }
    private bool UserExists(Guid id)
    {
        return _context.Users.Any(e => e.Id == id);
    }
}   