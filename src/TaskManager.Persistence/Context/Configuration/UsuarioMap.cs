using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Enums;

namespace TaskManager.Persistence.Context.Configuration;

public class UsuarioMap: IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Nome).HasColumnType("varchar").HasMaxLength(180);
        builder.Property(e => e.Email).HasColumnType("varchar").HasMaxLength(120);

        builder.HasMany(e => e.Projetos)
            .WithOne(e => e.Usuario)
            .HasForeignKey(e => e.UsuarioId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(e => e.Comentarios)
            .WithOne(e => e.Usuario)
            .HasForeignKey(e => e.UsuarioId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(e => e.HistoricoTarefas)
            .WithOne(e => e.Usuario)
            .HasForeignKey(e => e.UsuarioId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(e => e.Tarefas)
            .WithOne(e => e.Usuario)
            .HasForeignKey(e => e.UsuarioId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasData(
            new Usuario {Id = 1, Nome = "João Silva", Email = "joao@empresa.com", Funcao = (int)FuncaoUsuario.Colaborador},
            new Usuario
            {
                Id = 2, Nome = "Maria Santos", Email = "maria@empresa.com", Funcao = (int)FuncaoUsuario.Colaborador
            },
            new Usuario
            {
                Id = 3, Nome = "Carlos Lima", Email = "carlos@empresa.com", Funcao = (int)FuncaoUsuario.Colaborador
            },
            new Usuario {Id = 4, Nome = "Ana Souza", Email = "ana@empresa.com", Funcao = (int)FuncaoUsuario.Colaborador},
            new Usuario
            {
                Id = 5, Nome = "Fernanda Torres", Email = "fernanda@empresa.com", Funcao = (int)FuncaoUsuario.Gerente
            });
    }
}