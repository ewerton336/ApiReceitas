using ApiReceitas.ApiReceitas.Domain;
using MediatR;

namespace ApiReceitas.ApiReceitas.Application.Queries.Ingredientes
{
    public class GetIngredienteByIdCommand : IRequest<Ingrediente>
    {
        public int Id { get; set; }

        public GetIngredienteByIdCommand(int id)
        {
            Id = id;
        }
    }
}
