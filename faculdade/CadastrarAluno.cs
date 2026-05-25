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
    public partial class CadastrarAluno : Form
    {
        DAOAluno dao; // instância do DAO

        public CadastrarAluno()
        {
            InitializeComponent();
            this.dao = new DAOAluno(); // conecta ao banco
            CarregarCursos();          // carregar cursos no ComboBox
        }// fim do construtor

        // carregar cursos no ComboBox
        public void CarregarCursos()
        {
            DAOCurso daoCurso = new DAOCurso();
            daoCurso.PreencherVetor();
            for (int i = 0; i < daoCurso.contar; i++)
            {
                // mostra o título mas guarda o código
                CmbCurso.Items.Add(new { Texto = daoCurso.titulo[i], Valor = daoCurso.codigoCurso[i] });
            }
            CmbCurso.DisplayMember = "Texto"; // mostra o título
            CmbCurso.ValueMember = "Valor"; // guarda o código
        }// fim do carregar cursos

        // botão cadastrar
        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            if (TxtNome.Text == "" || CmbCurso.SelectedIndex == -1)
            {
                MessageBox.Show("Preencha todos os campos!");
            }
            else
            {
                string nome = TxtNome.Text;
                DateTime dataIngresso = DtpDataIngresso.Value;
                dynamic itemSelecionado = CmbCurso.SelectedItem;
                int codigoCurso = itemSelecionado.Valor;

                // inserir no banco
                this.dao.Inserir(nome, dataIngresso, codigoCurso);

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
            TxtNome.Text = "";
            DtpDataIngresso.Value = DateTime.Now; // volta para a data atual
            CmbCurso.SelectedIndex = -1;
        }// fim do limpar campos

        // botão voltar
        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }// fim do botão voltar

        private void TxtNome_TextChanged(object sender, EventArgs e) 
        {

        }
        private void DtpDataIngresso_ValueChanged(object sender, EventArgs e)
        {

        }
        private void CmbCurso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }// fim da classe
}// fim do projeto