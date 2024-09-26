using Microsoft.EntityFrameworkCore;
using TTgen.Models;

namespace TTgen.Services;

class SchoolClassService
{
    private readonly SchoolContext _context;

    public SchoolClassService(SchoolContext context)
    {
        _context = context;
    }

    public async Task<List<SchoolClass>> GetSchoolClassesAsync()
    {
        return await _context.SchoolClasses.ToListAsync();
    }

    public async Task AddSchoolClassAsync(SchoolClass schoolClass)
    {
        ArgumentNullException.ThrowIfNull(schoolClass);
        _context.SchoolClasses.Add(schoolClass);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateSchoolClassAsync(int id, SchoolClass schoolClass)
    {
        if (_context.Entry(schoolClass).State is EntityState.Modified or EntityState.Unchanged)
        {
            await _context.SaveChangesAsync();
        }

        throw new ArgumentException("Entity must be in modified state or unchanged state to be updated.");
    }
}
