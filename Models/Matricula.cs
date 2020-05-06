using System;
using System.Collections.Generic;
using UniversidadeFederal.Models.Enums;

namespace UniversidadeFederal.Models
{
    public class Matricula
    {
        public int MatriculaID { get; set; }
        public int CursoID { get; set; }
        public int EstudanteID { get; set; }
        public Nota? Nota { get; set; }
        public Curso Curso { get; set; }
        public Estudante Estudante { get; set; }

        public Matricula()
        {
        }

        public Matricula(int matriculaID, int cursoID, int estudandteID, Nota? nota, Curso curso, Estudante estudante)
        {
            MatriculaID = matriculaID;
            CursoID = cursoID;
            EstudanteID = estudandteID;
            Nota = nota;
            Curso = curso;
            Estudante = estudante;
        }
    }
}
