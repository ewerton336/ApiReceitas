using ApiReceitas.ApiReceitas.Domain;
using MediatR;

namespace ApiReceitas.ApiReceitas.Application.Queries
{
    public class DeleteIngredienteCommand : IRequest<bool>
    {
        public int Id { get; set; }


        public DeleteIngredienteCommand(int id)
        {
            Id = id;
        }
    }
}
