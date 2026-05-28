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
    public partial class CadastrarDisciplina : Form
    {
        DAODisciplina dao; // instância do DAO

        public CadastrarDisciplina()
        {
            InitializeComponent();

            this.dao = new DAODisciplina(); // conecta ao banco

            // carregar cursos
            DAOCurso curso = new DAOCurso();
            curso.PreencherVetor();

            for (int i = 0; i < curso.contar; i++)
            {
                CmbCurso.Items.Add(curso.titulo[i]);
            }

            // carregar professores
            DAOProfessor professor = new DAOProfessor();
            professor.PreencherVetor();

            for (int i = 0; i < professor.contar; i++)
            {
                CmbProfessor.Items.Add(professor.nome[i]);
            }

        }// fim do construtor

        private void TxtDisciplina_TextChanged(object sender, EventArgs e)
        {

        }

        private void CmbCurso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CmbProfessor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // botão cadastrar
        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            // verificar campos
            if (TxtDisciplina.Text == "" ||
                CmbCurso.SelectedIndex == -1 ||
                CmbProfessor.SelectedIndex == -1)
            {
                MessageBox.Show("Preencha todos os campos!");
            }
            else
            {
                // pegar dados
                string nomeDisciplina = TxtDisciplina.Text;

                int codigoCurso = CmbCurso.SelectedIndex + 1;

                int codigoProfessor = CmbProfessor.SelectedIndex + 1;

                // inserir no banco
                this.dao.Inserir(nomeDisciplina,
                                  codigoCurso,
                                  codigoProfessor);

                // limpar campos
                LimparCampos();

            }// fim do else

        }// fim do botão cadastrar

        // botão limpar
        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        // método limpar campos
        public void LimparCampos()
        {
            TxtDisciplina.Text = "";

            CmbCurso.SelectedIndex = -1;

            CmbProfessor.SelectedIndex = -1;

        }// fim limpar campos

        // botão voltar
        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }// fim da classe

}// fim do projeto