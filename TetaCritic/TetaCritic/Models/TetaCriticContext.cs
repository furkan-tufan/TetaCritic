using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TetaCritic.Models
{
    public class TetaCriticContext:DbContext
    {
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Film> Filmler { get; set; }
        public TetaCriticContext(DbContextOptions<TetaCriticContext> options) : base(options) {


        }

    }
}
