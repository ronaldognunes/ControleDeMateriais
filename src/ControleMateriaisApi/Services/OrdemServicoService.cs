using AutoMapper;
using ClosedXML.Excel;
using ControleMateriaisApi.Domain;
using ControleMateriaisApi.Domain.Enum;
using ControleMateriaisApi.Dto;
using ControleMateriaisApi.Repository.Interfaces;
using ControleMateriaisApi.Services.Interfaces;
using DocumentFormat.OpenXml.Spreadsheet;

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

            var ItemEntity = _mapper.Map<ItemOrdemServico>(item);
            response.Sucesso = await _itemOrdemServicoRepository.AlterarAsync(ItemEntity);
            return response;            
        }

        public async Task<ResponseDto<OrdemServicoDto>> AlterarOsAsync(int id, OrdemServicoDto os)
        {
            var response = new ResponseDto<OrdemServicoDto>();
            var Existe = await _repository.RecuperarPorIdAsync(id);
            if (Existe is null)
            {
                response.MensagensDeErros.Add("Ordem de serviço não existe");
                response.Sucesso = false;
                return response;
            }
            var mensagensErros = os.ValidaAlteracao();
            if (mensagensErros.Any())
            {
                response.MensagensDeErros.AddRange(mensagensErros);
                response.Sucesso = false;
                return response;
            }

            var osEntity = _mapper.Map<OrdemServico>(os);
            //alterar metodo para passar a alterar tudo
            response.Sucesso = await _repository.AlterarAsync(osEntity);
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
            var response = new ResponseDto<OrdemServicoDto>();
            var mensagensErros = os.ValidaCadastro();
            if (mensagensErros.Any())
            {
                response.MensagensDeErros.AddRange(mensagensErros);
                response.Sucesso = false;
                return response;
            }
            var osEntity = _mapper.Map<OrdemServico>(os);
            response.Sucesso = await _repository.CadastrarAsync(osEntity);
            return response;
        }


        public async Task<ResponseDto<OrdemServicoDto>> ConsultarOsPorIdAsync(int id)
        {
            var response = new ResponseDto<OrdemServicoDto>();
            var Existe = await _repository.RecuperarPorIdAsync(id);
            if (Existe is null)
            {
                response.MensagensDeErros.Add("Ordem de serviço não existe");
                response.Sucesso = false;
                return response;
            }
            response.result = _mapper.Map<OrdemServicoDto>(Existe);
            response.Sucesso = true;
            return response;
        }

        public async Task<ResponseDto<IList<OrdemServicoDto>>> ConsultarOsPorNomesAsync(string nome)
        {
            //var response = new ResponseDto<EntradaDto>();
            //var Existe = await _repository.RecuperarPorIdAsync(id);
            //if (Existe is null)
            //{
            //    response.MensagensDeErros.Add("Ordem de serviço não existe");
            //    response.Sucesso = false;
            //    return response;
            //}
            //var os = _mapper.Map<Entrada>(entrada);
            //response.Sucesso = await _repository.AlterarAsync(os);
            return null;
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
            response.Sucesso = await _repository.DeletarAsync(os);
            return response;
        }

        public async Task<ResponseDto<IList<OrdemServicoDto>>> ListarTodasOsAsync()
        {
            var response = new ResponseDto<IList<OrdemServicoDto>>();
            var Existe = await _repository.RecuperarTodosAsync();
            if (!Existe.Any())
            {
                response.MensagensDeErros.Add("Ordem de serviço não existe");
                response.Sucesso = false;
                return response;
            }
            response.result = _mapper.Map<IList<OrdemServicoDto>>(Existe);
            response.Sucesso = true;
            return response;
        }

        public async Task<ResponseDto<ArquivoDto>> GerarRelatorioAsync(TipoOrdemServico? tipoOrdem, DateTime? dataInicio, DateTime? dataFim)
        {
            var retorno = new ResponseDto<ArquivoDto>() { result = new ArquivoDto()};
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

                for(var i = 0; i < dadosRelatorio.Count(); i++)
                {
                    var os = dadosRelatorio.ToList()[i];
                    worksheet.Cell($"A{i + 2}").Value = os.IdOs;
                    worksheet.Cell($"B{i + 2}").Value = os.DataCadastro;
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
            return retorno;
        }

        public Task<ResponseDto<IList<ItemOrdemServicoDto>>> ListarTodosItensOsAsync(int idOs)
        {
            throw new NotImplementedException();
        }
    }
}
