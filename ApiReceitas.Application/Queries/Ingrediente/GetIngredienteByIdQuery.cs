using ApiReceitas.ApiReceitas.Domain;
using MediatR;

namespace ApiReceitas.ApiReceitas.Application.Queries.Ingredientes
{
    public class GetIngredienteByIdQuery : IRequest<Ingrediente>
    {
        public int Id { get; set; }

        public GetIngredienteByIdQuery(int id)
        {
            Id = id;
        }
    }
}
