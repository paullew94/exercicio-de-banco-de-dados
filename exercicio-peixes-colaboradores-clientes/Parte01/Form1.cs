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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPeixes_Click(object sender, EventArgs e)
        {
            Peixes peixe = new Peixes();
            peixe.Show();
        }

        private void btnColaboradores_Click(object sender, EventArgs e)
        {
            Colaboradores colaborador = new Colaboradores();
            colaborador.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes();
            cliente.Show();

        }
    }
}
