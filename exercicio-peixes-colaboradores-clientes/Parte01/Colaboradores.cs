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

        }
        private void Inserir()
        {

            Colaborador colaborador = new Colaborador();
            colaborador.Nome = txtNome.Text;
            colaborador.Cpf = mtbCpf.Text;
            colaborador.Salario = Convert.ToDecimal(mtbSalario.Text);
            colaborador.Sexo = cbSexo.SelectedItem.ToString();
            colaborador.Cargo = txtCargo.Text;
            colaborador.Programador = checkBoxProgramador.Text;

            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\Documentos\peixes.mdf;Integrated Security=True;Connect Timeout=30";
            conexao.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = @"INSERT INTO colaboradores (nome,cpf,salario,sexo,cargo,programador) VALUES (@NOME,@CPF,@SALARIO,@SEXO,@CARGO,@PROGRAMADOR)";

            comando.Parameters.AddWithValue("@NOME", colaborador.Nome);
            comando.Parameters.AddWithValue("@CPF", colaborador.Cpf);
            comando.Parameters.AddWithValue("@SALARIO", colaborador.Salario);
            comando.Parameters.AddWithValue("@SEXO", colaborador.Sexo);
            comando.Parameters.AddWithValue("@CARGO", colaborador.Cargo);
            comando.Parameters.AddWithValue("PROGRAMADOR", colaborador.Programador);
            MessageBox.Show("Registro criado com sucesso");
            LimparCampos();
            conexao.Close();
            AtualizarTabela();


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
            colaborador.Programador = checkBoxProgramador.Text;
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=T:\Documentos\peixes.mdf;Integrated Security=True;Connect Timeout=30";
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
            conexao.Close();
            AtualizarTabela();
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
            checkBoxProgramador;

        }

    }
}
