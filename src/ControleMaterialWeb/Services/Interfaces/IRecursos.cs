namespace ControleMaterialWeb.Services.Interfaces
{
    public interface IRecursos
    {
        void AlertaSucesso(string descricao = "", string tipo = "Operação realizada com sucesso");
        void AlertaErro(string descricao = "", string tipo = "Operação não efetuada");
    }
}
