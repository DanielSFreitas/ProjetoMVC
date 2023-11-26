using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMVC.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; } 
        public string Editora { get; set; } 
        public bool Reservado { get; set; }
        public  Genero Genero { get; set; }
    }

    
}