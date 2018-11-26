using System;
using System.ComponentModel.DataAnnotations;

namespace MvcControleJogo.Models{

    public class Categoria {
        [Key]
        public int ID{get; set;}
        public string NomeCategoria{get; set;}
        public string DescricaoCategoria{get; set;}
    }
}