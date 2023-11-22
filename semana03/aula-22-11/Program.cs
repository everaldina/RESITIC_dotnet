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
