using ApiReceitas.ApiReceitas.Domain;
using MediatR;

namespace ApiReceitas.ApiReceitas.Application.Queries
{
    public class UpdateIngredienteCommand : IRequest<Ingrediente>
    {
        public int? Id { get; set; }
        public string NomeIngrediente { get; set; }
    }
}
