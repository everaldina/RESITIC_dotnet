using Semana03.P003;


class Program{
    static void Main(string[] args){
        Estoque estoque = new Estoque();
        int opcao;

        // menu principal
        while(true){
                Console.WriteLine("\n1. Cadastrar produto");
                Console.WriteLine("2. Consultar produto");
                Console.WriteLine("3. Atualizar estoque");
                Console.WriteLine("4. Deletar produto");
                Console.WriteLine("5. Listar produtos");
                Console.WriteLine("6. Relatorios");
                Console.WriteLine("0. Sair");

            // leitura da opção
            do{
                try{
                    Console.Write("Digite a opção desejada: ");
                    opcao = int.Parse(Console.ReadLine()!);
                }catch(Exception){
                    opcao = -1;
                    Console.WriteLine("Opção inválida!");
                    Console.ReadLine();
                }
            }while(opcao < 0);

            Console.WriteLine();
            switch(opcao){
                case 0:
                    return;
                case 1:
                    App.cadastrarProduto(estoque);
                    break;
                case 2:
                    App.consultarProduto(estoque);
                    break;
                case 3:
                    App.atualizarEstoque(estoque);
                    break;
                case 4:
                    App.deletarProduto(estoque);
                    break;
                case 5:
                    App.listarProdutos(estoque);
                    break;
                case 6:
                    menuRelatorios(estoque);
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Console.ReadLine();
                    break;
            }
        }
    }

    # region Menu relatorios
    static void menuRelatorios(Estoque estoque){
        int opcao = -1;
        while(true){
            Console.WriteLine("1. Produtos com estoque abaixo de X");
            Console.WriteLine("2. Produtos com estoque entre [X, Y]");
            Console.WriteLine("3. Relatorio geral do estoque");
            Console.WriteLine("0. Menu principal");

            do{
                try{
                    Console.Write("Digite a opção desejada: ");
                    opcao = int.Parse(Console.ReadLine()!);
                    if (opcao < 0 || opcao > 3)
                        throw new Exception("Opção inválida!");
                }catch(Exception ex){
                    opcao = -1;
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }while(opcao < 0 || opcao > 3);

            Console.WriteLine("\n");
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
                default:
                    Console.WriteLine("Opção inválida!");
                    Console.ReadLine();
                    break;
            }
        }
    }
    # endregion
}
