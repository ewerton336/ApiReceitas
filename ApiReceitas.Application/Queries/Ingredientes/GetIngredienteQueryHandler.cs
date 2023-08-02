using ApiReceitas.ApiReceitas.Domain;
using ApiReceitas.ApiReceitas.Infrastructure;
using MediatR;


namespace ApiReceitas.ApiReceitas.Application.Queries.Ingredientes
{
    public class GetIngredienteQueryHandler : IRequestHandler<GetIngredienteQuery, Ingrediente>
    {
        private readonly IngredienteRepository _ingredienteRepository;

        public GetIngredienteQueryHandler(IngredienteRepository ingredienteRepository)
        {
            _ingredienteRepository = ingredienteRepository;
        }

        public Task<Ingrediente> Handle(GetIngredienteQuery request, CancellationToken cancellationToken)
        {
            var ingrediente = _ingredienteRepository.GetById(request.Id);

            if (ingrediente == null)
            {
                throw new Exception($"Ingrediente com o ID = {request.Id} não foi encontrado.");
            }

            return Task.FromResult(ingrediente);
        }
    }

}
