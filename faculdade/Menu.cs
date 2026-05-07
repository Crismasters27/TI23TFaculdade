using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace faculdade
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CadastrarAluno cad = new CadastrarAluno();
            cad.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConsultarAluno con = new ConsultarAluno();
            con.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AtualizarAluno atu = new AtualizarAluno();
            atu.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExcluirAluno exc = new ExcluirAluno();
            exc.ShowDialog();
        }
    }
}
