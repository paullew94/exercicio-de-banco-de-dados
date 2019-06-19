using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parte01
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

        }

        private void Inserir()
        {
            Cliente cliente = new Cliente();
            cliente.Nome = txtNome.Text;
            cliente.Saldo = Convert.ToDecimal(mtbSalario.Text);
            cliente.Telefone = mtbTelefone.Text;
            cliente.Estado = cbEstado.SelectedItem.ToString();
            cliente.Cidade = txtCidade.Text;
            cliente.Bairro = txtBairro.Text;
            cliente.Cep = mtbCep.Text;
            cliente.Logradouro = txtLogradouro.Text;
            cliente.Numero = nudNumero.Value();
        }
    }
}
