namespace Semana04.Avaliacao;

class App{
    public static void AdicionarMedico(List<Medico> medicos){
        string nome;
        string cpf;
        string crm;
        DateTime dataNascimento;

        Console.WriteLine("Digite o nome do médico:");
        nome = Console.ReadLine()!;
        try{
            Console.WriteLine("Digite a data de nascimento do médico:");
            dataNascimento = DateTime.Parse(Console.ReadLine()!);
        }catch (Exception e){
            Console.WriteLine("Data de nascimento inválida");
            return;
        }
        
        Console.WriteLine("Digite o CPF do médico:");
        cpf = Console.ReadLine()!;

        Console.WriteLine("Digite o CRM do médico:");
        crm = Console.ReadLine()!;

        try{
            Medico m = new Medico(nome, dataNascimento, cpf, crm);
        }catch (Exception e){
            Console.WriteLine(e.Message);
            return;
        }

        if(App.ExisteMedico(medicos, cpf)){
            Console.WriteLine("Médico já cadastrado");
            return;
        }
    }

    public static bool ExisteMedico(List<Medico> medicos, string cpf){
        try{
            Paciente p = medicos.Find(p => p.CPF == cpf);
            return true;
        }catch (Exception e){
            return false;
        }
    }
}