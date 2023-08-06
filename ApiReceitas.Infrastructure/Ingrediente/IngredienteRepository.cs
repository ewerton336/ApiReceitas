using ApiReceitas.ApiReceitas.Domain;
using System.Linq;

namespace ApiReceitas.ApiReceitas.Infrastructure
{
    public class IngredienteRepository
    {
        private readonly AppDbContext _dbContext;

        public IngredienteRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Ingrediente> GetAll()
        {
            return _dbContext.Ingredientes.ToList();
        }

        public Ingrediente GetById(int id)
        {
            return _dbContext.Ingredientes.Find(id);
        }

        public void Add(Ingrediente ingrediente)
        {
            _dbContext.Ingredientes.Add(ingrediente);
        }

        public void Remove(Ingrediente ingrediente)
        {
            _dbContext.Ingredientes.Remove(ingrediente);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public bool ExistIngredienteByNome(string nome)
        {
            return _dbContext.Ingredientes.Any(x => x.Nome == nome);
        }

        internal void Update(Ingrediente ingredienteExistente)
        {
            _dbContext.Ingredientes.Update(ingredienteExistente);
        }
    }
}
