using System;
using System.ComponentModel.DataAnnotations;

namespace MvcControleJogo.Models{

    public class Plataforma {
        [Key]
        public int ID{get; set;}
        public string NomePlataforma{get; set;}
        public string DescricaoPlataforma{get; set;}
    }
}