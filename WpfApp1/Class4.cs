using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
namespace WpfApp1
{
    public class ContaCorrente : Conta
    {
        public decimal Limite { get; private set; }

        public ContaCorrente(int numero, decimal limite) : base(numero)
        {
            Limite = limite;
        }

        public override void Sacar(decimal valor)
        {

            if (Limite + Saldo >= valor)
            {
                Saldo -= valor;
            }
            else
            {
                throw new ArgumentException("Saldo insuficiente, considerando o limite.");
            }
        }
    }
}