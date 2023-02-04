


using System.Collections.Generic;
using System.Threading.Tasks;
using CRUDAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly Contexto _contexto;

        public PessoasController(Contexto contexto)
        {
            _contexto = contexto;
        }

        // GET: api/Pessoas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetAllAsync()
        {
            return await _contexto.Pessoas.ToListAsync();
        }

        // GET: api/Pessoas/5
        [HttpGet("{pessoaId}")]
        public async Task<ActionResult<Pessoa>> GetPessoaIdAsync(int pessoaId)
        {
            Pessoa pessoa = await _contexto.Pessoas.FindAsync(pessoaId);

            if (pessoa == null)
            {
                return NotFound();
            }

            return pessoa;
        }

       //Metodo para salvar pessoas
       [HttpPost]
        public async Task<ActionResult<Pessoa>> SaveAsync(Pessoa pessoa)
        {
           await _contexto.Pessoas.AddAsync(pessoa);
            await _contexto.SaveChangesAsync();

            return Ok();
        }

         [HttpPut]
        public async Task<IActionResult> PutPessoaAsync( Pessoa pessoa)
        {
           _contexto.Pessoas.Update(pessoa);
            await _contexto.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Pessoas/5
        [HttpDelete("{pessoaId}")]
        public async Task<IActionResult> DeletePessoa(int pessoaId)
        {
            Pessoa pessoa = await _contexto.Pessoas.FindAsync(pessoaId);
            if(pessoa == null)
                return NotFound();
            
            _contexto.Pessoas.Remove(pessoa);
            await _contexto.SaveChangesAsync();

            return Ok();
        }
       
        
    }
}