using ApiReceitas.ApiReceitas.Application.Queries.Ingredientes.ApiReceitas.ApiReceitas.Application.Queries.Ingredientes;
using ApiReceitas.ApiReceitas.Domain;
using ApiReceitas.ApiReceitas.Infrastructure;
using MediatR;
using System.Linq;

namespace ApiReceitas.ApiReceitas.Application.Queries.Ingredientes
{
    public class IngredienteCommandHandlers : 
        IRequestHandler<GetAllIngredientesCommand, IEnumerable<Ingrediente>>,
        IRequestHandler<GetIngredienteByIdCommand, Ingrediente>,
         IRequestHandler<CreateIngredienteCommand, Ingrediente>,
        IRequestHandler<UpdateIngredienteCommand, Ingrediente>,

    {
        public IngredienteRepository _ingredienteRepository;
        public IngredienteCommandHandlers(IngredienteRepository ingredienteRepository)
        {
            _ingredienteRepository = ingredienteRepository;
        }

        public Task<IEnumerable<Ingrediente>> Handle(GetAllIngredientesCommand request, CancellationToken cancellationToken)
        {
            var ingredientes = _ingredienteRepository.GetAll();

            return Task.FromResult(ingredientes);
        }

        public Task<Ingrediente> Handle(GetIngredienteByIdCommand request, CancellationToken cancellationToken)
        {
            var ingrediente = _ingredienteRepository.GetById(request.Id);

            if (ingrediente == null)
            {
                throw new Exception($"Ingrediente com o ID = {request.Id} não foi encontrado.");
            }

            return Task.FromResult(ingrediente);
        }

        public Task<Ingrediente> Handle(CreateIngredienteCommand request, CancellationToken cancellationToken)
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
        

        public Task<Ingrediente> Handle(UpdateIngredienteCommand request, CancellationToken cancellationToken)
        {
            var ingredienteExistente = _ingredienteRepository.GetById(request.Id);
            if (ingredienteExistente == null)
            {
                throw new Exception($"Ingrediente com o ID = {request.Id} não foi encontrado.");
            }

            if (_ingredienteRepository.ExistIngredienteByNome(request.NomeIngrediente))
            {
                throw new Exception($"Ingrediente com o nome = {request.NomeIngrediente} já existe.");
            }

            ingredienteExistente.Nome = request.NomeIngrediente;
            _ingredienteRepository.Update(ingredienteExistente);
            _ingredienteRepository.SaveChanges();

            return Task.FromResult(ingredienteExistente);
        }
    }
}
