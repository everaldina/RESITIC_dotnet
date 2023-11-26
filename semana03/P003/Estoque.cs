using Semana03.P003;
public class Estoque{
    public List<(int cod, string nome, int qntd, float preco)> produtos { get; private set; }

    public int qntdProdutos { get; private set; } = 0;

    public Estoque(){
        produtos = new List<(int cod, string nome, int qntd, float preco)>();
    }

    public bool addProduto(int codigo, string nome, int qntd, float preco){
        if(existeProduto(codigo)){
            return false;
        }else{
            produtos.Add((codigo, nome, qntd, preco));
            qntdProdutos++;
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

    public (int cod, string nome, int qntd, float preco) buscarProduto(int codigo){
        if (existeProduto(codigo)){
            var produto = produtos.Find(p => p.cod == codigo);
            return produto;
        }else{
            throw new Exception("Produto não encontrado");
        }
    }

    public bool attEstoque(int codigo, int fluxo){
        try{
            var produto = buscarProduto(codigo);
            if (produto.qntd + fluxo < 0)
                return false;
            else{
                produto.qntd += fluxo;
                return true;
            }
        }catch(Exception){
            return false;
        }
    }

}