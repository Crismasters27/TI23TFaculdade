using faculdade;
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
    public partial class ExcluirCurso : Form
    {
        DAOCurso dao; // instância do DAO

        public ExcluirCurso()
        {
            InitializeComponent();
            this.dao = new DAOCurso(); // conecta ao banco
        }// fim do construtor

        private void TxtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        // botão excluir
        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (TxtCodigo.Text == "")
            {
                MessageBox.Show("Preencha o código!");
            }
            else
            {
                int codigo = Convert.ToInt32(TxtCodigo.Text);
                string titulo = this.dao.ConsultarTitulo(codigo);

                // verificar se o código existe
                if (titulo == "Código informado não existe!")
                {
                    MessageBox.Show("Código informado não existe!");
                    TxtCodigo.Text = "";
                }
                else
                {
                    // confirmar exclusão
                    DialogResult confirmar = MessageBox.Show($"Deseja excluir o curso {titulo}?", "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirmar == DialogResult.Yes)
                    {
                        string resultado = this.dao.Deletar(codigo);
                        MessageBox.Show(resultado);
                        TxtCodigo.Text = "";
                    }
                }
            }
        }// fim do botão excluir

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }// fim do botão voltar
    }
}
