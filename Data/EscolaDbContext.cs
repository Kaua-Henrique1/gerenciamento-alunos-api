using Microsoft.EntityFrameworkCore;
using gerenciamento_alunos_api.Models;

namespace gerenciamento_alunos_api.Data;

public class EscolaDbContext : DbContext
{
    public EscolaDbContext(DbContextOptions<EscolaDbContext> options) : base(options)
    {
    }

    public DbSet<Aluno> Alunos { get; set; } = null!;
}
