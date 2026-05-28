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
    public partial class AtualizarProfessor : Form
    {
        DAOProfessor dao; // instância do DAO
        public AtualizarProfessor()
        {
            InitializeComponent();
            this.dao = new DAOProfessor();
            CmbTitulacao.Items.Add("Graduado");
            CmbTitulacao.Items.Add("Especialista");
            CmbTitulacao.Items.Add("Mestre");
            CmbTitulacao.Items.Add("Doutor");
        }

        private void TxtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtNome_TextChanged(object sender, EventArgs e)
        {

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

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (TxtCodigo.Text == "")
            {
                MessageBox.Show("Preencha o código!");
            }
            else
            {
                int codigo = Convert.ToInt32(TxtCodigo.Text);
                string nome = this.dao.ConsultarNome(codigo);

                // verificar se o código existe
                if (nome == "Código informado não existe!")
                {
                    MessageBox.Show("Código informado não existe!");
                    TxtCodigo.Text = "";
                }
                else
                {
                    TxtNome.Text = nome;
                    CmbTitulacao.Text = this.dao.ConsultarTitulacao(codigo);
                    TxtDepartamento.Text = this.dao.ConsultarDepartamento(codigo);
                    TxtCargaHoraria.Text = this.dao.ConsultarCargaHoraria(codigo).ToString();
                }
            }
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
                this.dao.Atualizar(codigo, "nome", TxtNome.Text);
                this.dao.Atualizar(codigo, "titulacao", CmbTitulacao.Text);
                this.dao.Atualizar(codigo, "departamento", TxtDepartamento.Text);
                this.dao.Atualizar(codigo, "cargaHoraria", TxtCargaHoraria.Text);
                string resultado = this.dao.Atualizar(codigo, "cargaHoraria", TxtCargaHoraria.Text);
                MessageBox.Show(resultado);
                // limpar campos
                TxtCodigo.Text = "";
                TxtNome.Text = "";
                CmbTitulacao.SelectedIndex = -1;
                TxtDepartamento.Text = "";
                TxtCargaHoraria.Text = "";
            }
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
