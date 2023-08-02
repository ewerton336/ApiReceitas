using ApiReceitas.ApiReceitas.Domain;
using MediatR;

namespace ApiReceitas.ApiReceitas.Application.Queries.Ingredientes
{

    namespace ApiReceitas.ApiReceitas.Application.Queries.Ingredientes
    {
        public class GetAllIngredientesQuery : IRequest<IEnumerable<Ingrediente>>
        {
        }
    }
}
