using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTgen.Models;

namespace TTgen.Services;

public class TeacherService
{
    private readonly SchoolContext _context;

    public TeacherService(SchoolContext context)
    {
        _context = context;
    }

    public void AddTeacher(string name)
    {
        var teacher = new Teacher { Name = name };
        _context.Teachers.Add(teacher);
        _context.SaveChanges();
    }

    public void UpdateTeacher(int id, string newName)
    {
        var teacher = _context.Teachers.Find(id);
        if (teacher != null)
        {
            teacher.Name = newName;
            _context.SaveChanges();
        }
    }

    public void SoftDeleteTeacher(int id)
    {
        var teacher = _context.Teachers.Find(id);
        if (teacher != null)
        {
            teacher.IsActive = false;
            _context.SaveChanges();
        }
    }

    public List<Teacher> GetTeachers()
    {
        return _context.Teachers.ToList();
    }
}

