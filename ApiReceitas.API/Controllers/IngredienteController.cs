using ApiReceitas.ApiReceitas.Application.Queries.Ingredientes;
using ApiReceitas.ApiReceitas.Application.Queries.Ingredientes.ApiReceitas.ApiReceitas.Application.Queries.Ingredientes;
using ApiReceitas.ApiReceitas.Domain;
using ApiReceitas.ApiReceitas.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiReceitas.ApiReceitas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredienteController : ControllerBase
    {
        private readonly IngredienteRepository _ingredienteRepository;
        private readonly IMediator _mediator;
        AppDbContext _context;

        public IngredienteController(IngredienteRepository ingredienteRepository, 
            IMediator mediator,
            AppDbContext context)
        {
            _ingredienteRepository = ingredienteRepository;
            _mediator = mediator;
            _context = context;
        }

        // GET: api/Ingrediente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingrediente>>> GetIngredientes()
        {
            var query = new GetAllIngredientesQuery();
            var ingredientes = await _mediator.Send(query);

            return Ok(ingredientes);
        }

        // GET: api/Ingrediente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingrediente>> GetIngrediente(int id)
        {
            try
            {
                var query = new GetIngredienteByIdQuery(id);
                var ingrediente = await _mediator.Send(query);

                if (ingrediente == null)
                {
                    return NotFound();
                }

                return Ok(ingrediente);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // POST: api/Ingrediente
        [HttpPost]
        public ActionResult<Ingrediente> CreateIngrediente(CreateIngredienteQuery request)
        {
            try
            {
                return Ok(_mediator.Send(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT: api/Ingrediente/5
        [HttpPut("{id}")]
        public IActionResult UpdateIngrediente(int id, Ingrediente updatedIngrediente)
        {
            var ingrediente = _ingredienteRepository.GetById(id);

            if (ingrediente == null)
            {
                return NotFound();
            }

            ingrediente.Nome = updatedIngrediente.Nome;
            // Atualize aqui outras propriedades do ingrediente, se necessário.

            _ingredienteRepository.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Ingrediente/5
        [HttpDelete("{id}")]
        public IActionResult DeleteIngrediente(int id)
        {
            var ingrediente = _ingredienteRepository.GetById(id);

            if (ingrediente == null)
            {
                return NotFound();
            }

            _ingredienteRepository.Remove(ingrediente);
            _ingredienteRepository.SaveChanges();

            return NoContent();
        }
    }
}

