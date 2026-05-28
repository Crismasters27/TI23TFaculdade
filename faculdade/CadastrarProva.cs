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
    public partial class CadastrarProva : Form
    {
        DAOProva dao; // instância do DAO

        public CadastrarProva()
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

        // botão cadastrar
        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            if (TxtNota.Text == "" || CmbMatricula.SelectedIndex == -1 || CmbDisciplina.SelectedIndex == -1 || CmbProfessor.SelectedIndex == -1)
            {
                MessageBox.Show("Preencha todos os campos obrigatórios!");
            }
            else
            {
                double nota = Convert.ToDouble(TxtNota.Text);
                DateTime dataRealizacao = DtpDataRealizacao.Value;
                string observacao = TextObservacao.Text;
                dynamic itemMatricula = CmbMatricula.SelectedItem;
                dynamic itemDisciplina = CmbDisciplina.SelectedItem;
                dynamic itemProfessor = CmbProfessor.SelectedItem;
                int numeroMatricula = itemMatricula.Valor;
                int codigoDisciplina = itemDisciplina.Valor;
                int codigoProfessor = itemProfessor.Valor;

                // inserir no banco
                this.dao.Inserir(nota, dataRealizacao, observacao, numeroMatricula, codigoDisciplina, codigoProfessor);

                // limpar campos
                LimparCampos();
            }
        }// fim do botão cadastrar

        // botão limpar
        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }// fim do botão limpar

        // método limpar campos
        public void LimparCampos()
        {
            TxtNota.Text = "";
            DtpDataRealizacao.Value = DateTime.Now;
            TextObservacao.Text = "";
            CmbMatricula.SelectedIndex = -1;
            CmbDisciplina.SelectedIndex = -1;
            CmbProfessor.SelectedIndex = -1;
        }// fim do limpar campos

        // botão voltar
        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }// fim do botão voltar

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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void TxtObservacao_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }// fim da classe
}// fim do projeto