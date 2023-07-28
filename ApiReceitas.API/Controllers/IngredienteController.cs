﻿using ApiReceitas.ApiReceitas.Domain;
using ApiReceitas.ApiReceitas.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiReceitas.ApiReceitas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredienteController : ControllerBase
    {
            private readonly IngredienteRepository _ingredienteRepository;

            public IngredienteController(IngredienteRepository ingredienteRepository)
            {
                _ingredienteRepository = ingredienteRepository;
            }

            // GET: api/Ingrediente
            [HttpGet]
            public ActionResult<IEnumerable<Ingrediente>> GetIngredientes()
            {
                var ingredientes = _ingredienteRepository.GetAll();
                return Ok(ingredientes);
            }

            // GET: api/Ingrediente/5
            [HttpGet("{id}")]
            public ActionResult<Ingrediente> GetIngrediente(int id)
            {
                var ingrediente = _ingredienteRepository.GetById(id);

                if (ingrediente == null)
                {
                    return NotFound();
                }

                return Ok(ingrediente);
            }

            // POST: api/Ingrediente
            [HttpPost]
            public ActionResult<Ingrediente> CreateIngrediente(Ingrediente ingrediente)
            {
                _ingredienteRepository.Add(ingrediente);
                _ingredienteRepository.SaveChanges();

                return CreatedAtAction(nameof(GetIngrediente), new { id = ingrediente.Id }, ingrediente);
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
