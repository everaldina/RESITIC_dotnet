# region Tipos de Dados
/*
    2)  Quais são os tipos de dados numéricos inteiros disponíveis no .NET? 
        Dê exemplos de uso para cada um deles através de exemplos.

*/

// imprimimindo tipo, limites inferior e superor e tamanho em bytes
Console.WriteLine("Os tipos númericos inteiros disponíveis no .NET são:");
Console.WriteLine("Tipo\t     Limite inferior\t\tLimite superior\t\tTamanho (bytes)");
Console.WriteLine($"sbyte\t{sbyte.MinValue, 20}{sbyte.MaxValue, 27}{sizeof(sbyte), 17}");
Console.WriteLine($"byte\t{byte.MinValue, 20}{byte.MaxValue, 27}{sizeof(byte), 17}");
Console.WriteLine($"short\t{short.MinValue, 20}{short.MaxValue, 27}{sizeof(short), 17}");
Console.WriteLine($"ushort\t{ushort.MinValue, 20}{ushort.MaxValue, 27}{sizeof(ushort), 17}");
Console.WriteLine($"int\t{int.MinValue, 20}{int.MaxValue, 27}{sizeof(int), 17}");
Console.WriteLine($"uint\t{uint.MinValue, 20}{uint.MaxValue, 27}{sizeof(uint), 17}");
Console.WriteLine($"long\t{long.MinValue, 20}{long.MaxValue, 27}{sizeof(long), 17}");
Console.WriteLine($"ulong\t{ulong.MinValue, 20}{ulong.MaxValue, 27}{sizeof(ulong), 17}");
Console.WriteLine("\n");

#endregion

# region Conversão de Tipos
/*
    3)  Suponha que você tenha uma variável do tipo double e deseja convertê-la em um tipo int. 
        Como você faria essa conversão e o que aconteceria se a parte fracionária da variável 
        double não pudesse ser convertida em um int? Resolva o problema através de um exemplo em C#.

*/

double realFracionarioDown = 42.15645325, realFracionarioUp = 42.99, realFracionarioMid = 42.5;
double realExato = 42.0;
int castIntDown = (int)realFracionarioDown, castIntUp = (int)realFracionarioUp, castIntMid = (int)realFracionarioMid;
int convertIntDown = Convert.ToInt32(realFracionarioDown), convertIntUp = Convert.ToInt32(realFracionarioUp), convertIntMid = Convert.ToInt32(realFracionarioMid);

Console.WriteLine("Para converter um double em int, pode ser usado um cast ou o metodo Convert.ToInt32()");
Console.WriteLine("O cast trunca o numero, então para numeros com fração o mais indicado é o Convert");
Console.WriteLine("Em um numero float exato o cast e o Convert retornam o mesmo valor");
Console.WriteLine($"\tNumero double: {realFracionarioDown}");
Console.WriteLine($"\t - Cast: {castIntDown}\n\t - Convert: {convertIntDown}");
Console.WriteLine($"\tNumero double: {realFracionarioUp}");
Console.WriteLine($"\t - Cast: {castIntUp}\n\t - Convert: {convertIntUp}");
Console.WriteLine($"\tNumero double: {realFracionarioMid}");
Console.WriteLine($"\t - Cast: {castIntMid}\n\t - Convert: {convertIntMid}");
Console.WriteLine($"\tNumero double: {realExato}");
Console.WriteLine($"\t - Cast: {(int)realExato}\n\t - Convert: {Convert.ToInt32(realExato)}");
Console.WriteLine("\n");

# endregion

# region Operadores Aritméticos
/*
    4)  Dada a variável int x = 10 e a variável int y = 3, escreva código para calcular 
        e exibir o resultado da adição, subtração, multiplicação e divisão de x por y.

*/

Console.WriteLine("Operadores Aritméticos");
int x = 10, y = 3;
Console.WriteLine($"x = {x}\ty = {y}");
Console.WriteLine($" ->   x + y = {x + y}");
Console.WriteLine($" ->   x - y = {x - y}");
Console.WriteLine($" ->   x * y = {x * y}");
Console.WriteLine($" ->   x / y = {(double)x / y}");
Console.WriteLine("\n");

# endregion

# region Operadores de Comparação
/*
    5)  Considere as variáveis int a = 5 e int b = 8. Escreva código para determinar 
        se a é maior que b e exiba o resultado.

*/

Console.WriteLine("Operadores de Comparação");
int a = 5, b = 8;
Console.WriteLine($"a = {a} | b = {b}");
if(a > b)
    Console.WriteLine(" ->   a é maior que b.");
else
    Console.WriteLine(" ->   a é menor ou igual a b.");

Console.WriteLine("\n");

# endregion

# region Operadores de Igualdade
// 6)   Você tem duas strings, string str1 = "Hello" e string str2 = "World". Escreva código para verificar se
//      as duas strings são iguais e exibir o resultado.
# endregion

# region Operadores Lógicos
// 7)   Suponha que você tenha duas variáveis booleanas, bool condicao1 = true e bool condicao2 = false. Escreva 
//      código para verificar se ambas as condições são verdadeiras e exiba o resultado.
# endregion

# region Desafio de Mistura de Operadores
// 8)   Dadas as variáveis int num1 = 7, int num2 = 3, e int num3 = 10, escreva código para verificar se num1 é maior 
//      do que num2 e se num3 é igual a num1 + num2.
# endregion
