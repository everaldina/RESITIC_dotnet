namespace Semana03.Exercicio3;

public class App{
    public static Pessoa addPessoa(){
        string nome;
        int altura;

        Console.Write("Digite o nome: ");
        nome = Console.ReadLine()!;
        try{
            Console.Write("Digite a altura: ");
            altura = int.Parse(Console.ReadLine()!);
        }catch(FormatException){
            Console.WriteLine("Altura inválida!");
            altura = 0;
        }

        return new Pessoa(nome, altura);
    }


    public static int mediaAltura(List<Pessoa> lista){
        return (int) lista.Average(p => p.Altura);
    }
}