using MySql.Data.MySqlClient;//Importando os comandos de conexão com o banco
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;//Importando a estrutura de telas

namespace faculdade
{
    class DAOCurso
    {
        public MySqlConnection conexao;

        public int[] codigoCurso;
        public string[] tituloCurso;
        public string[] descricao;
        public string[] curriculo;
        public string[] tipo;
        public int[] duracao;

        public int i;
        public int contar;
        public string msg;

        public DAOCurso()
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
        public void Inserir(string tituloCurso, string descricao, string curriculo, string tipo, int duracao)
        {
            try
            {
                MySqlCommand sql = new MySqlCommand(
                    "INSERT INTO curso (titulocurso, descricao, curriculo, tipo, duracao) VALUES (" +
                    "'" + tituloCurso + "','" +
                    descricao + "','" +
                    curriculo + "','" +
                    tipo + "','" +
                    duracao + "')",
                    this.conexao
                );

                sql.ExecuteNonQuery();
                MessageBox.Show("Curso inserido com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao inserir curso\n\n" + erro);
            }
        }

        // PREENCHER VETORES
        public void PreencherVetor()
        {
            string query = "SELECT * FROM curso";

            codigoCurso = new int[100];
            tituloCurso = new string[100];
            descricao = new string[100];
            curriculo = new string[100];
            tipo = new string[100];
            duracao = new int[100];

            for (i = 0; i < 100; i++)
            {
                codigoCurso[i] = 0;
                tituloCurso[i] = "";
                descricao[i] = "";
                curriculo[i] = "";
                tipo[i] = "";
                duracao[i] = 0;
            }

            MySqlCommand coletar = new MySqlCommand(query, this.conexao);
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            contar = 0;

            while (leitura.Read())
            {
                codigoCurso[i] = Convert.ToInt32(leitura["codigocurso"]);
                tituloCurso[i] = leitura["titulocurso"].ToString();
                descricao[i] = leitura["descricao"].ToString();
                curriculo[i] = leitura["curriculo"].ToString();
                tipo[i] = leitura["tipo"].ToString();
                duracao[i] = Convert.ToInt32(leitura["duracao"]);

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
                msg += "\nCódigo do Curso: " + codigoCurso[i] +
                       "\nTítulo: " + tituloCurso[i] +
                       "\nDescrição: " + descricao[i] +
                       "\nCurrículo: " + curriculo[i] +
                       "\nTipo: " + tipo[i] +
                       "\nDuração: " + duracao[i] + " semestres" +
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
                if (codigoCurso[i] == codigo)
                {
                    return "\nCódigo do Curso: " + codigoCurso[i] +
                           "\nTítulo: " + tituloCurso[i] +
                           "\nDescrição: " + descricao[i] +
                           "\nCurrículo: " + curriculo[i] +
                           "\nTipo: " + tipo[i] +
                           "\nDuração: " + duracao[i] + " semestres";
                }
            }

            return "Curso não encontrado.";
        }
    }
}