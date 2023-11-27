using Semana03.P003;
public class Estoque{
    public List<(int cod, string nome, int qntd, float preco)> produtos { get; private set; }

    public int qntdProdutos => produtos.Count;

    public Estoque(){
        produtos = new List<(int cod, string nome, int qntd, float preco)>();
    }

    // adiciona um produto ao estoque, retorna true se o produto foi adicionado com sucesso
    // nao permite adicionar produtos com o mesmo codigo
    public bool addProduto(int codigo, string nome, int qntd, float preco){
        if(existeProduto(codigo)){
            return false;
        }else{
            produtos.Add((codigo, nome, qntd, preco));
            return true;
        }
    }

    // retorna true se o produto existe no estoque
    public bool existeProduto(int codigo){
        try{
            var produto = produtos.Single(p => p.cod == codigo);
            return true;
        }catch(Exception){
            return false;
        }
    }

    // retorna o indice do produto no estoque
    // lança uma exceção se o produto não existir
    public int buscarProduto(int codigo){
        if (existeProduto(codigo)){
            var produto = produtos.FindIndex(p => p.cod == codigo);
            return produto;
        }else{
            throw new Exception("Produto não encontrado!");
        }
    }

    // atualiza o estoque de um produto com um fluxo de entrada ou saída
    public bool attEstoque(int codigo, int fluxo){
        try{
            var index = buscarProduto(codigo);

            if (produtos[index].qntd + fluxo < 0) // não permite estoque negativo
                throw new Exception("Quantidade inválida!");
            else{
                produtos[index] = (produtos[index].cod, produtos[index].nome, produtos[index].qntd + fluxo, produtos[index].preco);
                return true;
            }
        }catch(Exception ex){
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    // deleta um produto do estoque
    public bool deletarProduto(int codigo){
        try{
            var index = buscarProduto(codigo);
            produtos.RemoveAt(index);
            return true;
        }catch(Exception ex){
            Console.WriteLine(ex.Message);
            return false;
        }
    }

}