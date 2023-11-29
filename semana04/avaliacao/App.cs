namespace Semana04.Avaliacao;

class App{
    public List<Medico> Medicos => medicos;
    public List<Paciente> Pacientes => pacientes;

    private List<Medico> medicos = new List<Medico>();
    private List<Paciente> pacientes = new List<Paciente>();

    public void AdicionarMedico(){
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

        if(ExisteMedico(medicos, cpf, crm)){
            Console.WriteLine("Médico já cadastrado");
            return;
        }else{
            medicos.Add(new Medico(nome, dataNascimento, cpf, crm));
            Console.WriteLine("Médico cadastrado com sucesso");
        }
    }

    public bool ExisteMedico(string cpf, string crm){
        try{
            Medico p = medicos.Find(p => p.CPF == cpf || p.CRM == crm);
            return true;
        }catch (Exception e){
            return false;
        }
    }

    public void AdicionarPaciente(){
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

    public bool ExistePaciente(string cpf){
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

        if(!ExistePaciente(pacientes, cpf)){
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

    public void RelatorioPacienteEntre(){
        int idadeInicio, idadeFim;

        try{
            Console.WriteLine("Digite a idade inicial:");
            idadeInicio = int.Parse(Console.ReadLine()!);
        }catch (Exception e){
            Console.WriteLine("Idade inválida");
            return;
        }

        try{
            Console.WriteLine("Digite a idade inicial:");
            idadeFim = int.Parse(Console.ReadLine()!);
        }catch (Exception e){
            Console.WriteLine("Idade inválida");
            return;
        }

        Console.WriteLine("--------Relatório Paciente Entre--------");

        List<Paciente> pacientesEntre = pacientes.FindAll(p => p.Idade >= idadeInicio && p.Idade <= idadeFim);
        if (pacientesEntre.Count == 0){
            Console.WriteLine("Nenhum paciente encontrado");
            return;
        }

        ImprimirPacientes(pacientesEntre);
    }

    public static void ImprimirPacientes(List<Paciente> pacientes){
        foreach (Paciente p in pacientes){
            Console.Write("Nome: " + p.Nome);
            Console.WriteLine(" | CPF: " + p.CPF);
            Console.WriteLine(" - Sexo: " + p.Sexo);
            Console.WriteLine(" - Idade: " + p.Idade);
            Console.WriteLine(" - Data de Nascimento: " + p.DataNascimento);
            Console.WriteLine(" - Sintomas: ");
            foreach (string s in p.Sintomas){
                Console.WriteLine("\t+ " + s);
            }
            Console.WriteLine("-------------------------------");
        }
    }

    public void RelatorioMedicoEntre(){
        int idadeInicio, idadeFim;

        try{
            Console.WriteLine("Digite a idade inicial:");
            idadeInicio = int.Parse(Console.ReadLine()!);
        }catch (Exception e){
            Console.WriteLine("Idade inválida");
            return;
        }

        try{
            Console.WriteLine("Digite a idade inicial:");
            idadeFim = int.Parse(Console.ReadLine()!);
        }catch (Exception e){
            Console.WriteLine("Idade inválida");
            return;
        }

        Console.WriteLine("--------Relatório Médico Entre--------");

        List<Medico> medicosEntre = medicos.FindAll(m => m.Idade >= idadeInicio && m.Idade <= idadeFim);
        if (medicosEntre.Count == 0){
            Console.WriteLine("Nenhum médico encontrado");
            return;
        }

        ImprimirMedicos(medicosEntre);
    }

    public static void ImprimirMedicos(List<Medico> medicos){
        foreach (Medico m in medicos){
            Console.Write("Nome: " + m.Nome);
            Console.Write(" | CPF: " + m.CPF);
            Console.Write(" | CRM: " + m.CRM);
            Console.WriteLine(" | Data de Nascimento: " + m.DataNascimento);
            Console.WriteLine(" - Idade: " + m.Idade);
            Console.WriteLine("-------------------------------");
        }
    }

    public svoid RelatorioPacienteSexo(){
        int opc;
        string sexo;

        Console.WriteLine("1 - Feminino");
        Console.WriteLine("2 - Masculino");
        Console.WriteLine("Digite a opção desejada:");

        try{
            opc = int.Parse(Console.ReadLine()!);
        }catch (Exception e){
            Console.WriteLine("Opção inválida");
            return;
        }

        if (opc == 1)
            sexo = "feminino";
        else
            sexo = "masculino";
    
        Console.WriteLine($"--------Relatório Paciente do Sexo {sexo}--------");
        List<Paciente> pacientesSexo = pacientes.FindAll(p => p.Sexo == sexo);
        if (pacientesSexo.Count == 0){
            Console.WriteLine("Nenhum paciente encontrado");
            return;
        }

        ImprimirPacientes(pacientesSexo);
    }

    public void RelatorioPacientesAlfabetico(){
        Console.WriteLine("--------Relatório Paciente--------");

        List<Paciente> pacientesOrdenados = pacientes.OrderBy(p => p.Nome).ToList();
        if (pacientesOrdenados.Count == 0){
            Console.WriteLine("Nenhum paciente encontrado");
            return;
        }

        ImprimirPacientes(pacientesOrdenados);
    }

    public void PacientePorSintoma(){
        string sintoma;

        Console.WriteLine("Digite o sintoma:");
        sintoma = Console.ReadLine()!;

        Console.WriteLine($"--------Relatório Paciente com '{sintoma}'--------");

        List<Paciente> pacientesSintoma = pacientes.FindAll(p => p.Sintomas.Contains(sintoma));
        if (pacientesSintoma.Count == 0){
            Console.WriteLine("Nenhum paciente encontrado");
            return;
        }

        ImprimirPacientes(pacientesSintoma);
    }

    public void AniversariantesDoMes(){
        Console.WriteLine("--------Relatório Aniversariantes do Mês--------");

        List<Paciente> pacientesAniversariantes = pacientes.FindAll(p => p.DataNascimento.Month == DateTime.Now.Month);
        List<Medico> medicosAniversariantes = medicos.FindAll(m => m.DataNascimento.Month == DateTime.Now.Month);
        
        Console.WriteLine("Médicos--------------------------");
        if (medicosAniversariantes.Count == 0){
            Console.WriteLine("Nenhum médico encontrado");
            return;
        }
        ImprimirMedicos(medicosAniversariantes);

        Console.WriteLine("\nPacientes------------------------");
        if (pacientesAniversariantes.Count == 0){
            Console.WriteLine("Nenhum paciente encontrado");
            return;
        }

        ImprimirPacientes(pacientesAniversariantes);
    }

}