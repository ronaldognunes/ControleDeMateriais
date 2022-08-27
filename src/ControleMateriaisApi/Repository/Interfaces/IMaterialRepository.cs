using ControleMateriaisApi.Domain;

namespace ControleMateriaisApi.Repository.Interfaces
{
    public interface IMaterialRepository : IBaseRepository<Material>
    {
        public Task<IList<Material>> RecuperarMaterialPorNomeAsync(string nome);
    }
}
