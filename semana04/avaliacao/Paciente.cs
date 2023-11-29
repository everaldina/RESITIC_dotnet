namespace Semana04.Avaliacao;

class Paciente : Pessoa{
    public string Sexo {get; set;}
    public List<String> Sintomas = new List<String>();

    public Paciente(string nome, DateTime dataNascimento, string cpf, string sexo) : base(nome, dataNascimento, cpf){
        Console.WriteLine($"{sexo} | {sexo.ToLower()} | {sexo.ToLower() != "masculino"} | {sexo.ToLower() != "feminino"} | {sexo.ToLower() != "masculino" && sexo.ToLower() != "feminino"}");
        
        if (sexo.ToLower() != "masculino" && sexo.ToLower() != "feminino")
            Sexo = sexo;
        else
            throw new Exception("Sexo invalido");
    }

    public void AdicionarSintoma(string sintoma){
        Sintomas.Add(sintoma);
    }
}