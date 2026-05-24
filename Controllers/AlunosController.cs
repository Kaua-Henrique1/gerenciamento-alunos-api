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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Aluno>>> Get() =>
        await _db.Alunos.ToListAsync();

    [HttpGet("/alunos/{id}")]
    public async Task<ActionResult<Aluno>> Get(int id)
    {
        var aluno = await _db.Alunos.FindAsync(id);
        if (aluno == null) return NotFound();
        return aluno;
    }

    [HttpPost]
    public async Task<ActionResult<Aluno>> Post(Aluno aluno)
    {
        _db.Alunos.Add(aluno);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = aluno.Id }, aluno);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Aluno aluno)
    {
        if (id != aluno.Id) return BadRequest();
        _db.Entry(aluno).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var aluno = await _db.Alunos.FindAsync(id);
        if (aluno == null) return NotFound();
        _db.Alunos.Remove(aluno);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
