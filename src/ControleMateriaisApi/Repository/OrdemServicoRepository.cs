using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Domain.Enum;
using ControleMateriaisApi.Dto;
using ControleMateriaisApi.Repository.Context;
using ControleMateriaisApi.Repository.Interfaces;
using Dapper;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace ControleMateriaisApi.Repository
{
    public class OrdemServicoRepository : BaseRepository<OrdemServico>,IOrdemServicoRepository
    {
        
        public OrdemServicoRepository(AplicationContext context) : base(context)
        {
            
        }

        public async Task<int?> CadastrarOsAsync(OrdemServico ordemServico)
        {
            var dados = await _db.AddAsync(ordemServico);
            await _context.SaveChangesAsync();
            
            return dados.Entity.Id;
        }

        public async Task<IEnumerable<RelatorioOs>> GerarRelatorio(TipoOrdemServico? tipoOrdem, DateTime? dataInicio, DateTime? dataFim)
        {
            var query = new StringBuilder();
            var parametros = new DynamicParameters();
            query.AppendLine(" select os.id_os as IdOs ,");
            query.AppendLine(" DATE(os.data_cadastro) As DataCadastro, ");
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

        public async Task<OrdemServico?> RetornarOrdemServicoAsync(int id)
        {
            return  await _db
                .Include(x => x.ItensOrdemServico)
                .ThenInclude(x => x.Material)                
                .Where(o => o.Id == id)
                .AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync();
        }

        public async Task<bool> VerificaMaterialAlgumaOs(int id)
        {
            var query = new StringBuilder();
            var parametros = new DynamicParameters();
            query.AppendLine(" select count(1) ");
            query.AppendLine(" from item_ordem_servico os ");
            query.AppendLine(" where os.id_material = @idMaterial ");

             parametros.Add("idMaterial", id, System.Data.DbType.Int32);
            

            var resultado = await _context.Database.GetDbConnection().ExecuteScalarAsync<int>(query.ToString(), parametros);

            return resultado > 0;
        }

        public async Task<bool> VerificaPoloAlgumaOs(int id)
        {
            var query = new StringBuilder();
            var parametros = new DynamicParameters();
            query.AppendLine(" select count(1) ");
            query.AppendLine(" from ordens_servico os ");
            query.AppendLine(" where os.id_polo = @idPolo ");

            parametros.Add("idPolo", id, System.Data.DbType.Int32);


            var resultado = await _context.Database.GetDbConnection().ExecuteScalarAsync<int>(query.ToString(), parametros);

            return resultado > 0;
        }

        public async Task<bool> VerificaUsuarioPertenceAlgumaOs(int id)
        {
            var query = new StringBuilder();
            var parametros = new DynamicParameters();
            query.AppendLine(" select count(1) ");
            query.AppendLine(" from ordens_servico os ");
            query.AppendLine(" where os.IdUsuario = @IdUsuario ");

            parametros.Add("IdUsuario", id, System.Data.DbType.Int32);


            var resultado = await _context.Database.GetDbConnection().ExecuteScalarAsync<int>(query.ToString(), parametros);

            return resultado > 0;
        }
    }
}
