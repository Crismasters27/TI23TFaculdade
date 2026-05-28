using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; // importando os comandos de conexão com o banco
using System.Windows.Forms;  // importando a estrutura de telas

namespace faculdade
{
    class DAOProva
    {
        // conexão
        public MySqlConnection conexao; // variável de conexão
        public string dados;            // guardar dados
        public string comando;          // guardar comando sql

        // vetores
        public int[] codigoProva;
        public double[] nota;
        public DateTime[] dataRealizacao;
        public string[] observacao;
        public int[] numeroMatricula;
        public int[] codigoDisciplina;
        public int[] codigoProfessor;

        // instância
        public int i;
        public int contar;
        public string msg;

        // construtor
        public DAOProva()
        {
            // conexão com o banco de dados
            this.conexao = new MySqlConnection("server=localhost;DataBase=faculdade;Uid=root;Password=;Convert Zero DateTime=True");

            try
            {
                this.conexao.Open(); // abrir conexão
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado!\n\n {erro}");
                this.conexao.Close(); // fechar conexão
            }// fim do try catch

        }// fim do construtor

        // inserir os dados
        public void Inserir(double nota, DateTime dataRealizacao, string observacao, int numeroMatricula, int codigoDisciplina, int codigoProfessor)
        {
            try
            {
                this.dados = $"('','{nota}','{dataRealizacao:yyyy-MM-dd}','{observacao}','{numeroMatricula}','{codigoDisciplina}','{codigoProfessor}')";
                this.comando = $"insert into prova(codigoProva, nota, dataRealizacao, observacao, numeroMatricula, codigoDisciplina, codigoProfessor) values{this.dados}";

                // executar sql
                MySqlCommand sql = new MySqlCommand(this.comando, this.conexao);

                // executar no banco
                string resultado = "" + sql.ExecuteNonQuery();

                // mensagem
                MessageBox.Show($"Inserido com sucesso!\n\n{resultado}");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado\n\n {erro}");
            }// fim do catch

        }// fim do inserir

        // preencher vetor
        public void PreencherVetor()
        {
            string query = "select * from prova";

            // instanciar vetores
            this.codigoProva = new int[100];
            this.nota = new double[100];
            this.dataRealizacao = new DateTime[100];
            this.observacao = new string[100];
            this.numeroMatricula = new int[100];
            this.codigoDisciplina = new int[100];
            this.codigoProfessor = new int[100];

            // valores padrões
            for (i = 0; i < 100; i++)
            {
                this.codigoProva[i] = 0;
                this.nota[i] = 0;
                this.dataRealizacao[i] = new DateTime();
                this.observacao[i] = "";
                this.numeroMatricula[i] = 0;
                this.codigoDisciplina[i] = 0;
                this.codigoProfessor[i] = 0;
            }// fim do for

            // executar comando sql
            MySqlCommand coletar = new MySqlCommand(query, this.conexao);

            // leitura do banco
            MySqlDataReader leitura = coletar.ExecuteReader();

            // zerar contador
            i = 0;
            this.contar = 0;

            // preencher vetores
            while (leitura.Read())
            {
                this.codigoProva[i] = Convert.ToInt32(leitura["codigoProva"]);
                this.nota[i] = Convert.ToDouble(leitura["nota"]);
                this.dataRealizacao[i] = Convert.ToDateTime(leitura["dataRealizacao"]);
                this.observacao[i] = leitura["observacao"] + "";
                this.numeroMatricula[i] = Convert.ToInt32(leitura["numeroMatricula"]);
                this.codigoDisciplina[i] = Convert.ToInt32(leitura["codigoDisciplina"]);
                this.codigoProfessor[i] = Convert.ToInt32(leitura["codigoProfessor"]);

                i++;
                this.contar++;

            }// fim do while

            leitura.Close(); // fechar leitura

        }// fim preencher vetor

        // consultar tudo
        public string ConsultarTudo()
        {
            PreencherVetor();

            this.msg = "";

            for (i = 0; i < this.contar; i++)
            {
                this.msg += $"\nCódigo Prova:      {this.codigoProva[i]}" +
                            $"\nNota:              {this.nota[i]}" +
                            $"\nData Realização:   {this.dataRealizacao[i].ToShortDateString()}" +
                            $"\nObservação:        {this.observacao[i]}" +
                            $"\nNúmero Matrícula:  {this.numeroMatricula[i]}" +
                            $"\nCódigo Disciplina: {this.codigoDisciplina[i]}" +
                            $"\nCódigo Professor:  {this.codigoProfessor[i]}\n\n";

            }// fim do for

            return this.msg;

        }// fim consultar tudo

        // consultar por código
        public string ConsultarPorCodigo(int codigoProva)
        {
            PreencherVetor();

            this.msg = "";

            for (i = 0; i < this.contar; i++)
            {
                if (this.codigoProva[i] == codigoProva)
                {
                    this.msg = $"\nCódigo Prova:      {this.codigoProva[i]}" +
                               $"\nNota:              {this.nota[i]}" +
                               $"\nData Realização:   {this.dataRealizacao[i].ToShortDateString()}" +
                               $"\nObservação:        {this.observacao[i]}" +
                               $"\nNúmero Matrícula:  {this.numeroMatricula[i]}" +
                               $"\nCódigo Disciplina: {this.codigoDisciplina[i]}" +
                               $"\nCódigo Professor:  {this.codigoProfessor[i]}\n\n";

                    return this.msg;

                }// fim do if

            }// fim do for

            return "Código informado não existe!";

        }// fim consultar por código

        // consultar nota
        public double ConsultarNota(int codigoProva)
        {
            PreencherVetor();

            for (i = 0; i < this.contar; i++)
            {
                if (this.codigoProva[i] == codigoProva)
                {
                    return this.nota[i];

                }// fim do if

            }// fim do for

            return 0;

        }// fim consultar nota

        // consultar data realização
        public DateTime ConsultarDataRealizacao(int codigoProva)
        {
            PreencherVetor();

            for (i = 0; i < this.contar; i++)
            {
                if (this.codigoProva[i] == codigoProva)
                {
                    return this.dataRealizacao[i];

                }// fim do if

            }// fim do for

            return new DateTime();

        }// fim consultar data realização

        // consultar observação
        public string ConsultarObservacao(int codigoProva)
        {
            PreencherVetor();

            for (i = 0; i < this.contar; i++)
            {
                if (this.codigoProva[i] == codigoProva)
                {
                    return this.observacao[i];

                }// fim do if

            }// fim do for

            return "Código informado não existe!";

        }// fim consultar observação

        // consultar matrícula
        public int ConsultarNumeroMatricula(int codigoProva)
        {
            PreencherVetor();

            for (i = 0; i < this.contar; i++)
            {
                if (this.codigoProva[i] == codigoProva)
                {
                    return this.numeroMatricula[i];

                }// fim do if

            }// fim do for

            return 0;

        }// fim consultar matrícula

        // consultar código disciplina
        public int ConsultarCodigoDisciplina(int codigoProva)
        {
            PreencherVetor();

            for (i = 0; i < this.contar; i++)
            {
                if (this.codigoProva[i] == codigoProva)
                {
                    return this.codigoDisciplina[i];

                }// fim do if

            }// fim do for

            return 0;

        }// fim consultar código disciplina

        // consultar código professor
        public int ConsultarCodigoProfessor(int codigoProva)
        {
            PreencherVetor();

            for (i = 0; i < this.contar; i++)
            {
                if (this.codigoProva[i] == codigoProva)
                {
                    return this.codigoProfessor[i];

                }// fim do if

            }// fim do for

            return 0;

        }// fim consultar código professor

        // atualizar
        public string Atualizar(int codigoProva, string campo, string novoDado)
        {
            try
            {
                string query = $"update prova set {campo} = '{novoDado}' where codigoProva = '{codigoProva}'";

                // executar comando
                MySqlCommand sql = new MySqlCommand(query, this.conexao);

                string resultado = "" + sql.ExecuteNonQuery();

                return $"Atualizado com sucesso\n\n {resultado}";

            }
            catch (Exception erro)
            {
                return $"Algo deu errado\n\n {erro}";
            }

        }// fim atualizar

        // deletar
        public string Deletar(int codigoProva)
        {
            try
            {
                string query = $"delete from prova where codigoProva = '{codigoProva}'";

                // executar comando
                MySqlCommand sql = new MySqlCommand(query, this.conexao);

                string resultado = "" + sql.ExecuteNonQuery();

                return $"Deletado com sucesso\n\n {resultado}";

            }
            catch (Exception erro)
            {
                return $"Algo deu errado\n\n {erro}";
            }

        }// fim deletar

    }// fim da classe

}// fim do projeto