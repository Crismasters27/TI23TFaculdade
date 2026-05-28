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
    public partial class AtualizarAluno : Form
    {
        DAOAluno dao; // instância do DAO
        public AtualizarAluno()
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
                CmbCurso.Items.Add(new { Texto = daoCurso.titulo[i], Valor = daoCurso.codigoCurso[i] });
            }
            CmbCurso.DisplayMember = "Texto";
            CmbCurso.ValueMember = "Valor";
        }// fim do carregar cursos


        private void TxtMatricula_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void DtpDataIngresso_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CmbCurso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            if (TxtMatricula.Text == "")
            {
                MessageBox.Show("Preencha a matrícula!");
            }
            else
            {
                int matricula = Convert.ToInt32(TxtMatricula.Text);
                string data = DtpDataIngresso.Value.ToString("yyyy-MM-dd");
                dynamic itemSelecionado = CmbCurso.SelectedItem;
                int codigoCurso = itemSelecionado.Valor;

                this.dao.Atualizar(matricula, "nome", TxtNome.Text);
                this.dao.Atualizar(matricula, "dataIngresso", data);
                string resultado = this.dao.Atualizar(matricula, "codigoCurso", codigoCurso.ToString());
                MessageBox.Show(resultado);

                // limpar campos
                TxtMatricula.Text = "";
                TxtNome.Text = "";
                DtpDataIngresso.Value = DateTime.Now;
                CmbCurso.SelectedIndex = -1;
            }
        }// fim do botão atualizar

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }// fim do botão voltar

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (TxtMatricula.Text == "")
            {
                MessageBox.Show("Preencha a matrícula!");
            }
            else
            {
                int matricula = Convert.ToInt32(TxtMatricula.Text);
                string nome = this.dao.ConsultarNome(matricula);

                // verificar se a matrícula existe
                if (nome == "Matrícula informada não existe!")
                {
                    MessageBox.Show("Matrícula informada não existe!");
                    TxtMatricula.Text = "";
                }
                else
                {
                    TxtNome.Text = nome;
                    DtpDataIngresso.Value = this.dao.ConsultarDataIngresso(matricula);

                    // selecionar o curso no ComboBox
                    int codigoCurso = this.dao.ConsultarCodigoCurso(matricula);
                    for (int i = 0; i < CmbCurso.Items.Count; i++)
                    {
                        dynamic item = CmbCurso.Items[i];
                        if (item.Valor == codigoCurso)
                        {
                            CmbCurso.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }// fim do botão buscar
    }// fim da classe
}// fim do projeto
