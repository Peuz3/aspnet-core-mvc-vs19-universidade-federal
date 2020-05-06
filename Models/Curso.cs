using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversidadeFederal.Models
{
    public class Curso
    {

        /*faz com que o banco de dados não gere um valor para a propriedade quando linhas 
        forem inseridas ou atualizadas na respectiva tabela. */
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CursoID { get; set; }
        public string Titulo { get; set; }
        public int Creditos { get; set; }
        public ICollection<Matricula> Matriculas { get; set; }

        public Curso()
        {
        }

        public Curso(int cursoID, string titulo, int creditos)
        {
            CursoID = cursoID;
            Titulo = titulo;
            Creditos = creditos;
        }
    }
}
