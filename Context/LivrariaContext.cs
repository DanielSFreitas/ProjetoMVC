using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoMVC.Models;

namespace ProjetoMVC.Context
{
    public class LivrariaContext: DbContext
    {
        public LivrariaContext(DbContextOptions <LivrariaContext> options ) : base(options)
        {

        }
        public DbSet<Livro> Livros{get; set;}
    }
}