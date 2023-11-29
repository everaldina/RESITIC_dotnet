class ContaBancaria{
    private int saldo;
    public int Saldo{
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
}