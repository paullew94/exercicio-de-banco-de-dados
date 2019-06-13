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
    public partial class Peixes : Form
    {
        public Peixes()
        {
            InitializeComponent();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count==0)
            {
                MessageBox.Show("Cadastre um peixe");
                return;
            }
            DialogResult caixaDeDialogo = MessageBox.Show("Deseja realmente apagar?","AVISO", MessageBoxButtons.YesNo);

            if (caixaDeDialogo== DialogResult.Yes)
            {

                SqlConnection conexao = new SqlConnection();
                conexao.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\Documentos\Peixes.mdf;Integrated Security=True;Connect Timeout=30";
                conexao.Open();

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexao;
                comando.CommandText = "DELETE FROM peixes WHERE id=@ID";

                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                comando.Parameters.AddWithValue("@ID", id);
                comando.ExecuteNonQuery();

                conexao.Close();
                AtualizarTabela();
            }
        }

        private void Inserir()
        {
            Peixe peixe = new Peixe();
            peixe.Nome = txtNome.Text;
            peixe.Raca = cbRaca.SelectedItem.ToString();
            peixe.Preco = Convert.ToDecimal(mtbPreco.Text);
            peixe.Quantidade = Convert.ToInt32(nudQuantidade.Value);

            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\Documentos\Peixes.mdf;Integrated Security=True;Connect Timeout=30";
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"INSERT INTO peixes(nome,raca,preco,quantidade) VALUES (@NOME,@RACA,@QUANTIDADE,@PRECO)";
           
            comando.Parameters.AddWithValue(@"NOME", peixe.Nome);
            comando.Parameters.AddWithValue(@"RACA", peixe.Raca);
            comando.Parameters.AddWithValue(@"PRECO", peixe.Preco);
            comando.Parameters.AddWithValue(@"QUANTIDADE", peixe.Quantidade);
            comando.ExecuteNonQuery();
            MessageBox.Show("Registro criado com sucesso");
            LimparCampos();
            conexao.Close();
            AtualizarTabela();

        }

        private void Alterar()
        {
            Peixe peixe = new Peixe();
            peixe.Nome = txtNome.Text;
            peixe.Raca = cbRaca.SelectedItem.ToString();
            peixe.Preco = Convert.ToDecimal(mtbPreco.Text);
            peixe.Quantidade = Convert.ToInt32(nudQuantidade.Value);

            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\Documentos\Peixes.mdf;Integrated Security=True;Connect Timeout=30";
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText=@"UPADTE peixes(nome,raca,preco,quantidade) SET nome=@NOME,raca=@RACA,preco=@PRECO,quantidade=@QUANTIDADE WHERE id=@ID";

            comando.Parameters.AddWithValue(@"NOME", peixe.Nome);
            comando.Parameters.AddWithValue(@"RACA", peixe.Raca);
            comando.Parameters.AddWithValue(@"PRECO", peixe.Preco);
            comando.Parameters.AddWithValue(@"QUANTIDADE", peixe.Quantidade);
            comando.ExecuteNonQuery();
            conexao.Close();
            LimparCampos();
            AtualizarTabela();


        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (lblID.Text=="0")
            {
                Inserir();
            }
            else
            {
                Alterar();
            }
        }

        private void LimparCampos()
        {
            lblID.Text = "0";
            txtNome.Clear();
            cbRaca.SelectedIndex = -1;
            mtbPreco.Clear();
            nudQuantidade.Value = 0;
        
        }

        private void AtualizarTabela()
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\Documentos\Peixes.mdf;Integrated Security=True;Connect Timeout=30";
            conexao.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "SELECT nome,raca,preco,quantidade FROM peixes";

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            dataGridView1.RowCount = 0;

            for(int i=0;i<tabela.Rows.Count;i++)
            {
                DataRow linha = tabela.Rows[i];
                Peixe peixe = new Peixe();
                peixe.Id = Convert.ToInt32(linha["id"]);
                peixe.Nome = linha["nome"].ToString();
                peixe.Preco =Convert.ToDecimal( linha["preco"]);
                peixe.Quantidade = Convert.ToInt32(linha["quantidade"]);

            }

        }
    }
}
