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

        [HttpGet("{id: int}", Name ="ObterCategoria")]
        public ActionResult<Categoria> GetId(int id)
        {
            var categoria = _context.Categoria.Find(id);

            if(id != categoria.CategoriaId)
            {
                return NotFound("Categoria não encontrada.");
            }

            return Ok(categoria);
        }

        [HttpPost]
        public ActionResult NewCategory(Categoria categoria)
        {
            try
            {
                _context.Categoria.Add(categoria);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                if(categoria is null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Houve um problema ao tratar sua solicitação. Entre em contato com o desenvolvedor.");
            }
            return new CreatedAtRouteResult("ObterCategoria", new { id = categoria.CategoriaId }, categoria);
        }

        [HttpPut("{id: int}")]
        public ActionResult UpdateCategory(Categoria categoria, int id)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest("Id não encontrado.");
            }

            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(categoria);
        }

        [HttpDelete("{id: int}")]
        public ActionResult DeleteCategory(int id)
        {
            var categoriaDelete = _context.Categoria.Find(id);

            if(categoriaDelete is null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Categoria não encontrada.");
            }

            _context.Categoria.Remove(categoriaDelete);
            _context.SaveChanges();

            return Ok(categoriaDelete);
        }
    }


}
