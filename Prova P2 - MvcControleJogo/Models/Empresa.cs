using System;
using System.ComponentModel.DataAnnotations;

namespace MvcControleJogo.Models{

    public class Empresa {
        [Key]
        public int ID{get; set;}
        public string NomeEmpresa{get; set;}
        public string Fundacao{get; set;}
        public string Cnpj{get; set;}
    }
}