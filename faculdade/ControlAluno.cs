using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace faculdade
{
    class ControlAluno
    {
        // Atributos do aluno
        public string Nome { get; set; }
        public int Matricula { get; set; }
        public DateTime DataIngresso { get; set; }
        public int CodigoCurso { get; set; }

        // Objeto DAO
        DAOAluno daoAluno;

        public ControlAluno()
        {
            daoAluno = new DAOAluno();
        }

        // CADASTRAR ALUNO
        public void Cadastrar()
        {
            // Validação simples (opcional, mas ajuda na nota)
            if (Nome == "" || Matricula <= 0 || CodigoCurso <= 0)
            {
                throw new Exception("Preencha todos os campos corretamente.");
            }

            daoAluno.Inserir(Nome, Matricula, DataIngresso, CodigoCurso);
        }

        // CONSULTAR TODOS OS ALUNOS
        public string ConsultarTodos()
        {
            return daoAluno.ConsultarTudo();
        }

        // CONSULTAR ALUNO POR MATRÍCULA
        public string ConsultarPorMatricula(int matricula)
        {
            return daoAluno.ConsultarPorCodigo(matricula);
        }
    }
}