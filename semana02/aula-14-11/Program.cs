# region exercicio foreach
// See https://aka.ms/new-console-template for more information
string[] colecao = {"Item1", "Item2", "Item3", "Item4"};

Console.WriteLine("USANDO FOR");
foreach (string item in colecao){
    Console.WriteLine(item);
}
Console.WriteLine();

# endregion

#region exercicio ler do teclado
Console.WriteLine("USANDO READLINE");
Console.Write("Digite o seu nome: ");
string nome = Console.ReadLine();
Console.WriteLine($"Olá {nome}.\n");

# endregion

#region exercicio 1
/*
    Escreva um programa em C# que imprime todos os números que são divisíveis por 3 ou por 4 entre 0 e 30;
*/
Console.WriteLine("EXERCICIO 1");
int i;
for (i=0; i<=30; i++){
    if (i%3 == 0 || i%4 == 0){
        Console.WriteLine(i+ " é divisivel por 3 ou 4");
    }
}

#endregion

#region exercicio 2
/*
    Faça um programa em C# que imprima os primeiros números da série de Fibonacci até passar de 100. 
    A série de Fibonacci é a seguinte: 0, 1, 1, 2, 3, 5, 8, 13, 21 etc... 
    Para calculá-la, o primeiro elemento vale 0, o segundo vale 1, daí por diante, o n-ésimo elemento vale 
    o (n-1)-ésimo elemento somado ao (n-2)-ésimo elemento (ex: 8 = 5 + 3)
*/
Console.WriteLine("\nEXERCICIO 2");
int fib0 = 0, fib1 = 1, fibn = fib0 + fib1;
for (i=0; fibn<=100; i++){
    Console.WriteLine($"fib({i}) = {fibn}");
    fib0 = fib1;
    fib1 = fibn;
    fibn = fib0 + fib1;
}
Console.WriteLine($"fib({i}) = {fibn}\n");

# endregion

#region exercicio 3
/*
Faça um programa que imprima a seguinte tabela até o nível 8:
1
2   4
3   6       9
4   8       12      16
n   n*2     n*3     n*4  ...    n*n
*/
Console.WriteLine("EXERCICIO 3");
for (i=1; i<=8; i++){
    for (var j=1; j<=i; j++){
        Console.Write($"{i*j}\t");
    }
    Console.WriteLine();
}


# endregion

# region Listas
// lista de inteiros
List<int> numeros = new List<int>();

// adicionando elementos
numeros.Add(1);
numeros.Add(2);
numeros.Add(3);
numeros.Add(4);
numeros.Add(5);

Console.WriteLine("LISTA DE INTEIROS");
foreach (int item in numeros){
    Console.WriteLine(item);
}

Console.WriteLine($"Tamanho da lista = {numeros.Count}");
Console.WriteLine($"Contem elemento 3? {numeros.Contains(3)}");
Console.WriteLine($"Contem elemento 6? {numeros.Contains(6)}");


// lista de nomes
List<string> listaNome = new List<string>();

// adicionando elementos
listaNome.Add("João");
listaNome.Add("Maria");
listaNome.Add("José");
listaNome.Add("Ana");

Console.WriteLine("\nLISTA DE NOMES");
foreach (string item in listaNome){
    Console.WriteLine(item);
}
# endregion

# region DateTime
// 01/01/0001 00:00:00 ate 31/12/9999 23:59:59
// depende de uma cultura

// exercicio1
/*
    Suponha que você tenha uma string contendo uma data no formato
    "dd/mm/aaaa" (por exemplo, "25/10/2023"). Crie um programa que divida a
    string em dia, mês e ano e exiba cada parte separadamente.
*/
string dataString = "25/10/2023", dataFormat = dataString.Replace("/", "-");
DateTime data = DateTime.Parse(dataFormat);
Console.WriteLine("Data: " + data.ToShortDateString());
Console.WriteLine("Dia: " + data.Day);
Console.WriteLine("Mês: " + data.Month);
Console.WriteLine("Ano: " + data.Year);



// exercicio2
/*
    Crie um programa que inicialize um array de inteiros com números de 1 a 10.
    Em seguida, itere pelo array e exiba apenas os números pares.
*/


// exercicio3
/*
    Crie uma lista de strings contendo nomes de cidades. Adicione mais
    algumas cidades a essa lista. Em seguida, crie um programa que itere pela
    lista e exiba todas as cidades cujos nomes começam com a letra "S".
*/


// exercicio4
/*
    Crie um programa que determine a diferença de tempo em minutos entre a
    data e hora atual e uma data e hora específica no futuro, por exemplo,
    "01/01/2024 12:00". Exiba o resultado
*/

# endregion