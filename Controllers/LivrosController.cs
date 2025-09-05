using Microsoft.AspNetCore.Mvc;
using Biblioteca.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Biblioteca.Models;

namespace Biblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly MongoDbService _mongoDbService;

        public LivrosController(MongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }

        [HttpGet]
        public async Task<List<Livro>> Get()
        {
            return await _mongoDbService.GetAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> Get(string id)
        {
            var livro = await _mongoDbService.GetAsync(id);

            if (livro is null)
            {
                return NotFound();
            }

            return livro;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Livro newLivro)
        {
            await _mongoDbService.CreateAsync(newLivro);
            return CreatedAtAction(nameof(Get), new { id = newLivro.Id }, newLivro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, Livro updatedLivro)
        {
            var livro = await _mongoDbService.GetAsync(id);

            if (livro is null)
            {
                return NotFound();
            }

            await _mongoDbService.UpdateAsync(id, updatedLivro);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var livro = await _mongoDbService.GetAsync(id);

            if (livro is null)
            {
                return NotFound();
            }

            await _mongoDbService.RemoveAsync(id);

            return NoContent();
        }
    }
}