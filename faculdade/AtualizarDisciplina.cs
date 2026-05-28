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
    public partial class AtualizarDisciplina : Form
    {
        DAODisciplina dao; // instância do DAO

        public AtualizarDisciplina()
        {
            InitializeComponent();

            this.dao = new DAODisciplina(); // conecta ao banco

            CarregarCursos(); // carregar cursos
            CarregarProfessores(); // carregar professores

        }// fim do construtor

        // carregar cursos no ComboBox
        public void CarregarCursos()
        {
            DAOCurso daoCurso = new DAOCurso();
            daoCurso.PreencherVetor();
            for (int i = 0; i < daoCurso.contar; i++)
            {
                CmbCurso.Items.Add(new
                {
                    Texto = daoCurso.titulo[i],
                    Valor = daoCurso.codigoCurso[i]
                });

            }// fim do for
            CmbCurso.DisplayMember = "Texto";
            CmbCurso.ValueMember = "Valor";

        }// fim carregar cursos

        // carregar professores no ComboBox
        public void CarregarProfessores()
        {
            DAOProfessor daoProfessor = new DAOProfessor();

            daoProfessor.PreencherVetor();

            for (int i = 0; i < daoProfessor.contar; i++)
            {
                CmbProfessor.Items.Add(new
                {
                    Texto = daoProfessor.nome[i],
                    Valor = daoProfessor.codigoProfessor[i]
                });

            }// fim do for

            CmbProfessor.DisplayMember = "Texto";

            CmbProfessor.ValueMember = "Valor";

        }// fim carregar professores

        private void TxtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtDisciplina_TextChanged(object sender, EventArgs e)
        {

        }

        private void CmbCurso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CmbProfessor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // botão buscar
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (TxtCodigo.Text == "")
            {
                MessageBox.Show("Preencha o código!");
            }
            else
            {
                int codigoDisciplina =
                    Convert.ToInt32(TxtCodigo.Text);

                string nome =
                    this.dao.ConsultarNomeDisciplina(codigoDisciplina);

                // verificar se existe
                if (nome == "Código informado não existe!")
                {
                    MessageBox.Show("Código informado não existe!");

                    TxtCodigo.Text = "";
                }
                else
                {
                    TxtDisciplina.Text = nome;

                    // selecionar curso
                    int codigoCurso =
                        this.dao.ConsultarCodigoCurso(codigoDisciplina);

                    for (int i = 0; i < CmbCurso.Items.Count; i++)
                    {
                        dynamic item = CmbCurso.Items[i];

                        if (item.Valor == codigoCurso)
                        {
                            CmbCurso.SelectedIndex = i;

                            break;
                        }

                    }// fim do for

                    // selecionar professor
                    int codigoProfessor =
                        this.dao.ConsultarCodigoProfessor(codigoDisciplina);

                    for (int i = 0; i < CmbProfessor.Items.Count; i++)
                    {
                        dynamic item = CmbProfessor.Items[i];

                        if (item.Valor == codigoProfessor)
                        {
                            CmbProfessor.SelectedIndex = i;

                            break;
                        }

                    }// fim do for

                }// fim do else

            }// fim do else

        }// fim botão buscar

        // botão atualizar
        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            if (TxtCodigo.Text == "")
            {
                MessageBox.Show("Preencha o código!");
            }
            else
            {
                int codigoDisciplina =
                    Convert.ToInt32(TxtCodigo.Text);

                dynamic cursoSelecionado =
                    CmbCurso.SelectedItem;

                int codigoCurso =
                    cursoSelecionado.Valor;

                dynamic professorSelecionado =
                    CmbProfessor.SelectedItem;

                int codigoProfessor =
                    professorSelecionado.Valor;

                // atualizar disciplina
                this.dao.Atualizar(codigoDisciplina,
                                   "nomeDisciplina",
                                   TxtDisciplina.Text);

                // atualizar curso
                this.dao.Atualizar(codigoDisciplina,
                                   "codigoCurso",
                                   codigoCurso.ToString());

                // atualizar professor
                string resultado =
                    this.dao.Atualizar(codigoDisciplina,
                                       "codigoProfessor",
                                       codigoProfessor.ToString());

                MessageBox.Show(resultado);

                // limpar campos
                TxtCodigo.Text = "";

                TxtDisciplina.Text = "";

                CmbCurso.SelectedIndex = -1;

                CmbProfessor.SelectedIndex = -1;

            }// fim do else

        }// fim botão atualizar

        // botão voltar
        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }// fim da classe

}// fim do projeto