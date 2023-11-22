namespace Semana03.Exercicio3;

public class Pessoa{
    public Pessoa(string nome, int altura){
        Nome = nome;
        if (altura < 0){
            Altura = 0;
        }else{
            Altura = altura;
        }
    }

    public string Nome{get; set;}
    public int Altura{get; set;}

}