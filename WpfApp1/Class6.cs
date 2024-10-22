using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfApp1
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Conta> Contas { get; set; }

        public Cliente(int id, string nome)
        {
            Id = id;
            Nome = nome;
            Contas = new List<Conta>();
        }

        public void AdicionarConta(Conta conta)
        {
            Contas.Add(conta);
        }
    }
}
