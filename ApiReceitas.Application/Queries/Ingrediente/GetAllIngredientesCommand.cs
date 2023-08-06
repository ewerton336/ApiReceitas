using ApiReceitas.ApiReceitas.Domain;
using MediatR;

namespace ApiReceitas.ApiReceitas.Application.Queries.Ingredientes
{

    namespace ApiReceitas.ApiReceitas.Application.Queries.Ingredientes
    {
        public class GetAllIngredientesCommand : IRequest<IEnumerable<Ingrediente>>
        {
        }
    }
}
