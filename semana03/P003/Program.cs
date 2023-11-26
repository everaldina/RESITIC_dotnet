using Semana03.P003;

Estoque estoque = new Estoque();

# region Menu principal
while(1){
    Console.WriteLine("1. Cadastrar produto");
    Console.WriteLine("2. Consultar produto");
    Console.WriteLine("3. Atualizar produto");
    Console.WriteLine("4. Listar produtos");
    Console.WriteLine("5. Relatorios");
    Console.WriteLine("0. Sair");
    Console.Write("Digite a opção desejada: ");
    int opcao = int.Parse(Console.ReadLine()!);

    switch(opcao){
        case 1:
            App.CadastrarProduto(estoque);
            break;
        case 2:
            App.ConsultarProduto(estoque);
            break;
        case 3:
            App.AtualizarEstoque(estoque);
            break;
        case 4:
            App.ListarProdutos(estoque);
            break;
        case 5:
            menuRelatorios(estoque);
            break;
        default:
            Console.WriteLine("Opção inválida!");
            Console.ReadLine();
            break;
    }
}
# endregion

# region Menu relatorios
public void menuRelarios(){
    int opcao = -1;
    while(1){
        Console.WeitrLine("1. Produtos com estoque abaixo de X");
        Console.WeitrLine("2. Produtos com estoque entre [X, Y]");
        Console.WeitrLine("3. Relatorio gerald do estoque");
        Console.WeitrLine("0. Menu principal");

        do{
            try{
                Console.Write("Digite a opção desejada: ");
                opcao = int.Parse(Console.ReadLine()!);
                if (opcao < 0 || opcao > 3)
                    throw new Exception("Opção inválida!");
            }catch(Exception ex){
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }while(opcao < 0 || opcao > 3);

        switch(opcao){
            case 1:
                App.qntdInferior(estoque);
                break;
            case 2:
                App.qntdEntre(estoque);
                break;
            case 3:
                App.totalEstoque(estoque);
                break;
            case 0:
                return;
        }
    }
}

# endregion
