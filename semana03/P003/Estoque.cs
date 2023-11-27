using Semana03.P003;
public class Estoque{
    public List<(int cod, string nome, int qntd, float preco)> produtos { get; private set; }

    public int qntdProdutos => produtos.Count;

    public Estoque(){
        produtos = new List<(int cod, string nome, int qntd, float preco)>();
    }

    public bool addProduto(int codigo, string nome, int qntd, float preco){
        if(existeProduto(codigo)){
            return false;
        }else{
            produtos.Add((codigo, nome, qntd, preco));
            return true;
        }
    }

    public bool existeProduto(int codigo){
        try{
            var produto = produtos.Single(p => p.cod == codigo);
            return true;
        }catch(Exception){
            return false;
        }
    }

    public int buscarProduto(int codigo){
        if (existeProduto(codigo)){
            var produto = produtos.FindIndex(p => p.cod == codigo);
            return produto;
        }else{
            throw new Exception("Produto não encontrado!");
        }
    }

    public bool attEstoque(int codigo, int fluxo){
        try{
            var index = buscarProduto(codigo);
            if (produtos[index].qntd + fluxo < 0)
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