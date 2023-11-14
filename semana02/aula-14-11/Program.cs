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