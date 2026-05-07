using MySql.Data.MySqlClient;//Importando os comandos de conexão com o banco
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;//Importando a estrutura de telas

namespace faculdade
{
    class DAOProva
    {
        public MySqlConnection conexao;

        public int[] codigoProva;
        public decimal[] nota;
        public DateTime[] dataProva;
        public string[] observacao;
        public int[] codigoDisciplina;

        public int i;
        public int contar;
        public string msg;

        public DAOProva()
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
        public void Inserir(decimal nota, DateTime dataProva, string observacao, int codigoDisciplina)
        {
            try
            {
                MySqlCommand sql = new MySqlCommand(
                    "INSERT INTO prova (nota, datas, observacao, disciplina_codigo) VALUES (" +
                    "'" + nota.ToString().Replace(",", ".") + "','" +
                    dataProva.ToString("yyyy-MM-dd") + "','" +
                    observacao + "','" +
                    codigoDisciplina + "')",
                    this.conexao
                );

                sql.ExecuteNonQuery();
                MessageBox.Show("Prova inserida com sucesso!");
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao inserir prova\n\n" + erro);
            }
        }

        // PREENCHER VETORES
        public void PreencherVetor()
        {
            string query = "SELECT * FROM prova";

            codigoProva = new int[100];
            nota = new decimal[100];
            dataProva = new DateTime[100];
            observacao = new string[100];
            codigoDisciplina = new int[100];

            for (i = 0; i < 100; i++)
            {
                codigoProva[i] = 0;
                nota[i] = 0;
                dataProva[i] = DateTime.MinValue;
                observacao[i] = "";
                codigoDisciplina[i] = 0;
            }

            MySqlCommand coletar = new MySqlCommand(query, this.conexao);
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            contar = 0;

            while (leitura.Read())
            {
                codigoProva[i] = Convert.ToInt32(leitura["codigoProva"]);
                nota[i] = Convert.ToDecimal(leitura["nota"]);
                dataProva[i] = Convert.ToDateTime(leitura["datas"]);
                observacao[i] = leitura["observacao"].ToString();
                codigoDisciplina[i] = Convert.ToInt32(leitura["disciplina_codigo"]);

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
                msg += "\nCódigo da Prova: " + codigoProva[i] +
                       "\nNota: " + nota[i] +
                       "\nData: " + dataProva[i].ToString("dd/MM/yyyy") +
                       "\nObservação: " + observacao[i] +
                       "\nCódigo da Disciplina: " + codigoDisciplina[i] +
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
                if (codigoProva[i] == codigo)
                {
                    return "\nCódigo da Prova: " + codigoProva[i] +
                           "\nNota: " + nota[i] +
                           "\nData: " + dataProva[i].ToString("dd/MM/yyyy") +
                           "\nObservação: " + observacao[i] +
                           "\nCódigo da Disciplina: " + codigoDisciplina[i];
                }
            }

            return "Prova não encontrada.";
        }
    }
}
