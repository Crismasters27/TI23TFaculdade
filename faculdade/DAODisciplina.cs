using MySql.Data.MySqlClient;//Importando os comandos de conexão com o banco
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;//Importando a estrutura de telas

namespace faculdade
{
    class DAODisciplina
    {
        public MySqlConnection conexao;

        public int[] codigo;
        public string[] nomeDisciplina;

        public int i;
        public int contar;
        public string msg;

        public DAODisciplina()
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
        public void Inserir(string nomeDisciplina)
        {
            try
            {
                MySqlCommand sql = new MySqlCommand(
                    "INSERT INTO disciplina (nomeDisciplina) VALUES ('" + nomeDisciplina + "')",
                    this.conexao
                );

                sql.ExecuteNonQuery();
                MessageBox.Show("Disciplina inserida com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao inserir disciplina\n\n" + erro);
            }
        }

        // PREENCHER VETORES
        public void PreencherVetor()
        {
            string query = "SELECT * FROM disciplina";

            codigo = new int[100];
            nomeDisciplina = new string[100];

            for (i = 0; i < 100; i++)
            {
                codigo[i] = 0;
                nomeDisciplina[i] = "";
            }

            MySqlCommand coletar = new MySqlCommand(query, this.conexao);
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            contar = 0;

            while (leitura.Read())
            {
                codigo[i] = Convert.ToInt32(leitura["codigo"]);
                nomeDisciplina[i] = leitura["nomeDisciplina"].ToString();

                i++;
                contar++;
            }

            leitura.Close();
        }

        // CONSULTAR TODAS
        public string ConsultarTudo()
        {
            PreencherVetor();
            msg = "";

            for (i = 0; i < contar; i++)
            {
                msg += "\nCódigo da Disciplina: " + codigo[i] +
                       "\nNome da Disciplina: " + nomeDisciplina[i] +
                       "\n---------------------------\n";
            }

            return msg;
        }

        // CONSULTAR POR CÓDIGO
        public string ConsultarPorCodigo(int cod)
        {
            PreencherVetor();

            for (i = 0; i < contar; i++)
            {
                if (codigo[i] == cod)
                {
                    return "\nCódigo da Disciplina: " + codigo[i] +
                           "\nNome da Disciplina: " + nomeDisciplina[i];
                }
            }

            return "Disciplina não encontrada.";
        }
    }
}
