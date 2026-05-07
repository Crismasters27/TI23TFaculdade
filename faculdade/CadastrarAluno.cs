using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace faculdad
{
    public partial class CadastrarAluno : Form
    {
        DAOAluno dao;

        public CadastrarAluno()
        {
            InitializeComponent();
            dao = new DAOAluno();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" ||
                textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Preencha todos os campos!");
            }
            else
            {
                int matricula = Convert.ToInt32(textBox1.Text);
                string nome = textBox2.Text;
                string data = textBox3.Text;
                int codigoCurso = Convert.ToInt32(textBox4.Text);

                dao.Inserir(matricula, nome, data, codigoCurso);

                LimparCampos();
            }
        }

        private void LimparCampos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
