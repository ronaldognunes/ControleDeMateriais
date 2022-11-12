using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Domain.Enum;
using ControleMateriaisApi.Repository.Context;
using ControleMateriaisApi.Repository.Interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace ControleMateriaisApi.Repository
{
    public class OrdemServicoRepository : BaseRepository<OrdemServico>,IOrdemServicoRepository
    {
        readonly AplicationContext teste;
        public OrdemServicoRepository(AplicationContext context) : base(context)
        {
            teste = context;
        }

        public async Task<IEnumerable<RelatorioOs>> GerarRelatorio(TipoOrdemServico? tipoOrdem, DateTime? dataInicio, DateTime? dataFim)
        {
            var query = new StringBuilder();
            var parametros = new DynamicParameters();
            query.AppendLine(" select os.id_polo as IdOs ,");
            query.AppendLine(" os.data_cadastro As DataCadastro, ");
            query.AppendLine(" mt.id_material As IdMaterial, ");
            query.AppendLine(" mt.nome As NomeMaterial, ");
            query.AppendLine(" it.quantidade As Quantidade, ");
            query.AppendLine(" mt.unidade_medida As UnidadeMedida, ");
            query.AppendLine(" case when os.tipo_ordem_servico = 1 then \"Os - Entrada\"  ");
            query.AppendLine("      when os.tipo_ordem_servico = 2 then \"Os - Saida\"  ");
            query.AppendLine(" end As TipoOrdemServico ");
            query.AppendLine(" from ordens_servico os ");
            query.AppendLine(" inner join item_ordem_servico it on os.id_os = it.id_ordem_servico ");
            query.AppendLine(" inner join materiais mt on it.id_material = mt.id_material ");
            query.AppendLine(" where 1 = 1 ");

            if (tipoOrdem > 0)
            {
                query.AppendLine(" and os.tipo_ordem_servico = @tipoOrdem ");
                parametros.Add("tipoOrdem", tipoOrdem );
            }

            if(dataInicio is not null)
            {
                query.AppendLine(" and DATE(os.data_cadastro) >= DATE(@dataInicio) ");
                parametros.Add("dataInicio", dataInicio, System.Data.DbType.DateTime);
            }

            if (dataFim is not null)
            {
                query.AppendLine(" and DATE(os.data_cadastro) <= DATE(@dataFim) ");
                parametros.Add("dataFim", dataFim, System.Data.DbType.DateTime);
            }

            var resultado = await _context.Database.GetDbConnection().QueryAsync<RelatorioOs>(query.ToString(),parametros);            

            return resultado;
        }
    }
}
