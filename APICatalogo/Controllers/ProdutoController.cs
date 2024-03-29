using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APICatalogo.Entities;
using APICatalogo.Context;

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

        [HttpGet("{id:int}", Name="ObterProduto")]
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
        public ActionResult Post(Produto produto)
        {
            _context.Produto.Add(produto);
            _context.SaveChanges();

            if(produto is null)
            {
                return BadRequest("Requisição inválida!");
            }
            return new CreatedAtRouteResult("ObterProduto", new {id = produto.Id}, produto);
        }
    }


}
