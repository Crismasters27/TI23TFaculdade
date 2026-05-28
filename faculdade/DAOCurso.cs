using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;// Importando os comandos de conexão com o banco
using System.Windows.Forms;// Importando a estrutura de telas

namespace faculdade
{
    class DAOCurso
    {

        // conexão

        public MySqlConnection conexao;// variável de conexão
        public string dados;// guardar dados
        public string comando;// guardar comando sql
        
        // vetores

        public int[] codigoCurso;
        public string[] titulo;
        public string[] descricao;
        public string[] curriculo;
        public string[] tipo;
        public int[] duracao;

        // instância

        public int i;
        public int contar;
        public string msg;

        // construtor

        public DAOCurso()
        {

            // conexão com o banco de dados
            this.conexao = new MySqlConnection("server=localhost;DataBase=faculdade;Uid=root;Password=;Convert Zero DateTime=True");
            try
            {
                this.conexao.Open();// abrir a conexão
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado!\n\n {erro}");
                this.conexao.Close();// fechar a conexão com o BD
            }// fim do try_catch
        }// fim do construtor

        // inserir os dados

        public void Inserir(string titulo, string descricao, string curriculo, string tipo, int duracao)
        {
            try
            {
                this.dados = $"('','{titulo}','{descricao}','{curriculo}','{tipo}','{duracao}')";
                this.comando = $"insert into curso(codigoCurso, titulo, descricao, curriculo, tipo, duracao)  values{this.dados}";// comando sql
                MySqlCommand sql = new MySqlCommand(this.comando, this.conexao);// executar sql
                string resultado = "" + sql.ExecuteNonQuery();// executar no banco
                MessageBox.Show($"Inserido com sucesso! \n\n{resultado}");// mensagem
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Algo deu errado\n\n {erro}");
            }// fim do catch
        }// fim do método

        //Preencher Vetor --> Coletar os dados do banco e preenhcer o vetor

        public void PreencherVetor()
        {
            string query = "select * from curso";// buscar tudo da tabela
            // instanciar vetores
            this.codigoCurso = new int[100];
            this.titulo = new string[100];
            this.descricao = new string[100];
            this.curriculo = new string[100];
            this.tipo = new string[100];
            this.duracao = new int[100];

            // preencher vetores com valores padrões
            for (i = 0; i < 100; i++)
            {
                this.codigoCurso[i] = 0;
                this.titulo[i] = "";
                this.descricao[i] = "";
                this.curriculo[i] = "";
                this.tipo[i] = "";
                this.duracao[i] = 0;
            }// fim do for

            // executar o comando do SQL
            MySqlCommand coletar = new MySqlCommand(query, this.conexao);

            // leitura do dado do banco
            MySqlDataReader leitura = coletar.ExecuteReader();

            // zerar contador
            i = 0;
            this.contar = 0;

            // preencher vetores
            while (leitura.Read())
            {
                this.codigoCurso[i] = Convert.ToInt32(leitura["codigoCurso"]);
                this.titulo[i] = leitura["titulo"] + "";
                this.descricao[i] = leitura["descricao"] + "";
                this.curriculo[i] = leitura["curriculo"] + "";
                this.tipo[i] = leitura["tipo"] + "";
                this.duracao[i] = Convert.ToInt32(leitura["duracao"]);
                i++;
                this.contar++;// Informar quantos dados tem no banco
            }// fim do while

            leitura.Close();// fechar leitura
        }// fim preencher vetor

        // consultar tudo

        public string ConsultarTudo()
        {
            PreencherVetor();// preencher todos os dados do vetor
            this.msg = "";
            for (i = 0; i < this.contar; i++)// percorrer vetor
            {
                this.msg += $"\nCódigoCurso:   {this.codigoCurso[i]} " +
                            $"\nTítulo:     {this.titulo[i]} " +
                            $"\nDescrição:   {this.descricao[i]}" +
                            $"\nCurrículo: {this.curriculo[i]}" +
                            $"\nTipo: {this.tipo[i]}" +
                            $"\nDuração: {this.duracao[i]}\n\n";
            }
            return this.msg;
        }// fim do método consultar tudo

        // consultar por código

        public string ConsultarPorCodigo(int codigoCurso)
        {
            PreencherVetor();// preencher todos os dados do vetor
            this.msg = "";
            for (i = 0; i < this.contar; i++)// percorrer vetor
            {
                // comparar código
                if (this.codigoCurso[i] == codigoCurso)
                {
                    this.msg = $"\nCódigoCurso:   {this.codigoCurso[i]} " +
                            $"\nTítulo:     {this.titulo[i]} " +
                            $"\nDescrição:   {this.descricao[i]}" +
                            $"\nCurrículo: {this.curriculo[i]}" +
                            $"\nTipo: {this.tipo[i]}" +
                            $"\nDuração: {this.duracao[i]}\n\n";
                    return this.msg;
                }// fim do if
            }// fim do for
            return "Código informado não existe!";
        }// fim do método consultar por código

        // consultar título

        public string ConsultarTitulo(int codigoCurso)
        {
            PreencherVetor();
            for (i = 0; i < this.contar; i++)
            {
                if (this.codigoCurso[i] == codigoCurso)
                {
                    return this.titulo[i];
                }// fim do if
            }// fim do for
            return "Código informado não existe!";
        }// fim consultar título

        // consultar descrição

        public string ConsultarDescricao(int codigoCurso)
        {
            PreencherVetor();
            for (i = 0; i < this.contar; i++)
            {
                if (this.codigoCurso[i] == codigoCurso)
                {
                    return this.descricao[i];
                }// fim do if
            }// fim do for
            return "Código informado não existe!";
        }// fim consultar descrição

        // consultar currículo

        public string ConsultarCurriculo(int codigoCurso)
        {

            PreencherVetor();
            for (i = 0; i < this.contar; i++)
            {
                if (this.codigoCurso[i] == codigoCurso)
                {
                    return this.curriculo[i];
                }// fim do if
            }// fim do for
            return "Código informado não existe!";
        }// fim consultar currículo

        // consultar tipo

        public string ConsultarTipo(int codigoCurso)
        {
            PreencherVetor();
            for (i = 0; i < this.contar; i++)
            {
                if (this.codigoCurso[i] == codigoCurso)
                {
                    return this.tipo[i];
                }// fim do if
            }// fim do for
            return "Código informado não existe!";
        }// fim consultar tipo

        // consultar duração

        public int ConsultarDuracao(int codigoCurso)
        {
            PreencherVetor();
            for (i = 0; i < this.contar; i++)
            {
                if (this.codigoCurso[i] == codigoCurso)
                {
                    return this.duracao[i];
                }// fim do if
            }// fim do for
            return 0;
        }// fim consultar duração

        // atualizar

        public string Atualizar(int codigoCurso, string campo, string novoDado)
        {
            try
            {
                // comando update
                string query = $"update curso set {campo} = '{novoDado}' where codigoCurso = '{codigoCurso}'";
                // executar o comando
                MySqlCommand sql = new MySqlCommand(query, this.conexao);
                string resultado = "" + sql.ExecuteNonQuery();// comando de inserção no banco
                return $"Atualizado com sucesso\n\n {resultado}";
            }
            catch (Exception erro)
            {
                return $"Algo deu errado\n\n {erro}";
            }
        }// fim atualizar

        // deletar

        public string Deletar(int codigoCurso)
        {
            try
            {
                // comando delete
                string query = $"delete from curso where codigoCurso = '{codigoCurso}'";
                // executar o comando
                MySqlCommand sql = new MySqlCommand(query, this.conexao);
                string resultado = "" + sql.ExecuteNonQuery();// comando de inserção no banco
                return $"Deletado com sucesso\n\n {resultado}";
            }
            catch (Exception erro)
            {
                return $"Algo deu errado\n\n {erro}";
            }

        }// fim do deletar

    }// fim da classe

}// fim do projeto