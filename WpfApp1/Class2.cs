using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;


namespace WpfApp1
{
    public class GerenciadorDeContas
    {
        private List<Conta> contas = new List<Conta>();

        public void AdicionarConta(Conta conta)
        {
            contas.Add(conta);
        }

        public Conta ObterConta(int numero)
        {
            return contas.FirstOrDefault(c => c.Numero == numero);
        }

        public List<Conta> ObterTodasContas()
        {
            return contas;
        }
    }
}
