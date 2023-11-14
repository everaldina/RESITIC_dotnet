# region exercicio foreach
// See https://aka.ms/new-console-template for more information
string[] colecao = {"Item1", "Item2", "Item3", "Item4"};

foreach (string item in colecao){
    Console.WriteLine(item);
}

# endregion

#region exercicio ler do teclado
Console.Write("Digite o seu nome: ");
string nome = Console.ReadLine();
Console.WriteLine($"Olá {nome}.");

# endregion

