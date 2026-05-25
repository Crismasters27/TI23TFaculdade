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
    public partial class ConsultarAluno : Form
    {
        DAOAluno dao; // instância do DAO

        public ConsultarAluno()
        {
            InitializeComponent();
            this.dao = new DAOAluno();
            ChamarMetodo(DgvAluno); // configurar toda a estrutura
        }// fim do construtor

        // chamar método
        public void ChamarMetodo(DataGridView datagrid)
        {
            ConfigurarDataGrid(datagrid); // configuro a estrutura
            NomeColunas(datagrid);        // configuro os nomes
            AdicionarDados(datagrid);     // adiciono os dados
        }// fim do método

        // configurar o DataGridView
        public void ConfigurarDataGrid(DataGridView dataGrid)
        {
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.AllowUserToResizeColumns = false;
            dataGrid.AllowUserToResizeRows = false;
            dataGrid.ColumnCount = 4; // número de colunas da tabela aluno
        }// fim do configurar

        // nomear as colunas
        public void NomeColunas(DataGridView dataGrid)
        {
            dataGrid.Columns[0].Name = "Matrícula";
            dataGrid.Columns[1].Name = "Nome";
            dataGrid.Columns[2].Name = "Data de Ingresso";
            dataGrid.Columns[3].Name = "Curso";
        }// fim do nomear colunas

        // adicionar dados do banco no DataGridView
        public void AdicionarDados(DataGridView dataGrid)
        {
            this.dao.PreencherVetor();
            for (int i = 0; i < this.dao.contar; i++)
            {
                dataGrid.Rows.Add(
                    this.dao.numeroMatricula[i],
                    this.dao.nome[i],
                    this.dao.dataIngresso[i].ToString("dd/MM/yyyy"),
                    this.dao.codigoCurso[i]
                );
            }// fim do for
        }// fim do adicionar dados

        // retornar DataGridView
        public DataGridView RetornarData()
        {
            return DgvAluno;
        }// fim do retornar data

        // botão voltar
        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }// fim do botão voltar

        private void DgvAluno_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

    }// fim da classe
}// fim do projeto