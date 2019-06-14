using System;
using System.Data;
using System.Data.SqlClient;
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
                conexao.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\Documentos\peixes.mdf;Integrated Security=True;Connect Timeout=30";
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
            peixe.Id = Convert.ToInt32(lblID.Text);
            peixe.Nome = txtNome.Text;
            peixe.Raca = cbRaca.SelectedItem.ToString();
            peixe.Preco = Convert.ToDecimal(mtbPreco.Text);
            peixe.Quantidade = Convert.ToInt32(nudQuantidade.Value);

            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\Documentos\peixes.mdf;Integrated Security=True;Connect Timeout=30";
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"INSERT INTO peixes(nome,raca,preco,quantidade) VALUES (@NOME,@RACA,@PRECO,@QUANTIDADE)";
           
            comando.Parameters.AddWithValue(@"NOME", peixe.Nome);
            comando.Parameters.AddWithValue(@"RACA", peixe.Raca);
            comando.Parameters.AddWithValue(@"PRECO", peixe.Preco);
            comando.Parameters.AddWithValue(@"QUANTIDADE", peixe.Quantidade);
            comando.ExecuteNonQuery();
            MessageBox.Show("Registro criado com sucesso");
            conexao.Close();
            AtualizarTabela();
            LimparCampos();

        }

        private void Alterar()
        {
            Peixe peixe = new Peixe();
            peixe.Nome = txtNome.Text;
            peixe.Raca = cbRaca.SelectedItem.ToString();
            peixe.Preco = Convert.ToDecimal(mtbPreco.Text);
            peixe.Quantidade = Convert.ToInt32(nudQuantidade.Value);

            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\Documentos\peixes.mdf;Integrated Security=True;Connect Timeout=30";
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText=@"UPADTE peixes SET nome=@NOME,raca=@RACA,preco=@PRECO,quantidade=@QUANTIDADE WHERE id=@ID";
            comando.Parameters.AddWithValue("@ID", peixe.Id);
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
                AtualizarTabela();
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
            conexao.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\Documentos\peixes.mdf;Integrated Security=True;Connect Timeout=30";
            conexao.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "SELECT id,nome,raca,preco,quantidade FROM peixes";

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            dataGridView1.RowCount = 0;

            for(int i=0;i<tabela.Rows.Count;i++)
            {
                DataRow linha = tabela.Rows[i];
                Peixe peixe = new Peixe();
                peixe.Id= Convert.ToInt32(linha["id"]);
                peixe.Nome = linha["nome"].ToString();
                peixe.Raca = linha["raca"].ToString();
                peixe.Preco =Convert.ToDecimal( linha["preco"]);
                peixe.Quantidade = Convert.ToInt32(linha["quantidade"]);
                dataGridView1.Rows.Add(new string[] { peixe.Id.ToString(), peixe.Nome, peixe.Raca, peixe.Preco.ToString(), peixe.Quantidade.ToString() });

            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\Documentos\peixes.mdf;Integrated Security=True;Connect Timeout=30";
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.CommandText = @" SELECT id,nome,raca,preco,quantidade FROM peixes WHERE id= @ID";
            comando.Parameters.AddWithValue("@ID", id);
            comando.Connection = conexao;

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            DataRow linha = tabela.Rows[0];
            Peixe peixe = new Peixe();
            peixe.Id = Convert.ToInt32(linha["id"]);
            peixe.Nome = linha["nome"].ToString();
            peixe.Raca = linha["raca"].ToString();
            peixe.Preco = Convert.ToDecimal(linha["preco"]);
            peixe.Quantidade = Convert.ToInt32(linha["quantidade"]);

            lblID.Text = peixe.Id.ToString();
            txtNome.Text = peixe.Nome;
            cbRaca.SelectedItem = peixe.Raca;
            mtbPreco.Text = peixe.Preco.ToString();
            nudQuantidade.Value = peixe.Quantidade;

            conexao.Close();

        }

        private void Peixes_Activated(object sender, EventArgs e)
        {
            AtualizarTabela();
        }
    }
}
