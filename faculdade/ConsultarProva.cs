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
    public partial class ConsultarProva : Form
    {
        DAOProva dao; // instância do DAO

        public ConsultarProva()
        {
            InitializeComponent();
            this.dao = new DAOProva();
            ChamarMetodo(DgvProva); // configurar toda a estrutura
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
            dataGrid.ColumnCount = 7; // número de colunas da tabela prova
        }// fim do configurar

        // nomear as colunas
        public void NomeColunas(DataGridView dataGrid)
        {
            dataGrid.Columns[0].Name = "Código";
            dataGrid.Columns[1].Name = "Nota";
            dataGrid.Columns[2].Name = "Data de Realização";
            dataGrid.Columns[3].Name = "Observação";
            dataGrid.Columns[4].Name = "Matrícula";
            dataGrid.Columns[5].Name = "Disciplina";
            dataGrid.Columns[6].Name = "Professor";
        }// fim do nomear colunas

        // adicionar dados do banco no DataGridView
        public void AdicionarDados(DataGridView dataGrid)
        {
            this.dao.PreencherVetor();
            for (int i = 0; i < this.dao.contar; i++)
            {
                dataGrid.Rows.Add(
                    this.dao.codigoProva[i],
                    this.dao.nota[i],
                    this.dao.dataRealizacao[i].ToString("dd/MM/yyyy"),
                    this.dao.observacao[i],
                    this.dao.numeroMatricula[i],
                    this.dao.codigoDisciplina[i],
                    this.dao.codigoProfessor[i]
                );
            }// fim do for
        }// fim do adicionar dados

        // retornar DataGridView
        public DataGridView RetornarData()
        {
            return DgvProva;
        }// fim do retornar data

        // botão voltar
        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }// fim do botão voltar

        private void DgvProva_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }// fim da classe
}// fim do projeto