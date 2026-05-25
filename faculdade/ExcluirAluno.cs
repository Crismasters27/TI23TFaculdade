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
    public partial class ExcluirAluno : Form
    {
        DAOAluno dao; // instância do DAO
        public ExcluirAluno()
        {
            InitializeComponent();
            this.dao = new DAOAluno(); // conecta ao banco
        }// fim do construtor

        private void TxtMatricula_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (TxtMatricula.Text == "")
            {
                MessageBox.Show("Preencha a matrícula!");
            }
            else
            {
                int matricula = Convert.ToInt32(TxtMatricula.Text);
                string nome = this.dao.ConsultarNome(matricula);

                // verificar se a matrícula existe
                if (nome == "Matrícula informada não existe!")
                {
                    MessageBox.Show("Matrícula informada não existe!");
                    TxtMatricula.Text = "";
                }
                else
                {
                    // confirmar exclusão
                    DialogResult confirmar = MessageBox.Show($"Deseja excluir o aluno {nome}?", "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirmar == DialogResult.Yes)
                    {
                        string resultado = this.dao.Deletar(matricula);
                        MessageBox.Show(resultado);
                        TxtMatricula.Text = "";
                    }
                }
            }
        }// fim do botão excluir

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }// fim da classe
}// fim do projeto
