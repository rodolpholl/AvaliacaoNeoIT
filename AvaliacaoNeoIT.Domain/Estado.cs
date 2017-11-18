using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoNeoIT.Domain
{
    public class Estado
    {
        public int IdEstado { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public string Descricao { get; set; }
    }
}
