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
