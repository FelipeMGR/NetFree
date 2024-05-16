using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APICatalogo.Entities;
using APICatalogo.Context;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext _context;


        public CategoriaController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("produto")]
        public ActionResult<IEnumerable<Categoria>> GetAll()
        {
            var prod = _context.Categoria.Include(p => p.Produtos).AsNoTracking().Take(4);

            if (prod is null)
            {
                return NotFound("Categoria não encontrada.");
            }
            return Ok(prod);
        }

        [HttpGet] 
        public ActionResult<List<Categoria>> Get()
        {
            var categoria = _context.Categoria.ToList();

            if(categoria is null)
            {
                return NotFound("Categoria não encontra. Verifique a digitação e tente novamente.");
            }

            return categoria;
        }

        [HttpGet("{id: int}")]
        public ActionResult<Categoria> GetId(int id)
        {
            var categoria = _context.Categoria.Find(id);

            if(id != categoria.CategoriaId)
            {
                return NotFound("Categoria não encontrada.");
            }

            return Ok(categoria);
        }
    }


}
