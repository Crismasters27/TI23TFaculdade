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
    public partial class MenuDisciplina : Form
    {
        // telas
        CadastrarDisciplina cad;
        ConsultarDisciplina con;
        AtualizarDisciplina atu;
        ExcluirDisciplina exc;

        public MenuDisciplina()
        {
            InitializeComponent();
        }

        // botão cadastrar
        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            cad = new CadastrarDisciplina();
            cad.ShowDialog();
        }

        // botão consultar
        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            con = new ConsultarDisciplina();
            con.ShowDialog();
        }

        // botão atualizar
        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            atu = new AtualizarDisciplina();
            atu.ShowDialog();
        }

        // botão excluir
        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            exc = new ExcluirDisciplina();
            exc.ShowDialog();
        }

        // botão voltar
        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}