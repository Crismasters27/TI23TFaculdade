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
    public partial class ConsultarProfessor : Form
    {
        DAOProfessor dao; // instância do DAO
        public ConsultarProfessor()
        {
            InitializeComponent();
            this.dao = new DAOProfessor();
            ChamarMetodo(DgvProfessor); // configurar toda a estrutura
        }

        // chamar método
        public void ChamarMetodo(DataGridView datagrid)
        {
            ConfigurarDataGrid(datagrid); // configuro a estrutura
            NomeColunas(datagrid);        // configuro os nomes
            AdicionarDados(datagrid);     // adiciono os dados
        }// fim do método

        public void ConfigurarDataGrid(DataGridView dataGrid)
        {
            dataGrid.AllowUserToAddRows = false;
            dataGrid.AllowUserToDeleteRows = false;
            dataGrid.AllowUserToResizeColumns = false;
            dataGrid.AllowUserToResizeRows = false;
            dataGrid.ColumnCount = 5; // número de colunas da tabela professor
        }// fim do configurar

        // nomear as colunas
        public void NomeColunas(DataGridView dataGrid)
        {
            dataGrid.Columns[0].Name = "Código";
            dataGrid.Columns[1].Name = "Nome";
            dataGrid.Columns[2].Name = "Titulação";
            dataGrid.Columns[3].Name = "Departamento";
            dataGrid.Columns[4].Name = "Carga Horária";
        }// fim do nomear colunas

        // adicionar dados do banco no DataGridView
        public void AdicionarDados(DataGridView dataGrid)
        {
            this.dao.PreencherVetor();
            for (int i = 0; i < this.dao.contar; i++)
            {
                dataGrid.Rows.Add(
                    this.dao.codigoProfessor[i],
                    this.dao.nome[i],
                    this.dao.titulacao[i],
                    this.dao.departamento[i],
                    this.dao.cargaHoraria[i]
                );
            }// fim do for
        }// fim do adicionar dados

        // retornar DataGridView
        public DataGridView RetornarData()
        {
            return DgvProfessor;
        }// fim do retornar data

        private void DgvProfessor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
