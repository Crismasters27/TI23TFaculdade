using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;//Importando os comandos de conexão com o banco
using System.Windows.Forms;//Importando a estrutura de telas

namespace faculdade
{
    class DAOAluno
    {
        public MySqlConnection conexao;

        public int[] matricula;
        public string[] nome;
        public string[] data_ingresso;
        public int[] codigo_curso;

        public int i;
        public int contar;

        public DAOAluno()
        {
            conexao = new MySqlConnection(
                "server=localhost;database=faculdade;uid=root;password=;"
            );

            try
            {
                conexao.Open();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao conectar: " + erro);
            }
        }

        // INSERIR
        public void Inserir(int matricula, string nome, string dataIngresso, int codigoCurso)
        {
            string query = $"insert into aluno values('{matricula}','{nome}','{dataIngresso}','{codigoCurso}')";
            MySqlCommand sql = new MySqlCommand(query, conexao);
            sql.ExecuteNonQuery();

            MessageBox.Show("Aluno cadastrado com sucesso!");
        }

        // PREENCHER VETOR
        public void PreencherVetor()
        {
            matricula = new int[100];
            nome = new string[100];
            data_ingresso = new string[100];
            codigo_curso = new int[100];

            i = 0;
            contar = 0;

            string query = "select * from aluno";
            MySqlCommand sql = new MySqlCommand(query, conexao);
            MySqlDataReader leitor = sql.ExecuteReader();

            while (leitor.Read())
            {
                matricula[i] = Convert.ToInt32(leitor["matricula"]);
                nome[i] = leitor["nome"].ToString();
                data_ingresso[i] = leitor["data_ingresso"].ToString();
                codigo_curso[i] = Convert.ToInt32(leitor["codigo_curso"]);

                i++;
                contar++;
            }

            leitor.Close();
        }

        // CONSULTAR TUDO
        public string ConsultarTudo()
        {
            PreencherVetor();
            string msg = "";

            for (i = 0; i < contar; i++)
            {
                msg += "\nMatrícula: " + matricula[i] +
                       "\nNome: " + nome[i] +
                       "\nData Ingresso: " + data_ingresso[i] +
                       "\nCurso: " + codigo_curso[i] +
                       "\n----------------------\n";
            }

            return msg;
        }

        // DELETAR
        public string Deletar(int matricula)
        {
            string query = $"delete from aluno where matricula = '{matricula}'";
            MySqlCommand sql = new MySqlCommand(query, conexao);
            sql.ExecuteNonQuery();

            return "Aluno excluído com sucesso!";
        }
    }
}
