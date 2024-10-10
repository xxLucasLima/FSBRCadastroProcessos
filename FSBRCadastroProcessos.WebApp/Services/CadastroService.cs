using FSBRCadastroProcessos.WebApp.Models;
using FSBRCadastroProcessos.WebApp.Services;
using System.Net.Http.Json;

public class CadastroService : ICadastroService
{
    private readonly HttpClient _httpClient;

    public CadastroService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Cadastro>> GetAll()
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Cadastro>>("api/cadastro")
                   ?? Enumerable.Empty<Cadastro>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao buscar cadastros: {ex.Message}");
            return new List<Cadastro>();
        }
    }

    public async Task<Cadastro?> GetById(int id)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<Cadastro>($"api/cadastro/{id}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao buscar cadastro por ID: {ex.Message}");
            return null;
        }
    }

    public async Task<Cadastro?> Create(Cadastro cadastro)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/cadastro", cadastro);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Cadastro>();
            }
            else
            {
                Console.WriteLine($"Erro ao criar cadastro: {response.ReasonPhrase}");
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao criar cadastro: {ex.Message}");
            return null;
        }
    }

    public async Task<Cadastro?> Update(Cadastro cadastro)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"api/cadastro/{cadastro.Id}", cadastro);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Cadastro>();
            }
            else
            {
                Console.WriteLine($"Erro ao atualizar cadastro: {response.ReasonPhrase}");
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao atualizar cadastro: {ex.Message}");
            return null;
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/cadastro/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                Console.WriteLine($"Erro ao deletar cadastro: {response.ReasonPhrase}");
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao deletar cadastro: {ex.Message}");
            return false;
        }
    }

    public async Task ConfirmacaoVisualizacao(Cadastro cadastro)
    {
        try
        {
           await _httpClient.PutAsJsonAsync($"api/cadastro/confirmacaovisualizacao/{cadastro.Id}", cadastro);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao salvar confirmação de visualização: {ex.Message}");
        }
    }
}
