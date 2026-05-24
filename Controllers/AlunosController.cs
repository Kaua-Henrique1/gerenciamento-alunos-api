using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gerenciamento_alunos_api.Data;
using gerenciamento_alunos_api.Models;

namespace gerenciamento_alunos_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlunosController : ControllerBase
{
    private readonly EscolaDbContext _db;

    public AlunosController(EscolaDbContext db) => _db = db;

    
}
