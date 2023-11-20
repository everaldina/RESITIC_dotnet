// lista de tarefas estrutura:
// [<titulo>], [<descricao>], [concluido]
List<string[]> listaTarefas = new List<string[]>();
List<DateTime> listaDataVencimento = new List<DateTime>();

bool cont = true;
string? titulo, descricao;
DateTime dataVencimento;
int opcao;

while(cont){

    // menu
    Console.WriteLine("\n1 - Cria tarefa");
    Console.WriteLine("2 - Lista tarefas");
    Console.WriteLine("3 - Concluir tarefa");
    Console.WriteLine("4 - Tarefas concluidas");
    Console.WriteLine("5 - Tarefas pendentes");
    Console.WriteLine("6 - Remover tarefa");
    Console.WriteLine("7 - Buscar tarefa");
    Console.WriteLine("8 - Resumo de tarefas");
    Console.WriteLine("0 - Sair");
    Console.Write("Digite uma opção: ");
    opcao = Convert.ToInt32(Console.ReadLine());

    if(opcao == 0)
        cont = false;
# region Criar tarefa
    else if(opcao == 1){
        Console.Write("\nDigite o título da tarefa: ");
        titulo = Console.ReadLine();
        Console.Write("Digite a descrição da tarefa: ");
        descricao = Console.ReadLine();
        // valida data
        do{
            Console.Write("Digite a data de vencimento da tarefa (dd/mm/aaaa): ");
        }while(!DateTime.TryParse(Console.ReadLine(), out dataVencimento));

        // cria tarefa e adiciona
        string[] tarefa = {titulo, descricao, "false"};
        listaTarefas.Add(tarefa);
        listaDataVencimento.Add(dataVencimento);
    }
# endregion
# region Listar tarefas
    else if(opcao ==2){
        Console.WriteLine($"\n    {" ", 15}Tarefa{" ", 15}Data de vencimento");
        for(var i = 0; i < listaTarefas.Count; i++){
            string[] tarefa = listaTarefas[i];
            string concluido = tarefa[2] == "true" ? "[X]" : "[ ]"; // se concluido = true, imprime [X], senão imprime [ ]
            Console.WriteLine($"{concluido} {tarefa[0].ToUpper()} - {tarefa[1], -30}{listaDataVencimento[i].ToShortDateString()}");
        }
    }
# endregion
# region Concluir tarefa
    else if(opcao ==3){
        Console.Write("\nDigite o título da tarefa: ");
        titulo = Console.ReadLine();

        for(var i = 0; i<listaTarefas.Count; i++){
            string[] tarefa = listaTarefas[i]; // pega tarefa

            // compara titulo da tarefa ao titulo digitado
            if(tarefa[0].ToLower() == titulo.ToLower()){ 
                listaTarefas[i][2] = "true";
                Console.WriteLine("Tarefa concluida.");
                break;
            }
            if(i == listaTarefas.Count - 1)
                Console.WriteLine("Tarefa não encontrada.");
        }
    }
# endregion
# region Tarefas concluidas
    else if(opcao ==4){
        Console.WriteLine("\nTarefas concluidas:");
        foreach(string[] tarefa in listaTarefas){
            if(tarefa[2] == "true") // se concluido = true, imprime
                Console.WriteLine($"{tarefa[0].ToUpper()} - {tarefa[1]}");
        }
    }
# endregion
# region Tarefas pendentes
    else if(opcao ==5){
        Console.WriteLine("\nTarefas pendentes:");
        foreach(string[] tarefa in listaTarefas){
            if(tarefa[2] == "false") // se concluido = false, imprime
                Console.WriteLine($"{tarefa[0].ToUpper()} - {tarefa[1]}");
        }
    }
# endregion
# region Remover tarefa
    else if(opcao ==6){
        string[] tarefa;
        Console.Write("\nDigite o título da tarefa: ");
        titulo = Console.ReadLine();
        for(var i = 0; i<listaTarefas.Count; i++){
            tarefa = listaTarefas[i];

            // compara titulo da tarefa ao titulo digitado
            if(tarefa[0].ToLower() == titulo.ToLower()){ 
                listaTarefas.RemoveAt(i);
                listaDataVencimento.RemoveAt(i);
                Console.WriteLine("Tarefa removida.");
                break;
            }
            if(i == listaTarefas.Count - 1) // se não encontrar tarefa
                Console.WriteLine("Tarefa não encontrada.");
        }
    }
# endregion
# region Buscar tarefa
    else if(opcao ==7){
        Console.Write("\nDigite palavra-chave: ");
        string busca = Console.ReadLine().ToLower();
        Console.WriteLine("\nTarefas encontradas:");
        for(var i = 0; i<listaTarefas.Count; i++){
            string[] tarefa = listaTarefas[i]; // pega tarefa

            // se titulo ou descricao contem palavra-chave, imprime
            if(tarefa[0].ToLower().Contains(busca) || tarefa[1].ToLower().Contains(busca)){
                string concluido = (tarefa[2] == "true") ? "[X]" : "[ ]";
                Console.WriteLine($"{concluido} {tarefa[0]} - {tarefa[1], -30}{listaDataVencimento[i].ToShortDateString()}");
            }
        }
    }
# endregion
# region Resumo de tarefas
    else if(opcao ==8){
        int concluidas = 0, pendentes = 0;
        int indexPrimeiraTarefa, indexUltimaTarefa;
        string[] primeiraTarefa, ultimaTarefa;

        if(listaTarefas.Count > 0){
            indexPrimeiraTarefa = 0;
            indexUltimaTarefa = 0;
            for(var i = 0; i<listaTarefas.Count; i++){
                string[] tarefa = listaTarefas[i]; // pega tarefa

                // incrementa contador de tarefas concluidas ou pendentes
                if(tarefa[2] == "true")
                    concluidas++;
                else
                    pendentes++;

                // compara data de vencimento da tarefa com a data de vencimento da primeira e ultima tarefa
                if(listaDataVencimento[i] < listaDataVencimento[indexPrimeiraTarefa])
                    indexPrimeiraTarefa = i;
                if(listaDataVencimento[i] > listaDataVencimento[indexUltimaTarefa])
                    indexUltimaTarefa = i;
            }
            Console.WriteLine($"\nTarefas concluidas: {concluidas}");
            Console.WriteLine($"Tarefas pendentes: {pendentes}");

            // pega primeira e ultima tarefa e imprime
            primeiraTarefa = listaTarefas[indexPrimeiraTarefa];
            ultimaTarefa = listaTarefas[indexUltimaTarefa];
            Console.WriteLine($"Primeira tarefa: {primeiraTarefa[0]} - {primeiraTarefa[1]}");
            Console.WriteLine($"Última tarefa: {ultimaTarefa[0]} - {ultimaTarefa[1]}");
        }
        else{
            Console.WriteLine("Nenhuma tarefa cadastrada.");
        }
    }
# endregion
    else // se opcao invalida
        Console.WriteLine("Opção inválida.");
}

