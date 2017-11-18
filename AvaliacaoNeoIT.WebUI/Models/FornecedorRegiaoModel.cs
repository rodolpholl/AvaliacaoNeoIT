using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvaliacaoNeoIT.WebUI.Models
{
    public class FornecedorRegiaoModel
    {
        public bool Selecionado { get; set; }
        public RegiaoModel Regiao { get; set; }
        public string Uf { get; set; }
    }
}