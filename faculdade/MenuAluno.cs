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
    public partial class MenuAluno : Form
    {
        // declaração das telas
        CadastrarAluno CadastrarAluno;
        ConsultarAluno ConsultarAluno;
        AtualizarAluno AtualizarAluno;
        ExcluirAluno ExcluirAluno;

        public MenuAluno()
        {
            InitializeComponent();
        }// fim do construtor

        // botão cadastrar
        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            CadastrarAluno = new CadastrarAluno();
            CadastrarAluno.ShowDialog();
        }// fim do botão cadastrar

        // botão consultar
        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            ConsultarAluno = new ConsultarAluno();
            ConsultarAluno.ShowDialog();
        }// fim do botão consultar

        // botão atualizar
        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            AtualizarAluno = new AtualizarAluno();
            AtualizarAluno.ShowDialog();
        }// fim do botão atualizar

        // botão excluir
        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            ExcluirAluno = new ExcluirAluno();
            ExcluirAluno.ShowDialog();
        }// fim do botão excluir

        // botão voltar
        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }// fim do botão voltar

    }// fim da classe
}// fim do projeto