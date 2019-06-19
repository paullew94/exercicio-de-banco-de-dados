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
    public partial class Colaboradores : Form
    {
        public Colaboradores()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (lblID.Text == "0")
            {
                Inserir();
                AtualizarTabela();
            }
            else
            {
                Alterar();
            }
        }
        private void Inserir()
        {

            Colaborador colaborador = new Colaborador();
            colaborador.Id = Convert.ToInt32(lblID.Text);
            colaborador.Nome = txtNome.Text;
            colaborador.Cpf = mtbCpf.Text;
            colaborador.Salario = Convert.ToDecimal(mtbSalario.Text);
            colaborador.Sexo = cbSexo.SelectedItem.ToString();
            colaborador.Cargo = txtCargo.Text;
            if (checkBoxProgramador.Checked == true)
            {
                colaborador.Programador = "Sim";
            }
            else
            {
                colaborador.Programador = "Não";
            }



            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\Documentos\exercicio.mdf;Integrated Security=True;Connect Timeout=30";
            try
            {
                conexao.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"INSERT INTO colaboradores (nome,cpf,salario,sexo,cargo,programador) VALUES (@NOME,@CPF,@SALARIO,@SEXO,@CARGO,@PROGRAMADOR)";

            comando.Parameters.AddWithValue("@NOME", colaborador.Nome);
            comando.Parameters.AddWithValue("@CPF", colaborador.Cpf);
            comando.Parameters.AddWithValue("@SALARIO", colaborador.Salario);
            comando.Parameters.AddWithValue("@SEXO", colaborador.Sexo);
            comando.Parameters.AddWithValue("@CARGO", colaborador.Cargo);
            comando.Parameters.AddWithValue("PROGRAMADOR", colaborador.Programador);
            comando.ExecuteNonQuery();
            MessageBox.Show("Registro criado com sucesso");
          
            conexao.Close();
            AtualizarTabela();
            LimparCampos();


        }
        private void Alterar()
        {
            Colaborador colaborador = new Colaborador();
            colaborador.Id = Convert.ToInt32(lblID.Text);
            colaborador.Nome = txtNome.Text;
            colaborador.Cpf = mtbCpf.Text;
            colaborador.Salario = Convert.ToDecimal(mtbSalario.Text);
            colaborador.Sexo = cbSexo.SelectedItem.ToString();
            colaborador.Cargo = txtCargo.Text;
            if (checkBoxProgramador.Checked == true)
            {
                colaborador.Programador = "Sim";
            }
            else
            {
                colaborador.Programador = "Não";
            }

            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\Documentos\exercicio.mdf;Integrated Security=True;Connect Timeout=30";
            conexao.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"UPDATE colaboradores SET nome=@NOME,cpf=@CPF,salario=@SALARIO,cargo=@CARGO,programador=@PROGRAMADOR WHERE id=@ID";
            comando.Parameters.AddWithValue("@NOME", colaborador.Nome);
            comando.Parameters.AddWithValue("@CPF", colaborador.Cpf);
            comando.Parameters.AddWithValue("@SALARIO", colaborador.Salario);
            comando.Parameters.AddWithValue("@SEXO", colaborador.Sexo);
            comando.Parameters.AddWithValue("@CARGO", colaborador.Cargo);
            comando.Parameters.AddWithValue("PROGRAMADOR", colaborador.Programador);
            comando.ExecuteNonQuery();
            AtualizarTabela();
            conexao.Close();
            LimparCampos();

        }
        private void LimparCampos()
        {
            lblID.Text = "0";
            txtNome.Clear();
            mtbCpf.Clear();
            mtbSalario.Clear();
            cbSexo.SelectedIndex = -1;
            txtCargo.Clear();


        }
        private void AtualizarTabela()
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\Documentos\exercicio.mdf;Integrated Security=True;Connect Timeout=30";
            conexao.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = "SELECT id,nome,cpf,salario,sexo,cargo,programador FROM colaboradores";

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            dataGridView1.RowCount = 0;
            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                DataRow linha = tabela.Rows[i];
                Colaborador colaborador = new Colaborador();
                colaborador.Id = Convert.ToInt32(linha["id"]);
                colaborador.Nome = linha["nome"].ToString();
                colaborador.Cpf = linha["cpf"].ToString();
                colaborador.Salario = Convert.ToDecimal(linha["salario"]);
                colaborador.Sexo = linha["sexo"].ToString();
                colaborador.Cargo = linha["cargo"].ToString();
                colaborador.Programador = linha["programador"].ToString();
                dataGridView1.Rows.Add(new string[] { colaborador.Id.ToString(), colaborador.Nome, colaborador.Cpf, colaborador.Salario.ToString(), colaborador.Sexo, colaborador.Cargo, colaborador.Programador}); 
            }

        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Cadastre um colaborador");
                return;
            }
            DialogResult caixaDeDialogo = MessageBox.Show("Deseja realmente apagar?", "AVISO", MessageBoxButtons.YesNo);

            if (caixaDeDialogo == DialogResult.Yes)
            {

                SqlConnection conexao = new SqlConnection();
                conexao.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\Documentos\exercicio.mdf;Integrated Security=True;Connect Timeout=30";
                conexao.Open();

                SqlCommand comando = new SqlCommand();
                comando.Connection = conexao;
                comando.CommandText = "DELETE FROM colaboradores WHERE id=@ID";

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
            conexao.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\Documentos\exercicio.mdf;Integrated Security=True;Connect Timeout=30";
            conexao.Open();

            SqlCommand comando = new SqlCommand();
            comando.CommandText = @" SELECT id,nome,cpf,salario,sexo,cargo,programador FROM colaboradores WHERE id= @ID";
            comando.Parameters.AddWithValue("@ID", id);
            comando.Connection = conexao;

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            DataRow linha = tabela.Rows[0];
            Colaborador colaborador = new Colaborador();
            colaborador.Id = Convert.ToInt32(linha["id"]);
            colaborador.Nome = linha["nome"].ToString();
            colaborador.Cpf = linha["cpf"].ToString();
            colaborador.Salario = Convert.ToDecimal(linha["salario"]);
            colaborador.Sexo = linha["sexo"].ToString();
            colaborador.Cargo = linha["cargo"].ToString();
            colaborador.Programador = linha["programador"].ToString();

            lblID.Text = colaborador.Id.ToString();
            txtNome.Text = colaborador.Nome;
            mtbCpf.Text = colaborador.Cpf;
            mtbSalario.Text = colaborador.Salario.ToString();
            cbSexo.SelectedItem = colaborador.Sexo;
            txtCargo.Text = colaborador.Cargo;
            if(colaborador.Programador.ToLower() == "sim")
            {
            checkBoxProgramador.Checked = true ;

            }
            else
            {
                checkBoxProgramador.Checked = false;
            }

            conexao.Close();
        }

        private void Colaboradores_Activated(object sender, EventArgs e)
        {
            AtualizarTabela();
        }
    }
}
