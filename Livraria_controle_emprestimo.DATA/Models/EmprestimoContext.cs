﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Livraria_controle_emprestimo.DATA.Models
{
    public partial class EmprestimoContext : DbContext
    {
        public EmprestimoContext()
        {
        }

        public EmprestimoContext(DbContextOptions<EmprestimoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Livro> Livros { get; set; }
        public virtual DbSet<LivroClienteEmprestimo> LivroClienteEmprestimos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-466P3UV;Initial Catalog=Emprestimo;Integrated Security=True;Encrypt=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LivroClienteEmprestimo>(entity =>
            {
                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.LivroClienteEmprestimos)
                    .HasForeignKey(d => d.Clienteid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Livro_Cliente_Emprestimo_Cliente");

                entity.HasOne(d => d.Livro)
                    .WithMany(p => p.LivroClienteEmprestimos)
                    .HasForeignKey(d => d.Livroid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Livro_Cliente_Emprestimo_Livro");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}