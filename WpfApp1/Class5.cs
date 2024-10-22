using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace WpfApp1
{
    public abstract class Conta
    {
        public int Numero { get; set; }
        public decimal Saldo { get; protected set; }

        public Conta(int numero)
        {
            Numero = numero;
            Saldo = 0;
        }

        public virtual void Depositar(decimal valor)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("O valor do depósito deve ser positivo.");
            }
            Saldo += valor;
        }

        public virtual void Sacar(decimal valor)
        {
            if (valor <= 0 || valor > Saldo)
            {
                throw new ArgumentException("Valor de saque inválido.");
            }
            Saldo -= valor;
        }
    }
}