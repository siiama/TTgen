﻿namespace TTgen.Models;

public enum SubjectApplicableClasses
{
    Class1 = 1,
    Class2 = 2,
    Class3 = 3,
    Class4 = 4,
    Class5 = 5,
    Class6 = 6,
    Class7 = 7,
    Class8 = 8,
    Class9 = 9,
    Class10 = 10,
    Class11 = 11
}

public class Subject
{
    public int Id { get; set; }
    public string ShortName { get; set; }
    public string FullName { get; set; }
    public bool IsActive { get; set; }
    public SubjectApplicableClasses ApplicableClasses { get; set; }
}
