using System;
using System.Collections.Generic;

namespace gerenciamento_alunos_api.Models;

public partial class Aluno
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Curso { get; set; } = null!;

    public DateOnly DataNascimento { get; set; }
}
