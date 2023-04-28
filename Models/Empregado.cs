using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDEntity.Models
{
    public class Empregado
    {
        [Key]
        public int EmpregadoId { get; set; }
        [Column(TypeName="nvarchar(250)")]
        [Required(ErrorMessage ="Este campo é obrigatório")]
        [DisplayName("Nome Completo")]
        public string NomeCompleto { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public int Matricula { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Cargo { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Cidade { get; set; }


    }
}
