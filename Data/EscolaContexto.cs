using Microsoft.EntityFrameworkCore;
using UniversidadeFederal.Models;
using System;
using System.Collections.Generic;

namespace UniversidadeFederal.Data
{
    //Este código cria uma propriedade DbSet para cada conjunto de entidades
    public class EscolaContexto : DbContext
    {
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Estudante> Estudantes { get; set; }

        public EscolaContexto(DbContextOptions<EscolaContexto> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>().ToTable("Curso");
            modelBuilder.Entity<Matricula>().ToTable("Matricula");
            modelBuilder.Entity<Estudante>().ToTable("Estudante");
        }
    }
}
