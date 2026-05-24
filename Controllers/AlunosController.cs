using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gerenciamento_alunos_api.Data;
using gerenciamento_alunos_api.Models;
using Microsoft.AspNetCore.Authorization;

namespace gerenciamento_alunos_api.Controllers;
[Authorize] 
[ApiController]
[Route("api/[controller]")]
public class AlunosController : ControllerBase
{
    private readonly EscolaDbContext _db;

    public AlunosController(EscolaDbContext db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> GetAlunos()
    {
        var alunos = await _db.Alunos.ToListAsync();
        return Ok(alunos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAluno(int id)
    {
        var aluno = await _db.Alunos.FindAsync(id);
        if (aluno == null)
        {
            return NotFound();
        }
        return Ok(aluno);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAluno(Aluno aluno)
    {
        _db.Alunos.Add(aluno);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAluno), new { id = aluno.Id }, aluno);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAluno(int id, Aluno aluno)
    {
        if (id != aluno.Id)
        {
            return BadRequest();
        }

        _db.Entry(aluno).State = EntityState.Modified;

        try
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_db.Alunos.Any(e => e.Id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAluno(int id)
    {
        var aluno = await _db.Alunos.FindAsync(id);
        if (aluno == null)
        {
            return NotFound();
        }

        _db.Alunos.Remove(aluno);
        await _db.SaveChangesAsync();

        return NoContent();
    }

}
