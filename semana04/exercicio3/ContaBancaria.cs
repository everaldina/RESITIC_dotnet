namespace Semana3.Exercicio3;

class ContaBancaria{
    private float saldo;
    public float Saldo{
        get{
            return saldo;
        }

        set{
            if(value >= 0){
                saldo = value;
            }else{
                throw new ArgumentException("Saldo não pode ser negativo");
            }
        }
    }

    public ContaBancaria(float saldo){
        this.saldo = saldo;
    }
}