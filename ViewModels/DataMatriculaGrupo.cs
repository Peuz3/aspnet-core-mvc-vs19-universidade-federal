using System;
using System.ComponentModel.DataAnnotations;

namespace UniversidadeFederal.ViewModels
{
    public class DataMatriculaGrupo
    {
        [DataType(DataType.Date)]
        public DateTime? DataMatricula { get; set; }

        public int EstudanteContador { get; set; }
    }
}
