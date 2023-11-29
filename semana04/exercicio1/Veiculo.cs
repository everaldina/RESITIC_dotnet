namespace Semana3.Exercicio1;

class Veiculo{
    public string Modelo { get; set; }
    public int Ano { get; set; }
    public string Cor { get; set; }

    public int IdadeVeiculo => DateTime.Now.Year - Ano;

    public Veiculo(string modelo, int ano, string cor){
        Modelo = modelo;
        Ano = ano;
        Cor = cor;
    }


}