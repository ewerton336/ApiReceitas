using ApiReceitas.ApiReceitas.Application.Queries.Ingredientes.ApiReceitas.ApiReceitas.Application.Queries.Ingredientes;
using ApiReceitas.ApiReceitas.Domain;
using ApiReceitas.ApiReceitas.Infrastructure;
using MediatR;
using System.Linq;

namespace ApiReceitas.ApiReceitas.Application.Queries.Ingredientes
{
    public class IngredienteQueryHandlers : 
        IRequestHandler<GetAllIngredientesQuery, IEnumerable<Ingrediente>>,
        IRequestHandler<GetIngredienteByIdQuery, Ingrediente>,
         IRequestHandler<CreateIngredienteQuery, Ingrediente>
    {
        public IngredienteRepository _ingredienteRepository;
        public IngredienteQueryHandlers(IngredienteRepository ingredienteRepository)
        {
            _ingredienteRepository = ingredienteRepository;
        }

        public Task<IEnumerable<Ingrediente>> Handle(GetAllIngredientesQuery request, CancellationToken cancellationToken)
        {
            var ingredientes = _ingredienteRepository.GetAll();

            return Task.FromResult(ingredientes);
        }

        public Task<Ingrediente> Handle(GetIngredienteByIdQuery request, CancellationToken cancellationToken)
        {
            var ingrediente = _ingredienteRepository.GetById(request.Id);

            if (ingrediente == null)
            {
                throw new Exception($"Ingrediente com o ID = {request.Id} não foi encontrado.");
            }

            return Task.FromResult(ingrediente);
        }

        public Task<Ingrediente> Handle(CreateIngredienteQuery request, CancellationToken cancellationToken)
        {
            if (_ingredienteRepository.ExistIngredienteByNome(request.NomeIngrediente))
            {
                throw new Exception($"Ingrediente com o nome = {request.NomeIngrediente} já existe.");
            }

            var ingrediente = new Ingrediente { Nome = request.NomeIngrediente };
            _ingredienteRepository.Add(ingrediente);
            _ingredienteRepository.SaveChanges();

            return Task.FromResult(ingrediente);
        }
    }
}
