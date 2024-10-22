using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
namespace WpfApp1
{
    public class ContaPoupanca : Conta
    {
        private decimal taxaDeRendimento = 0.05m; // 0.5% de rendimento mensal

        public ContaPoupanca(int numero) : base(numero) { }

        public void AplicarRendimentoMensal()
        {
            Saldo += Saldo * taxaDeRendimento;
        }

        public override void Sacar(decimal valor)
        {
            if (Saldo >= valor)
            {
                Saldo -= valor;
                Saldo = Saldo + Saldo * taxaDeRendimento;
            }
            else
            {
                throw new ArgumentException("Saldo insuficiente.");
            }
        }
    }
}