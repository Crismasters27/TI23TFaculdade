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
    public partial class ConsultarCurso : Form
    {
        DAOCurso dao; // instância do DAO
        public ConsultarCurso()
        {
            InitializeComponent();
            this.dao = new DAOCurso();
            ChamarMetodo(DgvCurso); // configurar toda a estrutura
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
            dataGrid.AllowUserToAddRows = false; // não permite adicionar linhas
            dataGrid.AllowUserToDeleteRows = false; // não permite deletar linhas
            dataGrid.AllowUserToResizeColumns = false;
            dataGrid.AllowUserToResizeRows = false;
            dataGrid.ColumnCount = 6;     // número de colunas da tabela curso
        }// fim do configurar

        // nomear as colunas
        public void NomeColunas(DataGridView dataGrid)
        {
            dataGrid.Columns[0].Name = "Código";
            dataGrid.Columns[1].Name = "Título";
            dataGrid.Columns[2].Name = "Descrição";
            dataGrid.Columns[3].Name = "Currículo";
            dataGrid.Columns[4].Name = "Tipo";
            dataGrid.Columns[5].Name = "Duração";
        }// fim do nomear colunas

        // adicionar dados do banco no DataGridView
        public void AdicionarDados(DataGridView dataGrid)
        {
            this.dao.PreencherVetor(); // preencher o vetor com os dados do banco
            for (int i = 0; i < this.dao.contar; i++)
            {
                dataGrid.Rows.Add(
                    this.dao.codigoCurso[i],
                    this.dao.titulo[i],
                    this.dao.descricao[i],
                    this.dao.curriculo[i],
                    this.dao.tipo[i],
                    this.dao.duracao[i]
                );
            }// fim do for
        }// fim do adicionar dados

        // retornar DataGridView
        public DataGridView RetornarData()
        {
            return DgvCurso;
        }// fim do retornar data

        private void DgvCurso_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }// fim do DgvCurso

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }// fim da classe
}// fim do projeto
