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
    public partial class CadastrarProfessor : Form
    {
        DAOProfessor dao; // instância do DAO
        public CadastrarProfessor()
        {
            InitializeComponent();
            this.dao = new DAOProfessor(); // conecta ao banco
            CmbTitulacao.Items.Add("Graduado");
            CmbTitulacao.Items.Add("Especialista");
            CmbTitulacao.Items.Add("Mestre");
            CmbTitulacao.Items.Add("Doutor");
        }

        private void CmbTitulacao_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TxtDepartamento_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtCargaHoraria_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            if (TxtNome.Text == "" || CmbTitulacao.SelectedIndex == -1 || TxtDepartamento.Text == "" || TxtCargaHoraria.Text == "")
            {
                MessageBox.Show("Preencha todos os campos!");
            }
            else
            {
                string nome = TxtNome.Text;
                string titulacao = CmbTitulacao.SelectedItem.ToString();
                string departamento = TxtDepartamento.Text;
                int cargaHoraria = Convert.ToInt32(TxtCargaHoraria.Text);

                // inserir no banco
                this.dao.Inserir(nome, titulacao, departamento, cargaHoraria);

                // limpar campos
                LimparCampos();
            }
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        public void LimparCampos()
        {
            TxtNome.Text = "";
            CmbTitulacao.SelectedIndex = -1;
            TxtDepartamento.Text = "";
            TxtCargaHoraria.Text = "";
        }// fim do limpar campos

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtNome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
