using FSBRCadastroProcessos.API.Application.Interfaces;
using FSBRCadastroProcessos.API.Domain.Entities;
using FSBRCadastroProcessos.API.Infrastructure;

namespace FSBRCadastroProcessos.API.Application.Services
{
    public class CadastroService : ICadastroService
    {
        public readonly ICadastroRepository _cadastroRepository;

        public CadastroService(ICadastroRepository cadastroRepository)
        {
            _cadastroRepository = cadastroRepository;
        }
        public Task<Cadastro> Create(Cadastro entity)
        {
            return _cadastroRepository.Create(entity);
        }

        public Task<List<Cadastro>> GetAll()
        {
            return _cadastroRepository.GetAll();
        }

        public Task<Cadastro> GetById(int id)
        {
            return _cadastroRepository.GetById(id);
        }

        public Task<Cadastro> Update(Cadastro entity)
        {
            return _cadastroRepository.Update(entity);
        }

        Task<bool> ICadastroService.Delete(int id)
        {
            return _cadastroRepository.Delete(id);
        }
    }
}
