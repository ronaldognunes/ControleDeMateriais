using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Domain.Enum;
using ControleMateriaisApi.Repository.Context;
using ControleMateriaisApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace ControleMateriaisApi.Repository
{
    public class OrdemServicoRepository : BaseRepository<OrdemServico>,IOrdemServicoRepository
    {
        public OrdemServicoRepository(AplicationContext context) : base(context)
        {
        }

        public async Task<dynamic> GerarRelatorio()
        {        
	        
            var query = new StringBuilder();
            query.AppendLine(" select os.id_polo,");
            query.AppendLine(" os.data_cadastro, ");
            query.AppendLine(" mt.id_material, ");
            query.AppendLine(" mt.nome, ");
            query.AppendLine(" it.quantidade, ");
            query.AppendLine(" mt.unidade_medida, ");
            query.AppendLine(" os.tipo_ordem_servico ");
            query.AppendLine(" from ordens_servico os ");
            query.AppendLine(" inner join item_ordem_servico it on os.id_os = it.id_ordem_servico ");
            query.AppendLine(" inner join materiais mt on it.id_material = mt.id_material ");
            query.AppendLine(" where os.tipo_ordem_servico = 1 ");

            var resultado = await _context.Database.ExecuteSqlRawAsync(query.ToString());

            return resultado;
        }
    }
}
