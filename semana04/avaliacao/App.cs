namespace Semana04.Avaliacao;

class App{
    public static void AdicionarMedico(List<Medico> medicos){
        string nome;
        string cpf;
        string crm;
        DateTime dataNascimento;

        Console.WriteLine("--------Cadastro Medico--------");
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

        if(App.ExisteMedico(medicos, cpf, crm)){
            Console.WriteLine("Médico já cadastrado");
            return;
        }else{
            medicos.Add(new Medico(nome, dataNascimento, cpf, crm));
            Console.WriteLine("Médico cadastrado com sucesso");
        }
    }

    public static bool ExisteMedico(List<Medico> medicos, string cpf, string crm){
        try{
            Medico p = medicos.Find(p => p.CPF == cpf || p.CRM == crm);
            return true;
        }catch (Exception e){
            return false;
        }
    }

    public static void AdicionarPaciente(List<Paciente> pacientes){
        string nome;
        string cpf;
        string sexo;
        DateTime dataNascimento;

        Console.WriteLine("--------Cadastro Paciente--------");
        Console.WriteLine("Digite o nome do paciente:");
        nome = Console.ReadLine()!;

        try{
            Console.WriteLine("Digite a data de nascimento do paciente:");
            dataNascimento = DateTime.Parse(Console.ReadLine()!);
        }catch (Exception e){
            Console.WriteLine("Data de nascimento inválida");
            return;
        }
        
        Console.WriteLine("Digite o CPF do paciente:");
        cpf = Console.ReadLine()!;

        Console.WriteLine("Digite o sexo do paciente:");
        sexo = Console.ReadLine()!;

        try{
            Paciente p = new Paciente(nome, dataNascimento, cpf, sexo);
        }catch (Exception e){
            Console.WriteLine(e.Message);
            return;
        }

        if(App.ExistePaciente(pacientes, cpf)){
            Console.WriteLine("Paciente já cadastrado");
            return;
        }else{
            pacientes.Add(new Paciente(nome, dataNascimento, cpf, sexo));
            Console.WriteLine("Paciente cadastrado com sucesso");
        }
    }

    public static bool ExistePaciente(List<Paciente> pacientes, string cpf){
        try{
            Paciente p = pacientes.Find(p => p.CPF == cpf);
            return true;
        }catch (Exception e){
            return false;
        }
    }

    public static void AdicionarSintoma(List<Paciente> pacientes){
        string cpf;
        string sintoma;

        Console.WriteLine("--------Adicionar Sintoma--------");
        Console.WriteLine("Digite o CPF do paciente:");
        cpf = Console.ReadLine()!;

        if(!App.ExistePaciente(pacientes, cpf)){
            Console.WriteLine("Paciente não cadastrado");
            return;
        }

        Console.WriteLine("Digite o sintoma:");
        sintoma = Console.ReadLine()!;

        Paciente p = pacientes.Find(p => p.CPF == cpf);

        if (p.Sintomas.Contains(sintoma)){
            Console.WriteLine("Sintoma já cadastrado");
            return;
        }else{
            p.AdicionarSintoma(sintoma);
            Console.WriteLine("Sintoma adicionado com sucesso");
        }
    }

    public void RelatorioPacienteEntre(List<Paciente> pacientes){
        List<Paciente> pacientesEntre = pacientes.FindAll(p => p.DataNascimento >= dataInicial && p.DataNascimento <= dataFinal);
        foreach (Paciente p in pacientesEntre){
            Console.WriteLine(p.Nome);
        }
    }

}