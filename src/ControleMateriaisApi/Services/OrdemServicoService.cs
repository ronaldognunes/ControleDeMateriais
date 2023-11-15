using AutoMapper;
using ClosedXML.Excel;
using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Domain.Enum;
using ControleMateriaisApi.Dto;
using ControleMateriaisApi.Repository.Interfaces;
using ControleMateriaisApi.Services.Interfaces;

namespace ControleMateriaisApi.Services
{
    public class OrdemServicoService : IOrdemServicoService
    {
        private readonly IOrdemServicoRepository _repository;
        private readonly IMapper _mapper;
        private readonly IItemOrdemServicoRepository _itemOrdemServicoRepository;
        public OrdemServicoService(IOrdemServicoRepository repository,
                                   IMapper mapper,
                                   IItemOrdemServicoRepository itemRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _itemOrdemServicoRepository = itemRepository;
        }

        public async Task<ResponseDto<ItemOrdemServicoDto>> AlterarItemOsAsync(ItemOrdemServicoDto item)
        {
            var response = new ResponseDto<ItemOrdemServicoDto>();
            var mensagensErros = item.ValidarAlteracaoMateriais();
            if (mensagensErros.Any())
            {
                response.MensagensDeErros.AddRange(mensagensErros);
                response.Sucesso = false;
                return response;
            }

            var Existe = await _itemOrdemServicoRepository.RecuperarPorIdAsync(item.Id);

            if (Existe is null)
            {
                response.MensagensDeErros.Add("Item da Ordem de serviço não existe");
                response.Sucesso = false;
                return response;
            }

            var ItensEntity = _mapper.Map<List<ItemOrdemServico>>(item);
            var ItensParaAlterar = ItensEntity.Where(x => x.Id is not null);
            var ItensParaIncluir = ItensEntity.Where(x => x.Id is null).ToList();

            if (ItensParaAlterar.Count() > 0)
            {
                foreach (var i in ItensParaAlterar)
                {
                    await _itemOrdemServicoRepository.AlterarAsync(i);
                }                    
            }

            if (ItensParaIncluir.Count() > 0)                          
                    await _itemOrdemServicoRepository.CadastrarVariosAsync(ItensParaIncluir);
                
            response.Sucesso = true;
            return response;
        }

        public async Task<ResponseDto<OrdemServicoDto>> AlterarOsAsync(int id, AlteracaoOrdemServicoDto os)
        {
            var response = new ResponseDto<OrdemServicoDto>();
            var Existe = await _repository.RecuperarPorIdAsync(id);
            if (Existe is null)
            {
                response.MensagensDeErros.Add("Ordem de serviço não existe");
                response.Sucesso = false;
                return response;
            }
            var mensagensErros = os.ValidaDados();
            if (mensagensErros.Any())
            {
                response.MensagensDeErros.AddRange(mensagensErros);
                response.Sucesso = false;
                return response;
            }

            var osEntity = _mapper.Map<OrdemServico>(os);
            
            await _repository.AlterarAsync(osEntity);

            foreach(var item in osEntity.ItensOrdemServico)
            {
                await _itemOrdemServicoRepository.AlterarAsync(item);
            }
            response.Sucesso = true;

            return response;
        }

        public async Task<ResponseDto<ItemOrdemServicoDto>> ApagarItemOsAsync(int id)
        {
            var response = new ResponseDto<ItemOrdemServicoDto>();
            var Existe = await _itemOrdemServicoRepository.RecuperarPorIdAsync(id);
            if (Existe is null)
            {
                response.MensagensDeErros.Add("Item da Ordem de serviço não existe");
                response.Sucesso = false;
                return response;
            }
            var ItemOs = _mapper.Map<ItemOrdemServico>(Existe);
            response.Sucesso = await _itemOrdemServicoRepository.DeletarAsync(ItemOs);
            return response;
        }

        public async Task<ResponseDto<ItemOrdemServicoDto>> CadastrarItemOsAsync(CadastroItemOrdemServicoDto item)
        {
            var response = new ResponseDto<ItemOrdemServicoDto>();
            var mensagensErros = item.ValidarCadastroMateriais();
            if (mensagensErros.Any())
            {
                response.MensagensDeErros.AddRange(mensagensErros);
                response.Sucesso = false;
                return response;
            }
            var osEntity = _mapper.Map<ItemOrdemServico>(item);
            response.Sucesso = await _itemOrdemServicoRepository.CadastrarAsync(osEntity);
            return response;
        }

        public async Task<ResponseDto<OrdemServicoDto>> CadastrarOsAsync(CadastroOrdemServicoDto os)
        {
            var response = new ResponseDto<OrdemServicoDto>(){ result = new()};
            var mensagensErros = os.ValidaCadastro();
            if (mensagensErros.Any())
            {
                response.MensagensDeErros.AddRange(mensagensErros);
                response.Sucesso = false;
                return response;
            }

            if(os.Itens.Count == 0)
            {
                response.MensagensDeErros.Add("A Ordem de serviço não possui itens");
                response.Sucesso = false;
                return response;
            }

            foreach (var item in os.Itens)
            {
                response.MensagensDeErros.AddRange(item.ValidarCadastroMateriais());
            }
            if (response.MensagensDeErros.Any())
            {
                response.Sucesso = false;
                return response;
            }

            var osEntity = _mapper.Map<OrdemServico>(os);
            var id = await _repository.CadastrarOsAsync(osEntity);
            response.Sucesso = id > 0 ? true : false;
            response.result.Id = id;

            for(var i = 0 ; i < os.Itens.Count();i++)
            {
                os.Itens[i].IdOs = id;
            }

            var ItemEntity = _mapper.Map<List<ItemOrdemServico>>(os.Itens);
            response.Sucesso = await _itemOrdemServicoRepository.CadastrarVariosAsync(ItemEntity);
            return response;
        }


        public async Task<ResponseDto<RetornoOrdemServicoDto>> ConsultarOsPorIdAsync(int id)
        {
            var response = new ResponseDto<RetornoOrdemServicoDto>();
            var Existe = await _repository.RetornarOrdemServicoAsync(id);
            if (Existe is null)
            {
                response.MensagensDeErros.Add("Ordem de serviço não existe");
                response.Sucesso = false;
                return response;
            }
            response.result = _mapper.Map<RetornoOrdemServicoDto>(Existe);
            response.Sucesso = true;
            return response;
        }

        public async Task<ResponseDto<OrdemServicoDto>> DeletarOsAsync(int id)
        {
            var response = new ResponseDto<OrdemServicoDto>();
            var Existe = await _repository.RecuperarPorIdAsync(id);
            if (Existe is null)
            {
                response.MensagensDeErros.Add("Ordem de serviço não existe");
                response.Sucesso = false;
                return response;
            }
            var os = _mapper.Map<OrdemServico>(Existe);
            await _itemOrdemServicoRepository.DeletarTodosItens(os.Id??0);
            await _repository.DeletarAsync(os);
            response.Sucesso = true;
            return response;
        }

        public async Task<ResponseDto<IList<OrdemServicoDto>>> ListarTodasOsAsync(int qtdPorPag = 10, int pag = 1)
        {
            var response = new ResponseDto<IList<OrdemServicoDto>>();
            var Existe = await _repository.ConsultaPaginadaAsync(null, qtdPorPag, pag);
            if (!Existe.items.Any())
            {
                response.MensagensDeErros.Add("Ordem de serviço não existe");
                response.Sucesso = false;
                return response;
            }

            response.result = _mapper.Map<IList<OrdemServicoDto>>(Existe.items);
            response.Sucesso = true;
            response.TotalDePaginas = Convert.ToInt32(Existe.total);
            response.TotalDeRegistros = Existe.registros;
            return response;
        }

        public async Task<ResponseDto<ArquivoDto>> GerarRelatorioAsync(TipoOrdemServico? tipoOrdem, DateTime? dataInicio, DateTime? dataFim)
        {
            var retorno = new ResponseDto<ArquivoDto>() { result = new ArquivoDto() };
            var dadosRelatorio = await _repository.GerarRelatorio(tipoOrdem, dataInicio, dataFim);
            if (!dadosRelatorio.Any())
            {
                retorno.MensagensDeErros.Add("Nenhum registro encontrado para os filtro informados");
                retorno.Sucesso = false;
                return retorno;
            }
            var caminho = Directory.GetCurrentDirectory() + $"\\RelatoriosGerados\\";
            var nomeArquivo = $"Planilha_controle_material_{DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss")}.xlsx";
            var caminhoCompleto = caminho + nomeArquivo;

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Controle de Materiais");
                worksheet.Cell("A1").Value = "Número da OS";
                worksheet.Cell("B1").Value = "Data Cadastro";
                worksheet.Cell("C1").Value = "Código Material";
                worksheet.Cell("D1").Value = "Nome Material";
                worksheet.Cell("E1").Value = "Quantidade";
                worksheet.Cell("F1").Value = "Unidade de Medida";
                worksheet.Cell("G1").Value = "Tipo Ordem de Serviço";

                for (var i = 0; i < dadosRelatorio.Count(); i++)
                {
                    var os = dadosRelatorio.ToList()[i];
                    worksheet.Cell($"A{i + 2}").Value = os.IdOs;
                    worksheet.Cell($"B{i + 2}").Value = os.DataCadastro?.ToString("dd/MM/yyyy");
                    worksheet.Cell($"C{i + 2}").Value = os.IdMaterial;
                    worksheet.Cell($"D{i + 2}").Value = os.NomeMaterial;
                    worksheet.Cell($"E{i + 2}").Value = os.Quantidade;
                    worksheet.Cell($"F{i + 2}").Value = os.UnidadeMedida;
                    worksheet.Cell($"G{i + 2}").Value = os.TipoOrdemServico;
                }

                workbook.SaveAs(caminhoCompleto);
            }

            byte[] imagem = System.IO.File.ReadAllBytes(caminhoCompleto);
            string imagebase64 = System.Convert.ToBase64String(imagem);
            retorno.result.NomeArquivo = nomeArquivo;
            retorno.result.Base64 = imagebase64;
            retorno.Sucesso = true;
            return retorno;
        }

        public async Task<ResponseDto<IList<ItemOrdemServicoDto>>> ListarTodosItensOsAsync(int idOs, int qtdPorPag = 10, int pag = 1)
        {
            var retorno = new ResponseDto<IList<ItemOrdemServicoDto>>();
            var dados = await _itemOrdemServicoRepository.ConsultaPaginadaAsync(i => i.IdOs == idOs, qtdPorPag, pag);
            if (dados.items.Any())
            {
                retorno.result = _mapper.Map<IList<ItemOrdemServicoDto>>(dados.items);
                retorno.TotalDeRegistros = dados.registros;
                retorno.TotalDePaginas = Convert.ToInt32(dados.total);
                retorno.Sucesso = true;
                return retorno;
            }
            retorno.MensagensDeErros.Add("Nenhum Registro Encontrado");
            retorno.Sucesso = false;
            return retorno;
        }

        public async Task<ResponseDto<ItemOrdemServicoDto>> CadastrarVariosItensOsAsync(IList<CadastroItemOrdemServicoDto> oss)
        {
            var retorno = new ResponseDto<ItemOrdemServicoDto>();
            foreach (var os in oss)
            {
                retorno.MensagensDeErros.AddRange(os.ValidarCadastroMateriais());
            }
            if (retorno.MensagensDeErros.Any())
            {
                retorno.Sucesso = false;
                return retorno;
            }

            var ItemEntity = _mapper.Map<List<ItemOrdemServico>>(oss);
            retorno.Sucesso = await _itemOrdemServicoRepository.CadastrarVariosAsync(ItemEntity);
            return retorno;

        }

        public async Task<ResponseDto<OrdemServicoDto>> CadastrarOsReturnaId(CadastroOrdemServicoDto os)
        {
            var response = new ResponseDto<OrdemServicoDto>(){ result = new()};
            var mensagensErros = os.ValidaCadastro();
            if (mensagensErros.Any())
            {
                response.MensagensDeErros.AddRange(mensagensErros);
                response.Sucesso = false;
                return response;
            }
            var osEntity = _mapper.Map<OrdemServico>(os);
            var id = await _repository.CadastrarOsAsync(osEntity);
            response.Sucesso = id > 0 ? true : false;
            response.result.Id = id;
            return response;
        }

        public async Task<ResponseDto<IList<OrdemServicoDto>>> ListarTodasOsAsync(int idOs, int qtdPorPag = 10, int pag = 1)
        {
            if (idOs == 0)
                return await ListarTodasOsAsync(qtdPorPag, pag);

            var response = new ResponseDto<IList<OrdemServicoDto>>();
            var Existe = await _repository.ConsultaPaginadaAsync(p => p.Id == idOs, qtdPorPag, pag);
            if (!Existe.items.Any())
            {
                response.MensagensDeErros.Add("Ordem de serviço não existe");
                response.Sucesso = false;
                return response;
            }

            response.result = _mapper.Map<IList<OrdemServicoDto>>(Existe.items);
            response.Sucesso = true;
            response.TotalDePaginas = Convert.ToInt32(Existe.total);
            response.TotalDeRegistros = Existe.registros;
            return response;
        }

        public async Task<ResponseDto<IList<ItemOrdemServicoDto>>> ListarTodasItensOsAsync(int idOs, int qtdPorPag = 10, int pag = 1)
        {        
            var response = new ResponseDto<IList<ItemOrdemServicoDto>>();
            var Existe = await _itemOrdemServicoRepository.RetornarItensOrdemServicoComMateriais(idOs, qtdPorPag, pag);
            if (!Existe.itens.Any())
            {
                response.MensagensDeErros.Add($"não existe itens para essa ordem de serviço: {idOs}");
                response.Sucesso = false;
                return response;
            }

            response.result = _mapper.Map<IList<ItemOrdemServicoDto>>(Existe.itens);
            response.Sucesso = true;
            response.TotalDePaginas = Convert.ToInt32(Existe.totalDePaginas);
            response.TotalDeRegistros = Existe.totalDeItens;
            return response;
        }
    }
}
