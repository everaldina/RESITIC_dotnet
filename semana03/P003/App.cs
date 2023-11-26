using Microsoft.VisualBasic;

namespace Semana03.P003;

public class App{

    public void CadastrarProduto(Estoque e){
        int codigo;
        string nome = "";
        int qntd;
        float preco = -1;

        Console.WriteLine($"{"----CADASTRO DE PRODUTO----", 8}");

        codigo = lerCodigo();

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

        qntd = lerQuantidade();

        do{
            try{
                Console.Write("Digite o preço do produto: ");
                preco = float.Parse(Console.ReadLine()!);
                if (preco < 0)
                    throw new Exception("Preço inválido!");
            }catch(Exception){
                Console.WriteLine("Preço inválido!");
                Console.ReadLine();
            }
        }while(preco < 0);
        preco = float.Parse(preco.ToString("F2"));

        if (e.addProduto(codigo, nome, qntd, preco))
            Console.WriteLine("Produto cadastrado com sucesso!");
        else
            Console.WriteLine("Produto já cadastrado!");

        Console.ReadLine();
    }

    public void ConsultarProduto(Estoque e){
        int codigo;

        Console.WriteLine($"{"----CONSULTA DE PRODUTO----", 8}");
        
        codigo = lerCodigo();

        try{
            var produto = e.buscarProduto(codigo);
            Console.WriteLine($"{produto.cod, -5} - {produto.nome}: qntd. {produto.qntd, -5} | R$ {produto.preco:F2}" );
            Console.ReadLine();
        }catch(Exception ex){
            Console.WriteLine(ex.Message);
            Console.ReadLine();
        }
    }

    public void AtualizarEstoque(Estoque e){
        int codigo;
        int fluxo = 0;

        Console.WriteLine($"{"----ATUALIZAÇÃO DE ESTOQUE----", 8}");

        codigo = lerCodigo();

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

        if (e.attEstoque(codigo, fluxo))
            Console.WriteLine("Estoque atualizado com sucesso!");
        else
            Console.WriteLine("Erro ao atualizar estoque!");

        Console.ReadLine();
    }

    public void ListarProdutos(Estoque e){
        if (e.qntdProdutos > 0){
            Console.WriteLine($"{"----LISTA DE PRODUTOS----", 8}");
            imprimirProdutos(e.produtos.OrderBy(p => p.cod).ToList());
        }else{
            Console.WriteLine("Nenhum produto cadastrado!");
        }
        Console.ReadLine();
    }

    public void qntdInferior(Estoque e){
        int qntd = lerQuantidade();

        Console.WriteLine($"{"----LISTA DE PRODUTOS COM QUANTIDADE INFERIOR A", 8}{qntd}---");

        var produtos = e.produtos.FindAll(p => p.qntd < qntd).OrderBy(p => p.cod).ToList();

        if (produtos.Count > 0){
            imprimirProdutos(produtos);
        }else{
            Console.WriteLine("Nenhum produto encontrado!");
        }
        Console.ReadLine();
    }

    public void qntdEntre(Estoque e){
        int qntdInf = lerQuantidade(1);
        int qntdSup = lerQuantidade(2);

        Console.WriteLine($"{"----LISTA DE PRODUTOS COM QUANTIDADE ENTRE [", 8}{qntdInf}{", ", 8}{qntdSup}]---");

        var produtos = e.produtos.FindAll(p => p.qntd >= qntdInf && p.qntd <= qntdSup).OrderBy(p => p.cod).ToList();

        if (produtos.Count > 0){
            imprimirProdutos(produtos);
        }else{
            Console.WriteLine("Nenhum produto encontrado!");
        }
        Console.ReadLine();
    }

    public void totalEstoque(Estoque e){
        Console.WriteLine($"{"----TOTAL DO ESTOQUE----", 8}");
        Console.WriteLine($"{"Quantidade de produtos:", 8}{e.qntdProdutos}");
        Console.WriteLine($"{"Valor total do estoque:", 8}{e.produtos.Sum(p => p.qntd * p.preco)}");

        parcialProduto(e);
        
        Console.ReadLine();
    }

    public void parcialProduto(Estoque e){

        Console.WriteLine($"{"----PARCIAL DE PRODUTOS----", 8}");
        var precoParcial = e.produtos.Select(p => p.qntd * p.preco);

        var listaZip = e.produtos.Zip(precoParcial, (itemProduto, itemPreco) => new { iProd = itemProduto, iPreco = itemPreco });

        foreach(var item in listaZip){
            Console.WriteLine($"{item.iProd.cod, -5} - {item.iProd.nome}: R$ {item.iPreco:F2}" );
        }

    }


    public int lerCodigo(){
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

    public int lerQuantidade(int tipo=0){
        int qntd = -1;
        string modificador = " ";

        if (tipo == 1)
            modificador = " inferior ";
        else if (tipo == 2)
            modificador = " superior";


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

    public void imprimirProdutos( List<(int cod, string nome, int qntd, float preco)> produtos){
        Console.WriteLine($"{"COD.", -5} | {"NOME", -20} | {"QNTD.", -10} -| {"PRECO"}");
        foreach(var produto in produtos){
            Console.WriteLine($"{produto.cod, -8}{produto.nome, -20} {produto.qntd, -10} {produto.preco:F2}" );
        }

    }
}