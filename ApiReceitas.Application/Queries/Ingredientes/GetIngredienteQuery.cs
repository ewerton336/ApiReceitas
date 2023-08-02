using ApiReceitas.ApiReceitas.Domain;
using MediatR;

namespace ApiReceitas.ApiReceitas.Application.Queries.Ingredientes
{
    public class GetIngredienteQuery : IRequest<Ingrediente>
    {
        public int Id { get; set; }

        public GetIngredienteQuery(int id)
        {
            Id = id;
        }
    }
}
