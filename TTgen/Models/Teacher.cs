namespace TTgen.Models;

public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public bool IsPrimarySchoolTeacher { get; set; }
    public bool IsActive { get; set; }
}
