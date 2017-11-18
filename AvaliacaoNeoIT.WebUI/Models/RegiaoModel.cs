using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AvaliacaoNeoIT.WebUI.Models
{
    public class RegiaoModel
    {
        public long IdRegiao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        public EstadoModel Estado { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        public int IdEstado { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Região")]
        [StringLength(50, ErrorMessage = "Este Campo deve conter 50 caractéres no máximo.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Situação")]
        public string Ativo { get; set; }
    }
}