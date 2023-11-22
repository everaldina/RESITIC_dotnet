using Semana03.Exercicio3;

// Crie uma lista de tuplas, onde cada tupla contém o nome de uma pessoa 
// e a sua altura em centímetros. Utilize uma expressão lambda e LINQ para 
// calcular a altura média das pessoas na lista.

List<Pessoa> lista = new List<Pessoa>();

for (int i = 0; i < 3; i++){
    lista.Add(App.addPessoa());
}

Console.WriteLine($"A média de altura é {App.mediaAltura(lista)} cm");