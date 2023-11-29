using Semana3.Exercicio3;

ContaBancaria conta = new ContaBancaria(500);

Console.WriteLine(conta.Saldo); // 500

try{
    conta.Saldo = -100;
}catch(ArgumentException e){
    Console.WriteLine(e.Message); // Saldo não pode ser negativo
}
