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
    public partial class AtualizarCurso : Form
    {
        DAOCurso dao; // instância do DAO

        public AtualizarCurso()
        {
            InitializeComponent();
            this.dao = new DAOCurso(); // conecta ao banco
            CmbTipo.Items.Add("Bacharelado");
            CmbTipo.Items.Add("Licenciatura");
            CmbTipo.Items.Add("Tecnológico");
        }// fim do construtor

        private void AtualizarCurso_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void TxtDescricao_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtCurriculo_TextChanged(object sender, EventArgs e)
        {

        }

        private void CmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TxtDuracao_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtTitulo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
                    TxtTitulo.Text = titulo;
                    TxtDescricao.Text = this.dao.ConsultarDescricao(codigo);
                    TxtCurriculo.Text = this.dao.ConsultarCurriculo(codigo);
                    CmbTipo.Text = this.dao.ConsultarTipo(codigo);
                    TxtDuracao.Text = this.dao.ConsultarDuracao(codigo).ToString();
                }
            }
        }// fim do botão buscar

        private void TxtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            if (TxtCodigo.Text == "")
            {
                MessageBox.Show("Preencha o código!");
            }
            else
            {
                int codigo = Convert.ToInt32(TxtCodigo.Text);
                this.dao.Atualizar(codigo, "titulo", TxtTitulo.Text);
                this.dao.Atualizar(codigo, "descricao", TxtDescricao.Text);
                this.dao.Atualizar(codigo, "curriculo", TxtCurriculo.Text);
                this.dao.Atualizar(codigo, "tipo", CmbTipo.Text);
                string resultado = this.dao.Atualizar(codigo, "duracao", TxtDuracao.Text);
                MessageBox.Show(resultado);
                // limpar campos
                TxtCodigo.Text = "";
                TxtTitulo.Text = "";
                TxtDescricao.Text = "";
                TxtCurriculo.Text = "";
                TxtDuracao.Text = "";
                CmbTipo.SelectedIndex = -1;
            }
        }// fim do botão atualizar

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }// fim do botão voltar


    }
}
