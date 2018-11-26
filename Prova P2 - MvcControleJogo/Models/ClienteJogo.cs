using System;
using System.ComponentModel.DataAnnotations;

namespace MvcControleJogo.Models{

    public class ClienteJogo {
        [Key]
        public int ID{get; set;}
        public Cliente NomeClienteFK{get; set;}
        public Jogos NomeJogoFK{get; set;}
    }
}