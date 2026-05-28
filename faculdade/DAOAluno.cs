using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; // importando os comandos de conexão com o banco
using System.Windows.Forms;  // importando a estrutura de telas

namespace faculdade
{
    class DAOAluno
    {
        // conexão
        public MySqlConnection conexao; // variável de conexão
        public string dados;            // guardar dados
        public string comando;          // guardar comando sql

        // vetores
        public int[] numeroMatricula;
        public string[] nome;
        public DateTime[] dataIngresso;  // DateTime para armazenar a data
        public int[] codigoCurso;

        // instância
        public int i;
        public int contar;
        public string msg;

        // construtor
        public DAOAluno()
        {
            // conexão com o banco de dados
            this.conexao = new MySqlConnection("server=localhost;DataBase=faculdade;Uid=root;Password=;Convert Zero DateTime=True");
            try
            {
                this.conexao.Open(); // abrir a conexão
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado!\n\n {erro}");
                this.conexao.Close(); // fechar a conexão com o BD
            }// fim do try_catch
        }// fim do construtor

        // inserir os dados
        public void Inserir(string nome, DateTime dataIngresso, int codigoCurso)
        {
            try
            {
                string data = dataIngresso.ToString("yyyy-MM-dd"); // converter para o formato do MySQL
                this.dados = $"('','{nome}','{data}','{codigoCurso}')";
                this.comando = $"insert into aluno(numeroMatricula, nome, dataIngresso, codigoCurso) values{this.dados}";
                MySqlCommand sql = new MySqlCommand(this.comando, this.conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                MessageBox.Show($"Inserido com sucesso!\n\n{resultado}");
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado\n\n {erro}");
            }// fim do catch
        }// fim do método inserir

        // preencher vetor
        public void PreencherVetor()
        {
            string query = "select * from aluno"; // buscar tudo da tabela

            // instanciar vetores
            this.numeroMatricula = new int[100];
            this.nome = new string[100];
            this.dataIngresso = new DateTime[100]; // vetor DateTime
            this.codigoCurso = new int[100];

            // preencher vetores com valores padrões
            for (i = 0; i < 100; i++)
            {
                this.numeroMatricula[i] = 0;
                this.nome[i] = "";
                this.dataIngresso[i] = DateTime.MinValue; // valor padrão para DateTime
                this.codigoCurso[i] = 0;
            }// fim do for

            // executar o comando SQL
            MySqlCommand coletar = new MySqlCommand(query, this.conexao);

            // leitura do dado do banco
            MySqlDataReader leitura = coletar.ExecuteReader();

            // zerar contador
            i = 0;
            this.contar = 0;

            // preencher vetores
            while (leitura.Read())
            {
                this.numeroMatricula[i] = Convert.ToInt32(leitura["numeroMatricula"]);
                this.nome[i] = leitura["nome"] + "";
                this.dataIngresso[i] = Convert.ToDateTime(leitura["dataIngresso"]); // armazena como DateTime
                this.codigoCurso[i] = Convert.ToInt32(leitura["codigoCurso"]);
                i++;
                this.contar++; // informar quantos dados tem no banco
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
                this.msg += $"\nMatrícula:      {this.numeroMatricula[i]} " +
                            $"\nNome:           {this.nome[i]} " +
                            $"\nData Ingresso:  {this.dataIngresso[i].ToString("dd/MM/yyyy")}" + // formata na exibição
                            $"\nCódigo Curso:   {this.codigoCurso[i]}\n\n";
            }
            return this.msg;
        }// fim do consultar tudo

        // consultar por matrícula
        public string ConsultarPorMatricula(int numeroMatricula)
        {
            PreencherVetor();
            this.msg = "";
            for (i = 0; i < this.contar; i++)
            {
                if (this.numeroMatricula[i] == numeroMatricula)
                {
                    this.msg = $"\nMatrícula:      {this.numeroMatricula[i]} " +
                               $"\nNome:           {this.nome[i]} " +
                               $"\nData Ingresso:  {this.dataIngresso[i].ToString("dd/MM/yyyy")}" +
                               $"\nCódigo Curso:   {this.codigoCurso[i]}\n\n";
                    return this.msg;
                }// fim do if
            }// fim do for
            return "Matrícula informada não existe!";
        }// fim do consultar por matrícula

        // consultar nome
        public string ConsultarNome(int numeroMatricula)
        {
            PreencherVetor();
            for (i = 0; i < this.contar; i++)
            {
                if (this.numeroMatricula[i] == numeroMatricula)
                {
                    return this.nome[i];
                }// fim do if
            }// fim do for
            return "Matrícula informada não existe!";
        }// fim consultar nome

        // consultar data ingresso
        public DateTime ConsultarDataIngresso(int numeroMatricula)
        {
            PreencherVetor();
            for (i = 0; i < this.contar; i++)
            {
                if (this.numeroMatricula[i] == numeroMatricula)
                {
                    return this.dataIngresso[i]; // retorna DateTime
                }// fim do if
            }// fim do for
            return DateTime.MinValue; // retorna valor padrão se não encontrar
        }// fim consultar data ingresso

        // consultar código curso
        public int ConsultarCodigoCurso(int numeroMatricula)
        {
            PreencherVetor();
            for (i = 0; i < this.contar; i++)
            {
                if (this.numeroMatricula[i] == numeroMatricula)
                {
                    return this.codigoCurso[i];
                }// fim do if
            }// fim do for
            return 0;
        }// fim consultar código curso

        // atualizar
        public string Atualizar(int numeroMatricula, string campo, string novoDado)
        {
            try
            {
                string query = $"update aluno set {campo} = '{novoDado}' where numeroMatricula = '{numeroMatricula}'";
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
        public string Deletar(int numeroMatricula)
        {
            try
            {
                string query = $"delete from aluno where numeroMatricula = '{numeroMatricula}'";
                MySqlCommand sql = new MySqlCommand(query, this.conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                return $"Deletado com sucesso\n\n {resultado}";
            }
            catch (Exception erro)
            {
                return $"Algo deu errado\n\n {erro}";
            }
        }// fim do deletar

    }// fim da classe
}// fim do projeto