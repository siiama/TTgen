using Microsoft.EntityFrameworkCore;
using TTgen.Models;

namespace TTgen.Services;

public class TeacherService
{
    private readonly SchoolContext _context;

    public TeacherService(SchoolContext context)
    {
        _context = context;
    }

    public async Task<List<Teacher>> GetTeachersAsync()
    {
        return await _context.Teachers.ToListAsync();
    }

    public async Task AddTeacherAsync(Teacher teacher)
    {
        ArgumentNullException.ThrowIfNull(teacher);
        _context.Teachers.Add(teacher);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTeacherAsync(int id, Teacher teacher)
    {
        if (_context.Entry(teacher).State is EntityState.Modified or EntityState.Unchanged)
        {
            await _context.SaveChangesAsync();
        }

        throw new ArgumentException("Entity must be in modified state or unchanged state to be updated.");
    }

    public async Task SoftDeleteTeacherAsync(int id)
    {
        var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == id);
        teacher.IsActive = false;
        await _context.SaveChangesAsync();
    }
}

