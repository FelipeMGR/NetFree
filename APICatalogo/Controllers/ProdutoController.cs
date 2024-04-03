using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APICatalogo.Entities;
using APICatalogo.Context;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public ActionResult<IEnumerable<Produto>> Get()
        {
            var produtos = _context.Produto.ToList();
            if (produtos is null)
            {
                return NotFound("Produto não encontrado...");
            }
            return produtos;
        }

        [HttpGet("{id:int}", Name = "ObterProduto")]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _context.Produto.FirstOrDefault(x => x.Id == id);
            if (produto is null)
            {
                return NotFound("Produto não encontrado!");
            }
            return produto;
        }

        [HttpPost]
        public ActionResult Post(Produto produtoPost)
        {
            _context.Produto.Add(produtoPost);
            _context.SaveChanges();

            if (produtoPost is null)
            {
                return BadRequest("Requisição inválida!");
            }
            return new CreatedAtRouteResult("ObterProduto", new { id = produtoPost.Id }, produtoPost);
        }

        [HttpPut("{id: int}")]
        public ActionResult Put(int id, Produto produtoPost)
        {
            if (id != produtoPost.Id)
            {
                return BadRequest("Este id não existe!");
            }

            _context.Entry(produtoPost).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produtoPost);
        }

        [HttpDelete("{id: int}")]
        public ActionResult Delete(int id)
        {
            var produtoDelete = _context.Produto.FirstOrDefault(p => p.Id == id);
            //var produtosDelete = _context.Produto.Find(id); -> Mesmo resultado, mudando apenas o parâmetro utilizado. Com o .Find, utilizamos o argumento usado na chamada do método Delete

            if (produtoDelete is null)
            {
                return BadRequest("Este id não existe!");
            }

            _context.Produto.Remove(produtoDelete);
            _context.SaveChanges();

            return Ok(produtoDelete);
        }
    }


}
