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
    public partial class MenuProfessor : Form
    {
        // declaração das telas
        CadastrarProfessor CadastrarProfessor;
        ConsultarProfessor ConsultarProfessor;
        AtualizarProfessor AtualizarProfessor;
        ExcluirProfessor ExcluirProfessor;
        public MenuProfessor()
        {
            InitializeComponent();
        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            CadastrarProfessor = new CadastrarProfessor();
            CadastrarProfessor.ShowDialog();
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            ConsultarProfessor = new ConsultarProfessor();
            ConsultarProfessor.ShowDialog();
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            AtualizarProfessor = new AtualizarProfessor();
            AtualizarProfessor.ShowDialog();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            ExcluirProfessor = new ExcluirProfessor();
            ExcluirProfessor.ShowDialog();
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
