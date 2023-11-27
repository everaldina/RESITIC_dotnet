using Microsoft.VisualBasic;

namespace Semana03.P003;

public class App{

    // cadastra um produto no estoque
    public static void cadastrarProduto(Estoque e){
        int codigo;
        string nome = "";
        int qntd;
        float preco = -1;

        Console.WriteLine($"{"--------------CADASTRO DE PRODUTO--------------"}");

        // leitura de codigo do produto, deve ser um inteiro >= 0
        codigo = lerCodigo();

        // leitura de nome do produto, não pode ser nulo
        do{
            try{
                Console.Write("Digite o nome do produto (não nulo): ");
                nome = Console.ReadLine()!;
                if (string.IsNullOrEmpty(nome))
                    throw new Exception("Nome inválido!");
            }catch(Exception ex){
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }while(string.IsNullOrEmpty(nome));

        // leitura de quantidade do produto, deve ser um inteiro >= 0
        qntd = lerQuantidade();

        // leitura de preço do produto, deve ser um float > 0
        do{
            try{
                Console.Write("Digite o preço do produto: ");
                preco = float.Parse(Console.ReadLine()!);
                if (preco <= 0)
                    throw new Exception("Preço inválido!");
            }catch(Exception){
                Console.WriteLine("Preço inválido!");
                Console.ReadLine();
            }
        }while(preco <= 0);
        preco = float.Parse(preco.ToString("F2"));

        // tenta adicionar o produto ao estoque
        if (e.addProduto(codigo, nome, qntd, preco))
            Console.WriteLine("Produto cadastrado com sucesso!");
        else
            Console.WriteLine("Produto já cadastrado!");

        Console.ReadLine();
    }

    // consulta um produto no estoque
    public static void consultarProduto(Estoque e){
        int codigo;

        Console.WriteLine($"{"----CONSULTA DE PRODUTO----", 8}");
        
        // verifica se existe algum produto cadastrado
        if (e.qntdProdutos == 0){
            Console.WriteLine("Nenhum produto cadastrado!");
            Console.ReadLine();
            return;
        }

        // leitura de codigo do produto, deve ser um inteiro >= 0
        codigo = lerCodigo();

        // tenta buscar o produto no estoque
        try{
            var produto = e.produtos[e.buscarProduto(codigo)];
            Console.WriteLine($"cod. {produto.cod} - {produto.nome} | qntd. {produto.qntd} | R$ {produto.preco:F2}" );
            Console.ReadLine();
        }catch(Exception ex){
            Console.WriteLine(ex.Message);
            Console.ReadLine();
        }
    }

    // atualiza o estoque de um produto
    public static void atualizarEstoque(Estoque e){
        int codigo;
        int fluxo = 0;

        Console.WriteLine($"{"---------ATUALIZAÇÃO DE ESTOQUE---------"}");

        // verifica se existe algum produto cadastrado
        if (e.qntdProdutos == 0){
            Console.WriteLine("Nenhum produto cadastrado!");
            Console.ReadLine();
            return;
        }

        // leitura de codigo do produto, deve ser um inteiro >= 0
        codigo = lerCodigo();

        // leitura de fluxo do produto, deve ser um inteiro != 0
        do{
            try{
                Console.Write("Digite o fluxo (positivo ou negativo): ");
                fluxo = int.Parse(Console.ReadLine()!);
                if (fluxo == 0)
                    throw new Exception("Fluxo inválido!");
            }catch(Exception){
                Console.WriteLine("Fluxo inválido!");
                Console.ReadLine();
            }
        }while(fluxo == 0);

        // tenta atualizar o estoque do produto
        if (e.attEstoque(codigo, fluxo))
            Console.WriteLine("Estoque atualizado com sucesso!");

        Console.ReadLine();
    }

    // deleta um produto do estoque
    public static void deletarProduto(Estoque e){
        int codigo;

        Console.WriteLine($"{"-----------DELEÇÃO DE PRODUTO-----------"}");

        // verifica se existe algum produto cadastrado
        if (e.qntdProdutos == 0){
            Console.WriteLine("Nenhum produto cadastrado!");
            Console.ReadLine();
            return;
        }

        // leitura de codigo do produto, deve ser um inteiro >= 0
        codigo = lerCodigo();

        // tenta deletar o produto do estoque
        if (e.deletarProduto(codigo))
            Console.WriteLine("Produto deletado com sucesso!");

        Console.ReadLine();
    }

    // lista todos os produtos do estoque
    public static void listarProdutos(Estoque e){
        if (e.qntdProdutos > 0){
            Console.WriteLine("------------------LISTA DE PRODUTOS------------------");
            imprimirProdutos(e.produtos.OrderBy(p => p.cod).ToList());  // ordena a lista de produtos pelo codigo e imprime
        }else{
            Console.WriteLine("Nenhum produto cadastrado!");
        }
        Console.ReadLine();
    }

    // imprime relatorio com os produtos com quantidade inferior a um inteiro
    public static void qntdInferior(Estoque e){
        int qntd = lerQuantidade();
        string titulo = $"{"----LISTA DE PRODUTOS COM QUANTIDADE INFERIOR A "}{qntd}---";

        Console.WriteLine($"{titulo}");

        // filtra a lista de produtos com quantidade inferior a qntd, ordena pelo codigo
        var produtos = e.produtos.FindAll(p => p.qntd < qntd).OrderBy(p => p.cod).ToList();

        // imprime a lista de produtos
        if (produtos.Count > 0){
            imprimirProdutos(produtos);
        }else{
            Console.WriteLine("Nenhum produto encontrado!");
        }
        Console.ReadLine();
    }

    // imprime relatorio com os produtos com quantidade entre dois inteiros
    public static void qntdEntre(Estoque e){
        int qntdInf = lerQuantidade(1); // leitura de quantidade inferior, deve ser um inteiro >= 0
        int qntdSup;

        // leitura de quantidade superior, deve ser um inteiro >= 0 e maior que a inferior
        do{
            qntdSup = lerQuantidade(2);
            if (qntdSup < qntdInf){
                Console.WriteLine("Quantidade superior menor que a inferior!");
                Console.ReadLine();
            }
        }while(qntdSup < qntdInf);


        string titulo = $"{"----LISTA DE PRODUTOS COM QUANTIDADE ENTRE [ "}{qntdInf}{", "}{qntdSup} ]---";
        Console.WriteLine(titulo);

        // filtra a lista de produtos com quantidade entre qntdInf e qntdSup, ordena pelo codigo
        var produtos = e.produtos.FindAll(p => p.qntd >= qntdInf && p.qntd <= qntdSup).OrderBy(p => p.cod).ToList();

        // imprime a lista de produtos
        if (produtos.Count > 0){
            imprimirProdutos(produtos);
        }else{
            Console.WriteLine($"{"Nenhum produto encontrado!".PadLeft(titulo.Length/3)}");
        }
        Console.ReadLine();
    }

    // imprime relatorio com o total de cada produto e o valor total do estoque
    public static void totalEstoque(Estoque e){
        Console.WriteLine($"{"-----------TOTAL DO ESTOQUE-----------"}");
        Console.WriteLine($"{"  - Quantidade de produtos: "}{e.qntdProdutos}");
        Console.WriteLine($"{"  - Valor total do estoque: R$"}{e.produtos.Sum(p => p.qntd * p.preco):F2}"); // soma o valor total de cada produto

        Console.WriteLine();
        parcialProduto(e);

        Console.ReadLine();
    }

    // imprime relatorio com o total de cada produto
    public static void parcialProduto(Estoque e){

        Console.WriteLine($"{"----PARCIAL DE PRODUTOS----", 8}");
        var precoParcial = e.produtos.Select(p => p.qntd * p.preco); // calcula o valor total de cada produto

        // cria uma lista juntando os produtos do estoque com o valor total de cada produto
        var listaZip = e.produtos.Zip(precoParcial, (itemProduto, itemPreco) => new { iProd = itemProduto, iPreco = itemPreco });

        // imprime a lista de produtos com os seus valores totais
        foreach(var item in listaZip){
            Console.WriteLine($"{item.iProd.cod} - {item.iProd.nome}: R$ {item.iPreco:F2}" );
        }

    }

    // le um codigo de produto, deve ser um inteiro >= 0
    public static int lerCodigo(){
        int codigo = -1;
        do{
            try{
                Console.Write("Digite o código (inteiro) do produto: ");
                codigo = int.Parse(Console.ReadLine()!);
                if (codigo < 0){
                    Console.WriteLine("Código inválido!");
                    Console.ReadLine();
                }
            }catch(Exception){
                Console.WriteLine("Código inválido!");
                Console.ReadLine();
            }
        }while(codigo < 0);
        return codigo;
    }

    // le uma quantidade de produto, deve ser um inteiro >= 0
    // o tipo indica se a quantidade é inferior (1) ou superior (2), (0) para so um inteiro
    public static int lerQuantidade(int tipo=0){
        int qntd = -1;
        string modificador = " ";

        // modifica o texto de acordo com o tipo
        if (tipo == 1)
            modificador = " inferior ";
        else if (tipo == 2)
            modificador = " superior ";


        // leitura de quantidade do produto, deve ser um inteiro >= 0
        do{
            try{
                Console.Write($"Digite a quantidade{modificador}(inteiro) do produto: ");
                qntd = int.Parse(Console.ReadLine()!);
                if (qntd < 0){
                    Console.WriteLine("Quantidade inválida!");
                    Console.ReadLine();
                }
            }catch(Exception){
                Console.WriteLine("Quantidade inválida!");
                Console.ReadLine();
            }
        }while(qntd < 0);
        return qntd;
    }

    // imprime uma lista de produtos passada como parametro
    public static void imprimirProdutos( List<(int cod, string nome, int qntd, float preco)> produtos){
        Console.WriteLine($"{"COD.", -5} | {"NOME", -20} | {"QNTD.", -10} | {"PRECO"}");
        foreach(var produto in produtos){
            Console.WriteLine($"{produto.cod, -7}{produto.nome, -20}    {produto.qntd, -13}{produto.preco:F2}" );
        }

    }
}