using MediatR;
using ApiReceitas.ApiReceitas.Domain;
using ApiReceitas.ApiReceitas.Infrastructure;
using ApiReceitas.ApiReceitas.Application.Queries.Ingredientes.ApiReceitas.ApiReceitas.Application.Queries.Ingredientes;

namespace ApiReceitas.ApiReceitas.Application.Queries.Ingredientes
{
    public class GetAllIngredientesQueryHandler : IRequestHandler<GetAllIngredientesQuery, IEnumerable<Ingrediente>>
    {
        private readonly IngredienteRepository _ingredienteRepository;

        public GetAllIngredientesQueryHandler(IngredienteRepository ingredienteRepository)
        {
            _ingredienteRepository = ingredienteRepository;
        }

        public Task<IEnumerable<Ingrediente>> Handle(GetAllIngredientesQuery request, CancellationToken cancellationToken)
        {
            var ingredientes = _ingredienteRepository.GetAll();

            return Task.FromResult(ingredientes);
        }
    }
}
