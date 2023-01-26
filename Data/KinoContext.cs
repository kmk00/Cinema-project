using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kino.Models;

namespace Kino.Data
{
    public class KinoContext : DbContext
    {
        public KinoContext (DbContextOptions<KinoContext> options)
            : base(options)
        {
        }

        //public DbSet<Kino.Models.Rezerwacje> Rezerwacje { get; set; } = default!;
        public DbSet<Rezyserzy> Rezyserzy { get; set; }
        public DbSet<Gatunki> Gatunki { get; set; }
        public DbSet<Filmy> Filmy { get; set; }
        public DbSet<Seanse> Seanse{ get; set; }
        public DbSet<Kina> Kina { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rezyserzy>().ToTable("Rezyserzy");
            modelBuilder.Entity<Gatunki>().ToTable("Gatunki");
            modelBuilder.Entity<Filmy>().ToTable("Filmy");
            modelBuilder.Entity<Seanse>().ToTable("Seanse");
            modelBuilder.Entity<Kina>().ToTable("Kina");
        }




    }
}
