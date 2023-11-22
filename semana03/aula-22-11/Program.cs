#region Cultura
using System.Globalization;
CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");

# endregion



# region tuple
List<(int id, string nome, DateTime dataNasc)> list = new();
list.Add((1, "Everaldina Barbosa", new DateTime(2001, 07, 12)));
list.Add((2, "Alberto Henrique II", new DateTime(1999, 02, 14)));
list.Add((3, "Sabrina Guimaraes", new DateTime(2005, 11, 27)));

list.ForEach(item => Console.WriteLine($"{item.id} - Nome: {item.nome} - {item.dataNasc}"));

# endregion

# region expressao lambda

string[] pessoas = {"Everaldina Barbosa", "Alberto Henrique II", "Sabrina Guimaraes", "Marcos da Silva Santos", 
                    "Ana Ferreira", "Carla Maria", "Jose Santos", "Carlos da Silva", "Cosme Ferreira"};
string[] sobrenome = {"Silva", "Ferreira"};
Console.WriteLine($"Pessoas com sobrenome {sobrenome[0]} ou {sobrenome[1]}: {string.Join(", ", pessoas.Where(x => (x.Contains(sobrenome[0]) || x.Contains(sobrenome[1]))))}");
#endregion


# region LINQ
var students = new List<Student>{
   new Student(1, "Everaldina Barbisa", "123456789", new DateTime(2001, 07, 12), new List<string>{"123456789", "73982003551"}),
   new Student(2, "Alberto Henrique", "987654321", new DateTime(1999, 2, 14), new List<string>{"123456789", "73987654321"}),
   new Student(3, "Sabrina Guimaraes", "123456789", new DateTime(2005, 11, 27), new List<string>{"123456789", "77988237086"}),
   new Student(4, "Gabriel Freitas", "843753", new DateTime(2002, 10, 20), new List<string>{"123456789"})
};

var any = students.Any();
var anyHelder = students.Any(x => x.FullName.Contains("Helder"));

var singleOrDefault = students.SingleOrDefault(x => x.Id == 10);

var select = students.Select(x => x.PhoneNumbers);
var selectMany = students.SelectMany(x => x.PhoneNumbers);

var legalAge = students.Where(x => x.BirthDate <= DateTime.Today.AddYears(-18)).Select(x => x.FullName);
Console.WriteLine($"Legal age people: {string.Join(", ", legalAge)}");

# endregion


 public class Student{
   public Student(int id, string fullName, string document, DateTime birthDate, List<string> phoneNumbers)
   {
      Id = id;
      FullName = fullName;
      Document = document;
      BirthDate = birthDate;
      PhoneNumbers = new List<string>(phoneNumbers);
   }

   public int Id { get; set; }
   public string FullName { get; set; }
   public string Document { get; set; }
   public DateTime BirthDate { get; set; }
   public List<string> PhoneNumbers { get; set; }
}
