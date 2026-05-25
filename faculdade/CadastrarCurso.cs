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
    public partial class CadastrarCurso : Form
    {
        DAOCurso curso;
        public CadastrarCurso()
        {
            InitializeComponent();
            this.curso = new DAOCurso(); // conecta ao banco
            CmbTipo.Items.Add("Bacharelado");
            CmbTipo.Items.Add("Licenciatura");
            CmbTipo.Items.Add("Tecnológico");
        }// fim do construtor

        private void CmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TxtTitulo_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtDescricao_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtCurriculo_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtDuracao_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            // verificar se os campos estão preenchidos
            if (TxtTitulo.Text == "" || TxtDescricao.Text == "" || TxtCurriculo.Text == "" || TxtDuracao.Text == "" || CmbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Preencha todos os campos!");
            }
            else
            {
                string titulo = TxtTitulo.Text;
                string descricao = TxtDescricao.Text;
                string curriculo = TxtCurriculo.Text;
                string tipo = CmbTipo.SelectedItem.ToString();
                int duracao = Convert.ToInt32(TxtDuracao.Text);

                // inserir no banco
                this.curso.Inserir(titulo, descricao, curriculo, tipo, duracao);

                // limpar campos após cadastro
                LimparCampos();
            }
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }// fim do botao limpar

        // método para limpar os campos
        public void LimparCampos()
        {
            TxtTitulo.Text = "";
            TxtDescricao.Text = "";
            TxtCurriculo.Text = "";
            TxtDuracao.Text = "";
            CmbTipo.SelectedIndex = -1; // limpa a seleção do ComboBox
        }// fim do limpar campos

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CadastrarCurso_Load(object sender, EventArgs e)
        {

        }
    }
}
