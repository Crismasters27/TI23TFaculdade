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
    public partial class MenuProva : Form
    {
        // telas
        CadastrarProva cad;
        ConsultarProva con;
        AtualizarProva atu;
        ExcluirProva exc;

        public MenuProva()
        {
            InitializeComponent();
        }

        // botão cadastrar
        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            cad = new CadastrarProva();
            cad.ShowDialog();

        }// fim botão cadastrar

        // botão consultar
        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            con = new ConsultarProva();
            con.ShowDialog();

        }// fim botão consultar

        // botão atualizar
        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            atu = new AtualizarProva();
            atu.ShowDialog();

        }// fim botão atualizar

        // botão excluir
        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            exc = new ExcluirProva();
            exc.ShowDialog();

        }// fim botão excluir

        // botão voltar
        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();

        }// fim botão voltar

    }// fim da classe

}// fim do projeto