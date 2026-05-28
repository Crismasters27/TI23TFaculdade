using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; // importando os comandos de conexão com o banco
using System.Windows.Forms;  // importando a estrutura de telas

namespace faculdade
{
    class DAOProfessor
    {
        // conexão
        public MySqlConnection conexao; // variável de conexão
        public string dados;            // guardar dados
        public string comando;          // guardar comando sql

        // vetores
        public int[] codigoProfessor;
        public string[] nome;
        public string[] titulacao;
        public string[] departamento;
        public int[] cargaHoraria;

        // instância
        public int i;
        public int contar;
        public string msg;

        // construtor
        public DAOProfessor()
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
        public void Inserir(string nome, string titulacao, string departamento, int cargaHoraria)
        {
            try
            {
                this.dados = $"('','{nome}','{titulacao}','{departamento}','{cargaHoraria}')";
                this.comando = $"insert into professor(codigoProfessor, nome, titulacao, departamento, cargaHoraria) values{this.dados}";
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
            string query = "select * from professor"; // buscar tudo da tabela

            // instanciar vetores
            this.codigoProfessor = new int[100];
            this.nome = new string[100];
            this.titulacao = new string[100];
            this.departamento = new string[100];
            this.cargaHoraria = new int[100];

            // preencher vetores com valores padrões
            for (i = 0; i < 100; i++)
            {
                this.codigoProfessor[i] = 0;
                this.nome[i] = "";
                this.titulacao[i] = "";
                this.departamento[i] = "";
                this.cargaHoraria[i] = 0;
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
                this.codigoProfessor[i] = Convert.ToInt32(leitura["codigoProfessor"]);
                this.nome[i] = leitura["nome"] + "";
                this.titulacao[i] = leitura["titulacao"] + "";
                this.departamento[i] = leitura["departamento"] + "";
                this.cargaHoraria[i] = Convert.ToInt32(leitura["cargaHoraria"]);
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
                this.msg += $"\nCódigo:        {this.codigoProfessor[i]} " +
                            $"\nNome:          {this.nome[i]} " +
                            $"\nTitulação:     {this.titulacao[i]}" +
                            $"\nDepartamento:  {this.departamento[i]}" +
                            $"\nCarga Horária: {this.cargaHoraria[i]}\n\n";
            }
            return this.msg;
        }// fim do consultar tudo

        // consultar por código
        public string ConsultarPorCodigo(int codigoProfessor)
        {
            PreencherVetor();
            this.msg = "";
            for (i = 0; i < this.contar; i++)
            {
                if (this.codigoProfessor[i] == codigoProfessor)
                {
                    this.msg = $"\nCódigo:        {this.codigoProfessor[i]} " +
                               $"\nNome:          {this.nome[i]} " +
                               $"\nTitulação:     {this.titulacao[i]}" +
                               $"\nDepartamento:  {this.departamento[i]}" +
                               $"\nCarga Horária: {this.cargaHoraria[i]}\n\n";
                    return this.msg;
                }// fim do if
            }// fim do for
            return "Código informado não existe!";
        }// fim do consultar por código

        // consultar nome
        public string ConsultarNome(int codigoProfessor)
        {
            PreencherVetor();
            for (i = 0; i < this.contar; i++)
            {
                if (this.codigoProfessor[i] == codigoProfessor)
                {
                    return this.nome[i];
                }// fim do if
            }// fim do for
            return "Código informado não existe!";
        }// fim consultar nome

        // consultar titulação
        public string ConsultarTitulacao(int codigoProfessor)
        {
            PreencherVetor();
            for (i = 0; i < this.contar; i++)
            {
                if (this.codigoProfessor[i] == codigoProfessor)
                {
                    return this.titulacao[i];
                }// fim do if
            }// fim do for
            return "Código informado não existe!";
        }// fim consultar titulação

        // consultar departamento
        public string ConsultarDepartamento(int codigoProfessor)
        {
            PreencherVetor();
            for (i = 0; i < this.contar; i++)
            {
                if (this.codigoProfessor[i] == codigoProfessor)
                {
                    return this.departamento[i];
                }// fim do if
            }// fim do for
            return "Código informado não existe!";
        }// fim consultar departamento

        // consultar carga horária
        public int ConsultarCargaHoraria(int codigoProfessor)
        {
            PreencherVetor();
            for (i = 0; i < this.contar; i++)
            {
                if (this.codigoProfessor[i] == codigoProfessor)
                {
                    return this.cargaHoraria[i];
                }// fim do if
            }// fim do for
            return 0;
        }// fim consultar carga horária

        // atualizar
        public string Atualizar(int codigoProfessor, string campo, string novoDado)
        {
            try
            {
                string query = $"update professor set {campo} = '{novoDado}' where codigoProfessor = '{codigoProfessor}'";
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
        public string Deletar(int codigoProfessor)
        {
            try
            {
                string query = $"delete from professor where codigoProfessor = '{codigoProfessor}'";
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