using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoNeoIT.Domain
{
    public class FornecedorRegiao
    {
        public long IdFornecedorRegiao { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public long IdFornecedor { get; set; }
        [Required(ErrorMessage = "Campo Obrigatório!")]
        public long IdRegiao { get; set; }
    }
}
