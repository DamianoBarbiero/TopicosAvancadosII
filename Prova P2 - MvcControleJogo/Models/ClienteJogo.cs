using System;

namespace MvcControleJogo.Models{

    public class ClienteJogo {
        public int ID{get; set;}
        public Cliente NomeClienteFK{get; set;}
        public Jogos NomeJogoFK{get; set;}
    }
}