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
    public partial class ExcluirProva : Form
    {
        DAOProva dao; // instância do DAO

        public ExcluirProva()
        {
            InitializeComponent();
            this.dao = new DAOProva(); // conecta ao banco
        }// fim do construtor

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
                string prova = this.dao.ConsultarObservacao(codigo);

                // verificar se o código existe
                if (prova == "Código informado não existe!")
                {
                    MessageBox.Show("Código informado não existe!");
                    TxtCodigo.Text = "";
                }
                else
                {
                    // confirmar exclusão
                    DialogResult confirmar = MessageBox.Show($"Deseja excluir a prova de código {codigo}?", "Confirmar Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirmar == DialogResult.Yes)
                    {
                        string resultado = this.dao.Deletar(codigo);
                        MessageBox.Show(resultado);
                        TxtCodigo.Text = "";
                    }
                }
            }
        }// fim do botão excluir

        // botão voltar
        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }// fim do botão voltar

        private void TxtCodigo_TextChanged(object sender, EventArgs e) { }

    }// fim da classe
}// fim do projeto