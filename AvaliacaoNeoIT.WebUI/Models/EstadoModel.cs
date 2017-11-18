using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AvaliacaoNeoIT.WebUI.Models
{
    public class EstadoModel
    {
        public int IdEstado { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        [StringLength(50,ErrorMessage = "Este campo deve conter 50 caractéres no máximo")]
        [Display(Name = "UF")]
        public string Descricao { get; set; }
    }
}