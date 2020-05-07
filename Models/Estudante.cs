using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //Para fazer formatações nos dados

namespace UniversidadeFederal.Models
{
    public class Estudante
    {
        public int EstudanteID { get; set; }
        //Limita até 50 caractres
        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(50)]
        [Display(Name = "Último Nome")]
        public string SobreNome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} deve ser entre {2} e {1}")]
        [Display(Name = "Primeiro Nome")]
        public string Nome { get; set; }

        [Display(Name = "Data da Matrícula")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataMatricula { get; set; }

        [Display(Name = "Nome Completo")]
        public string NomeCompleto
        {
            get { return SobreNome + ", " + Nome; }
        }

        public ICollection<Matricula> Matriculas { get; set; }

    }

}
