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
    public partial class MenuCurso : Form
    {
        CadastrarCurso CadastrarCurso;
        ConsultarCurso ConsultarCurso;
        AtualizarCurso AtualizarCurso;
        ExcluirCurso ExcluirCurso;
        public MenuCurso()
        {
            InitializeComponent();
        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            CadastrarCurso = new CadastrarCurso();
            CadastrarCurso.ShowDialog();
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            ConsultarCurso = new ConsultarCurso();
            ConsultarCurso.ShowDialog();
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            AtualizarCurso = new AtualizarCurso();
            AtualizarCurso.ShowDialog();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            ExcluirCurso = new ExcluirCurso();
            ExcluirCurso.ShowDialog();
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Close(); // Fecha o MenuCurso e volta pro Menu principal
        }

        private void MenuCurso_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
