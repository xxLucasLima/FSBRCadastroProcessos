
using FSBRCadastroProcessos.WebApp.Models;

namespace FSBRCadastroProcessos.WebApp.Services
{
    public interface ICadastroService
    {
        Task<Cadastro> Create(Cadastro entity);
        Task<Cadastro> Update(Cadastro entity);
        Task<bool> Delete(int id);
        Task<IEnumerable<Cadastro>> GetAll();
        Task<Cadastro> GetById(int id);
    }
}
