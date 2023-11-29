namespace Semana04.Avaliacao;

abstract class Pessoa{
    public string Nome {get; set;}
    public DateTime DataNascimento {get; set;}

    private string cpf;
    public string CPF {
        get {return this.cpf;}
        set {
            if (value.Length == 11){
                cpf = value;
            }
        }
    }

    private Boolean validarCPF(string cpf){
        if (cpf.Length == 11 ){
            try{
                int.Parse(cpf);
                return true;
            }catch (Exception e){
                return false;
            }
        }else{
            return false;
        }
    }
}