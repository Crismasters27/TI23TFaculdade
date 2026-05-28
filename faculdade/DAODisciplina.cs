using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; // importando os comandos de conexão com o banco
using System.Windows.Forms;  // importando a estrutura de telas

namespace faculdade
{
    class DAODisciplina
    {
        // conexão
        public MySqlConnection conexao; // variável de conexão
        public string dados;            // guardar dados
        public string comando;          // guardar comando sql

        // vetores
        public int[] codigoDisciplina;
        public string[] nomeDisciplina;
        public int[] codigoCurso;
        public int[] codigoProfessor;

        // instância
        public int i;
        public int contar;
        public string msg;

        // construtor
        public DAODisciplina()
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
        public void Inserir(string nomeDisciplina, int codigoCurso, int codigoProfessor)
        {
            try
            {
                this.dados = $"('','{nomeDisciplina}','{codigoCurso}','{codigoProfessor}')";
                this.comando = $"insert into disciplina(codigoDisciplina, nomeDisciplina, codigoCurso, codigoProfessor) values{this.dados}";
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
            string query = "select * from disciplina"; // buscar tudo da tabela

            // instanciar vetores
            this.codigoDisciplina = new int[100];
            this.nomeDisciplina = new string[100];
            this.codigoCurso = new int[100];
            this.codigoProfessor = new int[100];

            // preencher vetores com valores padrões
            for (i = 0; i < 100; i++)
            {
                this.codigoDisciplina[i] = 0;
                this.nomeDisciplina[i] = "";
                this.codigoCurso[i] = 0;
                this.codigoProfessor[i] = 0;
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
                this.codigoDisciplina[i] = Convert.ToInt32(leitura["codigoDisciplina"]);
                this.nomeDisciplina[i] = leitura["nomeDisciplina"] + "";
                this.codigoCurso[i] = Convert.ToInt32(leitura["codigoCurso"]);
                this.codigoProfessor[i] = Convert.ToInt32(leitura["codigoProfessor"]);
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
                this.msg += $"\nCódigo:          {this.codigoDisciplina[i]} " +
                            $"\nNome:            {this.nomeDisciplina[i]} " +
                            $"\nCódigo Curso:    {this.codigoCurso[i]}" +
                            $"\nCódigo Professor:{this.codigoProfessor[i]}\n\n";
            }
            return this.msg;
        }// fim do consultar tudo

        // consultar por código
        public string ConsultarPorCodigo(int codigoDisciplina)
        {
            PreencherVetor();
            this.msg = "";
            for (i = 0; i < this.contar; i++)
            {
                if (this.codigoDisciplina[i] == codigoDisciplina)
                {
                    this.msg = $"\nCódigo:          {this.codigoDisciplina[i]} " +
                               $"\nNome:            {this.nomeDisciplina[i]} " +
                               $"\nCódigo Curso:    {this.codigoCurso[i]}" +
                               $"\nCódigo Professor:{this.codigoProfessor[i]}\n\n";
                    return this.msg;
                }// fim do if
            }// fim do for
            return "Código informado não existe!";
        }// fim do consultar por código

        // consultar nome disciplina
        public string ConsultarNomeDisciplina(int codigoDisciplina)
        {
            PreencherVetor();
            for (i = 0; i < this.contar; i++)
            {
                if (this.codigoDisciplina[i] == codigoDisciplina)
                {
                    return this.nomeDisciplina[i];
                }// fim do if
            }// fim do for
            return "Código informado não existe!";
        }// fim consultar nome disciplina

        // consultar código curso
        public int ConsultarCodigoCurso(int codigoDisciplina)
        {
            PreencherVetor();
            for (i = 0; i < this.contar; i++)
            {
                if (this.codigoDisciplina[i] == codigoDisciplina)
                {
                    return this.codigoCurso[i];
                }// fim do if
            }// fim do for
            return 0;
        }// fim consultar código curso

        // consultar código professor
        public int ConsultarCodigoProfessor(int codigoDisciplina)
        {
            PreencherVetor();
            for (i = 0; i < this.contar; i++)
            {
                if (this.codigoDisciplina[i] == codigoDisciplina)
                {
                    return this.codigoProfessor[i];
                }// fim do if
            }// fim do for
            return 0;
        }// fim consultar código professor

        // atualizar
        public string Atualizar(int codigoDisciplina, string campo, string novoDado)
        {
            try
            {
                string query = $"update disciplina set {campo} = '{novoDado}' where codigoDisciplina = '{codigoDisciplina}'";
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
        public string Deletar(int codigoDisciplina)
        {
            try
            {
                string query = $"delete from disciplina where codigoDisciplina = '{codigoDisciplina}'";
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