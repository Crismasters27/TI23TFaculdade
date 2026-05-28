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
    public partial class AtualizarProva : Form
    {
        DAOProva dao; // instância do DAO

        public AtualizarProva()
        {
            InitializeComponent();
            this.dao = new DAOProva(); // conecta ao banco
            CarregarMatriculas();      // carregar alunos no ComboBox
            CarregarDisciplinas();     // carregar disciplinas no ComboBox
            CarregarProfessores();     // carregar professores no ComboBox
        }// fim do construtor

        // carregar matrículas no ComboBox
        public void CarregarMatriculas()
        {
            DAOAluno daoAluno = new DAOAluno();
            daoAluno.PreencherVetor();
            for (int i = 0; i < daoAluno.contar; i++)
            {
                CmbMatricula.Items.Add(new { Texto = $"{daoAluno.numeroMatricula[i]} - {daoAluno.nome[i]}", Valor = daoAluno.numeroMatricula[i] });
            }
            CmbMatricula.DisplayMember = "Texto";
            CmbMatricula.ValueMember = "Valor";
        }// fim do carregar matrículas

        // carregar disciplinas no ComboBox
        public void CarregarDisciplinas()
        {
            DAODisciplina daoDisciplina = new DAODisciplina();
            daoDisciplina.PreencherVetor();
            for (int i = 0; i < daoDisciplina.contar; i++)
            {
                CmbDisciplina.Items.Add(new { Texto = daoDisciplina.nomeDisciplina[i], Valor = daoDisciplina.codigoDisciplina[i] });
            }
            CmbDisciplina.DisplayMember = "Texto";
            CmbDisciplina.ValueMember = "Valor";
        }// fim do carregar disciplinas

        // carregar professores no ComboBox
        public void CarregarProfessores()
        {
            DAOProfessor daoProfessor = new DAOProfessor();
            daoProfessor.PreencherVetor();
            for (int i = 0; i < daoProfessor.contar; i++)
            {
                CmbProfessor.Items.Add(new { Texto = daoProfessor.nome[i], Valor = daoProfessor.codigoProfessor[i] });
            }
            CmbProfessor.DisplayMember = "Texto";
            CmbProfessor.ValueMember = "Valor";
        }// fim do carregar professores

        // botão buscar
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (TxtCodigo.Text == "")
            {
                MessageBox.Show("Preencha o código!");
            }
            else
            {
                int codigo = Convert.ToInt32(TxtCodigo.Text);
                string obs = this.dao.ConsultarObservacao(codigo);

                // verificar se o código existe
                if (obs == "Código informado não existe!")
                {
                    MessageBox.Show("Código informado não existe!");
                    TxtCodigo.Text = "";
                }
                else
                {
                    TxtNota.Text = this.dao.ConsultarNota(codigo).ToString();
                    DtpDataRealizacao.Value = this.dao.ConsultarDataRealizacao(codigo);
                    TextObservacao.Text = obs;

                    // selecionar matrícula no ComboBox
                    int matricula = this.dao.ConsultarNumeroMatricula(codigo);
                    for (int i = 0; i < CmbMatricula.Items.Count; i++)
                    {
                        dynamic item = CmbMatricula.Items[i];
                        if (item.Valor == matricula)
                        {
                            CmbMatricula.SelectedIndex = i;
                            break;
                        }
                    }

                    // selecionar disciplina no ComboBox
                    int disciplina = this.dao.ConsultarCodigoDisciplina(codigo);
                    for (int i = 0; i < CmbDisciplina.Items.Count; i++)
                    {
                        dynamic item = CmbDisciplina.Items[i];
                        if (item.Valor == disciplina)
                        {
                            CmbDisciplina.SelectedIndex = i;
                            break;
                        }
                    }

                    // selecionar professor no ComboBox
                    int professor = this.dao.ConsultarCodigoProfessor(codigo);
                    for (int i = 0; i < CmbProfessor.Items.Count; i++)
                    {
                        dynamic item = CmbProfessor.Items[i];
                        if (item.Valor == professor)
                        {
                            CmbProfessor.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }// fim do botão buscar

        // botão atualizar
        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            if (TxtCodigo.Text == "")
            {
                MessageBox.Show("Preencha o código!");
            }
            else
            {
                int codigo = Convert.ToInt32(TxtCodigo.Text);
                string dataFormatada = DtpDataRealizacao.Value.ToString("yyyy-MM-dd");
                dynamic itemMatricula = CmbMatricula.SelectedItem;
                dynamic itemDisciplina = CmbDisciplina.SelectedItem;
                dynamic itemProfessor = CmbProfessor.SelectedItem;

                this.dao.Atualizar(codigo, "nota", TxtNota.Text);
                this.dao.Atualizar(codigo, "dataRealizacao", dataFormatada);
                this.dao.Atualizar(codigo, "observacao", TextObservacao.Text);
                this.dao.Atualizar(codigo, "numeroMatricula", itemMatricula.Valor.ToString());
                this.dao.Atualizar(codigo, "codigoDisciplina", itemDisciplina.Valor.ToString());
                string resultado = this.dao.Atualizar(codigo, "codigoProfessor", itemProfessor.Valor.ToString());
                MessageBox.Show(resultado);

                // limpar campos
                TxtCodigo.Text = "";
                TxtNota.Text = "";
                DtpDataRealizacao.Value = DateTime.Now;
                TextObservacao.Text = "";
                CmbMatricula.SelectedIndex = -1;
                CmbDisciplina.SelectedIndex = -1;
                CmbProfessor.SelectedIndex = -1;
            }
        }// fim do botão atualizar

        // botão voltar
        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }// fim do botão voltar

        private void TxtCodigo_TextChanged(object sender, EventArgs e)
        {

        }
        private void TxtNota_TextChanged(object sender, EventArgs e)
        {

        }
        private void DtpDataRealizacao_ValueChanged(object sender, EventArgs e)
        {

        }
        private void TextObservacao_TextChanged(object sender, EventArgs e)
        {

        }
        private void CmbMatricula_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void CmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void CmbProfessor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

    }// fim da classe
}// fim do projeto