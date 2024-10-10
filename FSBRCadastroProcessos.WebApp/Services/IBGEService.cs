
using FSBRCadastroProcessos.WebApp.Models;
using System.Net.Http.Json;

namespace FSBRCadastroProcessos.WebApp.Services
{
    public class IBGEService : IIBGEService
    {
        private readonly HttpClient _httpClient;

        public IBGEService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Municipio>> GetMunicipioByUfAsync(string uf)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<Municipio>>($"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{uf}/municipios")
                       ?? Enumerable.Empty<Municipio>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter municípios do IBGE: {ex.Message}");
                return Enumerable.Empty<Municipio>();
            }
        }

        public async Task<IEnumerable<UF>> GetUfsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<UF>>("https://servicodados.ibge.gov.br/api/v1/localidades/estados")
                       ?? Enumerable.Empty<UF>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter UFs do IBGE: {ex.Message}");
                return Enumerable.Empty<UF>();
            }
        }
    }
}
