using ApiReceitas.ApiReceitas.Domain;
using MediatR;

namespace ApiReceitas.ApiReceitas.Application.Queries.Ingredientes
{
    public class CreateIngredienteQuery : IRequest<Ingrediente>
    {
        public string NomeIngrediente { get; set; }
    }
}