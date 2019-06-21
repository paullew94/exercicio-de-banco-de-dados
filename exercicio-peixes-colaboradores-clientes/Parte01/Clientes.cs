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
            comando.CommandText = @"UPDATE clientes SET nome=@NOME,saldo=@SALDO,telefone=@TELEFONE,estado=@ESTADO,cidade=@CIDADE,bairro=@BAIRRO,cep=@CEP,logradouro=@LOGRADOURO,numero=@NUMERO,complemento=@COMPLEMENTO,nome_sujo=@NOME_SUJO,altura=@ALTURA,peso=@PESO WHERE id=@ID";
            comando.Parameters.AddWithValue("@NOME", cliente.Nome);
            comando.Parameters.AddWithValue("@SALDO", cliente.Saldo);
            comando.Parameters.AddWithValue("@TELEFONE", cliente.Telefone);
            comando.Parameters.AddWithValue("@ESTADO", cliente.Estado);
            comando.Parameters.AddWithValue("@CIDADE", cliente.Cidade);
            comando.Parameters.AddWithValue("@BAIRRO", cliente.Bairro);
            comando.Parameters.AddWithValue("@CEP", cliente.Cep);
            comando.Parameters.AddWithValue("@LOGRADURO", cliente.Logradouro);
            comando.Parameters.AddWithValue("@NUMERO", cliente.Numero);
            comando.Parameters.AddWithValue("@COMPLEMENTO", cliente.Complemento);
            comando.Parameters.AddWithValue("@NOME_SUJO", cliente.NomeSujo);
            comando.Parameters.AddWithValue("@ALTURA", cliente.Altura);
            comando.Parameters.AddWithValue("@PESO", cliente.Peso);

            comando.ExecuteNonQuery();
            AtualizarTabela();
            conexao.Close();
            LimparCampos();
        }

        private void LimparCampos()
        {
            lblID.Text = "0";
            txtNome.Clear();
            mtbSalario.Clear();
            mtbTelefone.Clear();
            cbEstado.SelectedIndex = -1;
            txtBairro.Clear();
            mtbCep.Clear();
            txtLogradouro.Clear();
            nudNumero.Value = 0;
            txtComplemento.Clear();
            ckbNomeSujo.Checked = false;
            txtAltura.Clear();
            txtPeso.Clear();
        }
        private void AtualizarTabela()
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = @"";
            conexao.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "SELECT id,nome,saldo,telefone,estado,cidade,bairro,cep,logradouro,numero,complemento,nome_sujo,altura,peso FROM clientes";

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            dataGridView1.RowCount = 0;
            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                DataRow linha = tabela.Rows[i];
                Cliente cliente = new Cliente();
                cliente.Id = Convert.ToInt32(linha["id"]);
                cliente.Nome = linha["nome"].ToString();
                cliente.Saldo = Convert.ToDecimal(linha["saldo"]);
                cliente.Telefone = linha["telefone"].ToString();
                cliente.Estado = linha["estado"].ToString();
                cliente.Cidade = linha["cidade"].ToString();
                cliente.Bairro = linha["bairro"].ToString();
                cliente.Cep = linha["cep"].ToString();
                cliente.Logradouro = linha["logradouro"].ToString();
                cliente.Numero = Convert.ToInt32(linha["numero"]);
                cliente.Complemento = linha["complemento"].ToString();
                cliente.NomeSujo = linha["nome_sujo"].ToString();
                cliente.Altura = Convert.ToDecimal(linha["altura"]);
                cliente.Peso = Convert.ToDecimal(linha["peso"]);
                dataGridView1.Rows.Add(new string[] { cliente.Id.ToString(), cliente.Nome, cliente.Saldo.ToString(), cliente.Telefone, cliente.Estado, cliente.Cidade, cliente.Bairro, cliente.Cep, cliente.Logradouro, cliente.Numero.ToString(), cliente.Complemento, cliente.NomeSujo, cliente.Altura.ToString(), cliente.Peso.ToString() });
            }
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Cadastre um cliente");
                return;
            }
            DialogResult caixaDeDialogo = MessageBox.Show("Deseja realmente apagar?", "AVISO", MessageBoxButtons.YesNo);

            if (caixaDeDialogo == DialogResult.Yes)
            {

                SqlConnection conexao = new SqlConnection();
                conexao.ConnectionString = @"";
                conexao.Open();

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexao;
                comando.CommandText = "DELETE FROM clientes WHERE id=@ID";

                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                comando.Parameters.AddWithValue("@ID", id);
                comando.ExecuteNonQuery();

                conexao.Close();
                AtualizarTabela();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = @"";
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.CommandText = @" SELECT id,nome,saldo,telefone,estado,cidade,bairro,cep,logradouro,numero,complemento,nome_sujo,altura,peso FROM clientes WHERE id= @ID";
            comando.Parameters.AddWithValue("@ID", id);
            comando.Connection = conexao;

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            DataRow linha = tabela.Rows[0];
            Cliente cliente = new Cliente();
            cliente.Id = Convert.ToInt32(linha["id"]);
            cliente.Nome = linha["nome"].ToString();
            cliente.Saldo = Convert.ToDecimal(linha["saldo"]);
            cliente.Telefone = linha["telefone"].ToString();
            cliente.Estado = linha["estado"].ToString();
            cliente.Cidade = linha["cidade"].ToString();
            cliente.Bairro = linha["bairro"].ToString();
            cliente.Cep = linha["cep"].ToString();
            cliente.Logradouro = linha["logradouro"].ToString();
            cliente.Numero = Convert.ToInt32(linha["numero"]);
            cliente.Complemento = linha["complemento"].ToString();
            cliente.NomeSujo = linha["nome_sujo"].ToString();
            cliente.Altura = Convert.ToDecimal(linha["altura"]);
            cliente.Peso = Convert.ToDecimal(linha["peso"]);

            lblID.Text = cliente.Id.ToString();
            txtNome.Text = cliente.Nome;
            mtbSalario.Text = cliente.Saldo.ToString();
            mtbTelefone.Text = cliente.Telefone;
            cbEstado.SelectedItem = cliente.Estado.ToString();
            txtCidade.Text = cliente.Cidade;
            txtBairro.Text = cliente.Bairro;
            mtbCep.Text = cliente.Cep;
            txtLogradouro.Text = cliente.Logradouro;
            nudNumero.Value = cliente.Numero;
            txtComplemento.Text = cliente.Complemento;
            if(cliente.NomeSujo.ToLower()=="sim")
            {
                ckbNomeSujo.Checked = true;
            }
            else
            {
                ckbNomeSujo.Checked = false;
            }
            txtAltura.Text = cliente.Altura.ToString();
            txtPeso.Text = cliente.Peso.ToString();
            conexao.Close();
        }

        private void Clientes_Activated(object sender, EventArgs e)
        {
            AtualizarTabela();
        }
    }
}
