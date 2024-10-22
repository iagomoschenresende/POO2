using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfApp1
{
    public class Transacao
    {
        public DateTime Data { get; private set; }
        public string Tipo { get; private set; } // "Depósito" ou "Saque"
        public decimal Valor { get; private set; }

        public Transacao(string tipo, decimal valor)
        {
            Data = DateTime.Now;
            Tipo = tipo;
            Valor = valor;
        }

        public override string ToString()
        {
            return $"{Data}: {Tipo} de {Valor:C}";
        }
    }

    public class GerenciadorDeTransacoes
    {
        private List<Transacao> historicoDeTransacoes = new List<Transacao>();

        public void RegistrarTransacao(string tipo, decimal valor)
        {
            Transacao transacao = new Transacao(tipo, valor);
            historicoDeTransacoes.Add(transacao);
        }

        public List<Transacao> ObterHistoricoDeTransacoes()
        {
            return historicoDeTransacoes;
        }

        public void Depositar(Conta conta, decimal valor)
        {
            conta.Depositar(valor);
            RegistrarTransacao("Depósito", valor);
        }

        public void Sacar(Conta conta, decimal valor)
        {
            conta.Sacar(valor);
            RegistrarTransacao("Saque", valor);
        }
    }
}
