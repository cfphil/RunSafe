using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RunSafe.Models;
using Microsoft.EntityFrameworkCore;

namespace RunSafe.Data
{
    public class AssetContext : DbContext
    {
        public AssetContext(DbContextOptions<AssetContext> options) : base(options)
        {

        }
        
        public DbSet<Person> Person { get; set; }
        public DbSet<Relation> Relation { get; set; }
        public DbSet<Ping> Ping { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configure the pks etc on the tables
            modelBuilder.Entity<Person>()
                .HasKey(P => new { P.Person_ID });
            modelBuilder.Entity<Person>()
                .Property(P => P.Person_ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Ping>()
                .HasKey(P => new { P.Ping_ID });
            modelBuilder.Entity<Ping>()
                .Property(P => P.Ping_ID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Relation>()
                .HasKey(R => new { R.Relation_ID });
            modelBuilder.Entity<Relation>()
                .Property(R => R.Relation_ID)
                .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Ping>().ToTable("Ping");
            modelBuilder.Entity<Relation>().ToTable("Relation");
        }
    }
}
