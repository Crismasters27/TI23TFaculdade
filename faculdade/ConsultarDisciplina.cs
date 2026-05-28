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
    public partial class ConsultarDisciplina : Form
    {
        DAODisciplina dao;

        public ConsultarDisciplina()
        {
            InitializeComponent();
            this.dao = new DAODisciplina();
            ChamarMetodo(DgvDisciplina);

        }// fim do construtor

        private void DgvDisciplina_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // chamar métodos
        public void ChamarMetodo(DataGridView dataGrid)
        {
            ConfigurarDataGrid(dataGrid);
            NomeColunas(dataGrid);
            AdicionarDados(dataGrid);
        }// fim chamar método

        // nome das colunas
        public void NomeColunas(DataGridView dataGrid)
        {
            dataGrid.Columns[0].Name = "Código";
            dataGrid.Columns[1].Name = "Disciplina";
            dataGrid.Columns[2].Name = "Curso";
            dataGrid.Columns[3].Name = "Professor";

        }// fim nome colunas

        // configurar estrutura da tabela
        public void ConfigurarDataGrid(DataGridView dataGrid)
        {
            dataGrid.AllowUserToAddRows = false;

            dataGrid.AllowUserToDeleteRows = false;

            dataGrid.AllowUserToResizeColumns = false;

            dataGrid.AllowUserToResizeRows = false;

            dataGrid.ColumnCount = 4;

        }// fim configurar datagrid

        // adicionar dados na tabela
        public void AdicionarDados(DataGridView dataGrid)
        {
            // preencher vetor
            this.dao.PreencherVetor();

            for (int i = 0; i < this.dao.contar; i++)
            {
                dataGrid.Rows.Add(this.dao.codigoDisciplina[i],
                                  this.dao.nomeDisciplina[i],
                                  this.dao.codigoCurso[i],
                                  this.dao.codigoProfessor[i]);

            }// fim do for

        }// fim adicionar dados

        // retornar datagrid
        public DataGridView retornarData()
        {
            return DgvDisciplina;

        }// fim retornar data

        // botão voltar
        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }// fim da classe

}// fim do projeto