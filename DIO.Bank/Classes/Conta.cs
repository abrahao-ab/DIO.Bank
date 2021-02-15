using System;
namespace DIO.Bank

{
    //INÍCIO
   public class Conta
    {
        private TipoConta TipoConta { get; set; }

        private double Saldo { get; set; }

        private double Credito { get; set; }

        private string Nome { get; set; }

        //TORNA AS INSTÂNCIAS PÚBLICAS
        public Conta (TipoConta tipoConta, double saldo, double credito, string nome)
        {
            //Instâncias
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }
      
        //SACAR
        public bool Sacar(double valorSaque)
        {
            //Verificação de crédito
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }
            this.Saldo -= valorSaque;

            Console.WriteLine("O Saldo atual da conta é de {0} é {1}", this.Nome, this.Saldo);
            return true;
        }

        //DEPOSITAR
        public void Depositar(double valorDeposito)
        {
            //Adicionando Saldo na conta
            this.Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }

        //TRANSFERIR
        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        //INFORMAÇÕES DA CONTA
        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: R$ " + this.Saldo + " | ";
            retorno += "Crédito: R$ " + this.Credito + " | ";

            return retorno;
        }
    }

    
}
