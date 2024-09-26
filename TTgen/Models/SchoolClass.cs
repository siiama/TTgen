using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTgen.Models;

public enum Number
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

public enum Letter
{
    А,
    Б,
    В,
    Г,
    Д,
    Е,
    Ё,
    Ж,
    З,
    И,
    Й,
    К,
    Л,
    М,
    Н,
    О,
    П,
    Р,
    С,
    Т,
    У,
    Ф,
    Х,
    Ц,
    Ч,
    Ш,
    Щ,
    Ъ,
    Ы,
    Ь,
    Э,
    Ю,
    Я
}

public class SchoolClass
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Number Number { get; set; }
    public Letter Letter { get; set; }
    public Year EnrollmentYear { get; set; }
}
