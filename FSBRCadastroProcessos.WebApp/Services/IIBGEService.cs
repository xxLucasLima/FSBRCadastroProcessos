using FSBRCadastroProcessos.WebApp.Models;

namespace FSBRCadastroProcessos.WebApp.Services
{
    public interface IIBGEService
    {
        Task<IEnumerable<UF>> GetUfsAsync();
        Task<IEnumerable<Municipio>> GetMunicipioByUfAsync(string uf);

    }
}
