using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoNeoIT.Domain
{
    public class Regiao
    {
        public long IdRegiao { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public int IdEstado { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public bool Ativo { get; set; }
    }
}
