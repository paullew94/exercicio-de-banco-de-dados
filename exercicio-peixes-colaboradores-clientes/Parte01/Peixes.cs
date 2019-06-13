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
        }
    }
}
