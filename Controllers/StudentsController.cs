using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentService.Data;
using StudentService.Models;

namespace StudentService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly AppDbContext _context;

    public StudentsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/students
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetAll()
    {
        return await _context.Students.ToListAsync();
    }

    // GET: api/students/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetById(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student is null)
            return NotFound(new { message = $"Student with id {id} not found." });

        return student;
    }

    // POST: api/students
    [HttpPost]
    public async Task<ActionResult<Student>> Create(Student student)
    {
        student.EnrolledAt = DateTime.UtcNow;
        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
    }

    // PUT: api/students/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Student updatedStudent)
    {
        if (id != updatedStudent.Id)
            return BadRequest(new { message = "Id in URL does not match Id in body." });

        var existing = await _context.Students.FindAsync(id);
        if (existing is null)
            return NotFound(new { message = $"Student with id {id} not found." });

        existing.FirstName = updatedStudent.FirstName;
        existing.LastName = updatedStudent.LastName;
        existing.Email = updatedStudent.Email;
        existing.Age = updatedStudent.Age;
        existing.Major = updatedStudent.Major;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/students/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student is null)
            return NotFound(new { message = $"Student with id {id} not found." });

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
