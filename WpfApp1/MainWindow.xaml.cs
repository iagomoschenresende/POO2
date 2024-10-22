using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private GerenciadorDeClientes gerenciadorDeClientes;
        private GerenciadorDeContas gerenciadorDeContas;
        private GerenciadorDeTransacoes gerenciadorDeTransacoes;
        

        public MainWindow()
        {
            InitializeComponent();
            gerenciadorDeClientes = new GerenciadorDeClientes();
            gerenciadorDeContas = new GerenciadorDeContas();
            gerenciadorDeTransacoes = new GerenciadorDeTransacoes();
        }

        // Método para adicionar um cliente
        private void BtnAdicionarCliente_Click(object sender, RoutedEventArgs e)
        {
            string nomeCliente = txtNomeCliente.Text;
            if (!string.IsNullOrEmpty(nomeCliente))
            {
                // Criação de um novo cliente com Id baseado no número de clientes já existentes
                Cliente novoCliente = new Cliente(gerenciadorDeClientes.ObterTodosClientes().Count + 1, nomeCliente);
                gerenciadorDeClientes.AdicionarCliente(novoCliente);
                lstClientes.Items.Add(novoCliente.Nome);
                txtNomeCliente.Clear();
            }
        }

        // Método para adicionar uma conta corrente ao cliente selecionado
        private void BtnAdicionarContaCorrente_Click(object sender, RoutedEventArgs e)
        {
            if (lstClientes.SelectedIndex >= 0 && decimal.TryParse(txtLimite.Text, out decimal limite))
            {
                Cliente clienteSelecionado = gerenciadorDeClientes.ObterTodosClientes()[lstClientes.SelectedIndex];

                // Criação de uma nova conta corrente
                ContaCorrente novaContaCorrente = new ContaCorrente(gerenciadorDeContas.ObterTodasContas().Count + 1, limite);
                clienteSelecionado.AdicionarConta(novaContaCorrente);
                lstContasCliente.Items.Add($"Conta {novaContaCorrente.Numero} - Corrente");
                txtLimite.Clear();
            }
            else
            {
                MessageBox.Show("Selecione um cliente e insira um limite válido.");
            }
        }

        // Método para adicionar uma conta poupança ao cliente selecionado
        private void BtnAdicionarContaPoupanca_Click(object sender, RoutedEventArgs e)
        {
            if (lstClientes.SelectedIndex >= 0)
            {
                Cliente clienteSelecionado = gerenciadorDeClientes.ObterTodosClientes()[lstClientes.SelectedIndex];

                // Criação de uma nova conta poupança
                ContaPoupanca novaContaPoupanca = new ContaPoupanca(gerenciadorDeContas.ObterTodasContas().Count + 1);
                clienteSelecionado.AdicionarConta(novaContaPoupanca);
                lstContasCliente.Items.Add($"Conta {novaContaPoupanca.Numero} - Poupança");
            }
            else
            {
                MessageBox.Show("Selecione um cliente.");
            }
        }

        private void LstClientes_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (lstClientes.SelectedIndex >= 0)
            {
                Cliente clienteSelecionado = gerenciadorDeClientes.ObterTodosClientes()[lstClientes.SelectedIndex];
                lstContasCliente.Items.Clear();
                foreach (var conta in clienteSelecionado.Contas)
                {
                    if (conta is ContaCorrente)
                        lstContasCliente.Items.Add($"Conta {conta.Numero} - Corrente - Saldo: {conta.Saldo:C}");
                    else if (conta is ContaPoupanca)
                        lstContasCliente.Items.Add($"Conta {conta.Numero} - Poupança - Saldo: {conta.Saldo:C}");
                }
            }
        }

        // Depósito
        private void BtnDepositar_Click(object sender, RoutedEventArgs e)
        {
            if (lstClientes.SelectedIndex >= 0 && lstContasCliente.SelectedIndex >= 0 && decimal.TryParse(txtValor.Text, out decimal valor))
            {
                Cliente clienteSelecionado = gerenciadorDeClientes.ObterTodosClientes()[lstClientes.SelectedIndex];
                Conta contaSelecionada = clienteSelecionado.Contas[lstContasCliente.SelectedIndex];

                gerenciadorDeTransacoes.Depositar(contaSelecionada, valor);
                LstClientes_SelectionChanged(null, null); // Atualiza o saldo
                txtValor.Clear();
            }
            else
            {
                MessageBox.Show("Selecione um cliente, uma conta e insira um valor válido.");
            }
        }

        // Saque
        private void BtnSacar_Click(object sender, RoutedEventArgs e)
        {
            if (lstClientes.SelectedIndex >= 0 && lstContasCliente.SelectedIndex >= 0 && decimal.TryParse(txtValor.Text, out decimal valor))
            {
                Cliente clienteSelecionado = gerenciadorDeClientes.ObterTodosClientes()[lstClientes.SelectedIndex];
                Conta contaSelecionada = clienteSelecionado.Contas[lstContasCliente.SelectedIndex];

                try
                {
                    gerenciadorDeTransacoes.Sacar(contaSelecionada, valor);
                    LstClientes_SelectionChanged(null, null); // Atualiza o saldo
                    txtValor.Clear();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Selecione um cliente, uma conta e insira um valor válido.");
            }
        }
    }
}
