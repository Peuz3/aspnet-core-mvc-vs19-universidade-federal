﻿using System;
using System.Collections.Generic;

namespace UniversidadeFederal.Models
{
    public class Estudante
    {
        public int EstudanteID { get; set; }
        public string SobreNome { get; set; }
        public string Nome { get; set; }
        public DateTime DataMatricula { get; set; }

        public ICollection<Matricula> Matriculas { get; set; }

    }
        
}
