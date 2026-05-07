using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace faculdade
{
    class ControlCurso
    {
        // Atributos do curso
        public string TituloCurso { get; set; }
        public string Descricao { get; set; }
        public string Curriculo { get; set; }
        public string Tipo { get; set; }
        public int Duracao { get; set; }

        // Objeto DAO
        DAOCurso daoCurso;

        public ControlCurso()
        {
            daoCurso = new DAOCurso();
        }

        // CADASTRAR CURSO
        public void Cadastrar()
        {
            // Validação simples
            if (TituloCurso == "" || Tipo == "" || Duracao <= 0)
            {
                throw new Exception("Preencha todos os campos obrigatórios.");
            }

            daoCurso.Inserir(TituloCurso, Descricao, Curriculo, Tipo, Duracao);
        }

        // CONSULTAR TODOS OS CURSOS
        public string ConsultarTodos()
        {
            return daoCurso.ConsultarTudo();
        }

        // CONSULTAR CURSO POR CÓDIGO
        public string ConsultarPorCodigo(int codigo)
        {
            return daoCurso.ConsultarPorCodigo(codigo);
        }
    }
}
