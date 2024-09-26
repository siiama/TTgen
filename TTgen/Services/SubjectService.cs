using Microsoft.EntityFrameworkCore;
using TTgen.Models;

namespace TTgen.Services;

class SubjectService
{
    private readonly SchoolContext _context;

    public SubjectService(SchoolContext context)
    {
        _context = context;
    }

    public async Task<List<Subject>> GetSubjectsAsync()
    {
        return await _context.Subjects.ToListAsync();
    }

    public async Task AddSubjectAsync(Subject subject)
    {
        ArgumentNullException.ThrowIfNull(subject);
        _context.Subjects.Add(subject);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateSubjectAsync(int id, Subject subject)
    {
        if (_context.Entry(subject).State is EntityState.Modified or EntityState.Unchanged)
        {
            await _context.SaveChangesAsync();
        }

        throw new ArgumentException("Entity must be in modified state or unchanged state to be updated.");
    }

    public async Task SoftDeleteSubjectAsync(int id)
    {
        var subject = await _context.Subjects.FirstOrDefaultAsync(x => x.Id == id);
        subject.IsActive = false;
        await _context.SaveChangesAsync();
    }
}
