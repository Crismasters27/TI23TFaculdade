using MySql.Data.MySqlClient;//Importando os comandos de conexão com o banco
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;//Importando a estrutura de telas

namespace faculdade
{
    class DAOProfessor
    {
        public MySqlConnection conexao;

        public int[] codigoProfessor;
        public string[] nome;
        public string[] titulacao;
        public string[] departamento;
        public int[] cargaHoraria;

        public int i;
        public int contar;
        public string msg;

        public DAOProfessor()
        {
            this.conexao = new MySqlConnection(
                "server=localhost;DataBase=faculdade;Uid=root;Password=;Convert Zero DateTime=True"
            );

            try
            {
                this.conexao.Open();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao conectar ao banco\n\n" + erro);
            }
        }

        // INSERIR
        public void Inserir(string nome, string titulacao, string departamento, int cargaHoraria)
        {
            try
            {
                MySqlCommand sql = new MySqlCommand(
                    "INSERT INTO professor (nome, titulacao, departamento, cargaHoraria) VALUES (" +
                    "'" + nome + "','" +
                    titulacao + "','" +
                    departamento + "','" +
                    cargaHoraria + "')",
                    this.conexao
                );

                sql.ExecuteNonQuery();
                MessageBox.Show("Professor inserido com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao inserir professor\n\n" + erro);
            }
        }

        // PREENCHER VETORES
        public void PreencherVetor()
        {
            string query = "SELECT * FROM professor";

            codigoProfessor = new int[100];
            nome = new string[100];
            titulacao = new string[100];
            departamento = new string[100];
            cargaHoraria = new int[100];

            for (i = 0; i < 100; i++)
            {
                codigoProfessor[i] = 0;
                nome[i] = "";
                titulacao[i] = "";
                departamento[i] = "";
                cargaHoraria[i] = 0;
            }

            MySqlCommand coletar = new MySqlCommand(query, this.conexao);
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            contar = 0;

            while (leitura.Read())
            {
                codigoProfessor[i] = Convert.ToInt32(leitura["codigoProfessor"]);
                nome[i] = leitura["nome"].ToString();
                titulacao[i] = leitura["titulacao"].ToString();
                departamento[i] = leitura["departamento"].ToString();
                cargaHoraria[i] = Convert.ToInt32(leitura["cargaHoraria"]);

                i++;
                contar++;
            }

            leitura.Close();
        }

        // CONSULTAR TODOS
        public string ConsultarTudo()
        {
            PreencherVetor();
            msg = "";

            for (i = 0; i < contar; i++)
            {
                msg += "\nCódigo do Professor: " + codigoProfessor[i] +
                       "\nNome: " + nome[i] +
                       "\nTitulação: " + titulacao[i] +
                       "\nDepartamento: " + departamento[i] +
                       "\nCarga Horária: " + cargaHoraria[i] +
                       "\n---------------------------\n";
            }

            return msg;
        }

        // CONSULTAR POR CÓDIGO
        public string ConsultarPorCodigo(int codigo)
        {
            PreencherVetor();

            for (i = 0; i < contar; i++)
            {
                if (codigoProfessor[i] == codigo)
                {
                    return "\nCódigo do Professor: " + codigoProfessor[i] +
                           "\nNome: " + nome[i] +
                           "\nTitulação: " + titulacao[i] +
                           "\nDepartamento: " + departamento[i] +
                           "\nCarga Horária: " + cargaHoraria[i];
                }
            }

            return "Professor não encontrado.";
        }
    }
}
