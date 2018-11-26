using System;
using System.ComponentModel.DataAnnotations;

namespace MvcControleJogo.Models{
    public class Cliente {
        [Key]
        public int ID{get; set;}
        public string NomeCliente{get; set;}
        public string Rg{get; set;}
        public string Cpf{get; set;}
        public string Celular{get; set;}
        public string AnoNasc{get; set;}
    }
}