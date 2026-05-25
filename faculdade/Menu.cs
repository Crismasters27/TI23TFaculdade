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
    public partial class Menu : Form
    {
        // declaração das telas
        MenuCurso MenuCurso;
        MenuAluno MenuAluno;
        MenuProfessor MenuProfessor;
        MenuDisciplina MenuDisciplina;
        MenuProva MenuProva;
        public Menu()
        {
            InitializeComponent();
        }

        private void BtnCurso_Click(object sender, EventArgs e)
        {
            MenuCurso = new MenuCurso();
            MenuCurso.ShowDialog();
        }

        private void BtnAluno_Click(object sender, EventArgs e)
        {
            MenuAluno = new MenuAluno();
            MenuAluno.ShowDialog();
        }

        private void BtnProfessor_Click(object sender, EventArgs e)
        {
            MenuProfessor = new MenuProfessor();
            MenuProfessor.ShowDialog();
        }

        private void BtnDisciplina_Click(object sender, EventArgs e)
        {
            MenuDisciplina = new MenuDisciplina();
            MenuDisciplina.ShowDialog();
        }

        private void BtnProva_Click(object sender, EventArgs e)
        {
            MenuProva = new MenuProva();
            MenuProva.ShowDialog();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close(); // Fecha o Menu Principal
        }
    }
}
