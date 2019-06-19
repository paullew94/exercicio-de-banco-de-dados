using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            cliente.Numero = Convert.ToInt32(nudNumero.Value);
            cliente.Complemento = txtComplemento.Text;
            if (ckbNomeSujo.Checked == true)
            {
                cliente.NomeSujo = "Sim";
            }
            else
            {
                cliente.NomeSujo = "Não";
            }
            cliente.Altura = Convert.ToDecimal(txtAltura.Text);
            cliente.Peso = Convert.ToDecimal(txtPeso.Text);

            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\Documentos\exercicio.mdf;Integrated Security=True;Connect Timeout=30";

            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"INSERT INTO clientes (nome,saldo,telefone,estado,cidade,bairro,cep,logradouro,numero,complemento,nome_sujo,altura,peso) VALUES (@NOME,@SALDO,@TELEFONE,@ESTADO,@BAIRRO,@CEP,@LOGRADOURO,@NUMERO,@COMPLEMENTO,@NOME_SUJO,@ALTURA,@PESO)";
            comando.Parameters.AddWithValue("@NOME", cliente.Nome);
            comando.Parameters.AddWithValue("@SALDO", cliente.Saldo);
            comando.Parameters.AddWithValue("@TELEFONE", cliente.Telefone);
            comando.Parameters.AddWithValue("@ESTADO", cliente.Estado);
            comando.Parameters.AddWithValue("@BAIRRO", cliente.Bairro);
            comando.Parameters.AddWithValue("@CEP", cliente.Cep);
            comando.Parameters.AddWithValue("@LOGRADURO", cliente.Logradouro);
            comando.Parameters.AddWithValue("@NUMERO", cliente.Numero);
            comando.Parameters.AddWithValue("@COMPLEMENTO", cliente.Complemento);
            comando.Parameters.AddWithValue("@NOME_SUJO", cliente.NomeSujo);
            comando.Parameters.AddWithValue("@ALTURA", cliente.Altura);
            comando.Parameters.AddWithValue("@PESO", cliente.Peso);
            comando.ExecuteNonQuery();
            MessageBox.Show("Registro criado com sucesso");

            conexao.Close();
            AtualizarTabela();
            LimparCampos();


        }

        private void Alterar()
        {
            Cliente cliente = new Cliente();
            cliente.Id = Convert.ToInt32(lblID.Text);
            cliente.Nome = txtNome.Text;
            cliente.Saldo = Convert.ToDecimal(mtbSalario.Text);
            cliente.Telefone = mtbTelefone.Text;
            cliente.Estado = cbEstado.SelectedItem.ToString();
            cliente.Cidade = txtCidade.Text;
            cliente.Bairro = txtBairro.Text;
            cliente.Cep = mtbCep.Text;
            cliente.Logradouro = txtLogradouro.Text;
            cliente.Numero = Convert.ToInt32(nudNumero.Value);
            cliente.Complemento = txtComplemento.Text;
            if (ckbNomeSujo.Checked == true)
            {
                cliente.NomeSujo = "Sim";
            }
            else
            {
                cliente.NomeSujo = "Não";

            }
            cliente.Altura = Convert.ToDecimal(txtAltura.Text);
            cliente.Peso = Convert.ToDecimal(txtPeso.Text);
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\Documentos\exercicio.mdf;Integrated Security=True;Connect Timeout=30";
            conexao.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"UPDATE clientes SET nome=@NOME,saldo=@SALDO,telefone=@TELEFONE,estado=@ESTADO,cidade=@CIDADE, WHERE id=@ID";
        }
    }
}
