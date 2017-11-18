using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvaliacaoNeoIT.WebUI.Models
{
    public class FornecedorModel
    {
        public long IdFornecedor { get; set; }
        public string CNPJ { get; set; }
        public string Nome { get; set; }
    }
}