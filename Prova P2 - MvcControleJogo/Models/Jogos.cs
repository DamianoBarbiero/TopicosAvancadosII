using System;

namespace MvcControleJogo.Models{
    public class Jogos {
        public int ID{get; set;}
        public string NomeJogo{get; set;}
        public Categoria NomeCategoriaFK{get; set;}
        public Plataforma NomePlataformaFK{get; set;}
        public Empresa DesenvolvedorFK{get; set;}
        public string AnoLanc{get; set;}
    }
}