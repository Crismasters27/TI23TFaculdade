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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }// fim do construtor

        // botão entrar
        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            if (TxtUsuario.Text == "" || TxtSenha.Text == "")
            {
                MessageBox.Show("Preencha todos os campos!");
            }
            else if (TxtUsuario.Text == "admin" && TxtSenha.Text == "1234")
            {
                Menu menu = new Menu();
                menu.Show();      // abre o menu
                this.Hide();      // esconde o login
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos!");
                TxtSenha.Text = "";
                TxtUsuario.Focus();
                TxtUsuario.Text = ""; // move para depois do Focus
            }
        }// fim do botão entrar

        // botão sair
        private void BtnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }// fim do botão sair

        private void TxtUsuario_TextChanged(object sender, EventArgs e)
        {

        }
        private void TxtSenha_TextChanged(object sender, EventArgs e)
        {

        }

    }// fim da classe
}// fim do projeto