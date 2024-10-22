using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfApp1
{
    public interface ITransacao
    {
        void Sacar(decimal valor);
        void Depositar(decimal valor);
        void Transferir(Conta contaDestino, decimal valor);
    }

}